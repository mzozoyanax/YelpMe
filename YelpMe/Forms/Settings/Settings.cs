using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScrapeHero.Api;
using ScrapeHero.Models;
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
using YelpMe.ViewModels;

namespace YelpMe.Forms
{
    public partial class Settings : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        private Models.Settings settings = new Models.Settings();
        private List<NameApiKeys> nameApiKeys = new List<NameApiKeys>();
        private NameApiSettings nameApiSettings = new NameApiSettings();
        private List<string> apiKeyList = new List<string>();


        public Settings()
        {
            InitializeComponent();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                bool noValues = (settings == null || nameApiKeys == null || nameApiSettings == null);

                if (noValues)
                {
                    Models.Settings s = new Models.Settings();

                    s.SearchOffline = rbSearchOffline.Checked;
                    s.UseNameApi = ckEnableNameApi.Checked;
                    s.FacebookPixelInstalled = rbFacebookPixelInstalled.Checked;
                    s.HasYouTubeChannel = rbYouTubeChannel.Checked;

                    appDbContext.Settings.Add(s);
                    appDbContext.SaveChanges();

                    foreach (var item in apiKeyList)
                    {
                        NameApiKeys nameApiKeys = new NameApiKeys();

                        nameApiKeys.ApiKey = item;

                        appDbContext.NameApiKeys.Add(nameApiKeys);
                        appDbContext.SaveChanges();
                    }

                    NameApiSettings nameApiSettings = new NameApiSettings();

                    nameApiSettings.SelectApiKeyId = appDbContext.NameApiKeys.Where(x => x.ApiKey == cboNameAPIKeys.Text).FirstOrDefault().Id;
                    nameApiSettings.UseMultipleKeys = ckMutilpeNameAPI.Checked;
                    nameApiSettings.ValidEmail = ckValidateEmails.Checked;
                    nameApiSettings.HumanNameEmails = ckGetHumanNames.Checked;

                    appDbContext.NameApiSettings.Add(nameApiSettings);
                    appDbContext.SaveChanges();
                }
                else
                {
                    var query = appDbContext.Settings.FirstOrDefault();

                    query.SearchOffline = rbSearchOffline.Checked;
                    query.UseNameApi = ckEnableNameApi.Checked;
                    query.FacebookPixelInstalled = rbFacebookPixelInstalled.Checked;
                    query.HasYouTubeChannel = rbYouTubeChannel.Checked;

                    appDbContext.SaveChanges();

                    foreach (var item in apiKeyList)
                    {
                        var nameApiKeys = appDbContext.NameApiKeys.Where(x => x.ApiKey == cboNameAPIKeys.Text).FirstOrDefault();

                        if (nameApiKeys == null)
                        {
                            NameApiKeys nameApiKeysNew = new NameApiKeys();

                            nameApiKeysNew.ApiKey = item;

                            appDbContext.NameApiKeys.Add(nameApiKeysNew);
                            appDbContext.SaveChanges();
                        }
                    }

                    NameApiSettings nameApiSettings = appDbContext.NameApiSettings.FirstOrDefault();

                    nameApiSettings.SelectApiKeyId = appDbContext.NameApiKeys.Where(x => x.ApiKey == cboNameAPIKeys.Text).FirstOrDefault().Id;
                    nameApiSettings.UseMultipleKeys = ckMutilpeNameAPI.Checked;
                    nameApiSettings.ValidEmail = ckValidateEmails.Checked;
                    nameApiSettings.HumanNameEmails = ckGetHumanNames.Checked;

                    appDbContext.SaveChanges();
                }

                MessageBox.Show("Settings updated successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var records = new List<SearchViewModels>
                {
                    new SearchViewModels {
                        Id = 1,
                        Keywords = "",
                        Location = "",
                        Page = 0
                    },
                };

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(records);
                    }
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                settings = appDbContext.Settings.FirstOrDefault();
                nameApiSettings = appDbContext.NameApiSettings.FirstOrDefault();
                nameApiKeys = appDbContext.NameApiKeys.ToList();

                foreach (var key in nameApiKeys)
                {
                    cboNameAPIKeys.Items.Add(key.ApiKey);
                }

                ckEnableNameApi.Checked = settings.UseNameApi;
                ckGetHumanNames.Checked = nameApiSettings.HumanNameEmails;
                ckValidateEmails.Checked = nameApiSettings.ValidEmail;
                ckMutilpeNameAPI.Checked = nameApiSettings.UseMultipleKeys;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNameApiKey_Click(object sender, EventArgs e)
        {
            apiKeyList.Add(cboNameAPIKeys.Text);
            cboNameAPIKeys.Items.Add(cboNameAPIKeys.Text);
        }

        private void btnRemoveNameApiKey_Click(object sender, EventArgs e)
        {
            apiKeyList.Clear();
            cboNameAPIKeys.Items.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            var confirmResult = MessageBox.Show("Resetting all of your setting back to default means you will loose all your settings data. Would you still like to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                appDbContext.Database.ExecuteSqlRaw("truncate table Settings");
                appDbContext.Database.ExecuteSqlRaw("truncate table NameApiSettings");
                appDbContext.Database.ExecuteSqlRaw("truncate table NameApiKeys");

                Application.Restart();
            }

        }
    }
}
