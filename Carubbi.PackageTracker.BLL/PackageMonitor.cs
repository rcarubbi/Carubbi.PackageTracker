using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using Google.TTS;


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
                StatusModified?.Invoke(this, EventArgs.Empty);
            }

        }





        public PackageMonitor()
        {
            this.Packages = new List<Package>();
            this.State = MonitorState.Stopped;
            this.Path = System.Windows.Forms.Application.StartupPath;
            this.Config = new MonitorConfig();
            LoadConfig();
        }

        public event EventHandler<NotifyUpdateEventArgs> PackageModified;

        public event EventHandler StatusModified;

        private System.Timers.Timer _timer;

        private const string URL_CORREIO = "http://www2.correios.com.br/sistemas/rastreamento/ctrl/ctrlRastreamento.cfm";

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

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void Start()
        {
         

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

            var html = GetHtml(p);
            var updates = ReadHTML(html);
            var comparer = new UpdateEqualityComparer();
            updates = updates.Except(p.Updates, comparer).ToList();
            if (updates.Count <= 0) return;

            p.Updates = updates;
            this.SavePackages();

            foreach (var u in updates)
            {
                PackageModified?.Invoke(this, new NotifyUpdateEventArgs() { Package = p, Update = u });
                SendSmsNotification(p, u);
                PlayVoiceNotification(p, u);
                Thread.Sleep(2000);
            }
        }

        private void PlayVoiceNotification(Package p, UpdateEntry u)
        {
            if (VoiceNotification)
            {
                Google.TTS.TtsHelper.ReproduzirSincrono(p.GetVoiceMessage(u), Idioma.Portugues);
            }
        }

        private void SendSmsNotification(Package p, UpdateEntry u)
        {
            if (!SmsNotification) return;
            if (string.IsNullOrEmpty(Config.PhoneNumber)) return;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(string.Format(URL_SMS, Config.PhoneNumber, HttpUtility.UrlEncode(p.GetMessage(u)), Config.SmsPassword));
                request.Method = "get";
                request.BeginGetResponse(null, null);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Não foi possível enviar notificação via sms para {Config.PhoneNumber}", ex);
            }
        }

        private static string GetHtml(Package p)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "acao", "track" },
                { "objetos", p.TrackNumber }
            };
            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(URL_CORREIO, content).Result;

            var html = response.Content.ReadAsStringAsync().Result;

            return html;
        }

        private const int DATA_HORA_INDEX = 1;
        private const int STATUS_INDEX = 3;

        private static List<UpdateEntry> ReadHTML(string html)
        {
            var updates = new List<UpdateEntry>();

            var data  = string.Empty;
            var hora = string.Empty;
            var local = string.Empty;
            var status = string.Empty;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            var table = doc.DocumentNode.SelectNodes("//*[contains(@class, 'listEvent')]").FirstOrDefault();
            if (table == null) return updates;
            foreach (var tr in table.ChildNodes)
            {
                status = string.Empty;
                var tdCounter = -1;
                if (tr.NodeType == HtmlNodeType.Text)
                    continue;

                foreach (var td in tr.ChildNodes)
                {
                    tdCounter++;
                    if (td.NodeType == HtmlNodeType.Text)
                        continue;

                    switch (tdCounter)
                    {
                        case DATA_HORA_INDEX:
                            data = td.ChildNodes[0].InnerText.Trim();
                            hora = td.ChildNodes[2].InnerText.Replace("\r", string.Empty).Trim();
                            local = td.ChildNodes[5].InnerText.Replace("&nbsp;", " ");
                            break;
                        case STATUS_INDEX:
                            status = td.ChildNodes.Aggregate(status, (current, message) => current + message.InnerText);
                            status = status.Replace("\r", Environment.NewLine).Replace("&nbsp;", " ");
                            break;
                    }
                }


                var dataHora = $"{data} {hora}";
                if (!DateTime.TryParse(dataHora, out var datahoraTipada)) continue;
                var entry = new UpdateEntry
                {
                    DateTime = datahoraTipada,
                    Local = local,
                    State = Regex.Replace(status, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline).Trim()
                };
                updates.Add(entry);
            }

            return updates.OrderBy(x => x.DateTime).ToList();
        }

        private void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Close();
                _timer.Dispose();
            }
            State = MonitorState.Stopped;
        }

        public void Refresh()
        {
 
            while (State == MonitorState.Running)
                Thread.Sleep(1000);

            var currentState = State;
            State = MonitorState.Running;
            foreach (var p in Packages)
            {
                VerifyPackage(p);
            }
            State = currentState;
        }

        public void SaveConfig()
        {
            var serializer = new BinaryFormatter();
            var fs = new FileStream(System.IO.Path.Combine(Path, "Config.dat"), FileMode.Create);

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
            var serializer = new BinaryFormatter();
            try
            {
                var fs = new FileStream(System.IO.Path.Combine(Path, "Config.dat"), FileMode.Open);
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
            catch (FileNotFoundException)
            {

            }
        }
    }
}
