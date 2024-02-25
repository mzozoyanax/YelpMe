namespace YelpMe.Forms.Accounts
{
    partial class Add_New_Account
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
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtSmtpHost = new TextBox();
            lblSmtpHost = new Label();
            txtSmtpPort = new TextBox();
            lblSmtpPort = new Label();
            txtImapPort = new TextBox();
            lblImapPort = new Label();
            txtImapHost = new TextBox();
            lblImapHost = new Label();
            btnAdd = new Button();
            ckSmtpSSL = new CheckBox();
            ckImapSSL = new CheckBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            rtxtSignature = new RichTextBox();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(18, 67);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(188, 64);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(634, 31);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(188, 101);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(634, 31);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(18, 104);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // txtSmtpHost
            // 
            txtSmtpHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSmtpHost.Location = new Point(188, 138);
            txtSmtpHost.Name = "txtSmtpHost";
            txtSmtpHost.Size = new Size(634, 31);
            txtSmtpHost.TabIndex = 5;
            // 
            // lblSmtpHost
            // 
            lblSmtpHost.AutoSize = true;
            lblSmtpHost.Location = new Point(18, 141);
            lblSmtpHost.Name = "lblSmtpHost";
            lblSmtpHost.Size = new Size(100, 25);
            lblSmtpHost.TabIndex = 4;
            lblSmtpHost.Text = "SMTP Host";
            // 
            // txtSmtpPort
            // 
            txtSmtpPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSmtpPort.Location = new Point(188, 175);
            txtSmtpPort.Name = "txtSmtpPort";
            txtSmtpPort.Size = new Size(634, 31);
            txtSmtpPort.TabIndex = 7;
            // 
            // lblSmtpPort
            // 
            lblSmtpPort.AutoSize = true;
            lblSmtpPort.Location = new Point(18, 178);
            lblSmtpPort.Name = "lblSmtpPort";
            lblSmtpPort.Size = new Size(94, 25);
            lblSmtpPort.TabIndex = 6;
            lblSmtpPort.Text = "SMTP Port";
            // 
            // txtImapPort
            // 
            txtImapPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImapPort.Location = new Point(188, 249);
            txtImapPort.Name = "txtImapPort";
            txtImapPort.Size = new Size(634, 31);
            txtImapPort.TabIndex = 11;
            // 
            // lblImapPort
            // 
            lblImapPort.AutoSize = true;
            lblImapPort.Location = new Point(18, 252);
            lblImapPort.Name = "lblImapPort";
            lblImapPort.Size = new Size(92, 25);
            lblImapPort.TabIndex = 10;
            lblImapPort.Text = "IMAP Port";
            // 
            // txtImapHost
            // 
            txtImapHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImapHost.Location = new Point(188, 212);
            txtImapHost.Name = "txtImapHost";
            txtImapHost.Size = new Size(634, 31);
            txtImapHost.TabIndex = 9;
            // 
            // lblImapHost
            // 
            lblImapHost.AutoSize = true;
            lblImapHost.Location = new Point(18, 215);
            lblImapHost.Name = "lblImapHost";
            lblImapHost.Size = new Size(98, 25);
            lblImapHost.TabIndex = 8;
            lblImapHost.Text = "IMAP Host";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(674, 457);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(148, 56);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add Account";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ckSmtpSSL
            // 
            ckSmtpSSL.AutoSize = true;
            ckSmtpSSL.Location = new Point(188, 434);
            ckSmtpSSL.Name = "ckSmtpSSL";
            ckSmtpSSL.Size = new Size(116, 29);
            ckSmtpSSL.TabIndex = 13;
            ckSmtpSSL.Text = "SMTP SSL";
            ckSmtpSSL.UseVisualStyleBackColor = true;
            // 
            // ckImapSSL
            // 
            ckImapSSL.AutoSize = true;
            ckImapSSL.Location = new Point(310, 434);
            ckImapSSL.Name = "ckImapSSL";
            ckImapSSL.Size = new Size(114, 29);
            ckImapSSL.TabIndex = 14;
            ckImapSSL.Text = "IMAP SSL";
            ckImapSSL.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(188, 27);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(634, 31);
            txtUsername.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 15;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 297);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 17;
            label2.Text = "Signature (HTML)";
            // 
            // rtxtSignature
            // 
            rtxtSignature.Location = new Point(188, 294);
            rtxtSignature.Name = "rtxtSignature";
            rtxtSignature.Size = new Size(634, 125);
            rtxtSignature.TabIndex = 18;
            rtxtSignature.Text = "";
            // 
            // Add_New_Account
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(849, 525);
            Controls.Add(rtxtSignature);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(ckImapSSL);
            Controls.Add(ckSmtpSSL);
            Controls.Add(btnAdd);
            Controls.Add(txtImapPort);
            Controls.Add(lblImapPort);
            Controls.Add(txtImapHost);
            Controls.Add(lblImapHost);
            Controls.Add(txtSmtpPort);
            Controls.Add(lblSmtpPort);
            Controls.Add(txtSmtpHost);
            Controls.Add(lblSmtpHost);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Name = "Add_New_Account";
            Text = "Add_New_Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtSmtpHost;
        private Label lblSmtpHost;
        private TextBox txtSmtpPort;
        private Label lblSmtpPort;
        private TextBox txtImapPort;
        private Label lblImapPort;
        private TextBox txtImapHost;
        private Label lblImapHost;
        private Button btnAdd;
        private CheckBox ckSmtpSSL;
        private CheckBox ckImapSSL;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private RichTextBox rtxtSignature;
    }
}