using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Carubbi.PackageTracker.BLL;

namespace Carubbi.PackageTracker.UI
{
    public partial class frmConfig : Form
    {
        public PackageMonitor Monitor
        {
            get;
            private set;
        }

        public event EventHandler Ok;


        public frmConfig(PackageMonitor monitor)
        {
            InitializeComponent();
            Monitor = monitor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (Ok != null)
                Ok(sender, e);
            this.Close();
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
