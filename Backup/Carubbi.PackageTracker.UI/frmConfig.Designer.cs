namespace Carubbi.PackageTracker.UI
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.grpProxy = new System.Windows.Forms.GroupBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.txtProxyDomain = new System.Windows.Forms.TextBox();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.lblProxyDomain = new System.Windows.Forms.Label();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.lblProxyUsername = new System.Windows.Forms.Label();
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
            this.grpProxy.SuspendLayout();
            this.grpSMS.SuspendLayout();
            this.grpStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProxy
            // 
            this.grpProxy.Controls.Add(this.txtProxyPassword);
            this.grpProxy.Controls.Add(this.txtProxyDomain);
            this.grpProxy.Controls.Add(this.txtProxyUsername);
            this.grpProxy.Controls.Add(this.lblProxyDomain);
            this.grpProxy.Controls.Add(this.lblProxyPassword);
            this.grpProxy.Controls.Add(this.lblProxyUsername);
            this.grpProxy.Location = new System.Drawing.Point(12, 12);
            this.grpProxy.Name = "grpProxy";
            this.grpProxy.Size = new System.Drawing.Size(462, 90);
            this.grpProxy.TabIndex = 0;
            this.grpProxy.TabStop = false;
            this.grpProxy.Text = "Proxy";
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(113, 42);
            this.txtProxyPassword.MaxLength = 30;
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '*';
            this.txtProxyPassword.Size = new System.Drawing.Size(175, 21);
            this.txtProxyPassword.TabIndex = 3;
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Location = new System.Drawing.Point(113, 63);
            this.txtProxyDomain.MaxLength = 30;
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(175, 21);
            this.txtProxyDomain.TabIndex = 5;
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(113, 20);
            this.txtProxyUsername.MaxLength = 9;
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(175, 21);
            this.txtProxyUsername.TabIndex = 1;
            // 
            // lblProxyDomain
            // 
            this.lblProxyDomain.AutoSize = true;
            this.lblProxyDomain.Location = new System.Drawing.Point(15, 66);
            this.lblProxyDomain.Name = "lblProxyDomain";
            this.lblProxyDomain.Size = new System.Drawing.Size(51, 13);
            this.lblProxyDomain.TabIndex = 4;
            this.lblProxyDomain.Text = "Domain";
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.AutoSize = true;
            this.lblProxyPassword.Location = new System.Drawing.Point(15, 45);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.Size = new System.Drawing.Size(61, 13);
            this.lblProxyPassword.TabIndex = 2;
            this.lblProxyPassword.Text = "Password";
            // 
            // lblProxyUsername
            // 
            this.lblProxyUsername.AutoSize = true;
            this.lblProxyUsername.Location = new System.Drawing.Point(15, 24);
            this.lblProxyUsername.Name = "lblProxyUsername";
            this.lblProxyUsername.Size = new System.Drawing.Size(65, 13);
            this.lblProxyUsername.TabIndex = 0;
            this.lblProxyUsername.Text = "Username";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(318, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(399, 269);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
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
            this.grpSMS.Location = new System.Drawing.Point(12, 108);
            this.grpSMS.Name = "grpSMS";
            this.grpSMS.Size = new System.Drawing.Size(462, 81);
            this.grpSMS.TabIndex = 1;
            this.grpSMS.TabStop = false;
            this.grpSMS.Text = "SMS";
            // 
            // txtSmsPassword
            // 
            this.txtSmsPassword.Location = new System.Drawing.Point(113, 43);
            this.txtSmsPassword.MaxLength = 30;
            this.txtSmsPassword.Name = "txtSmsPassword";
            this.txtSmsPassword.PasswordChar = '*';
            this.txtSmsPassword.Size = new System.Drawing.Size(175, 21);
            this.txtSmsPassword.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(113, 22);
            this.txtPhoneNumber.MaxLength = 10;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(175, 21);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // lblSmsPassword
            // 
            this.lblSmsPassword.AutoSize = true;
            this.lblSmsPassword.Location = new System.Drawing.Point(15, 46);
            this.lblSmsPassword.Name = "lblSmsPassword";
            this.lblSmsPassword.Size = new System.Drawing.Size(61, 13);
            this.lblSmsPassword.TabIndex = 2;
            this.lblSmsPassword.Text = "Password";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(15, 25);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(91, 13);
            this.lblPhoneNumber.TabIndex = 0;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // grpStorage
            // 
            this.grpStorage.Controls.Add(this.txtPath);
            this.grpStorage.Controls.Add(this.lblStoragePath);
            this.grpStorage.Location = new System.Drawing.Point(15, 200);
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
            this.txtPath.Size = new System.Drawing.Size(343, 21);
            this.txtPath.TabIndex = 1;
            // 
            // lblStoragePath
            // 
            this.lblStoragePath.AutoSize = true;
            this.lblStoragePath.Location = new System.Drawing.Point(15, 26);
            this.lblStoragePath.Name = "lblStoragePath";
            this.lblStoragePath.Size = new System.Drawing.Size(32, 13);
            this.lblStoragePath.TabIndex = 0;
            this.lblStoragePath.Text = "Path";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 301);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpStorage);
            this.Controls.Add(this.grpSMS);
            this.Controls.Add(this.grpProxy);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.grpProxy.ResumeLayout(false);
            this.grpProxy.PerformLayout();
            this.grpSMS.ResumeLayout(false);
            this.grpSMS.PerformLayout();
            this.grpStorage.ResumeLayout(false);
            this.grpStorage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProxy;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.TextBox txtProxyDomain;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.Label lblProxyDomain;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.Label lblProxyUsername;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpSMS;
        private System.Windows.Forms.TextBox txtSmsPassword;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblSmsPassword;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.GroupBox grpStorage;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblStoragePath;
    }
}