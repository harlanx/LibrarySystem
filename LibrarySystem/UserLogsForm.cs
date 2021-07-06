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
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class UserLogsForm : Form
    {
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-PH");
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public UserLogsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FillUserLogsDGV();
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

        public void PopulateUserLogsDGV(int log_id, string account_name, string action_type, string action_value, string action_date)
        {
            object[] row = { log_id, account_name, action_type, action_value, action_date };
            dvulfGridView.Rows.Add(row);
        }

        public void FillUserLogsDGV()
        {
            try
            {
                dvulfGridView.Rows.Clear();
                dtb.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Logs ORDER BY action_date DESC";
                    using (adapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.Fill(dtb);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(dtb))
                {
                    if (dtbreader.HasRows)
                    {
                        int numbering = 1;
                        dvulfGridView.Columns[0].ValueType = typeof(int);
                        dvulfGridView.Columns[4].ValueType = typeof(DateTime);
                        foreach (DataRow row in dtb.Rows.Cast<DataRow>().Take(100))
                        {
                            PopulateUserLogsDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                            numbering += 1;
                        }
                        btnulfSaveLogs.Enabled = true;
                        btnulfDeleteLogs.Enabled = true;
                        dvulfGridView.Enabled = true;
                        txtulfSearchbox.Enabled = true;
                        cbulfSearchby.Enabled = true;
                        btnulfSearch.Enabled = true;
                    }
                    else
                    {
                        dvulfGridView.Enabled = true;
                        btnulfSaveLogs.Enabled = false;
                        btnulfDeleteLogs.Enabled = false;
                        txtulfSearchbox.Enabled = false;
                        cbulfSearchby.Enabled = false;
                        btnulfSearch.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvulfGridView.ClearSelection();
            }
        }

        private bool DeleteLogs()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "DELETE * FROM Logs";
                    using (adapter.DeleteCommand = new OleDbCommand(sqlQuery, con))
                    {
                        if (adapter.DeleteCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Delete Logs", dtb.Rows.Count.ToString() + " Logs");
                            return true;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return false;
        }

        private void ExportToText()
        {
            if (dvulfGridView.Rows.Count > 0)
            {
                using (var txtwriter = new StreamWriter(Path.Combine(docPath, "ExportedUserLogs.txt")))
                {
                    foreach (DataGridViewRow row in dvulfGridView.Rows)
                    {
                        txtwriter.WriteLine(row.Cells[0].Value + " | " + row.Cells[1].Value + " | " + row.Cells[2].Value + " | " + row.Cells[3].Value + " | " + row.Cells[4].Value);
                    }
                    MessageBox.Show("The File is Located at" + (Path.Combine(docPath, "ExportedUserLogs.txt")).ToString());
                }
            }
            else
            {
                MessageBox.Show("User Logs List is Currently Empty");
            }
        }

        private void UserLogsForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblUserLogs;
            dvulfGridView.ClearSelection();
            cbulfSearchby.SelectedIndex = 0;
        }

        private void UserLogsForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void btnulfSearch_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtulfSearchbox.Text) || string.IsNullOrWhiteSpace(txtulfSearchbox.Text)) && cbulfSearchby.Text == "Search by Action")
            {
                dvulfGridView.Rows.Clear();
                int numbering = 1;
                foreach (DataRow row in dtb.Select("", "action_type ASC"))
                {
                    PopulateUserLogsDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    numbering += 1;
                }
            }

            if ((string.IsNullOrEmpty(txtulfSearchbox.Text) || string.IsNullOrWhiteSpace(txtulfSearchbox.Text)) && cbulfSearchby.Text == "Search by User")
            {
                dvulfGridView.Rows.Clear();
                int numbering = 1;
                foreach (DataRow row in dtb.Select("", "account_name ASC"))
                {
                    PopulateUserLogsDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    numbering += 1;
                }
            }

            if (!(string.IsNullOrWhiteSpace(txtulfSearchbox.Text)) && cbulfSearchby.Text == "Search by Action")
            {
                dvulfGridView.Rows.Clear();
                int numbering = 1;
                foreach (DataRow row in dtb.Select("action_type LIKE '%" + txtulfSearchbox.Text + "%'", "action_type DESC, action_date DESC"))
                {
                    PopulateUserLogsDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    numbering += 1;
                }
            }

            if (!(string.IsNullOrWhiteSpace(txtulfSearchbox.Text)) && cbulfSearchby.Text == "Search by User")
            {
                dvulfGridView.Rows.Clear();
                int numbering = 1;
                foreach (DataRow row in dtb.Select("account_name LIKE '%" + txtulfSearchbox.Text + "%'", "account_name ASC, action_date DESC"))
                {
                    PopulateUserLogsDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    numbering += 1;
                }
            }
        }

        private void btnulfSaveLogs_Click(object sender, EventArgs e)
        {
            ExportToText();
        }

        private void btnulfDeleteLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete.", "Deleting Logs", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool processSuccess;
                using (new RunProcess(this))
                {
                    processSuccess = DeleteLogs();
                }
                if (processSuccess)
                {
                    FillUserLogsDGV();
                    MessageBox.Show("User Logs Successfully Deleted.");
                }
            }
            else
            {
                return;
            }
        }

        private void btnulfDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnulfReset_Click(object sender, EventArgs e)
        {
            FillUserLogsDGV();
        }
    }
}
