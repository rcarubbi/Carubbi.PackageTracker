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
    public partial class frmUpdatesPopup : Form
    {
        public frmUpdatesPopup(Package p)
        {
            InitializeComponent();
            Package = p;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Package Package
        {
            set
            {
                this.Text += string.Concat(" - ", value.Alias);

                dgvUpdates.DataSource = value.Updates;
                dgvUpdates.Columns[0].Width = 150;
                dgvUpdates.Columns[1].Width = 250;
                dgvUpdates.Columns[2].Width = 150;
            }
        }


    }
}
