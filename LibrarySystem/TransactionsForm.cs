using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class TransactionsForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();
        ToolTip toolTip = new ToolTip();

        public TransactionsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FillTransactionFormDGV();
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

        private void PopulateTransactionFormDGV(int numbering, string visitorName, string bookTitle, string transaction, string information, decimal ammountPaid, string date)
        {
            object[] row = { numbering, visitorName, bookTitle, transaction, information, ammountPaid.ToString("C2", CultureInfo.CurrentCulture), DateTime.Parse(date) };
            dvtfGridView.Rows.Add(row);
        }

        private void FillTransactionFormDGV()
        {
            try
            {
                dvtfGridView.Rows.Clear();
                dtb.Rows.Clear();
                string sqlQuery = "SELECT * FROM Transactions ORDER BY transaction_date DESC";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (adapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(dtb);
                    }
                }
                using (DataTableReader dtbReader = new DataTableReader(dtb))
                {
                    dvtfGridView.Columns[0].ValueType = typeof(int);
                    dvtfGridView.Columns[5].ValueType = typeof(decimal);
                    dvtfGridView.Columns[6].ValueType = typeof(DateTime);
                    if (dtbReader.HasRows)
                    {
                        foreach (DataRow row in dtb.Rows)
                        {
                            PopulateTransactionFormDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), (Decimal)row[5], row[6].ToString());
                        }
                    }
                    else
                    {
                        dvtfGridView.Rows.Add("0", "NO RECORDS");
                        dvtfGridView.Enabled = false;
                        btntfSearch.Enabled = false;
                        btntfDeleteTransactions.Enabled = false;
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvtfGridView.ClearSelection();
            }
        }

        private bool DeleteTransactions()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "Delete * FROM Transactions";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Delete Transactions", dtb.Rows.Count.ToString() + " Transactions");
                            return true;
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return false;
        }

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblTransactions;
            cbtfSearchbyExt.Visible = false;
            dvtfGridView.ClearSelection();
            cbtfSearchby.SelectedIndex = 0;
        }

        private void TransactionsForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void cbtfSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtfSearchby.Text == "Search by Date" || cbtfSearchby.Text == "Search by Transaction")
            {
                cbtfSearchbyExt.Items.Clear();
                if (cbtfSearchby.Text == "Search by Date")
                {
                    cbtfSearchbyExt.Items.Add("Newest");
                    cbtfSearchbyExt.Items.Add("Oldest");
                }
                else
                {
                    cbtfSearchbyExt.Items.Add("Borrowed");
                    cbtfSearchbyExt.Items.Add("Returned");
                }
                cbtfSearchbyExt.SelectedIndex = 0;
                txttfSearchbox.Hide();
                cbtfSearchbyExt.Show();
            }
            else
            {
                txttfSearchbox.Visible = true;
                cbtfSearchbyExt.Visible = false;
            }
        }

        private void cbtfSearchby_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbtfSearchbyExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btntfSearch_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txttfSearchbox.Text) || string.IsNullOrEmpty(txttfSearchbox.Text)) 
                && (cbtfSearchby.Text == "Search by Book Title" || cbtfSearchby.Text == "Search by Visitor"))
            {
                toolTip.Show("Field is currently empty.", txttfSearchbox, 5, txttfSearchbox.Height - 1, 3000);
                return;
            }
            dvtfGridView.Rows.Clear();
            int numbering = 1;
            if (!(string.IsNullOrWhiteSpace(txttfSearchbox.Text) || string.IsNullOrEmpty(txttfSearchbox.Text))
                && (cbtfSearchby.Text == "Search by Book Title" || cbtfSearchby.Text == "Search by Visitor"))
            {
                string searchThis = (cbtfSearchby.Text == "Search by Book Title" ? "book_title" : "visitor_name");
                foreach (DataRow row in dtb.Select(searchThis + " LIKE '%" + txttfSearchbox.Text + "%'", searchThis + " DESC"))
                {
                    PopulateTransactionFormDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), (Decimal)row[5], row[6].ToString());
                    numbering += 1;
                }
            }
            else if (cbtfSearchby.Text == "Search by Date" || cbtfSearchby.Text == "Search by Transaction")
            {
                if (cbtfSearchby.Text == "Search by Date")
                {
                    foreach (DataRow row in dtb.Select("", cbtfSearchbyExt.Text == "Newest" ? "transaction_date DESC" : "transaction_date ASC"))
                    {
                        PopulateTransactionFormDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), (Decimal)row[5], row[6].ToString());
                        numbering += 1;
                    }
                }
                else
                {
                    foreach (DataRow row in dtb.Select("transaction = " + (cbtfSearchbyExt.Text == "Borrowed" ? "'Borrowed'" : "'Returned'"), "transaction_date DESC"))
                    {
                        PopulateTransactionFormDGV(numbering, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), (Decimal)row[5], row[6].ToString());
                        numbering += 1;
                    }
                }
            }
        }

        private void btntfReset_Click(object sender, EventArgs e)
        {
            FillTransactionFormDGV();
        }

        private void btntfDeleteTransactions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete.", "Deleting Transactions", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool processSuccess;
                using (new RunProcess(this))
                {
                    processSuccess = DeleteTransactions();
                }
                if (processSuccess)
                {
                    FillTransactionFormDGV();
                    MessageBox.Show("Transactions Successfully Deleted");
                }
            }
            else
            {
                return;
            }
        }

        private void btntfSaveLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Function Yet", "Work In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btntfDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
