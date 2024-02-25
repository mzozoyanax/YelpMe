using CsvHelper;
using Microsoft.EntityFrameworkCore;
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
using YelpMe.Forms.Accounts;
using YelpMe.Models;

namespace YelpMe.Forms
{
    public partial class Accounts_Manager : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        public Accounts_Manager()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            appDbContext.Database.ExecuteSqlRaw("truncate table accounts");

            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_Account add_New_Account = new Add_New_Account();
            add_New_Account.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any cell is selected in the DataGridView
                if (dgvAccounts.SelectedCells.Count > 0)
                {
                    int columnIndex = dgvAccounts.SelectedCells[0].ColumnIndex;
                    List<object> columnValues = new List<object>();

                    // Loop through the selected cells in the specific column
                    foreach (DataGridViewCell cell in dgvAccounts.SelectedCells)
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
                        var query = appDbContext.Accounts.Where(x => x.Id == Id).FirstOrDefault();

                        appDbContext.Accounts.Remove(query);
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

        private void Accounts_Manager_Load(object sender, EventArgs e)
        {
            dgvAccounts.DataSource = appDbContext.Accounts.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dgvAccounts.DataSource = appDbContext.Accounts.ToList();

            appDbContext.SaveChanges();

            MessageBox.Show("Account data updated successfully...");
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            var query = appDbContext.Accounts.ToList();

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
                        var records = csv.GetRecords<Models.Accounts>();
                        // Process the records as needed

                        foreach (var item in records)
                        {
                            Models.Accounts accounts = new Models.Accounts();

                            accounts.UserName = item.UserName;
                            accounts.Email = item.Email;
                            accounts.Password = item.Password;
                            accounts.SmtpHost = item.SmtpHost;
                            accounts.SmtpPort = item.SmtpPort;
                            accounts.ImapHost = item.ImapHost;
                            accounts.ImapPort = item.ImapPort;
                            accounts.StmpSsl = item.StmpSsl;
                            accounts.ImapSsl = item.ImapSsl;
                            accounts.Signature = item.Signature;

                            appDbContext.Accounts.Add(accounts);
                            appDbContext.SaveChanges();
                        }

                        dgvAccounts.DataSource = appDbContext.Accounts.ToList();
                    }
                }
            }
        }
    }
}
