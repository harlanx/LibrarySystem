using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class BackupAndRestoreForm : Form
    {

        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        public BackupAndRestoreForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void SaveToLog(string actionType, string actionInformation)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO Logs (account_name, action_type, action_information, action_date) VALUES (?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", LoginForm.accountName);
                        cmd.Parameters.AddWithValue("?", actionType);
                        cmd.Parameters.AddWithValue("?", actionInformation);
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SaveAppSettings()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "UPDATE AppSettings SET login_username = ?, login_password = ?, remember_me = ?, accession_number = ?, client_id = ?, daily_fee = ?, maximum_fee = ?, damaged_type = ?, damaged_fee = ?, lost_type = ?, lost_fee = ?, maximum_book = ? WHERE setting_id = 1";
                    using (OleDbCommand cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.LoginUserName);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.LoginPassword);
                        cmd.Parameters.Add("?", OleDbType.Boolean).Value = Properties.Settings.Default.RememberMe;
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Counter_Access_Number);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Counter_Client_ID);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Daily_Fee);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Maximum_Fee);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Damaged_Type);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Damaged_Fee);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Lost_Type);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Lost_Fee);
                        cmd.Parameters.AddWithValue("?", Properties.Settings.Default.Maximum_Book);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void BackupAndRestoreForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblBackup;
            btnCreateDatabaseBackup.Enabled = false;
            btnRestoreDatabase.Enabled = false;
        }

        private void BackupAndRestoreForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.Description = "Database Backup Destination";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = fbd.SelectedPath;
                txtDestination.SelectionStart = fbd.SelectedPath.Length;
                btnCreateDatabaseBackup.Enabled = true;
            }
        }

        private void btnCreateDatabaseBackup_Click(object sender, EventArgs e)
        {
            string databasePathAndName = AppDomain.CurrentDomain.BaseDirectory + "SJCLibrarySystem.accdb";
            string backupPathAndName = string.Format(@"{0}\SJCLibrarySystem_{1}.accdb", txtDestination.Text, DateTime.Today.ToString("MMM-dd-yyyy"));
            try
            {
                if (File.Exists(backupPathAndName))
                {
                    if (MessageBox.Show(string.Format("SJCLibrarySystem_{0}.accdb already exist in the destination path, Overwrite the file?", DateTime.Today.ToString("MMM-dd-yyyy")), "File Already Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SaveAppSettings();
                        File.Copy(databasePathAndName, backupPathAndName, true);
                        MessageBox.Show("Backup Successfully Created.");
                    }
                    return;
                }
                else
                {
                    SaveAppSettings();
                    File.Copy(databasePathAndName, backupPathAndName);
                    MessageBox.Show("Backup Successfully Created.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "shell:MyComputerFolder";
            ofd.Filter = "Access Database Files (*.accdb)|*.accdb";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = ofd.FileName;
                txtSource.SelectionStart = ofd.FileName.Length;
                btnRestoreDatabase.Enabled = true;
            }
        }

        private void btnRestoreDatabase_Click(object sender, EventArgs e)
        {
            string databasePathAndName = AppDomain.CurrentDomain.BaseDirectory + "SJCLibrarySystem.accdb";
            string sourcePathAndName = txtSource.Text;
            try
            {
                File.Copy(sourcePathAndName, databasePathAndName, true);
                Properties.Settings.Default.RestoredFlag = true;
                Properties.Settings.Default.Save();
                if (MessageBox.Show("Successfully Restored Backup, Restarting The Application") == DialogResult.OK)
                {
                    Application.Restart();
                    Environment.Exit(0);
                } 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
