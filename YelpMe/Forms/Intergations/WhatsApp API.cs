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

namespace ScrapeHero.Forms.Intergations
{
    public partial class WhatsApp_API : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        public WhatsApp_API()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var query = appDbContext.WhatsAppIntergations.FirstOrDefault();

                if (query == null)
                {
                    WhatsAppIntergation whatsAppIntergation = new WhatsAppIntergation();

                    whatsAppIntergation.InstanceId = txtInstanceId.Text;
                    whatsAppIntergation.ApiTokenInstance = txtInstanceToken.Text;

                    appDbContext.WhatsAppIntergations.Add(whatsAppIntergation);
                    appDbContext.SaveChanges();
                }
                else
                {
                    query.InstanceId = txtInstanceId.Text;
                    query.ApiTokenInstance = txtInstanceToken.Text;

                    appDbContext.SaveChanges();
                }

                MessageBox.Show("WhatsApp Instance successfully added...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WhatsApp_API_Load(object sender, EventArgs e)
        {
            try
            {
                var query = appDbContext.WhatsAppIntergations.FirstOrDefault();

                txtInstanceId.Text = query.InstanceId;
                txtInstanceToken.Text = query.ApiTokenInstance;
            }
            catch (Exception)
            {

            }
        }
    }
}
