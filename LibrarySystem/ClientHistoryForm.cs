using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class ClientHistoryForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        string clientTable = "";
        string clientName = "";
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();

        public ClientHistoryForm(string clientTableParam, string clientNameParam)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            clientTable = clientTableParam;
            clientName = clientNameParam;
            FillClientHistoryDGV();
        }

        private void PopulateClientHistory(int accessNum, string bookTitle, string transactionType, string date)
        {
            object[] row = {"BID"+accessNum.ToString("D4"), bookTitle, transactionType, DateTime.Parse(date)};
            dgvchfHistoryList.Rows.Add(row);
        }

        private void FillClientHistoryDGV()
        {
            try
            {
                dgvchfHistoryList.Rows.Clear();
                dtb.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    if (con.TableExists(clientTable))
                    {
                        con.Open();
                        string sqlQuery = string.Format("SELECT * FROM {0} ORDER BY status = 'Borrowed', due_date ASC", clientTable);
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
                        dgvchfHistoryList.Columns[0].ValueType = typeof(int);
                        dgvchfHistoryList.Columns[3].ValueType = typeof(DateTime);
                        foreach(DataRow row in dtb.Rows)
                        {
                            PopulateClientHistory(Convert.ToInt32(row[1].ToString()), row[2].ToString(), row[5].ToString(), row[3].ToString());
                        }
                        dgvchfHistoryList.Enabled = true;
                    }
                    else
                    {
                        dgvchfHistoryList.Rows.Add("0000", "NO RECORDS");
                        dgvchfHistoryList.Enabled = false;
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dgvchfHistoryList.ClearSelection();
            }
        }

        private void ClientHistoryForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void ClientHistoryForm_Load(object sender, EventArgs e)
        {
            lblClientName.Text = clientName;
        }

    }
}
