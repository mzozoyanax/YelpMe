namespace YelpMe
{
    partial class YelpMe
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBatchSearch = new Button();
            btnSearch = new Button();
            txtKeywords = new TextBox();
            lblKeywords = new Label();
            btnClearResults = new Button();
            lstResults = new ListBox();
            menuStrip1 = new MenuStrip();
            dataControlsToolStripMenuItem = new ToolStripMenuItem();
            dataControlsToolStripMenuItem1 = new ToolStripMenuItem();
            blockedEmailAddressesToolStripMenuItem = new ToolStripMenuItem();
            accountsToolStripMenuItem = new ToolStripMenuItem();
            addNewAccountToolStripMenuItem = new ToolStripMenuItem();
            viewAccountsToolStripMenuItem = new ToolStripMenuItem();
            templateToolStripMenuItem = new ToolStripMenuItem();
            intergationsToolStripMenuItem = new ToolStripMenuItem();
            whatsappAPIToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            generalSettingsToolStripMenuItem = new ToolStripMenuItem();
            cloudServerSettingsToolStripMenuItem = new ToolStripMenuItem();
            btnSendEmail = new Button();
            cboAccount = new ComboBox();
            grpRevision = new GroupBox();
            btnRefresh = new Button();
            txtSentContacts = new TextBox();
            lblSentContacts = new Label();
            txtUniqueContact = new TextBox();
            lblUniqueContacts = new Label();
            txtAllContacts = new TextBox();
            lblAllContact = new Label();
            ckTestMode = new CheckBox();
            ckSplitAccount = new CheckBox();
            ckABTesting = new CheckBox();
            cboABTest = new ComboBox();
            lblABTests = new Label();
            cboTemplates = new ComboBox();
            label4 = new Label();
            lblBody = new Label();
            rtxtBody = new RichTextBox();
            txtSubject = new TextBox();
            lblSubject = new Label();
            label1 = new Label();
            label2 = new Label();
            txtLocation = new TextBox();
            label3 = new Label();
            txtPages = new TextBox();
            ckFacebook = new CheckBox();
            btnDataControls = new Button();
            ckHtmlMode = new CheckBox();
            btnAddAB = new Button();
            btnRemoveAB = new Button();
            ckYouTubeChannel = new CheckBox();
            ckContactPage = new CheckBox();
            ckAccelerateMode = new CheckBox();
            ckPersonalEmails = new CheckBox();
            ckWhatsApp = new CheckBox();
            label5 = new Label();
            txtDelay = new TextBox();
            menuStrip1.SuspendLayout();
            grpRevision.SuspendLayout();
            SuspendLayout();
            // 
            // btnBatchSearch
            // 
            btnBatchSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBatchSearch.Location = new Point(1057, 125);
            btnBatchSearch.Name = "btnBatchSearch";
            btnBatchSearch.Size = new Size(172, 65);
            btnBatchSearch.TabIndex = 7;
            btnBatchSearch.Text = "Batch Search";
            btnBatchSearch.UseVisualStyleBackColor = true;
            btnBatchSearch.Click += btnBatchSearch_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(1057, 48);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(172, 68);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeywords
            // 
            txtKeywords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeywords.Location = new Point(144, 67);
            txtKeywords.Name = "txtKeywords";
            txtKeywords.Size = new Size(498, 31);
            txtKeywords.TabIndex = 3;
            // 
            // lblKeywords
            // 
            lblKeywords.AutoSize = true;
            lblKeywords.Location = new Point(31, 70);
            lblKeywords.Name = "lblKeywords";
            lblKeywords.Size = new Size(89, 25);
            lblKeywords.TabIndex = 2;
            lblKeywords.Text = "Keywords";
            // 
            // btnClearResults
            // 
            btnClearResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearResults.Location = new Point(1057, 210);
            btnClearResults.Name = "btnClearResults";
            btnClearResults.Size = new Size(172, 85);
            btnClearResults.TabIndex = 1;
            btnClearResults.Text = "Clear Result";
            btnClearResults.UseVisualStyleBackColor = true;
            btnClearResults.Click += btnClearResults_Click;
            // 
            // lstResults
            // 
            lstResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 25;
            lstResults.Location = new Point(20, 192);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(1020, 129);
            lstResults.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dataControlsToolStripMenuItem, accountsToolStripMenuItem, templateToolStripMenuItem, intergationsToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1246, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // dataControlsToolStripMenuItem
            // 
            dataControlsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataControlsToolStripMenuItem1, blockedEmailAddressesToolStripMenuItem });
            dataControlsToolStripMenuItem.Name = "dataControlsToolStripMenuItem";
            dataControlsToolStripMenuItem.Size = new Size(87, 29);
            dataControlsToolStripMenuItem.Text = "General";
            dataControlsToolStripMenuItem.Click += dataControlsToolStripMenuItem_Click;
            // 
            // dataControlsToolStripMenuItem1
            // 
            dataControlsToolStripMenuItem1.Name = "dataControlsToolStripMenuItem1";
            dataControlsToolStripMenuItem1.Size = new Size(310, 34);
            dataControlsToolStripMenuItem1.Text = "Data Controls";
            dataControlsToolStripMenuItem1.Click += dataControlsToolStripMenuItem1_Click;
            // 
            // blockedEmailAddressesToolStripMenuItem
            // 
            blockedEmailAddressesToolStripMenuItem.Name = "blockedEmailAddressesToolStripMenuItem";
            blockedEmailAddressesToolStripMenuItem.Size = new Size(310, 34);
            blockedEmailAddressesToolStripMenuItem.Text = "Blocked Email Addresses";
            blockedEmailAddressesToolStripMenuItem.Click += blockedEmailAddressesToolStripMenuItem_Click;
            // 
            // accountsToolStripMenuItem
            // 
            accountsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNewAccountToolStripMenuItem, viewAccountsToolStripMenuItem });
            accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            accountsToolStripMenuItem.Size = new Size(101, 29);
            accountsToolStripMenuItem.Text = "Accounts";
            // 
            // addNewAccountToolStripMenuItem
            // 
            addNewAccountToolStripMenuItem.Name = "addNewAccountToolStripMenuItem";
            addNewAccountToolStripMenuItem.Size = new Size(258, 34);
            addNewAccountToolStripMenuItem.Text = "Add New Account";
            addNewAccountToolStripMenuItem.Click += addNewAccountToolStripMenuItem_Click;
            // 
            // viewAccountsToolStripMenuItem
            // 
            viewAccountsToolStripMenuItem.Name = "viewAccountsToolStripMenuItem";
            viewAccountsToolStripMenuItem.Size = new Size(258, 34);
            viewAccountsToolStripMenuItem.Text = "View Accounts";
            viewAccountsToolStripMenuItem.Click += viewAccountsToolStripMenuItem_Click;
            // 
            // templateToolStripMenuItem
            // 
            templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            templateToolStripMenuItem.Size = new Size(107, 29);
            templateToolStripMenuItem.Text = "Templates";
            templateToolStripMenuItem.Click += templateToolStripMenuItem_Click;
            // 
            // intergationsToolStripMenuItem
            // 
            intergationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { whatsappAPIToolStripMenuItem });
            intergationsToolStripMenuItem.Name = "intergationsToolStripMenuItem";
            intergationsToolStripMenuItem.Size = new Size(123, 29);
            intergationsToolStripMenuItem.Text = "Intergations";
            // 
            // whatsappAPIToolStripMenuItem
            // 
            whatsappAPIToolStripMenuItem.Name = "whatsappAPIToolStripMenuItem";
            whatsappAPIToolStripMenuItem.Size = new Size(235, 34);
            whatsappAPIToolStripMenuItem.Text = "WhatsApp API ";
            whatsappAPIToolStripMenuItem.Click += whatsappAPIToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generalSettingsToolStripMenuItem, cloudServerSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(92, 29);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // generalSettingsToolStripMenuItem
            // 
            generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
            generalSettingsToolStripMenuItem.Size = new Size(284, 34);
            generalSettingsToolStripMenuItem.Text = "General Settings";
            generalSettingsToolStripMenuItem.Click += generalSettingsToolStripMenuItem_Click;
            // 
            // cloudServerSettingsToolStripMenuItem
            // 
            cloudServerSettingsToolStripMenuItem.Name = "cloudServerSettingsToolStripMenuItem";
            cloudServerSettingsToolStripMenuItem.Size = new Size(284, 34);
            cloudServerSettingsToolStripMenuItem.Text = "Cloud Server Settings";
            cloudServerSettingsToolStripMenuItem.Click += cloudServerSettingsToolStripMenuItem_Click;
            // 
            // btnSendEmail
            // 
            btnSendEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendEmail.Location = new Point(1057, 919);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(177, 61);
            btnSendEmail.TabIndex = 4;
            btnSendEmail.Text = "Send Email";
            btnSendEmail.UseVisualStyleBackColor = true;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // cboAccount
            // 
            cboAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboAccount.FormattingEnabled = true;
            cboAccount.Location = new Point(391, 353);
            cboAccount.Name = "cboAccount";
            cboAccount.Size = new Size(845, 33);
            cboAccount.TabIndex = 0;
            // 
            // grpRevision
            // 
            grpRevision.Controls.Add(btnRefresh);
            grpRevision.Controls.Add(txtSentContacts);
            grpRevision.Controls.Add(lblSentContacts);
            grpRevision.Controls.Add(txtUniqueContact);
            grpRevision.Controls.Add(lblUniqueContacts);
            grpRevision.Controls.Add(txtAllContacts);
            grpRevision.Controls.Add(lblAllContact);
            grpRevision.Location = new Point(20, 327);
            grpRevision.Name = "grpRevision";
            grpRevision.Size = new Size(342, 279);
            grpRevision.TabIndex = 6;
            grpRevision.TabStop = false;
            grpRevision.Text = "Revision";
            grpRevision.Enter += grpRevision_Enter;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(25, 222);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 38;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSentContacts
            // 
            txtSentContacts.Enabled = false;
            txtSentContacts.Location = new Point(25, 185);
            txtSentContacts.Name = "txtSentContacts";
            txtSentContacts.Size = new Size(291, 31);
            txtSentContacts.TabIndex = 5;
            txtSentContacts.TextChanged += txtSentContacts_TextChanged;
            // 
            // lblSentContacts
            // 
            lblSentContacts.AutoSize = true;
            lblSentContacts.Location = new Point(25, 157);
            lblSentContacts.Name = "lblSentContacts";
            lblSentContacts.Size = new Size(121, 25);
            lblSentContacts.TabIndex = 4;
            lblSentContacts.Text = "Sent Contacts";
            // 
            // txtUniqueContact
            // 
            txtUniqueContact.Enabled = false;
            txtUniqueContact.Location = new Point(25, 117);
            txtUniqueContact.Name = "txtUniqueContact";
            txtUniqueContact.Size = new Size(291, 31);
            txtUniqueContact.TabIndex = 3;
            // 
            // lblUniqueContacts
            // 
            lblUniqueContacts.AutoSize = true;
            lblUniqueContacts.Location = new Point(24, 89);
            lblUniqueContacts.Name = "lblUniqueContacts";
            lblUniqueContacts.Size = new Size(142, 25);
            lblUniqueContacts.TabIndex = 2;
            lblUniqueContacts.Text = "Unique Contacts";
            // 
            // txtAllContacts
            // 
            txtAllContacts.Enabled = false;
            txtAllContacts.Location = new Point(25, 55);
            txtAllContacts.Name = "txtAllContacts";
            txtAllContacts.Size = new Size(291, 31);
            txtAllContacts.TabIndex = 1;
            // 
            // lblAllContact
            // 
            lblAllContact.AutoSize = true;
            lblAllContact.Location = new Point(24, 27);
            lblAllContact.Name = "lblAllContact";
            lblAllContact.Size = new Size(106, 25);
            lblAllContact.TabIndex = 0;
            lblAllContact.Text = "All Contacts";
            // 
            // ckTestMode
            // 
            ckTestMode.AutoSize = true;
            ckTestMode.Location = new Point(201, 788);
            ckTestMode.Name = "ckTestMode";
            ckTestMode.Size = new Size(120, 29);
            ckTestMode.TabIndex = 21;
            ckTestMode.Text = "Test Mode";
            ckTestMode.UseVisualStyleBackColor = true;
            // 
            // ckSplitAccount
            // 
            ckSplitAccount.AutoSize = true;
            ckSplitAccount.Location = new Point(20, 823);
            ckSplitAccount.Name = "ckSplitAccount";
            ckSplitAccount.Size = new Size(144, 29);
            ckSplitAccount.TabIndex = 20;
            ckSplitAccount.Text = "Rotate Emails";
            ckSplitAccount.UseVisualStyleBackColor = true;
            // 
            // ckABTesting
            // 
            ckABTesting.AutoSize = true;
            ckABTesting.Location = new Point(20, 788);
            ckABTesting.Name = "ckABTesting";
            ckABTesting.Size = new Size(127, 29);
            ckABTesting.TabIndex = 19;
            ckABTesting.Text = "A/B Testing";
            ckABTesting.UseVisualStyleBackColor = true;
            // 
            // cboABTest
            // 
            cboABTest.FormattingEnabled = true;
            cboABTest.Location = new Point(20, 701);
            cboABTest.Name = "cboABTest";
            cboABTest.Size = new Size(342, 33);
            cboABTest.TabIndex = 18;
            cboABTest.SelectedIndexChanged += cboABTest_SelectedIndexChanged;
            // 
            // lblABTests
            // 
            lblABTests.AutoSize = true;
            lblABTests.Location = new Point(20, 673);
            lblABTests.Name = "lblABTests";
            lblABTests.Size = new Size(84, 25);
            lblABTests.TabIndex = 17;
            lblABTests.Text = "A/B Tests";
            // 
            // cboTemplates
            // 
            cboTemplates.FormattingEnabled = true;
            cboTemplates.Location = new Point(20, 637);
            cboTemplates.Name = "cboTemplates";
            cboTemplates.Size = new Size(342, 33);
            cboTemplates.TabIndex = 16;
            cboTemplates.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 609);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 15;
            label4.Text = "Templates";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(391, 458);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(53, 25);
            lblBody.TabIndex = 14;
            lblBody.Text = "Body";
            // 
            // rtxtBody
            // 
            rtxtBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtxtBody.Location = new Point(391, 486);
            rtxtBody.Name = "rtxtBody";
            rtxtBody.Size = new Size(845, 385);
            rtxtBody.TabIndex = 13;
            rtxtBody.Text = "";
            // 
            // txtSubject
            // 
            txtSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubject.Location = new Point(391, 415);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(845, 31);
            txtSubject.TabIndex = 12;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(391, 387);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 11;
            lblSubject.Text = "Subject";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 325);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 22;
            label1.Text = "Account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 107);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 23;
            label2.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLocation.Location = new Point(144, 104);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(498, 31);
            txtLocation.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 144);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 25;
            label3.Text = "Page";
            // 
            // txtPages
            // 
            txtPages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPages.Location = new Point(144, 141);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(498, 31);
            txtPages.TabIndex = 26;
            // 
            // ckFacebook
            // 
            ckFacebook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckFacebook.AutoSize = true;
            ckFacebook.Location = new Point(667, 66);
            ckFacebook.Name = "ckFacebook";
            ckFacebook.Size = new Size(165, 29);
            ckFacebook.TabIndex = 28;
            ckFacebook.Text = "Facebook Pages\r\n";
            ckFacebook.UseVisualStyleBackColor = true;
            // 
            // btnDataControls
            // 
            btnDataControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDataControls.Location = new Point(20, 919);
            btnDataControls.Name = "btnDataControls";
            btnDataControls.Size = new Size(176, 61);
            btnDataControls.TabIndex = 31;
            btnDataControls.Text = "Data Controls";
            btnDataControls.UseVisualStyleBackColor = true;
            btnDataControls.Click += btnDataControls_Click;
            // 
            // ckHtmlMode
            // 
            ckHtmlMode.AutoSize = true;
            ckHtmlMode.Location = new Point(201, 823);
            ckHtmlMode.Name = "ckHtmlMode";
            ckHtmlMode.Size = new Size(129, 29);
            ckHtmlMode.TabIndex = 32;
            ckHtmlMode.Text = "Html Mode";
            ckHtmlMode.UseVisualStyleBackColor = true;
            // 
            // btnAddAB
            // 
            btnAddAB.Location = new Point(20, 740);
            btnAddAB.Name = "btnAddAB";
            btnAddAB.Size = new Size(112, 34);
            btnAddAB.TabIndex = 33;
            btnAddAB.Text = "Add";
            btnAddAB.UseVisualStyleBackColor = true;
            btnAddAB.Click += btnAddAB_Click;
            // 
            // btnRemoveAB
            // 
            btnRemoveAB.Location = new Point(144, 740);
            btnRemoveAB.Name = "btnRemoveAB";
            btnRemoveAB.Size = new Size(112, 34);
            btnRemoveAB.TabIndex = 34;
            btnRemoveAB.Text = "Remove";
            btnRemoveAB.UseVisualStyleBackColor = true;
            btnRemoveAB.Click += btnRemoveAB_Click;
            // 
            // ckYouTubeChannel
            // 
            ckYouTubeChannel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckYouTubeChannel.AutoSize = true;
            ckYouTubeChannel.Location = new Point(667, 99);
            ckYouTubeChannel.Name = "ckYouTubeChannel";
            ckYouTubeChannel.Size = new Size(182, 29);
            ckYouTubeChannel.TabIndex = 35;
            ckYouTubeChannel.Text = "YouTube Channels\r\n";
            ckYouTubeChannel.UseVisualStyleBackColor = true;
            // 
            // ckContactPage
            // 
            ckContactPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckContactPage.AutoSize = true;
            ckContactPage.Location = new Point(667, 134);
            ckContactPage.Name = "ckContactPage";
            ckContactPage.Size = new Size(184, 29);
            ckContactPage.TabIndex = 36;
            ckContactPage.Text = "Contact Page Only";
            ckContactPage.UseVisualStyleBackColor = true;
            // 
            // ckAccelerateMode
            // 
            ckAccelerateMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAccelerateMode.AutoSize = true;
            ckAccelerateMode.Location = new Point(868, 101);
            ckAccelerateMode.Name = "ckAccelerateMode";
            ckAccelerateMode.Size = new Size(170, 29);
            ckAccelerateMode.TabIndex = 37;
            ckAccelerateMode.Text = "Accelerate Mode";
            ckAccelerateMode.UseVisualStyleBackColor = true;
            // 
            // ckPersonalEmails
            // 
            ckPersonalEmails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckPersonalEmails.AutoSize = true;
            ckPersonalEmails.Location = new Point(868, 66);
            ckPersonalEmails.Name = "ckPersonalEmails";
            ckPersonalEmails.Size = new Size(159, 29);
            ckPersonalEmails.TabIndex = 38;
            ckPersonalEmails.Text = "Personal Emails";
            ckPersonalEmails.UseVisualStyleBackColor = true;
            // 
            // ckWhatsApp
            // 
            ckWhatsApp.AutoSize = true;
            ckWhatsApp.Location = new Point(20, 858);
            ckWhatsApp.Name = "ckWhatsApp";
            ckWhatsApp.Size = new Size(122, 29);
            ckWhatsApp.TabIndex = 39;
            ckWhatsApp.Text = "WhatsApp";
            ckWhatsApp.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 886);
            label5.Name = "label5";
            label5.Size = new Size(56, 25);
            label5.TabIndex = 40;
            label5.Text = "Delay";
            // 
            // txtDelay
            // 
            txtDelay.Location = new Point(472, 883);
            txtDelay.Name = "txtDelay";
            txtDelay.Size = new Size(409, 31);
            txtDelay.TabIndex = 41;
            // 
            // YelpMe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1246, 992);
            Controls.Add(txtDelay);
            Controls.Add(label5);
            Controls.Add(ckWhatsApp);
            Controls.Add(ckPersonalEmails);
            Controls.Add(ckAccelerateMode);
            Controls.Add(ckContactPage);
            Controls.Add(ckYouTubeChannel);
            Controls.Add(btnRemoveAB);
            Controls.Add(btnAddAB);
            Controls.Add(ckHtmlMode);
            Controls.Add(btnDataControls);
            Controls.Add(ckFacebook);
            Controls.Add(label3);
            Controls.Add(txtPages);
            Controls.Add(label2);
            Controls.Add(txtLocation);
            Controls.Add(label1);
            Controls.Add(cboAccount);
            Controls.Add(ckTestMode);
            Controls.Add(ckSplitAccount);
            Controls.Add(ckABTesting);
            Controls.Add(cboABTest);
            Controls.Add(lblABTests);
            Controls.Add(cboTemplates);
            Controls.Add(label4);
            Controls.Add(lblBody);
            Controls.Add(rtxtBody);
            Controls.Add(txtSubject);
            Controls.Add(lblSubject);
            Controls.Add(btnBatchSearch);
            Controls.Add(btnSearch);
            Controls.Add(grpRevision);
            Controls.Add(btnClearResults);
            Controls.Add(lstResults);
            Controls.Add(lblKeywords);
            Controls.Add(btnSendEmail);
            Controls.Add(txtKeywords);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "YelpMe";
            Text = "Scrape Hero";
            Load += YelpMe_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpRevision.ResumeLayout(false);
            grpRevision.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBatchSearch;
        private Button btnSearch;
        private TextBox txtKeywords;
        private Label lblKeywords;
        private Button btnClearResults;
        private ListBox lstResults;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dataControlsToolStripMenuItem;
        private ToolStripMenuItem accountsToolStripMenuItem;
        private ToolStripMenuItem dataControlsToolStripMenuItem1;
        private ToolStripMenuItem blockedEmailAddressesToolStripMenuItem;
        private ToolStripMenuItem addNewAccountToolStripMenuItem;
        private ToolStripMenuItem viewAccountsToolStripMenuItem;
        private ToolStripMenuItem templateToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button btnSendEmail;
        private ComboBox cboAccount;
        private GroupBox grpRevision;
        private TextBox txtUniqueContact;
        private Label lblUniqueContacts;
        private TextBox txtAllContacts;
        private Label lblAllContact;
        private TextBox txtSentContacts;
        private Label lblSentContacts;
        private CheckBox ckTestMode;
        private CheckBox ckSplitAccount;
        private CheckBox ckABTesting;
        private ComboBox cboABTest;
        private Label lblABTests;
        private ComboBox cboTemplates;
        private Label label4;
        private Label lblBody;
        private RichTextBox rtxtBody;
        private TextBox txtSubject;
        private Label lblSubject;
        private Label label1;
        private Label label2;
        private TextBox txtLocation;
        private Label label3;
        private TextBox txtPages;
        private CheckBox ckFacebook;
        private Button btnDataControls;
        private CheckBox ckHtmlMode;
        private Button btnAddAB;
        private Button btnRemoveAB;
        private CheckBox ckYouTubeChannel;
        private CheckBox ckContactPage;
        private CheckBox ckAccelerateMode;
        private ToolStripMenuItem generalSettingsToolStripMenuItem;
        private ToolStripMenuItem cloudServerSettingsToolStripMenuItem;
        private Button btnRefresh;
        private CheckBox ckPersonalEmails;
        private ToolStripMenuItem intergationsToolStripMenuItem;
        private ToolStripMenuItem whatsappAPIToolStripMenuItem;
        private CheckBox ckWhatsApp;
        private Label label5;
        private TextBox txtDelay;
    }
}