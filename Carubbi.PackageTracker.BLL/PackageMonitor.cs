using Google.TTS;
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
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Timer = System.Timers.Timer;

namespace Carubbi.PackageTracker.BLL
{
    public class PackageMonitor
    {
        private MonitorState _state;

        private Timer _timer;

        private const string UrlCorreio = "http://www2.correios.com.br/sistemas/rastreamento/ctrl/ctrlRastreamento.cfm";

        private const string UrlSms = "http://200.190.61.201:50296/br/contax_tenda?phone={0}&msgtext={1}&msgid=34126&user=contax_tenda&pwd={2}";

        private const int DataHoraIndex = 1;

        private const int StatusIndex = 3;

        private void Start()
        {
            _timer = new Timer(Config.Cycle * 60000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            State = MonitorState.Idle;
        }

        private void VerifyPackage(Package p)
        {
            var html = GetHtml(p);
            var updates = ReadHtml(html);
            var comparer = new UpdateEqualityComparer();
            updates = updates.Except(p.Updates, comparer).ToList();
            if (updates.Count <= 0) return;

            p.Updates = updates;
            SavePackages();

            foreach (var u in updates)
            {
                PackageModified?.Invoke(this, new NotifyUpdateEventArgs { Package = p, Update = u });
                SendSmsNotification(p, u);
                PlayVoiceNotification(p, u);
                Thread.Sleep(2000);
            }
        }

        private void PlayVoiceNotification(Package p, UpdateEntry u)
        {
            if (VoiceNotification)
            {
                TtsHelper.ReproduzirSincrono(p.GetVoiceMessage(u), Idioma.Portugues);
            }
        }

        private void SendSmsNotification(Package p, UpdateEntry u)
        {
            if (!SmsNotification) return;
            if (string.IsNullOrEmpty(Config.PhoneNumber)) return;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(string.Format(UrlSms, Config.PhoneNumber, HttpUtility.UrlEncode(p.GetMessage(u)), Config.SmsPassword));
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

            var response = client.PostAsync(UrlCorreio, content).Result;

            var html = response.Content.ReadAsStringAsync().Result;

            return html;
        }

        private static List<UpdateEntry> ReadHtml(string html)
        {
            var updates = new List<UpdateEntry>();

            var data = string.Empty;
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
                        case DataHoraIndex:
                            data = td.ChildNodes[0].InnerText.Trim();
                            hora = td.ChildNodes[2].InnerText.Replace("\r", string.Empty).Trim();
                            local = td.ChildNodes[5].InnerText.Replace("&nbsp;", " ");
                            break;
                        case StatusIndex:
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

        protected void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            State = MonitorState.Running;
            _timer.Stop();
            foreach (var p in Packages)
            {
                VerifyPackage(p);
            }
            _timer.Start();
            State = MonitorState.Idle;
        }

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

        public MonitorState State
        {
            get => _state;
            set
            {
                _state = value;
                StatusModified?.Invoke(this, EventArgs.Empty);
            }

        }
 
        public PackageMonitor()
        {
            Packages = new List<Package>();
            State = MonitorState.Stopped;
            Path = Application.StartupPath;
            Config = new MonitorConfig();
            LoadConfig();
        }

        public event EventHandler<NotifyUpdateEventArgs> PackageModified;

        public event EventHandler StatusModified;

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
            var serializer = new BinaryFormatter();
            var fs = new FileStream(System.IO.Path.Combine(Path, "Packages.dat"), FileMode.Create);

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
            var serializer = new BinaryFormatter();
            try
            {
                var fs = new FileStream(System.IO.Path.Combine(Path, "Packages.dat"), FileMode.Open);
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
            switch (State)
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
