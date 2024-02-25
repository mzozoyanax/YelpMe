namespace YelpMe.Forms
{
    partial class BlockedEmailAddresses
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
            btnAdd = new Button();
            dgvBlocker = new DataGridView();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBlocker).BeginInit();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 18);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(76, 18);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(739, 31);
            txtEmail.TabIndex = 1;
            txtEmail.TextChanged += textBox1_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(821, 18);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvBlocker
            // 
            dgvBlocker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBlocker.BackgroundColor = Color.White;
            dgvBlocker.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBlocker.Location = new Point(12, 69);
            dgvBlocker.Name = "dgvBlocker";
            dgvBlocker.RowHeadersWidth = 62;
            dgvBlocker.RowTemplate.Height = 33;
            dgvBlocker.Size = new Size(921, 356);
            dgvBlocker.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.Location = new Point(776, 438);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(157, 54);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete All";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // BlockedEmailAddresses
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(945, 504);
            Controls.Add(btnDelete);
            Controls.Add(dgvBlocker);
            Controls.Add(btnAdd);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Name = "BlockedEmailAddresses";
            Text = "BlockedEmailAddresses";
            Load += BlockedEmailAddresses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBlocker).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnAdd;
        private DataGridView dgvBlocker;
        private Button btnDelete;
    }
}