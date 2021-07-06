using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LibrarySystem
{
    public partial class BookHistoryForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        string bookTable = "";
        string bookTitle = "";
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();

        public BookHistoryForm(string bookTableParam, string bookTitleParam)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            bookTable = bookTableParam;
            bookTitle = bookTitleParam;
            FillBookHistoryDGV();
        }

        private void PopulateBookHistory(int historyId, string clientName, string transactionType, string information, string date)
        {
            object[] row = {historyId, clientName, transactionType, information, DateTime.Parse(date) };
            dgvbhfHistoryList.Rows.Add(row);
        }

        private void FillBookHistoryDGV()
        {
            try
            {
                dgvbhfHistoryList.Rows.Clear();
                dtb.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    if (con.TableExists(bookTable))
                    {
                        con.Open();
                        string sqlQuery = string.Format("SELECT * FROM {0} ORDER BY transaction_date DESC", bookTable);
                        using (adapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                        {
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                            adapter.Fill(dtb);
                        }
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(dtb))
                {
                    if (dtbreader.HasRows)
                    {
                        dgvbhfHistoryList.Columns[0].ValueType = typeof(int);
                        dgvbhfHistoryList.Columns[4].ValueType = typeof(DateTime);
                        foreach (DataRow row in dtb.Rows)
                        {
                            PopulateBookHistory(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                        }
                        dgvbhfHistoryList.Enabled = true;
                    }
                    else
                    {
                        dgvbhfHistoryList.Rows.Add("0", "NO RECORDS");
                        dgvbhfHistoryList.Enabled = false;
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dgvbhfHistoryList.ClearSelection();
            }
        }

        private void BookHistoryFormcs_Load(object sender, EventArgs e)
        {
            lblbhfBookTitle.Text = bookTitle;
        }

        private void BookHistoryFormcs_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }
    }
}
