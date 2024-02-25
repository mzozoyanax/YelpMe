namespace ScrapeHero.Forms.Settings.Cloud_Servers
{
    partial class Cloud_Server_Manager
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
            lblPath = new Label();
            txtPath = new TextBox();
            dgvCloud = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCloud).BeginInit();
            SuspendLayout();
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(9, 18);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(83, 25);
            lblPath.TabIndex = 11;
            lblPath.Text = "Url (Path)";
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Location = new Point(120, 15);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(881, 31);
            txtPath.TabIndex = 10;
            // 
            // dgvCloud
            // 
            dgvCloud.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCloud.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCloud.Location = new Point(9, 55);
            dgvCloud.Name = "dgvCloud";
            dgvCloud.RowHeadersWidth = 62;
            dgvCloud.RowTemplate.Height = 33;
            dgvCloud.Size = new Size(1213, 326);
            dgvCloud.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(168, 387);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 51);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete Servers";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.Location = new Point(8, 387);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(154, 51);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update Servers";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(1023, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(199, 37);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add New Server";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Cloud_Server_Manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 450);
            Controls.Add(lblPath);
            Controls.Add(txtPath);
            Controls.Add(dgvCloud);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "Cloud_Server_Manager";
            Text = "Cloud_Server_Manager";
            Load += Cloud_Server_Manager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCloud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPath;
        private TextBox txtPath;
        private DataGridView dgvCloud;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}