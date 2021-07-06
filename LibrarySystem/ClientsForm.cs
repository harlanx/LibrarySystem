using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.OleDb;
using System.Globalization;

namespace LibrarySystem
{
    public partial class ClientsForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dtb = new DataTable();
        ToolTip toolTip = new ToolTip();

        public ClientsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void PopulateClientsFormDGV(string clientId, string firstName, string middleName, string lastName, string contactNumber, string address, string dateRegistered, string dateModified)
        {
            object[] row = { clientId, firstName + " " + middleName + " " + lastName, contactNumber, address, DateTime.Parse(dateRegistered).ToShortDateString(), !string.IsNullOrEmpty(dateModified) ? DateTime.Parse(dateModified).ToShortDateString() : "--------"};
            dgvcfClientList.Rows.Add(row);
        }

        private void FillClientsFormDGV()
        {
            try
            {
                dgvcfClientList.Rows.Clear();
                dtb.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Clients ORDER BY date_registered DESC, date_modified DESC";
                    using (adapter = new OleDbDataAdapter(cmd = new OleDbCommand(sqlQuery, con)))
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(dtb);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(dtb))
                {
                    if (dtbreader.HasRows)
                    {
                        dgvcfClientList.Columns[0].ValueType = typeof(Int32);
                        dgvcfClientList.Columns[4].ValueType = typeof(DateTime);
                        dgvcfClientList.Columns[5].ValueType = typeof(DateTime);
                        foreach (DataRow row in dtb.Rows)
                        {
                            PopulateClientsFormDGV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        }
                        txtcfSearchbox.Enabled = true;
                        cbcfSearchby.Enabled = true;
                        btncfSearch.Enabled = true;
                        btncfReset.Enabled = true;
                        dgvcfClientList.Enabled = true;
                    }
                    else
                    {
                        dgvcfClientList.Rows.Add("0", "NO RECORDS");
                        txtcfSearchbox.Enabled = false;
                        cbcfSearchby.Enabled = false;
                        btncfSearch.Enabled = false;
                        btncfReset.Enabled = false;
                        dgvcfClientList.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dgvcfClientList.ClearSelection();
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            FillClientsFormDGV();
            cbcfSearchby.SelectedIndex = 0;
        }

        private void ClientsForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void txtcfSearchbox_Leave(object sender, EventArgs e)
        {
            if (txtcfSearchbox.Text == "")
            {
                txtcfSearchbox.Text = "Type In Client Information";
                txtcfSearchbox.ForeColor = Color.DarkGray;
            }
        }

        private void txtcfSearchbox_Enter(object sender, EventArgs e)
        {
            if (txtcfSearchbox.Text == "Type In Client Information")
            {
                txtcfSearchbox.Text = null;
                txtcfSearchbox.ForeColor = Color.Black;
            }
        }

        private void cbcfSearchby_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtcfSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbcfSearchby.Text == "Search by ID No.")
            {
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsDigit(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                    toolTip.Show("Numbers 0-9 are only allowed.", txtcfSearchbox, 5, txtcfSearchbox.Height - 1, 3000);
                }
            }
            else
            {
                if (txtcfSearchbox.Text.Length == 0 && e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsLetter(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back
                    && e.KeyChar != (char)Keys.Space)
                {
                    e.Handled = true;
                    toolTip.Show("Characters a-z and A-Z are only allowed.", txtcfSearchbox, 5, txtcfSearchbox.Height - 1, 3000);
                }
            }
        }

        private void txtcfSearchbox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int index = txt.Text.IndexOf("  ");
            int selectionStart = txt.SelectionStart;

            while (index != -1)
            {
                txt.Text = txt.Text.Replace("  ", " ");
                index = txt.Text.IndexOf("  ");
            }
            txt.SelectionStart = selectionStart;
        }

        private void cbcfSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcfSearchbox.Text = null;
            txtcfSearchbox_Leave(sender, e);
        }


        private void dgvcfClientList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvcfClientList.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                int currentClientId = Convert.ToInt32(dgvcfClientList.Rows[dgvcfClientList.SelectedRows[0].Index].Cells[0].Value);
                string currentClientFirstName = (from DataRow dr in dtb.Rows where (int)dr[0] == currentClientId select (string)dr[1]).FirstOrDefault();
                string currentClientMiddleName = (from DataRow dr in dtb.Rows where (int)dr[0] == currentClientId select (string)dr[2]).FirstOrDefault();
                string currentClientLastName = (from DataRow dr in dtb.Rows where (int)dr[0] == currentClientId select (string)dr[3]).FirstOrDefault();
                string clientTable = string.Format("CID{0}", currentClientId.ToString("D4"));
                string clientName = string.Format("{0} {1} {2}", currentClientFirstName, currentClientMiddleName, currentClientLastName);
                using (new RunProcess(this, false))
                {
                    ClientHistoryForm chf = new ClientHistoryForm(clientTable, clientName);
                    chf.ShowDialog();
                }
            }
        }

        private void btncfSearch_Click(object sender, EventArgs e)
        {
            dgvcfClientList.Rows.Clear();
            if ((string.IsNullOrWhiteSpace(txtcfSearchbox.Text) || txtcfSearchbox.Text == "Type In Client Information") && cbcfSearchby.Text == "Search by ID No.")
            {
                foreach (DataRow row in dtb.Select("", "client_id ASC"))
                {
                    PopulateClientsFormDGV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }
            }
            if ((string.IsNullOrWhiteSpace(txtcfSearchbox.Text) || txtcfSearchbox.Text == "Type In Client Information") && cbcfSearchby.Text == "Search by Name")
            {
                foreach (DataRow row in dtb.Select("", "first_name ASC"))
                {
                    PopulateClientsFormDGV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }
            }
            if (!(string.IsNullOrWhiteSpace(txtcfSearchbox.Text) || txtcfSearchbox.Text == "Type In Client Information") && cbcfSearchby.Text == "Search by ID No.")
            {
                foreach (DataRow row in dtb.Select("Convert(client_id, 'System.String') LIKE '" + txtcfSearchbox.Text + "%'", "client_id ASC"))
                {
                    PopulateClientsFormDGV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }
            }
            if (!(string.IsNullOrWhiteSpace(txtcfSearchbox.Text) || txtcfSearchbox.Text == "Type In Client Information") && cbcfSearchby.Text == "Search by Name")
            {
                foreach (DataRow row in dtb.Select("first_name LIKE '%" + txtcfSearchbox.Text + "%' OR middle_name LIKE '%" + txtcfSearchbox.Text + "%' OR last_name LIKE '%" + txtcfSearchbox.Text + "%'"))
                {
                    PopulateClientsFormDGV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }
            }
        }

        private void btncfReset_Click(object sender, EventArgs e)
        {
            FillClientsFormDGV();
            txtcfSearchbox.Text = null;
            txtcfSearchbox_Leave(sender, e);
            cbcfSearchby.SelectedIndex = 0;
        }

        private void btncfDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
