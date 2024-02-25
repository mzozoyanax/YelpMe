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
    public partial class Templates : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        public Templates()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Templates templates = new Models.Templates();

                templates.Name = txtName.Text;
                templates.Subject = txtSubject.Text;
                templates.Body = rtxtBody.Text;
                templates.HtmlMode = ckHtmlMode.Checked;

                appDbContext.Templates.Add(templates);
                appDbContext.SaveChanges();

                MessageBox.Show("Message added as a template...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Templates_Load(object sender, EventArgs e)
        {
            var templates = appDbContext.Templates.ToList();

            foreach (var temp in templates)
            {
                cboTemplates.Items.Add(temp.Name);
            }
        }

        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            var templates = appDbContext.Templates.Where(x => x.Name == cboTemplates.Text).FirstOrDefault();

            txtName.Text = templates.Name;
            txtSubject.Text = templates.Subject;
            rtxtBody.Text = templates.Body;
            ckHtmlMode.Checked = templates.HtmlMode;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            appDbContext.Database.ExecuteSqlRaw("truncate table templates");

            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var templates = appDbContext.Templates.Where(x => x.Name == cboTemplates.Text).FirstOrDefault();

            templates.Name = txtName.Text;
            templates.Subject = txtSubject.Text;
            templates.Body = rtxtBody.Text;
            templates.HtmlMode = ckHtmlMode.Checked;

            appDbContext.SaveChanges();

            MessageBox.Show("Temaplates updated successfully...");
        }
    }
}
