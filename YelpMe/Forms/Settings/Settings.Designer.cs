namespace YelpMe.Forms
{
    partial class Settings
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
            grpSearchOptions = new GroupBox();
            rbSearchOnline = new RadioButton();
            rbSearchOffline = new RadioButton();
            button1 = new Button();
            grpScrapeOptions = new GroupBox();
            ckMutilpeNameAPI = new CheckBox();
            cboNameAPIKeys = new ComboBox();
            ckEnableNameApi = new CheckBox();
            btnRemoveNameApiKey = new Button();
            btnAddNameApiKey = new Button();
            linkLabel1 = new LinkLabel();
            lblNameApiKeys = new Label();
            ckGetHumanNames = new CheckBox();
            ckValidateEmails = new CheckBox();
            rbFacebookPixelInstalled = new RadioButton();
            rbFacebookPixelNotInstalled = new RadioButton();
            grpFacebookPOptions = new GroupBox();
            grpYouTubeOptions = new GroupBox();
            ckYouTubeShorts = new CheckBox();
            rbNoYouTubeChannel = new RadioButton();
            rbYouTubeChannel = new RadioButton();
            btnSaveChanges = new Button();
            btnReset = new Button();
            grpSearchOptions.SuspendLayout();
            grpScrapeOptions.SuspendLayout();
            grpFacebookPOptions.SuspendLayout();
            grpYouTubeOptions.SuspendLayout();
            SuspendLayout();
            // 
            // grpSearchOptions
            // 
            grpSearchOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSearchOptions.Controls.Add(rbSearchOnline);
            grpSearchOptions.Controls.Add(rbSearchOffline);
            grpSearchOptions.Controls.Add(button1);
            grpSearchOptions.Location = new Point(12, 12);
            grpSearchOptions.Name = "grpSearchOptions";
            grpSearchOptions.Size = new Size(1052, 172);
            grpSearchOptions.TabIndex = 0;
            grpSearchOptions.TabStop = false;
            grpSearchOptions.Text = "Search Options";
            // 
            // rbSearchOnline
            // 
            rbSearchOnline.AutoSize = true;
            rbSearchOnline.Location = new Point(25, 69);
            rbSearchOnline.Name = "rbSearchOnline";
            rbSearchOnline.Size = new Size(366, 29);
            rbSearchOnline.TabIndex = 2;
            rbSearchOnline.TabStop = true;
            rbSearchOnline.Text = "Extract web data online using Cloud Data.\r\n";
            rbSearchOnline.UseVisualStyleBackColor = true;
            // 
            // rbSearchOffline
            // 
            rbSearchOffline.AutoSize = true;
            rbSearchOffline.Location = new Point(25, 35);
            rbSearchOffline.Name = "rbSearchOffline";
            rbSearchOffline.Size = new Size(361, 29);
            rbSearchOffline.TabIndex = 1;
            rbSearchOffline.TabStop = true;
            rbSearchOffline.Text = "Extract web data offline using Local Data.";
            rbSearchOffline.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(25, 116);
            button1.Name = "button1";
            button1.Size = new Size(217, 34);
            button1.TabIndex = 0;
            button1.Text = "Download Search Batch File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // grpScrapeOptions
            // 
            grpScrapeOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpScrapeOptions.Controls.Add(ckMutilpeNameAPI);
            grpScrapeOptions.Controls.Add(cboNameAPIKeys);
            grpScrapeOptions.Controls.Add(ckEnableNameApi);
            grpScrapeOptions.Controls.Add(btnRemoveNameApiKey);
            grpScrapeOptions.Controls.Add(btnAddNameApiKey);
            grpScrapeOptions.Controls.Add(linkLabel1);
            grpScrapeOptions.Controls.Add(lblNameApiKeys);
            grpScrapeOptions.Controls.Add(ckGetHumanNames);
            grpScrapeOptions.Controls.Add(ckValidateEmails);
            grpScrapeOptions.Location = new Point(12, 190);
            grpScrapeOptions.Name = "grpScrapeOptions";
            grpScrapeOptions.Size = new Size(1052, 242);
            grpScrapeOptions.TabIndex = 3;
            grpScrapeOptions.TabStop = false;
            grpScrapeOptions.Text = "Scraping Options";
            // 
            // ckMutilpeNameAPI
            // 
            ckMutilpeNameAPI.AutoSize = true;
            ckMutilpeNameAPI.Location = new Point(19, 196);
            ckMutilpeNameAPI.Name = "ckMutilpeNameAPI";
            ckMutilpeNameAPI.Size = new Size(363, 29);
            ckMutilpeNameAPI.TabIndex = 32;
            ckMutilpeNameAPI.Text = "Use all API Key for NAME API operations.";
            ckMutilpeNameAPI.UseVisualStyleBackColor = true;
            // 
            // cboNameAPIKeys
            // 
            cboNameAPIKeys.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNameAPIKeys.FormattingEnabled = true;
            cboNameAPIKeys.Location = new Point(19, 70);
            cboNameAPIKeys.Name = "cboNameAPIKeys";
            cboNameAPIKeys.Size = new Size(674, 33);
            cboNameAPIKeys.TabIndex = 29;
            // 
            // ckEnableNameApi
            // 
            ckEnableNameApi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckEnableNameApi.AutoSize = true;
            ckEnableNameApi.Location = new Point(935, 73);
            ckEnableNameApi.Name = "ckEnableNameApi";
            ckEnableNameApi.Size = new Size(90, 29);
            ckEnableNameApi.TabIndex = 28;
            ckEnableNameApi.Text = "Enable";
            ckEnableNameApi.UseVisualStyleBackColor = true;
            // 
            // btnRemoveNameApiKey
            // 
            btnRemoveNameApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveNameApiKey.Location = new Point(817, 70);
            btnRemoveNameApiKey.Name = "btnRemoveNameApiKey";
            btnRemoveNameApiKey.Size = new Size(112, 34);
            btnRemoveNameApiKey.TabIndex = 27;
            btnRemoveNameApiKey.Text = "Remove";
            btnRemoveNameApiKey.UseVisualStyleBackColor = true;
            btnRemoveNameApiKey.Click += btnRemoveNameApiKey_Click;
            // 
            // btnAddNameApiKey
            // 
            btnAddNameApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNameApiKey.Location = new Point(699, 70);
            btnAddNameApiKey.Name = "btnAddNameApiKey";
            btnAddNameApiKey.Size = new Size(112, 34);
            btnAddNameApiKey.TabIndex = 26;
            btnAddNameApiKey.Text = "Add";
            btnAddNameApiKey.UseVisualStyleBackColor = true;
            btnAddNameApiKey.Click += btnAddNameApiKey_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(298, 42);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(395, 25);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "more info - https://www.nameapi.org/en/home/";
            // 
            // lblNameApiKeys
            // 
            lblNameApiKeys.AutoSize = true;
            lblNameApiKeys.Location = new Point(19, 42);
            lblNameApiKeys.Name = "lblNameApiKeys";
            lblNameApiKeys.Size = new Size(132, 25);
            lblNameApiKeys.TabIndex = 24;
            lblNameApiKeys.Text = "Name API Keys";
            // 
            // ckGetHumanNames
            // 
            ckGetHumanNames.AutoSize = true;
            ckGetHumanNames.Location = new Point(19, 161);
            ckGetHumanNames.Name = "ckGetHumanNames";
            ckGetHumanNames.Size = new Size(395, 29);
            ckGetHumanNames.TabIndex = 23;
            ckGetHumanNames.Text = "Get email addresses that have human names.\r\n";
            ckGetHumanNames.UseVisualStyleBackColor = true;
            // 
            // ckValidateEmails
            // 
            ckValidateEmails.AutoSize = true;
            ckValidateEmails.Location = new Point(19, 126);
            ckValidateEmails.Name = "ckValidateEmails";
            ckValidateEmails.Size = new Size(223, 29);
            ckValidateEmails.TabIndex = 22;
            ckValidateEmails.Text = "Validate Email Adresses";
            ckValidateEmails.UseVisualStyleBackColor = true;
            // 
            // rbFacebookPixelInstalled
            // 
            rbFacebookPixelInstalled.AutoSize = true;
            rbFacebookPixelInstalled.Location = new Point(25, 35);
            rbFacebookPixelInstalled.Name = "rbFacebookPixelInstalled";
            rbFacebookPixelInstalled.Size = new Size(508, 29);
            rbFacebookPixelInstalled.TabIndex = 1;
            rbFacebookPixelInstalled.TabStop = true;
            rbFacebookPixelInstalled.Text = "Scrape leads with Facebook Pixels installed on their website.";
            rbFacebookPixelInstalled.UseVisualStyleBackColor = true;
            // 
            // rbFacebookPixelNotInstalled
            // 
            rbFacebookPixelNotInstalled.AutoSize = true;
            rbFacebookPixelNotInstalled.Location = new Point(25, 69);
            rbFacebookPixelNotInstalled.Name = "rbFacebookPixelNotInstalled";
            rbFacebookPixelNotInstalled.Size = new Size(607, 29);
            rbFacebookPixelNotInstalled.TabIndex = 2;
            rbFacebookPixelNotInstalled.TabStop = true;
            rbFacebookPixelNotInstalled.Text = "Scrape leads that do not have Facebook Pixels installed on their website.";
            rbFacebookPixelNotInstalled.UseVisualStyleBackColor = true;
            // 
            // grpFacebookPOptions
            // 
            grpFacebookPOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFacebookPOptions.Controls.Add(rbFacebookPixelNotInstalled);
            grpFacebookPOptions.Controls.Add(rbFacebookPixelInstalled);
            grpFacebookPOptions.Location = new Point(12, 438);
            grpFacebookPOptions.Name = "grpFacebookPOptions";
            grpFacebookPOptions.Size = new Size(1052, 135);
            grpFacebookPOptions.TabIndex = 4;
            grpFacebookPOptions.TabStop = false;
            grpFacebookPOptions.Text = "Facebook Page Options";
            // 
            // grpYouTubeOptions
            // 
            grpYouTubeOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpYouTubeOptions.Controls.Add(ckYouTubeShorts);
            grpYouTubeOptions.Controls.Add(rbNoYouTubeChannel);
            grpYouTubeOptions.Controls.Add(rbYouTubeChannel);
            grpYouTubeOptions.Location = new Point(12, 579);
            grpYouTubeOptions.Name = "grpYouTubeOptions";
            grpYouTubeOptions.Size = new Size(1052, 195);
            grpYouTubeOptions.TabIndex = 5;
            grpYouTubeOptions.TabStop = false;
            grpYouTubeOptions.Text = "YouTube Channel Options";
            // 
            // ckYouTubeShorts
            // 
            ckYouTubeShorts.AutoSize = true;
            ckYouTubeShorts.Location = new Point(25, 104);
            ckYouTubeShorts.Name = "ckYouTubeShorts";
            ckYouTubeShorts.Size = new Size(273, 29);
            ckYouTubeShorts.TabIndex = 3;
            ckYouTubeShorts.Text = "Scrape YouTube Short videos.";
            ckYouTubeShorts.UseVisualStyleBackColor = true;
            // 
            // rbNoYouTubeChannel
            // 
            rbNoYouTubeChannel.AutoSize = true;
            rbNoYouTubeChannel.Location = new Point(25, 69);
            rbNoYouTubeChannel.Name = "rbNoYouTubeChannel";
            rbNoYouTubeChannel.Size = new Size(584, 29);
            rbNoYouTubeChannel.TabIndex = 2;
            rbNoYouTubeChannel.TabStop = true;
            rbNoYouTubeChannel.Text = "Scrape leads that do no have a YouTube Channel Url on their website.";
            rbNoYouTubeChannel.UseVisualStyleBackColor = true;
            // 
            // rbYouTubeChannel
            // 
            rbYouTubeChannel.AutoSize = true;
            rbYouTubeChannel.Location = new Point(25, 35);
            rbYouTubeChannel.Name = "rbYouTubeChannel";
            rbYouTubeChannel.Size = new Size(531, 29);
            rbYouTubeChannel.TabIndex = 1;
            rbYouTubeChannel.TabStop = true;
            rbYouTubeChannel.Text = "Scrape leads that have a YouTube Channel Url on their website.";
            rbYouTubeChannel.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveChanges.Location = new Point(873, 780);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(191, 72);
            btnSaveChanges.TabIndex = 6;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.Location = new Point(12, 780);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(319, 72);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset To Default Settings";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1076, 864);
            Controls.Add(btnReset);
            Controls.Add(btnSaveChanges);
            Controls.Add(grpYouTubeOptions);
            Controls.Add(grpFacebookPOptions);
            Controls.Add(grpScrapeOptions);
            Controls.Add(grpSearchOptions);
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            grpSearchOptions.ResumeLayout(false);
            grpSearchOptions.PerformLayout();
            grpScrapeOptions.ResumeLayout(false);
            grpScrapeOptions.PerformLayout();
            grpFacebookPOptions.ResumeLayout(false);
            grpFacebookPOptions.PerformLayout();
            grpYouTubeOptions.ResumeLayout(false);
            grpYouTubeOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSearchOptions;
        private RadioButton rbSearchOnline;
        private RadioButton rbSearchOffline;
        private Button button1;
        private GroupBox grpScrapeOptions;
        private RadioButton rbFacebookPixelInstalled;
        private RadioButton rbFacebookPixelNotInstalled;
        private GroupBox grpFacebookPOptions;
        private GroupBox grpYouTubeOptions;
        private RadioButton rbNoYouTubeChannel;
        private RadioButton rbYouTubeChannel;
        private Button btnSaveChanges;
        private ComboBox cboNameAPIKeys;
        private CheckBox ckEnableNameApi;
        private Button btnRemoveNameApiKey;
        private Button btnAddNameApiKey;
        private LinkLabel linkLabel1;
        private Label lblNameApiKeys;
        private CheckBox ckGetHumanNames;
        private CheckBox ckValidateEmails;
        private CheckBox ckMutilpeNameAPI;
        private Button btnReset;
        private CheckBox ckYouTubeShorts;
    }
}