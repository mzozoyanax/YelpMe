namespace YelpMe.Forms
{
    partial class Accounts_Manager
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
            dgvAccounts = new DataGridView();
            button1 = new Button();
            btnDelete = new Button();
            button2 = new Button();
            btnUpdate = new Button();
            btnImportCSV = new Button();
            btnExportCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // dgvAccounts
            // 
            dgvAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(12, 12);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 62;
            dgvAccounts.RowTemplate.Height = 33;
            dgvAccounts.Size = new Size(1544, 372);
            dgvAccounts.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 398);
            button1.Name = "button1";
            button1.Size = new Size(197, 60);
            button1.TabIndex = 1;
            button1.Text = "Add New Account";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(621, 398);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(197, 60);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete All Accounts";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(418, 398);
            button2.Name = "button2";
            button2.Size = new Size(197, 60);
            button2.TabIndex = 3;
            button2.Text = "Delete Account";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.Location = new Point(215, 398);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(197, 60);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update Accounts";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnImportCSV
            // 
            btnImportCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImportCSV.Location = new Point(1156, 398);
            btnImportCSV.Name = "btnImportCSV";
            btnImportCSV.Size = new Size(197, 60);
            btnImportCSV.TabIndex = 6;
            btnImportCSV.Text = "Import From CSV";
            btnImportCSV.UseVisualStyleBackColor = true;
            btnImportCSV.Click += btnImportCSV_Click;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportCSV.Location = new Point(1359, 398);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(197, 60);
            btnExportCSV.TabIndex = 5;
            btnExportCSV.Text = "Export To CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // Accounts_Manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1568, 470);
            Controls.Add(btnImportCSV);
            Controls.Add(btnExportCSV);
            Controls.Add(btnUpdate);
            Controls.Add(button2);
            Controls.Add(btnDelete);
            Controls.Add(button1);
            Controls.Add(dgvAccounts);
            Name = "Accounts_Manager";
            Text = "Accounts Manager";
            Load += Accounts_Manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAccounts;
        private Button button1;
        private Button btnDelete;
        private Button button2;
        private Button btnUpdate;
        private Button btnImportCSV;
        private Button btnExportCSV;
    }
}