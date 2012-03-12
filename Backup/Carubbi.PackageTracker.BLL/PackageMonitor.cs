using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Net;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Carubbi.PackageTracker.BLL
{
    public class UpdateEqualityComparer : IEqualityComparer<UpdateEntry>
    {

        #region IEqualityComparer<UpdateEntry> Members

        public bool Equals(UpdateEntry x, UpdateEntry y)
        {
            return x.DateTime == y.DateTime;
        }

        public int GetHashCode(UpdateEntry obj)
        {
            return obj.DateTime.GetHashCode();
        }

        #endregion
    }

    public class UpdateComparer : IComparer<UpdateEntry>
    {


        #region IComparer<UpdateEntry> Members

        public int Compare(UpdateEntry x, UpdateEntry y)
        {
            if (x.DateTime > y.DateTime)
                return 1;
            else if (x.DateTime < y.DateTime)
                return -1;
            else
                return 0;
        }

        #endregion
    }

    public class NotifyUpdateEventArgs : EventArgs
    {
        public UpdateEntry Update
        {
            get;
            set;
        }

        public Package Package
        {
            get;
            set;
        }

    }

    public enum MonitorState : int
    {
        Stopped,
        Idle,
        Running
    }

    public class PackageMonitor
    {
        public bool VoiceNotification
        {
            get;
            set;
        }

        public bool SmsNotification
        {
            get;
            set;
        }

        public MonitorConfig Config
        {
            get;
            private set;
        }

        private MonitorState _state;
        public MonitorState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (StatusModified != null)
                    StatusModified(this, EventArgs.Empty);
            }

        }

        public delegate HtmlDocument LoadHtmlDocument(string htmlText);

        private LoadHtmlDocument _loadHtml;

        public PackageMonitor(LoadHtmlDocument loadMethod)
        {
            _loadHtml = loadMethod;
            this.Packages = new List<Package>();
            this.State = MonitorState.Stopped;
            this.Path = Application.StartupPath;
            this.Config = new MonitorConfig();
            LoadConfig();
        }

        public event EventHandler<NotifyUpdateEventArgs> PackageModified;

        public event EventHandler StatusModified;

        private System.Timers.Timer _timer;

        private const string URL_CORREIO = "http://websro.correios.com.br/sro_bin/txect01$.QueryList?P_LINGUA=001&P_TIPO=001&P_COD_UNI={0}";
        private const string PROXY_PATH = "http://proxy.itau/accelerated_pac_base.pac";
        private const string URL_SMS = "http://200.190.61.201:50296/br/contax_tenda?phone={0}&msgtext={1}&msgid=34126&user=contax_tenda&pwd={2}";

        public List<Package> Packages
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            set;
        }

        public void SavePackages()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fs = new FileStream(System.IO.Path.Combine(Path, "Packages.dat"), FileMode.Create);

            try
            {
                serializer.Serialize(fs, Packages);
            }
            catch (SerializationException e)
            {
                throw new ApplicationException("Erro ao salvar arquivo", e);
            }
            finally
            {
                fs.Close();
            }
        }

        public void LoadPackages()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            try
            {
                FileStream fs = new FileStream(System.IO.Path.Combine(Path, "Packages.dat"), FileMode.Open);
                try
                {
                    Packages = (List<Package>)serializer.Deserialize(fs);

                }
                catch (SerializationException e)
                {
                    throw new ApplicationException("Erro ao carregar arquivo", e);
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("Arquivo não encontrado", ex);
            }


        }

        public void StartStop()
        {
            switch (this.State)
            {
                case MonitorState.Idle:
                    Stop();
                    break;
                case MonitorState.Stopped:
                    Start();
                    break;
                case MonitorState.Running:
                    throw new ApplicationException("Aguarde até o final do processamento");

            }

        }

        private void Start()
        {
            Config.ValidateProxy();

            _timer = new System.Timers.Timer(Config.Cycle * 60000);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
            this.State = MonitorState.Idle;
        }

        protected void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.State = MonitorState.Running;
            _timer.Stop();
            foreach (Package p in Packages)
            {
                VerifyPackage(p);
            }
            _timer.Start();
            this.State = MonitorState.Idle;
        }

        private void VerifyPackage(Package p)
        {

            string html = GetHtml(p);
            List<UpdateEntry> updates = ReadHTML(html);
            UpdateEqualityComparer comparer = new UpdateEqualityComparer();
            updates = updates.Except(p.Updates, comparer).ToList();
            if (updates.Count > 0)
            {
                p.Updates = updates;
                this.SavePackages();

                foreach (UpdateEntry u in updates)
                {
                    if (PackageModified != null)
                        PackageModified(this, new NotifyUpdateEventArgs() { Package = p, Update = u });

                    SendSmsNotification(p, u);
                    PlayVoiceNotification(p, u);
                    Thread.Sleep(5000);
                }
            }
        }

        private void PlayVoiceNotification(Package p, UpdateEntry u)
        {
            if (VoiceNotification)
            {
                Google.TTS.TTSHelper.ProxyPath = PROXY_PATH;
                Google.TTS.TTSHelper.ProxyDomain = this.Config.ProxyDomain;
                Google.TTS.TTSHelper.ProxyPassword = this.Config.ProxyPassword;
                Google.TTS.TTSHelper.ProxyUserName = this.Config.ProxyUserName;
                Google.TTS.TTSHelper.ReproduzirSincrono(p.GetVoiceMessage(u), true);
            }
        }

        private void SendSmsNotification(Package p, UpdateEntry u)
        {
            if (SmsNotification)
            {
                if (!string.IsNullOrEmpty(Config.PhoneNumber))
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(URL_SMS, Config.PhoneNumber, HttpUtility.UrlEncode(p.GetMessage(u)), Config.SmsPassword));
                        request.Proxy = WebRequest.GetSystemWebProxy();
                        request.Method = "get";
                        request.Proxy.Credentials = new NetworkCredential(Config.ProxyUserName, Config.ProxyPassword, Config.ProxyDomain);
                        request.BeginGetResponse(null, null);
                        request = null;
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(string.Format("Não foi possível enviar notificação via sms para {0}", Config.PhoneNumber), ex);
                    }
                }
            }
        }

        private string GetHtml(Package p)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(URL_CORREIO, p.TrackNumber));
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = new NetworkCredential(Config.ProxyUserName, Config.ProxyPassword, Config.ProxyDomain);
            WebResponse response = request.GetResponse();
            Stream ms = response.GetResponseStream();
            string html = string.Empty;
            using (TextReader tr = new StreamReader(ms, Encoding.Default))
                html = tr.ReadToEnd();
            return html;
        }

        private List<UpdateEntry> ReadHTML(string html)
        {
            List<UpdateEntry> updates = new List<UpdateEntry>();
            HtmlDocument doc = _loadHtml(html);
            HtmlElementCollection table = doc.GetElementsByTagName("table");

            string dataHora = string.Empty;
            string local = string.Empty;
            string status = string.Empty;
            int tableChildCount = 1;

            if (table.Count > 0)
            {
                foreach (HtmlElement tableChild in table[0].Children)
                {

                    int trCount = 1;
                    foreach (HtmlElement tr in tableChild.Children)
                    {
                        if (trCount >= 2)
                        {
                            int tdCount = 1;
                            foreach (HtmlElement td in tr.Children)
                            {
                                switch (tdCount)
                                {
                                    case 1:
                                        dataHora = td.InnerText;
                                        break;
                                    case 2:
                                        local = td.InnerText;
                                        break;
                                    case 3:
                                        status = td.InnerText;
                                        break;
                                    default:
                                        break;
                                }

                                tdCount++;
                            }
                            DateTime datahoraTipada;
                            if (DateTime.TryParse(dataHora, out datahoraTipada))
                            {
                                UpdateEntry entry = new UpdateEntry();
                                entry.DateTime = datahoraTipada;
                                entry.Local = local;
                                entry.State = status;
                                updates.Add(entry);
                            }
                        }
                        trCount++;
                    }
                    tableChildCount++;
                }
            }
            UpdateComparer comparer = new UpdateComparer();
            updates.Sort(0, updates.Count, comparer);
            return updates;
        }

        private void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Close();
                _timer.Dispose();
            }
            this.State = MonitorState.Stopped;
        }

        public void Refresh()
        {

            Config.ValidateProxy();
            while (this.State == MonitorState.Running)
                Thread.Sleep(1000);

            MonitorState currentState = this.State;
            this.State = MonitorState.Running;
            foreach (Package p in Packages)
            {
                VerifyPackage(p);
            }
            this.State = currentState;
        }

        public void SaveConfig()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fs = new FileStream(System.IO.Path.Combine(Path, "Config.dat"), FileMode.Create);

            try
            {
                serializer.Serialize(fs, Config);
            }
            catch (SerializationException e)
            {
                throw new ApplicationException("Erro ao salvar arquivo", e);
            }
            finally
            {
                fs.Close();
            }

        }

        public void LoadConfig()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            try
            {
                FileStream fs = new FileStream(System.IO.Path.Combine(Path, "Config.dat"), FileMode.Open);
                try
                {
                    Config = (MonitorConfig)serializer.Deserialize(fs);

                }
                catch (SerializationException e)
                {
                    throw new ApplicationException("Erro ao carregar arquivo", e);
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException ex)
            {

            }
        }
    }
}
