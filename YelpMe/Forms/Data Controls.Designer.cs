namespace YelpMe.Forms
{
    partial class Data_Controls
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
            dgvBusiness = new DataGridView();
            btnExportCSV = new Button();
            btnImportCSV = new Button();
            btnDeleteById = new Button();
            btnUpdate = new Button();
            btnDeleteAll = new Button();
            grpFilters = new GroupBox();
            btnCleanEmails = new Button();
            lblResults = new Label();
            btnReset = new Button();
            ckLinkedin = new CheckBox();
            ckYouTube = new CheckBox();
            ckInstagram = new CheckBox();
            ckFacebook = new CheckBox();
            cboCleanUpProgram = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvBusiness).BeginInit();
            grpFilters.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBusiness
            // 
            dgvBusiness.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBusiness.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBusiness.Location = new Point(282, 12);
            dgvBusiness.Name = "dgvBusiness";
            dgvBusiness.RowHeadersWidth = 62;
            dgvBusiness.RowTemplate.Height = 33;
            dgvBusiness.Size = new Size(1053, 442);
            dgvBusiness.TabIndex = 0;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportCSV.Location = new Point(1173, 460);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(162, 55);
            btnExportCSV.TabIndex = 1;
            btnExportCSV.Text = "Export To CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnImportCSV
            // 
            btnImportCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImportCSV.Location = new Point(986, 460);
            btnImportCSV.Name = "btnImportCSV";
            btnImportCSV.Size = new Size(181, 55);
            btnImportCSV.TabIndex = 2;
            btnImportCSV.Text = "Import From CSV";
            btnImportCSV.UseVisualStyleBackColor = true;
            btnImportCSV.Click += btnImportCSV_Click;
            // 
            // btnDeleteById
            // 
            btnDeleteById.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteById.Location = new Point(12, 460);
            btnDeleteById.Name = "btnDeleteById";
            btnDeleteById.Size = new Size(160, 55);
            btnDeleteById.TabIndex = 3;
            btnDeleteById.Text = "Delete By Id";
            btnDeleteById.UseVisualStyleBackColor = true;
            btnDeleteById.Click += btnDeleteById_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.Location = new Point(346, 460);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(160, 55);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteAll.Location = new Point(178, 460);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(160, 55);
            btnDeleteAll.TabIndex = 5;
            btnDeleteAll.Text = "Delete All";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // grpFilters
            // 
            grpFilters.Controls.Add(cboCleanUpProgram);
            grpFilters.Controls.Add(btnCleanEmails);
            grpFilters.Controls.Add(lblResults);
            grpFilters.Controls.Add(btnReset);
            grpFilters.Controls.Add(ckLinkedin);
            grpFilters.Controls.Add(ckYouTube);
            grpFilters.Controls.Add(ckInstagram);
            grpFilters.Controls.Add(ckFacebook);
            grpFilters.Location = new Point(12, 12);
            grpFilters.Name = "grpFilters";
            grpFilters.Size = new Size(264, 442);
            grpFilters.TabIndex = 6;
            grpFilters.TabStop = false;
            grpFilters.Text = "Filters";
            // 
            // btnCleanEmails
            // 
            btnCleanEmails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCleanEmails.Location = new Point(19, 383);
            btnCleanEmails.Name = "btnCleanEmails";
            btnCleanEmails.Size = new Size(227, 44);
            btnCleanEmails.TabIndex = 7;
            btnCleanEmails.Text = "Clean-Up Emails";
            btnCleanEmails.UseVisualStyleBackColor = true;
            btnCleanEmails.Click += btnCleanEmails_Click;
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new Point(19, 257);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(71, 25);
            lblResults.TabIndex = 5;
            lblResults.Text = "Results:";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(19, 201);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // ckLinkedin
            // 
            ckLinkedin.AutoSize = true;
            ckLinkedin.Location = new Point(19, 148);
            ckLinkedin.Name = "ckLinkedin";
            ckLinkedin.Size = new Size(103, 29);
            ckLinkedin.TabIndex = 3;
            ckLinkedin.Text = "Linkedin";
            ckLinkedin.UseVisualStyleBackColor = true;
            ckLinkedin.CheckedChanged += ckLinkedin_CheckedChanged;
            // 
            // ckYouTube
            // 
            ckYouTube.AutoSize = true;
            ckYouTube.Location = new Point(19, 113);
            ckYouTube.Name = "ckYouTube";
            ckYouTube.Size = new Size(106, 29);
            ckYouTube.TabIndex = 2;
            ckYouTube.Text = "YouTube";
            ckYouTube.UseVisualStyleBackColor = true;
            ckYouTube.CheckedChanged += ckYouTube_CheckedChanged;
            // 
            // ckInstagram
            // 
            ckInstagram.AutoSize = true;
            ckInstagram.Location = new Point(19, 78);
            ckInstagram.Name = "ckInstagram";
            ckInstagram.Size = new Size(118, 29);
            ckInstagram.TabIndex = 1;
            ckInstagram.Text = "Instagram";
            ckInstagram.UseVisualStyleBackColor = true;
            ckInstagram.CheckedChanged += ckInstagram_CheckedChanged;
            // 
            // ckFacebook
            // 
            ckFacebook.AutoSize = true;
            ckFacebook.Location = new Point(19, 43);
            ckFacebook.Name = "ckFacebook";
            ckFacebook.Size = new Size(114, 29);
            ckFacebook.TabIndex = 0;
            ckFacebook.Text = "Facebook";
            ckFacebook.UseVisualStyleBackColor = true;
            ckFacebook.CheckedChanged += ckFacebook_CheckedChanged;
            // 
            // cboCleanUpProgram
            // 
            cboCleanUpProgram.FormattingEnabled = true;
            cboCleanUpProgram.Location = new Point(19, 344);
            cboCleanUpProgram.Name = "cboCleanUpProgram";
            cboCleanUpProgram.Size = new Size(227, 33);
            cboCleanUpProgram.TabIndex = 8;
            // 
            // Data_Controls
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1347, 527);
            Controls.Add(grpFilters);
            Controls.Add(btnDeleteAll);
            Controls.Add(btnUpdate);
            Controls.Add(btnDeleteById);
            Controls.Add(btnImportCSV);
            Controls.Add(btnExportCSV);
            Controls.Add(dgvBusiness);
            Name = "Data_Controls";
            Text = "Data_Controls";
            Load += Data_Controls_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBusiness).EndInit();
            grpFilters.ResumeLayout(false);
            grpFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBusiness;
        private Button btnExportCSV;
        private Button btnImportCSV;
        private Button btnDeleteById;
        private Button btnUpdate;
        private Button btnDeleteAll;
        private GroupBox grpFilters;
        private CheckBox ckLinkedin;
        private CheckBox ckYouTube;
        private CheckBox ckInstagram;
        private CheckBox ckFacebook;
        private Button btnReset;
        private Label lblResults;
        private Button btnCleanEmails;
        private ComboBox cboCleanUpProgram;
    }
}