using Carubbi.PackageTracker.BLL;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Carubbi.PackageTracker.UI
{
    public partial class frmPackageTracker : Form
    {
        public frmPackageTracker()
        {
            InitializeComponent();
        }

        private PackageMonitor _monitor;
        private frmConfig _config;
        private frmUpdatesPopup _updatesPopup;


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTrackNumber.Text))
                {
                    var p = new Package() { Alias = txtAlias.Text, TrackNumber = txtTrackNumber.Text };
                    if (!_monitor.Packages.Contains(p, Package.CompararPorTrackNumber))
                    {
                        _monitor.Packages.Add(p);
                        RefreshPackages();
                    }
                    else
                    {
                        throw new ApplicationException("Código de rastreio já existente");
                    }
                }
                else
                    throw new ApplicationException("Preencha o código de rastreio");
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPackages()
        {
            try
            {
                gdvPackages.DataSource = null;
                gdvPackages.DataSource = _monitor.Packages;
                gdvPackages.Columns[0].Width = 400;
                gdvPackages.Columns[1].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTrackNumber.Text)) return;

                var p = new Package() { TrackNumber = txtTrackNumber.Text, Alias = txtAlias.Text };
                if (_monitor.Packages.Contains(p, Package.CompararPorTrackNumber))
                {
                    var deletePackage = _monitor.Packages.Single(i => i.TrackNumber == txtTrackNumber.Text);
                    _monitor.Packages.Remove(deletePackage);
                    RefreshPackages();
                }
                else
                    throw new ApplicationException("Pacote não encontrado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCycles.SelectedItem == null)
                    throw new ApplicationException("Selecione um periodo de execução");

                _monitor.Config.Cycle = Convert.ToInt32(cboCycles.SelectedItem);
                _monitor.StartStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void frmPackageTracker_Load(object sender, EventArgs e)
        {
            try
            {
                _monitor = new PackageMonitor();
                _monitor.PackageModified += new EventHandler<NotifyUpdateEventArgs>(_monitor_PackageModified);
                _monitor.StatusModified += new EventHandler(_monitor_StatusModified);
                LoadCycles();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void _config_Ok(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_monitor.Config.PhoneNumber)) return;
            _monitor.SmsNotification = false;
            _monitor.Config.PhoneNumber = string.Empty;
            lblStatusSmsNotification.Text = string.Format("Sms Notification: Disabled");
        }

        void _monitor_StatusModified(object sender, EventArgs e)
        {
            ModifyButtons(_monitor.State != MonitorState.Running);

            lblStatus.Text = _monitor.State.ToString();
            notifyIcon.Text = $"Package Tracker - {_monitor.State.ToString()}";
            Application.DoEvents();
        }

      
      
        private void ModifyButtons(bool enable)
        {
            if (btnAdd.InvokeRequired)
            {
                var method = new Action<bool>(ModifyButtons);
                object[] parametro = { enable };
                Invoke(method, parametro);
            }
            else
            {
                btnAdd.Enabled =
                          btnRemove.Enabled =
                          btnSeeUpdates.Enabled =
                          enable;
            }
        }


        private void LoadCycles()
        {
            cboCycles.Items.AddRange(new object[] { 1, 5, 10, 15, 20, 25, 30, 60 });
            cboCycles.SelectedItem = 30;
        }

        void _monitor_PackageModified(object sender, NotifyUpdateEventArgs e)
        {
            try
            {
                notifyIcon.ShowBalloonTip(3000, "Package Notification", e.Package.GetMessage(e.Update), ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPackageTracker_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void mnuLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _monitor.LoadPackages();
                RefreshPackages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            try
            {
                _monitor.SavePackages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuVoiceNotification_Click(object sender, EventArgs e)
        {
            _monitor.VoiceNotification = !_monitor.VoiceNotification;
            var voiceNotification = _monitor.VoiceNotification ? "Enabled" : "Disabled";
            lblStatusVoiceNotification.Text = $"Voice Notification: {voiceNotification}";
        }

        private void mnuSMSNotification_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_monitor.Config.PhoneNumber)) return;
                _monitor.SmsNotification = !_monitor.SmsNotification;
                if (_monitor.SmsNotification)
                {
                    if (string.IsNullOrEmpty(_monitor.Config.SmsPassword))
                    {
                        _monitor.SmsNotification = false;
                        throw new ApplicationException("Preencha a senha para habilitar esta funcionalidade");
                    }
                }
                var smsNotification = _monitor.SmsNotification ? "Enabled" : "Disabled";
                lblStatusSmsNotification.Text = $"Sms Notification: {smsNotification}";
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void gdvPackages_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtAlias.Text = _monitor.Packages[e.RowIndex].Alias;
            txtTrackNumber.Text = _monitor.Packages[e.RowIndex].TrackNumber;
            _packageSelected = _monitor.Packages[e.RowIndex];
        }

        private Package _packageSelected;

        private void btnSeeUpdates_Click(object sender, EventArgs e)
        {
            if (_packageSelected != null)
            {
               _updatesPopup = new frmUpdatesPopup(_packageSelected);
               _updatesPopup.Show(this);
            }
            else
                MessageBox.Show("Selecione um pacote para visualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

      
        private void frmPackageTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;

        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.WindowState != FormWindowState.Minimized)
            {
                notifyMenu.Hide();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new Thread(new ThreadStart(_monitor.Refresh));
                t.Start();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuStartStopContext_Click(object sender, EventArgs e)
        {
            mnuStartStop_Click(sender, EventArgs.Empty);
        }

        private void mnuRefreshNow_Click(object sender, EventArgs e)
        {
            mnuRefresh_Click(sender, EventArgs.Empty);
        }

        private void mnuConnectionVariables_Click(object sender, EventArgs e)
        {
            _config = new frmConfig(_monitor);
            _config.Ok += new EventHandler(_config_Ok);
            _config.Show(this);
        }

   


    }
}
