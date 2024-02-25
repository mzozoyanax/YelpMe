using Microsoft.EntityFrameworkCore;
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

namespace YelpMe.Forms
{
    public partial class BlockedEmailAddresses : Form
    {
        private AppDbContext appDbContext = new AppDbContext();

        public BlockedEmailAddresses()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Blocker blocker = new Blocker();

                blocker.Email = txtEmail.Text;
                blocker.AddedDate = DateTime.Now;

                appDbContext.Blockers.Add(blocker);
                appDbContext.SaveChanges();

                MessageBox.Show("Email added to the blocked list...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvBlocker.DataSource = appDbContext.Blockers.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            appDbContext.Database.ExecuteSqlRaw("truncate table blocker");

            Application.Restart();
        }

        private void BlockedEmailAddresses_Load(object sender, EventArgs e)
        {
            dgvBlocker.DataSource = appDbContext.Blockers.ToList();
        }
    }
}
