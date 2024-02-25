namespace ScrapeHero.Forms.Intergations
{
    partial class WhatsApp_API
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
            txtInstanceId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtInstanceToken = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtInstanceId
            // 
            txtInstanceId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInstanceId.Location = new Point(225, 47);
            txtInstanceId.Name = "txtInstanceId";
            txtInstanceId.Size = new Size(563, 31);
            txtInstanceId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 1;
            label1.Text = "Instance Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 3;
            label2.Text = "Instance Token";
            // 
            // txtInstanceToken
            // 
            txtInstanceToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInstanceToken.Location = new Point(225, 95);
            txtInstanceToken.Name = "txtInstanceToken";
            txtInstanceToken.Size = new Size(563, 31);
            txtInstanceToken.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(636, 163);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 59);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Instance";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(12, 163);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(152, 59);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Instance";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // WhatsApp_API
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 234);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(txtInstanceToken);
            Controls.Add(label1);
            Controls.Add(txtInstanceId);
            Name = "WhatsApp_API";
            Text = "WhatsApp_API";
            Load += WhatsApp_API_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInstanceId;
        private Label label1;
        private Label label2;
        private TextBox txtInstanceToken;
        private Button btnAdd;
        private Button btnDelete;
    }
}