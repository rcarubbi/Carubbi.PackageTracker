using Carubbi.PackageTracker.BLL;
using System;
using System.Windows.Forms;

namespace Carubbi.PackageTracker.UI
{
    public partial class FrmUpdatesPopup : Form
    {
        public FrmUpdatesPopup(Package p)
        {
            InitializeComponent();
            Package = p;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Package Package
        {
            set
            {
                Text += string.Concat(" - ", value.Alias);

                dgvUpdates.DataSource = value.Updates;
                dgvUpdates.Columns[0].Width = 150;
                dgvUpdates.Columns[1].Width = 250;
                dgvUpdates.Columns[2].Width = 150;
            }
        }


    }
}
