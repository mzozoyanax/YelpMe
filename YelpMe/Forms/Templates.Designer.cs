namespace YelpMe.Forms
{
    partial class Templates
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
            lblBody = new Label();
            rtxtBody = new RichTextBox();
            txtSubject = new TextBox();
            lblSubject = new Label();
            label1 = new Label();
            txtName = new TextBox();
            lblTemplate = new Label();
            btnAddTemplate = new Button();
            button3 = new Button();
            button4 = new Button();
            cboTemplates = new ComboBox();
            ckHtmlMode = new CheckBox();
            SuspendLayout();
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(12, 178);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(53, 25);
            lblBody.TabIndex = 18;
            lblBody.Text = "Body";
            // 
            // rtxtBody
            // 
            rtxtBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtxtBody.Location = new Point(12, 206);
            rtxtBody.Name = "rtxtBody";
            rtxtBody.Size = new Size(1070, 394);
            rtxtBody.TabIndex = 17;
            rtxtBody.Text = "";
            // 
            // txtSubject
            // 
            txtSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubject.Location = new Point(12, 118);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(1070, 31);
            txtSubject.TabIndex = 16;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(12, 90);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 15;
            lblSubject.Text = "Subject";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 19;
            label1.Text = "Name";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(12, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(1070, 31);
            txtName.TabIndex = 20;
            // 
            // lblTemplate
            // 
            lblTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTemplate.AutoSize = true;
            lblTemplate.Location = new Point(190, 628);
            lblTemplate.Name = "lblTemplate";
            lblTemplate.Size = new Size(163, 25);
            lblTemplate.TabIndex = 21;
            lblTemplate.Text = "Selected Template: ";
            // 
            // btnAddTemplate
            // 
            btnAddTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddTemplate.Location = new Point(877, 683);
            btnAddTemplate.Name = "btnAddTemplate";
            btnAddTemplate.Size = new Size(205, 66);
            btnAddTemplate.TabIndex = 24;
            btnAddTemplate.Text = "Add Template";
            btnAddTemplate.UseVisualStyleBackColor = true;
            btnAddTemplate.Click += btnAddTemplate_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(12, 683);
            button3.Name = "button3";
            button3.Size = new Size(198, 66);
            button3.TabIndex = 25;
            button3.Text = "Update Template";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(216, 683);
            button4.Name = "button4";
            button4.Size = new Size(198, 66);
            button4.TabIndex = 26;
            button4.Text = "Remove Template";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // cboTemplates
            // 
            cboTemplates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboTemplates.FormattingEnabled = true;
            cboTemplates.Location = new Point(369, 625);
            cboTemplates.Name = "cboTemplates";
            cboTemplates.Size = new Size(713, 33);
            cboTemplates.TabIndex = 27;
            cboTemplates.SelectedIndexChanged += cboTemplates_SelectedIndexChanged;
            // 
            // ckHtmlMode
            // 
            ckHtmlMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ckHtmlMode.AutoSize = true;
            ckHtmlMode.Location = new Point(21, 627);
            ckHtmlMode.Name = "ckHtmlMode";
            ckHtmlMode.Size = new Size(136, 29);
            ckHtmlMode.TabIndex = 28;
            ckHtmlMode.Text = "HTML Mode";
            ckHtmlMode.UseVisualStyleBackColor = true;
            // 
            // Templates
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1094, 761);
            Controls.Add(ckHtmlMode);
            Controls.Add(cboTemplates);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btnAddTemplate);
            Controls.Add(lblTemplate);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(lblBody);
            Controls.Add(rtxtBody);
            Controls.Add(txtSubject);
            Controls.Add(lblSubject);
            Name = "Templates";
            Text = "Templates";
            Load += Templates_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBody;
        private RichTextBox rtxtBody;
        private TextBox txtSubject;
        private Label lblSubject;
        private Label label1;
        private TextBox txtName;
        private Label lblTemplate;
        private Button btnAddTemplate;
        private Button button3;
        private Button button4;
        private ComboBox cboTemplates;
        private CheckBox ckHtmlMode;
    }
}