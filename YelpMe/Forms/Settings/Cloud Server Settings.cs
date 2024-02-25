using Microsoft.EntityFrameworkCore;
using ScrapeHero.Models;
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

namespace ScrapeHero.Forms.Settings.Cloud_Servers
{
    public partial class Cloud_Server_Manager : Form
    {
        private AppDbContext appDbContext = new AppDbContext();

        public Cloud_Server_Manager()
        {
            InitializeComponent();
        }

        private void Cloud_Server_Manager_Load(object sender, EventArgs e)
        {
            try{
                dgvCloud.DataSource = appDbContext.Clouds.ToList();
            }
            catch
            {
                dgvCloud.DataSource = null; 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cloud cloud = new Cloud();

                cloud.Url = txtPath.Text;

                appDbContext.Clouds.Add(cloud);
                appDbContext.SaveChanges();

                MessageBox.Show("New server added successfully...");
                dgvCloud.DataSource = appDbContext.Clouds.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                appDbContext.Database.ExecuteSqlRaw("truncate table Clouds");

                Application.Restart();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCloud.DataSource = appDbContext.Clouds.ToList();
                appDbContext.SaveChanges();

                MessageBox.Show("Server updated successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
