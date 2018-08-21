using System.ComponentModel;
using System.Windows.Forms;

namespace Carubbi.PackageTracker.UI
{
    partial class FrmPackageTracker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackageTracker));
            this.gdvPackages = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblTrackNumber = new System.Windows.Forms.Label();
            this.grpPackageData = new System.Windows.Forms.GroupBox();
            this.btnSeeUpdates = new System.Windows.Forms.Button();
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
            this.gdvPackages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvPackages.Location = new System.Drawing.Point(15, 133);
            this.gdvPackages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gdvPackages.Name = "gdvPackages";
            this.gdvPackages.ReadOnly = true;
            this.gdvPackages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvPackages.Size = new System.Drawing.Size(638, 248);
            this.gdvPackages.TabIndex = 1;
            this.gdvPackages.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GdvPackages_CellMouseClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(348, 57);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 27);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "-";
            this.toolTip.SetToolTip(this.btnRemove, "Remove Pakcage");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(301, 57);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "+";
            this.toolTip.SetToolTip(this.btnAdd, "Add Package");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(10, 27);
            this.lblAlias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(48, 18);
            this.lblAlias.TabIndex = 0;
            this.lblAlias.Text = "Alias";
            // 
            // lblTrackNumber
            // 
            this.lblTrackNumber.AutoSize = true;
            this.lblTrackNumber.Location = new System.Drawing.Point(9, 59);
            this.lblTrackNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrackNumber.Name = "lblTrackNumber";
            this.lblTrackNumber.Size = new System.Drawing.Size(125, 18);
            this.lblTrackNumber.TabIndex = 2;
            this.lblTrackNumber.Text = "Track Number:";
            // 
            // grpPackageData
            // 
            this.grpPackageData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPackageData.Controls.Add(this.btnSeeUpdates);
            this.grpPackageData.Controls.Add(this.txtTrackNumber);
            this.grpPackageData.Controls.Add(this.btnRemove);
            this.grpPackageData.Controls.Add(this.btnAdd);
            this.grpPackageData.Controls.Add(this.txtAlias);
            this.grpPackageData.Controls.Add(this.lblAlias);
            this.grpPackageData.Controls.Add(this.lblTrackNumber);
            this.grpPackageData.Location = new System.Drawing.Point(15, 26);
            this.grpPackageData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPackageData.Name = "grpPackageData";
            this.grpPackageData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPackageData.Size = new System.Drawing.Size(638, 101);
            this.grpPackageData.TabIndex = 0;
            this.grpPackageData.TabStop = false;
            this.grpPackageData.Text = "Package Data";
            // 
            // btnSeeUpdates
            // 
            this.btnSeeUpdates.Location = new System.Drawing.Point(395, 57);
            this.btnSeeUpdates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeeUpdates.Name = "btnSeeUpdates";
            this.btnSeeUpdates.Size = new System.Drawing.Size(39, 27);
            this.btnSeeUpdates.TabIndex = 6;
            this.btnSeeUpdates.Text = "...";
            this.toolTip.SetToolTip(this.btnSeeUpdates, "Show Updates");
            this.btnSeeUpdates.UseVisualStyleBackColor = true;
            this.btnSeeUpdates.Click += new System.EventHandler(this.BtnSeeUpdates_Click);
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.Location = new System.Drawing.Point(141, 57);
            this.txtTrackNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTrackNumber.MaxLength = 13;
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(153, 27);
            this.txtTrackNumber.TabIndex = 3;
            // 
            // txtAlias
            // 
            this.txtAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlias.Location = new System.Drawing.Point(64, 25);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(548, 27);
            this.txtAlias.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Package Tracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRefresh,
            this.mnuStartStopContext,
            this.mnuSeparator,
            this.mnuExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(185, 100);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(184, 30);
            this.mnuRefresh.Text = "Refresh Now";
            this.mnuRefresh.Click += new System.EventHandler(this.MnuRefresh_Click);
            // 
            // mnuStartStopContext
            // 
            this.mnuStartStopContext.Name = "mnuStartStopContext";
            this.mnuStartStopContext.Size = new System.Drawing.Size(184, 30);
            this.mnuStartStopContext.Text = "Start/Stop";
            this.mnuStartStopContext.Click += new System.EventHandler(this.MnuStartStopContext_Click);
            // 
            // mnuSeparator
            // 
            this.mnuSeparator.Name = "mnuSeparator";
            this.mnuSeparator.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(184, 30);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusVoiceNotification,
            this.lblStatusSmsNotification});
            this.statusStrip.Location = new System.Drawing.Point(0, 378);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(668, 30);
            this.statusStrip.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            // 
            // lblStatusVoiceNotification
            // 
            this.lblStatusVoiceNotification.Name = "lblStatusVoiceNotification";
            this.lblStatusVoiceNotification.Size = new System.Drawing.Size(229, 25);
            this.lblStatusVoiceNotification.Text = "Voice Notification: Disabled";
            // 
            // lblStatusSmsNotification
            // 
            this.lblStatusSmsNotification.Name = "lblStatusSmsNotification";
            this.lblStatusSmsNotification.Size = new System.Drawing.Size(221, 25);
            this.lblStatusSmsNotification.Text = "Sms Notification: Disabled";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMonitor,
            this.mnuOptions});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(668, 26);
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
            this.mnuMonitor.Size = new System.Drawing.Size(85, 24);
            this.mnuMonitor.Text = "Monitor";
            // 
            // mnuStartStop
            // 
            this.mnuStartStop.Name = "mnuStartStop";
            this.mnuStartStop.Size = new System.Drawing.Size(217, 30);
            this.mnuStartStop.Text = "Start/Stop";
            this.mnuStartStop.Click += new System.EventHandler(this.MnuStartStop_Click);
            // 
            // mnuRefreshNow
            // 
            this.mnuRefreshNow.Name = "mnuRefreshNow";
            this.mnuRefreshNow.Size = new System.Drawing.Size(217, 30);
            this.mnuRefreshNow.Text = "Refresh Now";
            this.mnuRefreshNow.Click += new System.EventHandler(this.MnuRefreshNow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(217, 30);
            this.mnuSave.Text = "Save Packages";
            this.mnuSave.Click += new System.EventHandler(this.MnuSave_Click);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(217, 30);
            this.mnuLoad.Text = "Load Packages";
            this.mnuLoad.Click += new System.EventHandler(this.MnuLoad_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCycles,
            this.notificationsToolStripMenuItem,
            this.mnuConfig});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(87, 24);
            this.mnuOptions.Text = "Options";
            // 
            // mnuCycles
            // 
            this.mnuCycles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboCycles});
            this.mnuCycles.Name = "mnuCycles";
            this.mnuCycles.Size = new System.Drawing.Size(234, 30);
            this.mnuCycles.Text = "Cycles (Minutes)";
            // 
            // cboCycles
            // 
            this.cboCycles.Name = "cboCycles";
            this.cboCycles.Size = new System.Drawing.Size(121, 33);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVoiceNotification,
            this.mnuSMSNotification});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // mnuVoiceNotification
            // 
            this.mnuVoiceNotification.CheckOnClick = true;
            this.mnuVoiceNotification.Name = "mnuVoiceNotification";
            this.mnuVoiceNotification.Size = new System.Drawing.Size(239, 30);
            this.mnuVoiceNotification.Text = "Voice Notification";
            this.mnuVoiceNotification.Click += new System.EventHandler(this.MnuVoiceNotification_Click);
            // 
            // mnuSMSNotification
            // 
            this.mnuSMSNotification.CheckOnClick = true;
            this.mnuSMSNotification.Name = "mnuSMSNotification";
            this.mnuSMSNotification.Size = new System.Drawing.Size(239, 30);
            this.mnuSMSNotification.Text = "SMS Notification";
            this.mnuSMSNotification.Click += new System.EventHandler(this.MnuSMSNotification_Click);
            // 
            // mnuConfig
            // 
            this.mnuConfig.Name = "mnuConfig";
            this.mnuConfig.Size = new System.Drawing.Size(234, 30);
            this.mnuConfig.Text = "Configuration";
            this.mnuConfig.Click += new System.EventHandler(this.MnuConnectionVariables_Click);
            // 
            // frmPackageTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 408);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.gdvPackages);
            this.Controls.Add(this.grpPackageData);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmPackageTracker";
            this.Text = "Package Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPackageTracker_FormClosing);
            this.Load += new System.EventHandler(this.FrmPackageTracker_Load);
            this.SizeChanged += new System.EventHandler(this.FrmPackageTracker_SizeChanged);
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

        private DataGridView gdvPackages;
        private Button btnRemove;
        private Button btnAdd;
        private Label lblAlias;
        private Label lblTrackNumber;
        private GroupBox grpPackageData;
        private TextBox txtTrackNumber;
        private TextBox txtAlias;
        private NotifyIcon notifyIcon;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuMonitor;
        private ToolStripMenuItem mnuStartStop;
        private ToolStripMenuItem mnuOptions;
        private ToolStripMenuItem mnuLoad;
        private ToolStripMenuItem mnuSave;
        private ToolStripMenuItem notificationsToolStripMenuItem;
        private ToolStripMenuItem mnuVoiceNotification;
        private ToolStripMenuItem mnuSMSNotification;
        private ToolTip toolTip;
        private Button btnSeeUpdates;
        private ToolStripStatusLabel lblStatusVoiceNotification;
        private ToolStripStatusLabel lblStatusSmsNotification;
        private ContextMenuStrip notifyMenu;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuRefresh;
        private ToolStripMenuItem mnuStartStopContext;
        private ToolStripSeparator mnuSeparator;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuRefreshNow;
        private ToolStripMenuItem mnuConfig;
        private ToolStripMenuItem mnuCycles;
        private ToolStripComboBox cboCycles;
    }
}

