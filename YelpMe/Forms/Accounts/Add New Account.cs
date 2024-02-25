using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YelpMe.Models;

namespace YelpMe.Forms.Accounts
{
    public partial class Add_New_Account : Form
    {
        private AppDbContext appDbContext = new AppDbContext();

        public Add_New_Account()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Accounts accounts = new Models.Accounts();

                accounts.UserName = txtUsername.Text;
                accounts.Email = txtEmail.Text;
                accounts.Password = txtPassword.Text;
                accounts.SmtpHost = txtSmtpHost.Text;
                accounts.SmtpPort = int.Parse(txtSmtpPort.Text);
                accounts.StmpSsl = ckSmtpSSL.Checked;
                accounts.ImapHost = txtImapHost.Text;
                accounts.ImapPort = int.Parse(txtImapPort.Text);
                accounts.ImapSsl = ckSmtpSSL.Checked;
                accounts.Signature = rtxtSignature.Text;

                appDbContext.Accounts.Add(accounts);
                appDbContext.SaveChanges();

                MessageBox.Show("Account entered successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
