using Carubbi.PackageTracker.BLL;
using System;
using System.Windows.Forms;

namespace Carubbi.PackageTracker.UI
{
    public partial class FrmConfig : Form
    {
        public PackageMonitor Monitor
        {
            get;
        }

        public event EventHandler Ok;

        public FrmConfig(PackageMonitor monitor)
        {
            InitializeComponent();
            Monitor = monitor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveConfig();
            Ok?.Invoke(sender, e);
            Close();
        }

        private void SaveConfig()
        {
            Monitor.Path = txtPath.Text;
            Monitor.Config.PhoneNumber = txtPhoneNumber.Text;
            Monitor.Config.SmsPassword = txtSmsPassword.Text;
            Monitor.SaveConfig();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            Monitor.LoadConfig();
            txtPath.Text = Monitor.Path;
            txtPhoneNumber.Text = Monitor.Config.PhoneNumber;
            txtSmsPassword.Text = Monitor.Config.SmsPassword;
        }
    }
}
