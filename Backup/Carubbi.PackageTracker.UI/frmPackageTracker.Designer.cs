namespace Carubbi.PackageTracker.UI
{
    partial class frmPackageTracker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackageTracker));
            this.gdvPackages = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblTrackNumber = new System.Windows.Forms.Label();
            this.grpPackageData = new System.Windows.Forms.GroupBox();
            this.btnSeeUpdates = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.txtTrackNumber = new System.Windows.Forms.TextBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartStopContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusVoiceNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusSmsNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefreshNow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCycles = new System.Windows.Forms.ToolStripMenuItem();
            this.cboCycles = new System.Windows.Forms.ToolStripComboBox();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVoiceNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSMSNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gdvPackages)).BeginInit();
            this.grpPackageData.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdvPackages
            // 
            this.gdvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvPackages.Location = new System.Drawing.Point(16, 119);
            this.gdvPackages.Margin = new System.Windows.Forms.Padding(4);
            this.gdvPackages.Name = "gdvPackages";
            this.gdvPackages.ReadOnly = true;
            this.gdvPackages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvPackages.Size = new System.Drawing.Size(660, 352);
            this.gdvPackages.TabIndex = 1;
            this.gdvPackages.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gdvPackages_CellMouseClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(341, 40);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(43, 24);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "-";
            this.toolTip.SetToolTip(this.btnRemove, "Remove Pakcage");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(290, 40);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 24);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "+";
            this.toolTip.SetToolTip(this.btnAdd, "Add Package");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(8, 19);
            this.lblAlias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(36, 14);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "Alias";
            // 
            // lblTrackNumber
            // 
            this.lblTrackNumber.AutoSize = true;
            this.lblTrackNumber.Location = new System.Drawing.Point(8, 45);
            this.lblTrackNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrackNumber.Name = "lblTrackNumber";
            this.lblTrackNumber.Size = new System.Drawing.Size(98, 14);
            this.lblTrackNumber.TabIndex = 2;
            this.lblTrackNumber.Text = "Track Number:";
            // 
            // grpPackageData
            // 
            this.grpPackageData.Controls.Add(this.btnSeeUpdates);
            this.grpPackageData.Controls.Add(this.webBrowser);
            this.grpPackageData.Controls.Add(this.txtTrackNumber);
            this.grpPackageData.Controls.Add(this.btnRemove);
            this.grpPackageData.Controls.Add(this.btnAdd);
            this.grpPackageData.Controls.Add(this.txtAlias);
            this.grpPackageData.Controls.Add(this.lblAlias);
            this.grpPackageData.Controls.Add(this.lblTrackNumber);
            this.grpPackageData.Location = new System.Drawing.Point(16, 28);
            this.grpPackageData.Margin = new System.Windows.Forms.Padding(4);
            this.grpPackageData.Name = "grpPackageData";
            this.grpPackageData.Padding = new System.Windows.Forms.Padding(4);
            this.grpPackageData.Size = new System.Drawing.Size(660, 85);
            this.grpPackageData.TabIndex = 0;
            this.grpPackageData.TabStop = false;
            this.grpPackageData.Text = "Package Data";
            // 
            // btnSeeUpdates
            // 
            this.btnSeeUpdates.Location = new System.Drawing.Point(392, 40);
            this.btnSeeUpdates.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeeUpdates.Name = "btnSeeUpdates";
            this.btnSeeUpdates.Size = new System.Drawing.Size(43, 24);
            this.btnSeeUpdates.TabIndex = 6;
            this.btnSeeUpdates.Text = "...";
            this.toolTip.SetToolTip(this.btnSeeUpdates, "Show Updates");
            this.btnSeeUpdates.UseVisualStyleBackColor = true;
            this.btnSeeUpdates.Click += new System.EventHandler(this.btnSeeUpdates_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(570, 42);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser.MinimumSize = new System.Drawing.Size(27, 22);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(73, 22);
            this.webBrowser.TabIndex = 7;
            this.webBrowser.Visible = false;
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.Location = new System.Drawing.Point(114, 41);
            this.txtTrackNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrackNumber.MaxLength = 13;
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(168, 22);
            this.txtTrackNumber.TabIndex = 3;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(52, 16);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(591, 22);
            this.txtAlias.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Package Tracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRefresh,
            this.mnuStartStopContext,
            this.mnuSeparator,
            this.mnuExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(142, 76);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(141, 22);
            this.mnuRefresh.Text = "Refresh Now";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuStartStopContext
            // 
            this.mnuStartStopContext.Name = "mnuStartStopContext";
            this.mnuStartStopContext.Size = new System.Drawing.Size(141, 22);
            this.mnuStartStopContext.Text = "Start/Stop";
            this.mnuStartStopContext.Click += new System.EventHandler(this.mnuStartStopContext_Click);
            // 
            // mnuSeparator
            // 
            this.mnuSeparator.Name = "mnuSeparator";
            this.mnuSeparator.Size = new System.Drawing.Size(138, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(141, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusVoiceNotification,
            this.lblStatusSmsNotification});
            this.statusStrip.Location = new System.Drawing.Point(0, 479);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(689, 22);
            this.statusStrip.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusVoiceNotification
            // 
            this.lblStatusVoiceNotification.Name = "lblStatusVoiceNotification";
            this.lblStatusVoiceNotification.Size = new System.Drawing.Size(153, 17);
            this.lblStatusVoiceNotification.Text = "Voice Notification: Disabled";
            // 
            // lblStatusSmsNotification
            // 
            this.lblStatusSmsNotification.Name = "lblStatusSmsNotification";
            this.lblStatusSmsNotification.Size = new System.Drawing.Size(146, 17);
            this.lblStatusSmsNotification.Text = "Sms Notification: Disabled";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMonitor,
            this.mnuOptions});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(689, 24);
            this.menuStrip.TabIndex = 7;
            // 
            // mnuMonitor
            // 
            this.mnuMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartStop,
            this.mnuRefreshNow,
            this.toolStripSeparator1,
            this.mnuSave,
            this.mnuLoad});
            this.mnuMonitor.Name = "mnuMonitor";
            this.mnuMonitor.Size = new System.Drawing.Size(61, 20);
            this.mnuMonitor.Text = "Monitor";
            // 
            // mnuStartStop
            // 
            this.mnuStartStop.Name = "mnuStartStop";
            this.mnuStartStop.Size = new System.Drawing.Size(161, 22);
            this.mnuStartStop.Text = "Start/Stop";
            this.mnuStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
            // 
            // mnuRefreshNow
            // 
            this.mnuRefreshNow.Name = "mnuRefreshNow";
            this.mnuRefreshNow.Size = new System.Drawing.Size(161, 22);
            this.mnuRefreshNow.Text = "Refresh Now";
            this.mnuRefreshNow.Click += new System.EventHandler(this.mnuRefreshNow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(161, 22);
            this.mnuSave.Text = "Save Packages";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(161, 22);
            this.mnuLoad.Text = "Load Packages";
            this.mnuLoad.Click += new System.EventHandler(this.mnuLoad_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCycles,
            this.notificationsToolStripMenuItem,
            this.mnuConfig});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(62, 20);
            this.mnuOptions.Text = "Options";
            // 
            // mnuCycles
            // 
            this.mnuCycles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboCycles});
            this.mnuCycles.Name = "mnuCycles";
            this.mnuCycles.Size = new System.Drawing.Size(169, 22);
            this.mnuCycles.Text = "Cycles (Minutes)";
            // 
            // cboCycles
            // 
            this.cboCycles.Name = "cboCycles";
            this.cboCycles.Size = new System.Drawing.Size(121, 23);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVoiceNotification,
            this.mnuSMSNotification});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // mnuVoiceNotification
            // 
            this.mnuVoiceNotification.Name = "mnuVoiceNotification";
            this.mnuVoiceNotification.Size = new System.Drawing.Size(172, 22);
            this.mnuVoiceNotification.Text = "Voice Notification";
            this.mnuVoiceNotification.Click += new System.EventHandler(this.mnuVoiceNotification_Click);
            // 
            // mnuSMSNotification
            // 
            this.mnuSMSNotification.Name = "mnuSMSNotification";
            this.mnuSMSNotification.Size = new System.Drawing.Size(172, 22);
            this.mnuSMSNotification.Text = "SMS Notification";
            this.mnuSMSNotification.Click += new System.EventHandler(this.mnuSMSNotification_Click);
            // 
            // mnuConfig
            // 
            this.mnuConfig.Name = "mnuConfig";
            this.mnuConfig.Size = new System.Drawing.Size(169, 22);
            this.mnuConfig.Text = "Configuration";
            this.mnuConfig.Click += new System.EventHandler(this.mnuConnectionVariables_Click);
            // 
            // frmPackageTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 501);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.grpPackageData);
            this.Controls.Add(this.gdvPackages);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPackageTracker";
            this.Text = "Package Tracker";
            this.Load += new System.EventHandler(this.frmPackageTracker_Load);
            this.SizeChanged += new System.EventHandler(this.frmPackageTracker_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPackageTracker_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gdvPackages)).EndInit();
            this.grpPackageData.ResumeLayout(false);
            this.grpPackageData.PerformLayout();
            this.notifyMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvPackages;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblTrackNumber;
        private System.Windows.Forms.GroupBox grpPackageData;
        private System.Windows.Forms.TextBox txtTrackNumber;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuMonitor;
        private System.Windows.Forms.ToolStripMenuItem mnuStartStop;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVoiceNotification;
        private System.Windows.Forms.ToolStripMenuItem mnuSMSNotification;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSeeUpdates;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusVoiceNotification;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSmsNotification;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuStartStopContext;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefreshNow;
        private System.Windows.Forms.ToolStripMenuItem mnuConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuCycles;
        private System.Windows.Forms.ToolStripComboBox cboCycles;
    }
}

