using CsvHelper;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using ScrapeHero.Api;
using ScrapeHero.Constants;
using ScrapeHero.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YelpMe.Models;
using YelpMe.Repositories;
using YelpMe.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace YelpMe.Forms
{
    public partial class Data_Controls : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        private AppConstant appConstant = new AppConstant();
        private List<Business> businessesOnline = new List<Business>();
        private EmailBounceCheckerRepo emailBounceCheckerRepo = new EmailBounceCheckerRepo();

        public Data_Controls()
        {
            InitializeComponent();
        }

        private async void Data_Controls_Load(object sender, EventArgs e)
        {
            businessesOnline = appDbContext.Business.ToList();
            dgvBusiness.DataSource = businessesOnline;

            var emailCleanUpPrograms = appConstant.EmailCleaningPrograms();

            cboCleanUpProgram.Items.Add("-- Select Program --");
            cboCleanUpProgram.SelectedIndex = 0;

            foreach (var p in emailCleanUpPrograms)
            {
                cboCleanUpProgram.Items.Add(p);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog box
            DialogResult result = MessageBox.Show("Are you sure you want to delete all records from the 'business' table?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes," so proceed with truncating the table
                try
                {
                    appDbContext.Database.ExecuteSqlRaw("truncate table business");
                    MessageBox.Show("Business data deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // User clicked "No" or closed the dialog, so do nothing
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dgvBusiness.DataSource = appDbContext.Business.ToList();

                appDbContext.SaveChanges();

                MessageBox.Show("Business data has been updated successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            var query = businessesOnline;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(query);
                    }
                }
            }
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Set the initial directory for the dialog
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    using (var reader = new StreamReader(selectedFilePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<Models.Business>();
                        // Process the records as needed

                        foreach (var item in records)
                        {
                            Business business = new Business();

                            business.Name = item.Name;
                            business.Email = item.Email;
                            business.Phone = item.Phone;
                            business.Profile = item.Profile;
                            business.Website = item.Website;
                            business.FacebookPage = item.FacebookPage;
                            business.YouTubeChannel = item.YouTubeChannel;
                            business.Company = item.Company;
                            business.Location = item.Location;
                            business.Keywords = item.Keywords;
                            business.PersonalLine = item.PersonalLine;
                            business.Sent = item.Sent;
                            business.AddedDate = item.AddedDate;

                            appDbContext.Business.Add(business);
                            appDbContext.SaveChanges();
                        }

                        dgvBusiness.DataSource = appDbContext.Business.ToList();
                    }
                }
            }
        }

        private void btnDeleteById_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any cell is selected in the DataGridView
                if (dgvBusiness.SelectedCells.Count > 0)
                {
                    int columnIndex = dgvBusiness.SelectedCells[0].ColumnIndex;
                    List<object> columnValues = new List<object>();

                    // Loop through the selected cells in the specific column
                    foreach (DataGridViewCell cell in dgvBusiness.SelectedCells)
                    {
                        if (cell.ColumnIndex == columnIndex)
                        {
                            columnValues.Add(cell.Value);
                        }
                    }

                    // Do something with the selected column values
                    int Id = Convert.ToInt32(string.Join(", ", columnValues));

                    DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete row (" + Id + ") from your data controls?", "Delete Email Address", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var query = appDbContext.Business.Where(x => x.Id == Id).FirstOrDefault();

                        appDbContext.Business.Remove(query);
                        appDbContext.SaveChanges();

                        MessageBox.Show("Email deleted successfully...");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    MessageBox.Show("No cell is currently selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckFacebook_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFacebook.Checked)
            {
                businessesOnline = appDbContext.Business.Where(x => x.FacebookPage != "").ToList();

                dgvBusiness.DataSource = businessesOnline;

                lblResults.Text = "Results: " + businessesOnline.Count;
            }
        }

        private void ckInstagram_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInstagram.Checked)
            {
                businessesOnline = appDbContext.Business.Where(x => x.Instagram != "").ToList();

                dgvBusiness.DataSource = businessesOnline;

                lblResults.Text = "Results: " + businessesOnline.Count;
            }
        }

        private void ckYouTube_CheckedChanged(object sender, EventArgs e)
        {
            if (ckYouTube.Checked)
            {
                businessesOnline = appDbContext.Business.Where(x => x.YouTubeChannel != "").ToList();

                dgvBusiness.DataSource = businessesOnline;

                lblResults.Text = "Results: " + businessesOnline.Count;
            }
        }

        private void ckLinkedin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLinkedin.Checked)
            {
                businessesOnline = appDbContext.Business.Where(x => x.LinkedIn != "").ToList();

                dgvBusiness.DataSource = businessesOnline;

                lblResults.Text = "Results: " + businessesOnline.Count;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvBusiness.DataSource = appDbContext.Business.ToList();

            lblResults.Text = "Results: " + appDbContext.Business.ToList().Count;
        }

        private void btnCleanEmails_Click(object sender, EventArgs e)
        {
            try 
            {
                MessageBox.Show("Procedure is now in progress, please wait for it to complete...");

                bool result = false;

                switch(cboCleanUpProgram.SelectedIndex)
                {
                    case 1:
                        result = emailBounceCheckerRepo.UseSite24();
                        break;

                    case 2:
                        result = emailBounceCheckerRepo.UseZeroBounce();
                        break;

                    case 3:
                        result = emailBounceCheckerRepo.UseVerifDotEmail();
                        break;

                    case 4:
                        result = emailBounceCheckerRepo.UseSendBridge();
                        break;
                }

                if (result == true)
                {
                    MessageBox.Show("Email clean up is now complete!");
                }
                else
                {
                    MessageBox.Show("An error occurred in the process of cleaning up your emails. "
                        + "Please try using another program or try again later.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
