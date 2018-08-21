using System.ComponentModel;
using System.Windows.Forms;

namespace Carubbi.PackageTracker.UI
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpSMS = new System.Windows.Forms.GroupBox();
            this.txtSmsPassword = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblSmsPassword = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.grpStorage = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblStoragePath = new System.Windows.Forms.Label();
            this.grpSMS.SuspendLayout();
            this.grpStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(393, 188);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpSMS
            // 
            this.grpSMS.Controls.Add(this.txtSmsPassword);
            this.grpSMS.Controls.Add(this.txtPhoneNumber);
            this.grpSMS.Controls.Add(this.lblSmsPassword);
            this.grpSMS.Controls.Add(this.lblPhoneNumber);
            this.grpSMS.Location = new System.Drawing.Point(12, 12);
            this.grpSMS.Name = "grpSMS";
            this.grpSMS.Size = new System.Drawing.Size(462, 101);
            this.grpSMS.TabIndex = 1;
            this.grpSMS.TabStop = false;
            this.grpSMS.Text = "SMS";
            // 
            // txtSmsPassword
            // 
            this.txtSmsPassword.Location = new System.Drawing.Point(157, 56);
            this.txtSmsPassword.MaxLength = 30;
            this.txtSmsPassword.Name = "txtSmsPassword";
            this.txtSmsPassword.PasswordChar = '*';
            this.txtSmsPassword.Size = new System.Drawing.Size(299, 28);
            this.txtSmsPassword.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(157, 22);
            this.txtPhoneNumber.MaxLength = 10;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(299, 28);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // lblSmsPassword
            // 
            this.lblSmsPassword.AutoSize = true;
            this.lblSmsPassword.Location = new System.Drawing.Point(15, 59);
            this.lblSmsPassword.Name = "lblSmsPassword";
            this.lblSmsPassword.Size = new System.Drawing.Size(89, 20);
            this.lblSmsPassword.TabIndex = 2;
            this.lblSmsPassword.Text = "Password";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(15, 25);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(136, 20);
            this.lblPhoneNumber.TabIndex = 0;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // grpStorage
            // 
            this.grpStorage.Controls.Add(this.txtPath);
            this.grpStorage.Controls.Add(this.lblStoragePath);
            this.grpStorage.Location = new System.Drawing.Point(15, 119);
            this.grpStorage.Name = "grpStorage";
            this.grpStorage.Size = new System.Drawing.Size(459, 63);
            this.grpStorage.TabIndex = 2;
            this.grpStorage.TabStop = false;
            this.grpStorage.Text = "Storage";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(110, 23);
            this.txtPath.MaxLength = 200;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(343, 28);
            this.txtPath.TabIndex = 1;
            // 
            // lblStoragePath
            // 
            this.lblStoragePath.AutoSize = true;
            this.lblStoragePath.Location = new System.Drawing.Point(15, 26);
            this.lblStoragePath.Name = "lblStoragePath";
            this.lblStoragePath.Size = new System.Drawing.Size(47, 20);
            this.lblStoragePath.TabIndex = 0;
            this.lblStoragePath.Text = "Path";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 231);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpStorage);
            this.Controls.Add(this.grpSMS);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.grpSMS.ResumeLayout(false);
            this.grpSMS.PerformLayout();
            this.grpStorage.ResumeLayout(false);
            this.grpStorage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

 
        private Button btnCancel;
        private Button btnOK;
        private GroupBox grpSMS;
        private TextBox txtSmsPassword;
        private TextBox txtPhoneNumber;
        private Label lblSmsPassword;
        private Label lblPhoneNumber;
        private GroupBox grpStorage;
        private TextBox txtPath;
        private Label lblStoragePath;
    }
}