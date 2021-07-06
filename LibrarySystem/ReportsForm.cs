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
    public partial class ReportsForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();
        public ReportsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            cbrfReportType.SelectedIndex = 0;
            reportViewer.Clear();
        }

        private void ReportsForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void FillReportViewer(string sqlQuery, string embeddedResource, string dataSet)
        {
            try
            {
                dtb.Clear();
                reportViewer.Clear();
                reportViewer.LocalReport.DataSources.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (adapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(dtb);
                        DataTable visitordtb = new DataTable();
                        reportViewer.LocalReport.ReportEmbeddedResource = embeddedResource;
                        reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(dataSet, dtb));
                        this.reportViewer.RefreshReport();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnrfLoad_Click(object sender, EventArgs e)
        {
            string query;
            string rdlc;
            string data;
            if (cbrfReportType.Text == "Books")
            {
                query = "SELECT * FROM Books";
                rdlc = "LibrarySystem.BooksReport.rdlc";
                data = "BookDataSet";
            }
            else if (cbrfReportType.Text == "Books(Count)")
            {
                //Access Database Engine's IIF is the equal function of CASE WHEN in sql query
                query = "SELECT book_title, SUM(IIF(status = 'Available',1,0)) AS available_book, SUM(IIF(status = 'Unavailable',1,0)) AS unavailable_book, COUNT(*) AS total_book FROM Books GROUP BY book_title";
                rdlc = "LibrarySystem.BooksCountReport.rdlc";
                data = "BookCountDataSet";
            }
            else if (cbrfReportType.Text == "Clients")
            {
                query = "SELECT first_name & ' ' & middle_name & ' ' & last_name AS first_name, contact_number, address, date_registered FROM Clients;";
                rdlc = "LibrarySystem.ClientsReport.rdlc";
                data = "ClientDataSet";
            }
            else
            {
                query = "SELECT * FROM Transactions";
                rdlc = "LibrarySystem.TransactionsReport.rdlc";
                data = "TransactionDataSet";
            }
            using (new RunProcess(this))
            {
                FillReportViewer(query, rdlc, data);
            }
        }

        private void cbrfReportType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnrfDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
