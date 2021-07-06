using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class MainForm : Form
    {
        #region Variables and Classes
        //Database Variables and Classes
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        string cultureCurrencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter booksAdapter = new OleDbDataAdapter();
        OleDbDataAdapter clientsAdapter = new OleDbDataAdapter();
        OleDbDataAdapter clientBooksAdapter = new OleDbDataAdapter();
        DataTable booksDataTable = new DataTable();
        DataTable clientsDataTable = new DataTable();
        DataTable clientsBooksDataTable = new DataTable();
        //ToolTips
        ToolTip toolTip = new ToolTip();
        ToolTip toolTip1 = new ToolTip();
        ToolTip toolTip2 = new ToolTip();
        ToolTip toolTip3 = new ToolTip();
        ToolTip toolTip4 = new ToolTip();
        ToolTip toolTip5 = new ToolTip();
        ToolTip toolTip6 = new ToolTip();
        ToolTip toolTip7 = new ToolTip();
        ToolTip toolTip8 = new ToolTip();
        ToolTip toolTip9 = new ToolTip();
        //User Info
        string accountName = LoginForm.accountName;
        string accountType = LoginForm.accountType;
        #endregion

        public MainForm()
        {
            using (new RunProcess(this, false))
            {
                InitializeComponent();
                this.DoubleBuffered = true;
                menumf.Renderer = new MenuStripRenderer();
                FillMainFormDGV();
                lblmfUser.Text = accountName;
                lblmfAccType.Text = accountType;
            }
        }

        private void SaveToLog(string actionType, string actionInformation)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO Logs (account_name, action_type, action_information, action_date) VALUES (?, ?, ?, ?)";
                    using (cmd = new OleDbCommand(sqlQuery, con))
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

        #region MenuStrip
        private class MenuStripRenderer : ToolStripProfessionalRenderer
        {
            public MenuStripRenderer() : base(new MenuStripColors()) { }
        }

        private class MenuStripColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.CornflowerBlue; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.RoyalBlue; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.CornflowerBlue; }
            }
            public override Color MenuBorder
            {
                get { return Color.RoyalBlue; }
            }
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    TransactionsForm tf = new TransactionsForm();
                    tf.ShowDialog();
                }
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    ReportsForm rf = new ReportsForm();
                    rf.ShowDialog();
                }
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    ClientsForm cf = new ClientsForm();
                    cf.ShowDialog();
                }
            }
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    CreateAccountForm caf = new CreateAccountForm();
                    caf.ShowDialog();
                }
            }
        }

        private void viewAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    AccountListForm alf = new AccountListForm();
                    alf.ShowDialog();
                }
            }
        }

        private void feesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                if (pnlmfReturn.Visible == true && !string.IsNullOrEmpty(txtpnlrbName.Text))
                {
                    MessageBox.Show("Cannot update fees while returning books");
                    return;
                }
                using (new RunProcess(this, false))
                {
                    FeesForm ff = new FeesForm();
                    ff.ShowDialog();
                }
            }
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    BackupAndRestoreForm barf = new BackupAndRestoreForm();
                    barf.ShowDialog();
                }
            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountType != "Administrator")
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                using (new RunProcess(this, false))
                {
                    UserLogsForm ulf = new UserLogsForm();
                    ulf.ShowDialog();
                }
            }
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_ResizeBegin(null, null);
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable && this.WindowState == FormWindowState.Normal)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Bounds = Screen.PrimaryScreen.Bounds;
                SizeGripStyle = SizeGripStyle.Hide;
            }
            else if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable && this.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Bounds = Screen.PrimaryScreen.Bounds;
                SizeGripStyle = SizeGripStyle.Hide;
            }
            else
            {
                Size = MinimumSize;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                SizeGripStyle = SizeGripStyle.Show;
                CenterToScreen();
            }
            MainForm_ResizeEnd(null, null);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (FormBorderStyle == System.Windows.Forms.FormBorderStyle.None && e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Log Out of System?", "Exiting Program", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveToLog("Logout", "Success");
                Properties.Settings.Default.Last_Date = DateTime.Now;
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Handles Logout and X button Click
        /// </summary>
        private void btnmfLogout_Click(object sender, EventArgs e)
        {
            SaveToLog("Logout", "Success");
            //Removes the FormClosing event handler;
            this.FormClosing -= MainForm_FormClosing;
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form.Name != "LoginForm")
                {
                    if (form.Name == "MainForm")
                    {
                        using (new RunProcess(this))
                        {
                            LoginForm lf = new LoginForm();
                            lf.ShowDialog();
                        }
                    }
                    form.Close();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Log Out of System?", "Exiting Program", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SaveToLog("Logout", "Force Close");
                    Properties.Settings.Default.Last_Date = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Main Form
        //Database Functions
        /// <summary>
        /// Populates the GridView, used in foreach.
        /// </summary>
        /// <param name="accessionNumber"></param>
        /// <param name="bookTitle"></param>
        /// <param name="author"></param>
        /// <param name="publisher"></param>
        /// <param name="volume"></param>
        /// <param name="category"></param>
        /// <param name="classification"></param>
        /// <param name="status"></param>
        /// <param name="information"></param>
        private void PopulateMainformDGV(int accessionNumber, string bookTitle, string author, string publisher, string volume, string category, string classification, string status, string information)
        {
            object[] row = { accessionNumber, bookTitle, author, publisher, volume, category, classification, status, information };
            dvmfGridView.Rows.Add(row);
        }

        /// <summary>
        /// Gets the data from database thens calls the populate method
        /// </summary>
        private void FillMainFormDGV()
        {
            try
            {
                dvmfGridView.CellFormatting -= dvmfGridView_CellFormatting;
                dvmfGridView.Rows.Clear();
                booksDataTable.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Books";
                    using (booksAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        booksAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        booksAdapter.Fill(booksDataTable);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(booksDataTable))
                {
                    if (dtbreader.HasRows)
                    {
                        dvmfGridView.CellFormatting += dvmfGridView_CellFormatting;
                        dvmfGridView.Columns[0].ValueType = typeof(int);
                        dvmfGridView.Columns[4].ValueType = typeof(int);
                        foreach (DataRow row in booksDataTable.Rows)
                        {
                            PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                        }
                        dvmfGridView.Enabled = true;
                        btnmfSearch.Enabled = true;
                    }
                    else
                    {
                        btnmfSearch.Enabled = false;
                        dvmfGridView.Rows.Add(null, "NO RECORDS");
                        dvmfGridView.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvmfGridView.ClearSelection();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //Need to tweak this bastard a bit more, not yet perfect on fullscreen.
            /*1280x720 = Form's Minimum Size and Default Size
             222 = Top Panel's Default Height
             421 = Bottom Panel's Default Height
             400 = Top Panel's Maximum Height
             898 = Default Height + Top Panel's Maximum Height - Top Panel's Default Height*/
            int topPanelHeight = (this.Size == MinimumSize ? 222 : Convert.ToInt32(Size.Height + 222 - 720));
            int bottomPanelHeight = (this.Size == MinimumSize ? 421 : Convert.ToInt32(Size.Height + 421 - 898));
            Size topPanelSize = new Size(411, topPanelHeight >= 400 ? 400 : topPanelHeight);
            Size bottomPanelSize = new Size(411, topPanelHeight <= 400 ? 421 : bottomPanelHeight);
            Point topPanelLocation = (this.Size == MinimumSize ? new Point(850, 34) : new Point(pnlmfAddBooks.Location.X, pnlmfAddBooks.Location.Y));
            Point bottomPanelLocation = (this.Size == MinimumSize ? new Point(850, 255) : new Point(pnlmfAddBooks.Location.X, pnlscextEditClient.Location.Y + topPanelSize.Height - 1));
            //Add Client
            pnlmfAddClient.MaximumSize = bottomPanelSize;
            pnlmfAddClient.Size = bottomPanelSize;
            pnlmfAddClient.Location = bottomPanelLocation;
            //Search Client
            pnlmfSearchClient.MaximumSize = bottomPanelSize;
            pnlmfSearchClient.Size = bottomPanelSize;
            pnlmfSearchClient.Location = bottomPanelLocation;
            pnlscextEditClient.MaximumSize = topPanelSize;
            pnlscextEditClient.Size = topPanelSize;
            pnlscextEditClient.Location = topPanelLocation;
            //Borrow Book
            pnlmfBorrow.MaximumSize = bottomPanelSize;
            pnlmfBorrow.Size = bottomPanelSize;
            pnlmfBorrow.Location = bottomPanelLocation;
            pnlbbextViewList.MaximumSize = topPanelSize;
            pnlbbextViewList.Size = topPanelSize;
            pnlbbextViewList.Location = topPanelLocation;
            //Return Book
            pnlmfReturn.MaximumSize = bottomPanelSize;
            pnlmfReturn.Size = bottomPanelSize;
            pnlmfReturn.Location = bottomPanelLocation;
            pnlrbextViewList.MaximumSize = topPanelSize;
            pnlrbextViewList.Size = topPanelSize;
            pnlrbextViewList.Location = topPanelLocation;
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
            MainForm_Resize(null, null);
            this.Refresh();
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = lblBookList;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Main Form
            this.ActiveControl = lblBookList;
            dvmfGridView.ClearSelection();
            cbmfType.SelectedIndex = 0;
            //Add Client
            pnlmfAddClient.Visible = false;
            dtppnlacDateRegistered.Format = DateTimePickerFormat.Custom;
            dtppnlacDateRegistered.CustomFormat = "MM/dd/yyyy";
            this.dtppnlacDateRegistered.Enabled = false;
            //Search Client
            pnlmfSearchClient.Visible = false;
            pnlscextEditClient.Visible = false;
            //Add Books
            pnlmfAddBooks.Visible = false;
            txtpnlabPublisher.Visible = false;
            btnpnlabAddPublisher.Visible = false;
            txtpnlabCategory.Visible = false;
            btnpnlabAddCategory.Visible = false;
            cbpnlabVolume.DataSource = Enumerable.Range(1, 200).ToList();
            cbpnlabVolume.SelectedIndex = -1;
            dtppnlabDateAdded.Format = DateTimePickerFormat.Custom;
            dtppnlabDateAdded.CustomFormat = "MM/dd/yyyy";
            this.dtppnlabDateAdded.Enabled = false;
            cbpnlabYearPublished.DataSource = Enumerable.Range(1850, DateTime.UtcNow.Year - 1849).Reverse().ToList();
            cbpnlabYearPublished.SelectedIndex = -1;
            //Edit Books
            pnlmfEdit.Visible = false;
            txtpnlePublisher.Visible = false;
            btnpnleAddPublisher.Visible = false;
            txtpnleCategory.Visible = false;
            btnpnleAddCategory.Visible = false;
            cbpnleVolume.DataSource = Enumerable.Range(1, 200).ToList();
            cbpnleVolume.SelectedIndex = -1;
            dtppnleDateModified.Format = DateTimePickerFormat.Custom;
            dtppnleDateModified.CustomFormat = "MM/dd/yyyy";
            this.dtppnleDateModified.Enabled = false;
            cbpnleYearPublished.DataSource = Enumerable.Range(1850, DateTime.UtcNow.Year - 1849).Reverse().ToList();
            cbpnleYearPublished.SelectedIndex = -1;
            //Borrow Books
            pnlmfBorrow.Visible = false;
            pnlbbextViewList.Visible = false;
            //Return Books
            pnlmfReturn.Visible = false;
            pnlrbextViewList.Visible = false;
        }

        private void ShowMainFormButtons()
        {
            btnmfAddClient.Show();
            btnmfSearchClient.Show();
            btnmfAddBooks.Show();
            btnmfEdit.Show();
            btnmfBorrow.Show();
            btnmfReturn.Show();
            lblmfUser.Show();
            lblmfAccType.Show();
            btnmfLogout.Show();
        }

        private void HideMainFormButtons()
        {
            btnmfAddClient.Hide();
            btnmfSearchClient.Hide();
            btnmfAddBooks.Hide();
            btnmfEdit.Hide();
            btnmfBorrow.Hide();
            btnmfReturn.Hide();
            lblmfUser.Hide();
            lblmfAccType.Hide();
            btnmfLogout.Hide();
        }

        private void txtmfSearch_Leave(object sender, EventArgs e)
        {
            txtmfSearch.TextChanged -= txtmfSearch_TextChanged;
            if (txtmfSearch.Text == "")
            {
                txtmfSearch.Text = "Type In Book Title";
                txtmfSearch.ForeColor = Color.DarkGray;
            }
            txtmfSearch.Text = txtmfSearch.Text.Trim();
            txtmfSearch.TextChanged += txtmfSearch_TextChanged;
        }

        private void txtmfSearch_Enter(object sender, EventArgs e)
        {
            txtmfSearch.TextChanged -= txtmfSearch_TextChanged;
            if (txtmfSearch.Text == "Type In Book Title")
            {
                txtmfSearch.Text = null;
                txtmfSearch.ForeColor = Color.Black;
            }
            txtmfSearch.TextChanged += txtmfSearch_TextChanged;
        }

        private void txtmfSearch_TextChanged(object sender, EventArgs e)
        {
            int index = txtmfSearch.Text.IndexOf("  ");
            int selectionStart = txtmfSearch.SelectionStart;
            while (index != -1)
            {
                txtmfSearch.Text = txtmfSearch.Text.Replace("  ", " ");
                index = txtmfSearch.Text.IndexOf("  ");
            }
            txtmfSearch.SelectionStart = selectionStart;
            if (!string.IsNullOrEmpty(txtmfSearch.Text))
            {
                btnmfSearch_Click(null, null);
            }
            else
            {
                btnmfReset_Click(null, null);
            }
        }

        private void txtmfSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtmfSearch.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void cbmfType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbmfType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmfSearch_TextChanged(null, null);
        }

        int currentBookAccessionNumber;
        bool currentBookPublisherExist;
        bool currentBookCategoryExist;
        string currentBookTitle;
        string currentBookAuthor;
        string currentBookPublisher;
        string currentBookYearPublished;
        string currentBookVolume;
        string currentBookNumberOfPages;
        string currentBookCategory;
        string currentBookClassification;
        string currentBookSubclass;
        string currentBookPrice;
        string currentBookStatus;
        string currentBookInformation;

        /// <summary>
        /// Handles the clicks of the Books DataGridView depends on the current visible panel.
        /// </summary>
        private void dvmfGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Book History
            if (pnlmfEdit.Visible == false && pnlmfBorrow.Visible == false && dvmfGridView.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                string bookTable = "BID" + Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value).ToString("D4");
                string bookTitle = dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                using (new RunProcess(this, false))
                {
                    BookHistoryForm bhf = new BookHistoryForm(bookTable, bookTitle);
                    bhf.ShowDialog();
                }
            }

            //Edit Books
            if (pnlmfEdit.Visible == true && dvmfGridView.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                txtpnlePrice.TextChanged -= txtpnlePrice_TextChanged;
                txtpnlePrice.TextChanged += txtpnlePrice_TextChanged;
                cbpnleClassification.SelectedIndexChanged -= cbpnleClassification_SelectedIndexChanged;
                cbpnleClassification.SelectedIndexChanged += cbpnleClassification_SelectedIndexChanged;
                //Store the current selected book information
                currentBookAccessionNumber = Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value);
                currentBookTitle = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[1]).FirstOrDefault();
                currentBookAuthor = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[2]).FirstOrDefault();
                currentBookPublisher = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[3]).FirstOrDefault();
                currentBookYearPublished = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (int)dr[4]).FirstOrDefault().ToString();
                currentBookVolume = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (int)dr[5]).FirstOrDefault().ToString();
                currentBookNumberOfPages = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (int)dr[6]).FirstOrDefault().ToString();
                currentBookCategory = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[7]).FirstOrDefault();
                currentBookClassification = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[8]).FirstOrDefault().ToString()[0].ToString();
                currentBookSubclass = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[8]).FirstOrDefault();
                decimal book_price = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (decimal)dr[9]).FirstOrDefault();
                currentBookPrice = book_price.ToString("C2", CultureInfo.CurrentCulture);
                currentBookStatus = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[12]).FirstOrDefault();
                currentBookInformation = (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (object)dr[13]).FirstOrDefault().ToString();
                //Passing the stored information to the controls
                txtpnleAccessNo.Text = "BID" + currentBookAccessionNumber.ToString("D4");
                txtpnleBookTitle.Text = currentBookTitle;
                txtpnleAuthor.Text = currentBookAuthor;
                if (cbpnlePublisher.FindStringExact(currentBookPublisher) > -1)
                {
                    cbpnlePublisher.SelectedIndex = cbpnlePublisher.FindStringExact(currentBookPublisher);
                    currentBookPublisherExist = true;
                }
                else
                {
                    cbpnlePublisher.Items.Add(currentBookPublisher);
                    cbpnlePublisher.SelectedIndex = cbpnlePublisher.FindStringExact(currentBookPublisher);
                    currentBookPublisherExist = false;
                }

                cbpnleYearPublished.SelectedIndex = cbpnleYearPublished.FindStringExact(currentBookYearPublished);
                cbpnleVolume.SelectedIndex = cbpnleVolume.FindStringExact(currentBookVolume);
                txtpnleNumberOfPages.Text = currentBookNumberOfPages;
                if (cbpnleCategory.FindStringExact(currentBookCategory) > -1)
                {
                    cbpnleCategory.SelectedIndex = cbpnleCategory.FindStringExact(currentBookCategory);
                    currentBookCategoryExist = true;
                }
                else
                {
                    cbpnleCategory.Items.Add(currentBookCategory);
                    cbpnleCategory.SelectedIndex = cbpnleCategory.FindStringExact(currentBookCategory);
                    currentBookCategoryExist = false;
                }
                cbpnleClassification.SelectedIndex = cbpnleClassification.FindStringExact(currentBookClassification);
                cbpnleSubClass.SelectedIndex = cbpnleSubClass.FindString(currentBookSubclass);
                txtpnlePrice.Text = currentBookPrice;
                cbpnleStatus.SelectedIndex = cbpnleStatus.FindStringExact(currentBookStatus);
                cbpnleInformation.SelectedIndex = cbpnleInformation.FindStringExact(currentBookInformation);
                btnpnleEditBook.Enabled = true;
                btnpnleCancel.Text = "Cancel";
            }
            //Borrow Books
            if (pnlmfBorrow.Visible == true && dvpnlbbGridView.Enabled == true && dvmfGridView.SelectedRows.Count > 0 && dvmfGridView.CurrentRow != null)
            {
                btnpnlbbAdd_Click(null, null);
            }
        }

        private void dvmfGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dvmfGridView.Rows)
            {
                if (row.Cells[7].Value.ToString() == "Unavailable" && (row.Cells[8].Value.ToString() == "Damaged" || row.Cells[8].Value.ToString() == "Lost" || row.Cells[8].Value.ToString() == "Missing"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (row.Cells[7].Value.ToString() == "Unavailable" && row.Cells[8].Value.ToString() == "Borrowed")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnmfSearch_Click(object sender, EventArgs e)
        {
            dvmfGridView.Rows.Clear();
            //All (Default)
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "All (Default)")
            {
                foreach (DataRow row in booksDataTable.Select("", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "All (Default)")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            //Available
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Available")
            {
                foreach (DataRow row in booksDataTable.Select("status = 'Available'", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Available")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND status = 'Available'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            //Borrowed
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Borrowed")
            {
                foreach (DataRow row in booksDataTable.Select("information = 'Borrowed'", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Borrowed")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND information = 'Borrowed'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            //Due Today
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Due Today")
            {
                foreach (DataRow row in booksDataTable.Select("information = 'Borrowed'", "due_date DESC"))
                {
                    if (DateTime.Parse(row[14].ToString()).Date == DateTime.Today.Date)
                    {
                        PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                    }
                }
            }

            if ((!string.IsNullOrEmpty(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Due Today")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text +"%' AND information = 'Borrowed'", "due_date DESC"))
                {
                    if (DateTime.Parse(row[14].ToString()).Date == DateTime.Today.Date)
                    {
                        PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                    }
                }
            }

            //Lost
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Lost")
            {
                foreach (DataRow row in booksDataTable.Select("information = 'Lost'", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Lost")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND information = 'Lost'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            //Missing
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Missing")
            {
                foreach (DataRow row in booksDataTable.Select("information = 'Missing'", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Missing")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND information = 'Missing'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }


            //Overdue
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Overdue")
            {
                foreach (DataRow row in booksDataTable.Select("information = 'Borrowed'", "due_date DESC"))
                {
                    if (DateTime.Parse(row[14].ToString()).Date < DateTime.Today.Date)
                    {
                        PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                    }
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Overdue")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND information = 'Borrowed'", "due_date DESC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            //Unavailable
            if (txtmfSearch.Text == "Type In Book Title" && cbmfType.Text == "Unavailable")
            {
                foreach (DataRow row in booksDataTable.Select("status = 'Unavailable'", "access_num ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }

            if ((!string.IsNullOrWhiteSpace(txtmfSearch.Text) && txtmfSearch.Text != "Type In Book Title") && cbmfType.Text == "Unavailable")
            {
                foreach (DataRow row in booksDataTable.Select("book_title LIKE '" + txtmfSearch.Text + "%' AND status = 'Unavailable'", "book_title ASC"))
                {
                    PopulateMainformDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(), row[7].ToString(), row[8].ToString(), row[12].ToString(), row[13].ToString());
                }
            }
            dvmfGridView.ClearSelection();
        }

        private void btnmfReset_Click(object sender, EventArgs e)
        {
            cbmfType.SelectedIndex = 0;
            FillMainFormDGV();
        }

        /// <summary>
        /// Show the panel that is passed on the paramter then hides the other visible panels
        /// </summary>
        /// <param name="panelToShow"></param>
        private void ShowPanel(Panel panelToShow)
        {
            List<Panel> mainFormPanels = new List<Panel> { pnlmfAddClient, pnlmfSearchClient, pnlmfAddBooks, pnlmfEdit, pnlmfBorrow, pnlmfReturn };
            foreach (Panel visiblePanels in mainFormPanels)
            {
                if (visiblePanels == panelToShow)
                {
                    visiblePanels.Show();
                }
                else
                {
                    visiblePanels.Hide();
                }
            }
        }
        #endregion

        #region Add Client Panel
        private void btnmfAddClient_Click(object sender, EventArgs e)
        {
            if (pnlmfAddClient.Visible == false)
            {
                txtpnlacClientID.Text = ("CID" + Properties.Settings.Default.Counter_Client_ID.ToString("D4"));
                txtpnlacContactNumber.TextChanged -= txtpnlacContactNumber_TextChanged;
                ShowPanel(pnlmfAddClient);
                this.ActiveControl = txtpnlacFirstName;
            }
            else
            {
                pnlmfAddClient.Hide();
            }
        }

        /// <summary>
        /// Refills the clients datatable with the latest data
        /// </summary>
        private void FetchUpdatedClientsData()
        {
            try
            {
                clientsDataTable.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Clients";
                    using (clientsAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        clientsAdapter.Fill(clientsDataTable);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Method For Adding New Client
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="contactNumber"></param>
        /// <param name="address"></param>
        /// <returns>The Method Result</returns>
        private bool AddClient(string firstName, string middleName, string lastName, string contactNumber, string address)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO Clients(first_name, middle_name, last_name, contact_number, address, date_registered) VALUES(?, ?, ?, ?, ?, ?)";
                    using (clientsAdapter.InsertCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.InsertCommand.Parameters.Clear();
                        clientsAdapter.InsertCommand.Parameters.AddWithValue("?", firstName);
                        clientsAdapter.InsertCommand.Parameters.AddWithValue("?", middleName);
                        clientsAdapter.InsertCommand.Parameters.AddWithValue("?", lastName);
                        clientsAdapter.InsertCommand.Parameters.AddWithValue("?", contactNumber);
                        clientsAdapter.InsertCommand.Parameters.AddWithValue("?", address);
                        clientsAdapter.InsertCommand.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        if (clientsAdapter.InsertCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Add Client", firstName + " " + middleName + " " + lastName);
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

        private void pnlmfAddClient_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfAddClient.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlacFirstName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtpnlacFirstName);
            if (txtpnlacFirstName.Text == "")
            {
                txtpnlacFirstName.Text = "Enter First Name e.g., Juan";
                txtpnlacFirstName.ForeColor = Color.DarkGray;
            }
            txtpnlacFirstName.Text = txtpnlacFirstName.Text.Trim();
        }
        private void txtpnlacMidName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtpnlacMidName);
            if (txtpnlacMidName.Text == "")
            {
                txtpnlacMidName.Text = "Enter Middle Name e.g., Santos";
                txtpnlacMidName.ForeColor = Color.DarkGray;
            }
            txtpnlacMidName.Text = txtpnlacMidName.Text.Trim();
        }
        private void txtpnlacLastName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtpnlacLastName);
            if (txtpnlacLastName.Text == "")
            {
                txtpnlacLastName.Text = "Enter Last Name e.g., Dela Cruz";
                txtpnlacLastName.ForeColor = Color.DarkGray;
            }
            txtpnlacLastName.Text = txtpnlacLastName.Text.Trim();
        }
        private void txtpnlacAddress_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtpnlacAddress);
            if (txtpnlacAddress.Text == "")
            {
                txtpnlacAddress.Text = "Enter Address e.g., Calaocan, San Jose City, Nueva Ecija";
                txtpnlacAddress.ForeColor = Color.DarkGray;
            }
            txtpnlacAddress.Text = txtpnlacAddress.Text.Trim();
        }
        private void txtpnlacContactNumber_Leave(object sender, EventArgs e)
        {
            txtpnlacContactNumber.TextChanged -= txtpnlacContactNumber_TextChanged;
            toolTip.Hide(txtpnlacContactNumber);
            if (txtpnlacContactNumber.Text == "" || txtpnlacContactNumber.Text.Equals("09"))
            {
                txtpnlacContactNumber.Text = "Contact Number e.g., 09272727xxx";
                txtpnlacContactNumber.ForeColor = Color.DarkGray;
            }
        }

        private void txtpnlacFirstName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(txtpnlacFirstName);
            if (txtpnlacFirstName.Text == "Enter First Name e.g., Juan")
            {
                txtpnlacFirstName.Text = null;
                txtpnlacFirstName.ForeColor = Color.Black;
            }
        }
        private void txtpnlacMidName_Enter(object sender, EventArgs e)
        {
            toolTip2.Hide(txtpnlacMidName);
            if (txtpnlacMidName.Text == "Enter Middle Name e.g., Santos")
            {
                txtpnlacMidName.Text = null;
                txtpnlacMidName.ForeColor = Color.Black;
            }
        }
        private void txtpnlacLastName_Enter(object sender, EventArgs e)
        {
            toolTip3.Hide(txtpnlacLastName);
            if (txtpnlacLastName.Text == "Enter Last Name e.g., Dela Cruz")
            {
                txtpnlacLastName.Text = null;
                txtpnlacLastName.ForeColor = Color.Black;
            }
        }
        private void txtpnlacAddress_Enter(object sender, EventArgs e)
        {
            toolTip4.Hide(txtpnlacAddress);
            if (txtpnlacAddress.Text == "Enter Address e.g., Calaocan, San Jose City, Nueva Ecija")
            {
                txtpnlacAddress.Text = null;
                txtpnlacAddress.ForeColor = Color.Black;
            }
        }
        private void txtpnlacContactNumber_Enter(object sender, EventArgs e)
        {
            toolTip5.Hide(txtpnlacContactNumber);
            txtpnlacContactNumber.TextChanged += txtpnlacContactNumber_TextChanged;
            if (txtpnlacContactNumber.Text == "Contact Number e.g., 09272727xxx")
            {
                txtpnlacContactNumber.Text = null;
                txtpnlacContactNumber.ForeColor = Color.Black;
            }
            txtpnlacContactNumber.SelectionStart = txtpnlacContactNumber.Text.Length;
        }

        private void txtpnlacFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlacFirstName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlacFirstName, 5, txtpnlacFirstName.Height - 1, 3000);
            }
        }

        private void txtpnlacMidName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlacMidName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlacMidName, 5, txtpnlacMidName.Height - 1, 3000);
            }
        }

        private void txtpnlacLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlacLastName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlacLastName, 5, txtpnlacLastName.Height - 1, 3000);
            }
        }

        private void txtpnlacContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlacContactNumber, 5, txtpnlacContactNumber.Height - 1, 3000);
            }
        }

        private void txtpnlacAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlacAddress.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != ','
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, (,) and (.) are only allowed.", txtpnlacAddress, 5, txtpnlacAddress.Height - 1, 3000);
            }
        }

        private void txtpnlacFirstName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlacMidName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlacLastName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlacContactNumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtpnlacContactNumber.Text.StartsWith("09"))
            {
                txtpnlacContactNumber.Text = "09";
                txtpnlacContactNumber.SelectionStart = txtpnlacContactNumber.Text.Length;
            }
        }

        private void txtpnlacAddress_TextChanged(object sender, EventArgs e)
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

        private void btnpnlacSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtpnlacFirstName.Text) || txtpnlacFirstName.Text == "Enter First Name e.g., Juan")
                || (string.IsNullOrWhiteSpace(txtpnlacMidName.Text) || txtpnlacMidName.Text == "Enter Middle Name e.g., Santos")
                || (string.IsNullOrWhiteSpace(txtpnlacLastName.Text) || txtpnlacLastName.Text == "Enter Last Name e.g., Dela Cruz")
                || (txtpnlacContactNumber.Text.Length <= 10 || txtpnlacContactNumber.Text == "Contact Number e.g., 09272727xxx")
                || (string.IsNullOrWhiteSpace(txtpnlacAddress.Text) || txtpnlacAddress.Text == "Enter Address e.g., Calaocan, San Jose City, Nueva Ecija"))
            {
                if (string.IsNullOrWhiteSpace(txtpnlacFirstName.Text) || txtpnlacFirstName.Text == "Enter First Name e.g., Juan")
                {
                    toolTip1.Show("Field is currently empty.", txtpnlacFirstName, 5, txtpnlacFirstName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtpnlacMidName.Text) || txtpnlacMidName.Text == "Enter Middle Name e.g., Santos")
                {
                    toolTip2.Show("Field is currently empty.", txtpnlacMidName, 5, txtpnlacMidName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtpnlacLastName.Text) || txtpnlacLastName.Text == "Enter Last Name e.g., Dela Cruz")
                {
                    toolTip3.Show("Field is currently empty.", txtpnlacLastName, 5, txtpnlacLastName.Height - 1, 3000);
                }
                if (txtpnlacContactNumber.Text == "Contact Number e.g., 09272727xxx")
                {
                    toolTip4.Show("Field is currently empty.", txtpnlacContactNumber, 5, txtpnlacContactNumber.Height - 1, 3000);
                }
                if (txtpnlacContactNumber.Text.Length <= 10)
                {
                    toolTip4.Show("Type in the 11 digit number e.g., 0935631xxxx", txtpnlacContactNumber, 5, txtpnlacContactNumber.Height - 1, 3000);
                }
                if (txtpnlacAddress.Text == "Enter Address e.g., Calaocan, San Jose City, Nueva Ecija")
                {
                    toolTip5.Show("Field is currently empty.", txtpnlacAddress, 5, txtpnlacAddress.Height - 1, 3000);
                }
                return;
            }
            else
            {
                FetchUpdatedClientsData();
                bool clientExist = clientsDataTable.Rows.Cast<DataRow>().Count(row => (row[1].ToString() == txtpnlacFirstName.Text) && row[2].ToString() == txtpnlacMidName.Text && row[3].ToString() == txtpnlacLastName.Text && row[4].ToString() == txtpnlacContactNumber.Text) > 0;
                Console.WriteLine("CLient Exist condition");
                if (clientExist)
                {
                    Console.WriteLine("Client Exist");
                    if (MessageBox.Show("Client already exist in database, Continue?", "Client Matched", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        bool processSuccess;
                        using (new RunProcess(pnlmfAddClient))
                        {
                            processSuccess = AddClient(txtpnlacFirstName.Text, txtpnlacMidName.Text, txtpnlacLastName.Text, txtpnlacContactNumber.Text, txtpnlacAddress.Text);
                        }
                        if (processSuccess)
                        {
                            Properties.Settings.Default.Counter_Client_ID = Properties.Settings.Default.Counter_Client_ID + 1;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            btnpnlacClear_Click(null, null);
                            MessageBox.Show("Client Susccessfully Added");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Client Not Exist");
                    bool processSuccess;
                    using (new RunProcess(pnlmfAddClient))
                    {
                        processSuccess = AddClient(txtpnlacFirstName.Text, txtpnlacMidName.Text, txtpnlacLastName.Text, txtpnlacContactNumber.Text, txtpnlacAddress.Text);
                        Console.WriteLine("processSuccess Done executing");
                    }
                    if (processSuccess)
                    {
                        Console.WriteLine("Process bool true");
                        Properties.Settings.Default.Counter_Client_ID = Properties.Settings.Default.Counter_Client_ID + 1;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();
                        btnpnlacClear_Click(null, null);
                        MessageBox.Show("Client Susccessfully Added");
                    }
                }
            }
        }

        private void btnpnlacClear_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblpnlacPanelName;
            txtpnlacClientID.Text = ("CID" + Properties.Settings.Default.Counter_Client_ID.ToString("D4"));
            txtpnlacFirstName.Text = null;
            txtpnlacFirstName_Leave(null, null);
            txtpnlacMidName.Text = null;
            txtpnlacMidName_Leave(null, null);
            txtpnlacLastName.Text = null;
            txtpnlacLastName_Leave(null, null);
            txtpnlacAddress.Text = null;
            txtpnlacAddress_Leave(null, null);
            txtpnlacContactNumber.TextChanged -= txtpnlacContactNumber_TextChanged;
            txtpnlacContactNumber.Text = null;
            txtpnlacContactNumber_Leave(null, null);
        }

        private void btnpnlacCancel_Click(object sender, EventArgs e)
        {
            btnpnlacClear_Click(null, null);
            pnlmfAddClient.Hide();
        }
        #endregion

        #region Search Client Panel
        private void btnmfSearchClient_Click(object sender, EventArgs e)
        {
            if (pnlmfSearchClient.Visible == false)
            {
                btnpnlscResetResult_Click(null, null);
                dvpnlscGridView.ClearSelection();
                cbpnlscSearchBy.SelectedIndex = 0;
                txtpnlscextContactNo.TextChanged -= txtpnlscextContactNo_TextChanged;
                this.ActiveControl = txtpnlscSearch;
                ShowPanel(pnlmfSearchClient);
            }
            else
            {
                pnlmfSearchClient.Hide();
            }
        }

        private void PopulateSearchClientDGV(int clientId, string firstName, string middleName, string lastName, string contactNumber, string address)
        {
            object[] row = { clientId, firstName + " " + middleName + " " + lastName, contactNumber, address };
            dvpnlscGridView.Rows.Add(row);
        }

        private void FillSearchClientDGV()
        {
            try
            {
                dvpnlscGridView.Rows.Clear();
                clientsDataTable.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Clients ORDER BY date_registered DESC, date_modified DESC";
                    using (clientsAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        clientsAdapter.Fill(clientsDataTable);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(clientsDataTable))
                {
                    if (dtbreader.HasRows)
                    {
                        dvpnlscGridView.Columns[0].ValueType = typeof(Int32);
                        foreach (DataRow row in clientsDataTable.Rows.Cast<DataRow>().Take(30))
                        {
                            PopulateSearchClientDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                        }
                        btnpnlscSearch.Enabled = true;
                        btnpnlscEditClient.Enabled = true;
                    }
                    else
                    {
                        btnpnlscSearch.Enabled = false;
                        btnpnlscEditClient.Enabled = false;
                        dvpnlscGridView.Rows.Add("0", "NO RECORDS");
                        dvpnlscGridView.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvpnlscGridView.ClearSelection();
            }
        }

        private bool UpdateClient(int clientID, string firstName, string middleName, string lastName, string contactNumber, string address)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "UPDATE Clients SET first_name = ?, middle_name = ?, last_name = ?, contact_number = ?, address = ?, date_modified = ? WHERE client_id = ?";
                    using (clientsAdapter.UpdateCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.UpdateCommand.Parameters.Clear();
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", firstName);
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", middleName);
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", lastName);
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", contactNumber);
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", address);
                        clientsAdapter.UpdateCommand.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        clientsAdapter.UpdateCommand.Parameters.AddWithValue("?", clientID);
                        if (clientsAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Update Client", firstName + " " + lastName);
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

        private bool DeleteClient(int clientID, string firstName, string lastName)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM Clients WHERE client_id = ?";
                    using (clientsAdapter.DeleteCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.DeleteCommand.Parameters.Clear();
                        clientsAdapter.DeleteCommand.Parameters.AddWithValue("?", clientID);
                        if (clientsAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Delete Client", firstName + " " + lastName);
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

        private void pnlmfSearchClient_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfSearchClient.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void pnlscextEditClient_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlscextEditClient.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlscSearch_Leave(object sender, EventArgs e)
        {
            if (txtpnlscSearch.Text == "")
            {
                txtpnlscSearch.Text = "Type In Client Information";
                txtpnlscSearch.ForeColor = Color.DarkGray;
            }
        }

        private void txtpnlscSearch_Enter(object sender, EventArgs e)
        {
            if (txtpnlscSearch.Text == "Type In Client Information")
            {
                txtpnlscSearch.Text = null;
                txtpnlscSearch.ForeColor = Color.Black;
            }
        }

        private void txtpnlscSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbpnlscSearchBy.Text == "Search by ID No.")
            {
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsDigit(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                    toolTip.Show("Numbers 0-9 are only allowed.", txtpnlscSearch, 5, txtpnlscSearch.Height - 1, 3000);
                }
            }
            else
            {
                if (txtpnlscSearch.Text.Length == 0 && e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsLetter(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back
                    && e.KeyChar != (char)Keys.Space)
                {
                    e.Handled = true;
                    toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlscSearch, 5, txtpnlscSearch.Height - 1, 3000);
                }
            }
        }

        private void txtpnlscSearch_TextChanged(object sender, EventArgs e)
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

        int currentClientId;
        string currentClientFirstName;
        string currentClientMiddleName;
        string currentClientLastName;
        string currentClientContactNumber;
        string currentClientAddress;

        private void populateSearchClientExtension()
        {
            txtpnlscextContactNo.TextChanged -= txtpnlscextContactNo_TextChanged;
            txtpnlscextContactNo.TextChanged += txtpnlscextContactNo_TextChanged;
            currentClientId = Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value);
            currentClientFirstName = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[1]).FirstOrDefault();
            currentClientMiddleName = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[2]).FirstOrDefault();
            currentClientLastName = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[3]).FirstOrDefault();
            currentClientContactNumber = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[4]).FirstOrDefault();
            currentClientAddress = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvpnlscGridView.Rows[dvpnlscGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[5]).FirstOrDefault();
            txtpnlscextFirstName.Text = currentClientFirstName;
            txtpnlscextMidName.Text = currentClientMiddleName;
            txtpnlscextLastName.Text = currentClientLastName;
            txtpnlscextContactNo.Text = currentClientContactNumber;
            txtpnlscextAddress.Text = currentClientAddress;
            EnableEditClient(false);
        }

        private void EnableEditClient(bool condition)
        {
            if (condition)
            {
                btnpnlscextUpdate.Show();
                btnpnlscextDelete.Show();
                txtpnlscextFirstName.Enabled = true;
                txtpnlscextMidName.Enabled = true;
                txtpnlscextLastName.Enabled = true;
                txtpnlscextContactNo.Enabled = true;
                txtpnlscextAddress.Enabled = true;
            }
            else
            {
                btnpnlscextEdit.Enabled = true;
                btnpnlscextUpdate.Hide();
                btnpnlscextDelete.Hide();
                txtpnlscextFirstName.Enabled = false;
                txtpnlscextMidName.Enabled = false;
                txtpnlscextLastName.Enabled = false;
                txtpnlscextContactNo.Enabled = false;
                txtpnlscextAddress.Enabled = false;
            }
        }

        private void dvpnlscGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvpnlscGridView.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                populateSearchClientExtension();
                this.ActiveControl = txtpnlscSearch;
                if (cbpnlscSearchBy.Text == "Search by ID No.")
                {
                    txtpnlscSearch.Text = currentClientId.ToString();
                }
                else
                {
                    txtpnlscSearch.Text = currentClientFirstName + " " + currentClientMiddleName + " " + currentClientLastName;
                }
            }
        }

        private void txtpnlscextFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlscextFirstName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlscextFirstName, 5, txtpnlscextFirstName.Height - 1, 3000);
            }
        }

        private void txtpnlscextMidName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlscextMidName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlscextMidName, 5, txtpnlscextMidName.Height - 1, 3000);
            }
        }

        private void txtpnlscextLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlscextLastName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlscextLastName, 5, txtpnlscextLastName.Height - 1, 3000);
            }
        }

        private void txtpnlscextContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlscextContactNo, 5, txtpnlscextContactNo.Height - 1, 3000);
            }
        }

        private void txtpnlscextAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlscextAddress.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != ','
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, (,) and (.) are only allowed.", txtpnlscextAddress, 5, txtpnlscextAddress.Height - 1, 3000);
            }
        }

        private void txtpnlscextFirstName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlscextMidName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlscextLastName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlscextContactNo_TextChanged(object sender, EventArgs e)
        {
            if (!txtpnlscextContactNo.Text.StartsWith("09"))
            {
                txtpnlscextContactNo.Text = "09";
                txtpnlscextContactNo.SelectionStart = txtpnlscextContactNo.Text.Length;
            }
        }

        private void txtpnlscextAddress_TextChanged(object sender, EventArgs e)
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

        private void cbpnlscSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlscSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtpnlscSearch.Text = null;
            txtpnlscSearch_Leave(null, null);
        }

        private void btnpnlscSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnlscSearch.Text) || txtpnlscSearch.Text == "Type In Client Information")
            {
                toolTip.Show("Field is currently empty.", txtpnlscSearch, txtpnlscSearch.Width - 140, txtpnlscSearch.Height - 1, 3000);
                return;
            }
            else
            {
                dvpnlscGridView.Rows.Clear();
                if (cbpnlscSearchBy.Text == "Search by ID No.")
                {
                    foreach (DataRow row in clientsDataTable.Select("Convert(client_id, 'System.String') LIKE '" + txtpnlscSearch.Text + "%'", "client_id ASC").Cast<DataRow>().Take(30))
                    {
                        PopulateSearchClientDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }
                }
                else if (cbpnlscSearchBy.Text == "Search by Name")
                {
                    foreach (DataRow row in clientsDataTable.Select("first_name LIKE '%" + txtpnlscSearch.Text + "%' OR middle_name LIKE '%" + txtpnlscSearch.Text + "%' OR last_name LIKE '%" + txtpnlscSearch.Text + "%'").Cast<DataRow>().Take(10))
                    {
                        PopulateSearchClientDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }
                }
                dvpnlscGridView.ClearSelection();
            }
        }

        private void btnpnlscResetResult_Click(object sender, EventArgs e)
        {
            FillSearchClientDGV();
            txtpnlscSearch.Text = null;
            txtpnlscSearch_Leave(null, null);
            cbpnlscSearchBy.SelectedIndex = 0;
        }

        private void btnpnlscEditClient_Click(object sender, EventArgs e)
        {
            if (dvpnlscGridView.SelectedRows.Count > 0)
            {
                HideMainFormButtons();
                populateSearchClientExtension();
                pnlscextEditClient.Show();
            }
        }

        private void btnpnlscHistory_Click(object sender, EventArgs e)
        {
            if (dvpnlscGridView.SelectedRows.Count > 0)
            {
                populateSearchClientExtension();
                string clientTable = string.Format("CID{0}", currentClientId.ToString("D4"));
                string clientName = currentClientFirstName + " " + currentClientMiddleName + " " + currentClientLastName;
                using (new RunProcess(pnlmfSearchClient, false))
                {
                    ClientHistoryForm chf = new ClientHistoryForm(clientTable, clientName);
                    chf.ShowDialog();
                }
            }
        }

        private void btnpnlscDone_Click(object sender, EventArgs e)
        {
            ShowMainFormButtons();
            pnlmfSearchClient.Hide();
            pnlscextEditClient.Hide();
        }

        private void btnpnlscextEdit_Click(object sender, EventArgs e)
        {
            btnpnlscextUpdate.Show();
            btnpnlscextDelete.Show();
            txtpnlscextFirstName.Enabled = true;
            txtpnlscextMidName.Enabled = true;
            txtpnlscextLastName.Enabled = true;
            txtpnlscextContactNo.Enabled = true;
            txtpnlscextAddress.Enabled = true;
        }

        private void btnpnlscextUpdate_Click(object sender, EventArgs e)
        {
            if (txtpnlscextFirstName.Text == currentClientFirstName
                && txtpnlscextMidName.Text == currentClientMiddleName
                && txtpnlscextLastName.Text == currentClientLastName
                && txtpnlscextContactNo.Text == currentClientContactNumber
                && txtpnlscextAddress.Text == currentClientAddress)
            {
                MessageBox.Show("No changes were made.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtpnlscextFirstName.Text)
                || string.IsNullOrWhiteSpace(txtpnlscextMidName.Text)
                || string.IsNullOrWhiteSpace(txtpnlscextLastName.Text)
                || (txtpnlscextContactNo.Text.Length <= 10)
                || string.IsNullOrWhiteSpace(txtpnlscextAddress.Text))
            {
                if (string.IsNullOrWhiteSpace(txtpnlscextFirstName.Text))
                {
                    toolTip1.Show("Field is currently empty.", txtpnlscextFirstName, 5, txtpnlscextFirstName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtpnlscextMidName.Text))
                {
                    toolTip2.Show("Field is currently empty.", txtpnlscextMidName, 5, txtpnlscextMidName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtpnlscextLastName.Text))
                {
                    toolTip3.Show("Field is currently empty.", txtpnlscextLastName, 5, txtpnlscextLastName.Height - 1, 3000);
                }
                if (txtpnlscextContactNo.Text.Length <= 10)
                {
                    toolTip4.Show("Type in your 11 digit number e.g., 0935631xxxx", txtpnlscextContactNo, 5, txtpnlscextContactNo.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtpnlscextAddress.Text))
                {
                    toolTip4.Show("Field is currently empty.", txtpnlscextAddress, 5, txtpnlscextAddress.Height - 1, 3000);
                }
                return;
            }
            else
            {
                bool processSuccess;
                using (new RunProcess(pnlscextEditClient))
                {
                    processSuccess = UpdateClient(currentClientId, txtpnlscextFirstName.Text, txtpnlscextMidName.Text, txtpnlscextLastName.Text, txtpnlscextContactNo.Text, txtpnlscextAddress.Text);
                }
                if (processSuccess)
                {
                    FillSearchClientDGV();
                    txtpnlscextFirstName.Text = null;
                    txtpnlscextMidName.Text = null;
                    txtpnlscextLastName.Text = null;
                    txtpnlscextContactNo.TextChanged -= txtpnlscextContactNo_TextChanged;
                    txtpnlscextContactNo.Text = null;
                    txtpnlscextAddress.Text = null;
                    btnpnlscextEdit.Enabled = false;
                    EnableEditClient(false);
                    MessageBox.Show("Client Information Updated.");
                }
            }
        }

        private void btnpnlscextDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete.", "Deleting Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool processResult;
                using (new RunProcess(pnlscextEditClient))
                {
                    processResult = DeleteClient(currentClientId, (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == currentClientId select (string)dr[1]).FirstOrDefault(), (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == currentClientId select (string)dr[3]).FirstOrDefault());
                }
                if (processResult)
                {
                    FillSearchClientDGV();
                    txtpnlscextFirstName.Text = null;
                    txtpnlscextMidName.Text = null;
                    txtpnlscextLastName.Text = null;
                    txtpnlscextContactNo.TextChanged -= txtpnlscextContactNo_TextChanged;
                    txtpnlscextContactNo.Text = null;
                    txtpnlscextAddress.Text = null;
                    btnpnlscextEdit.Enabled = false;
                    EnableEditClient(false);
                    MessageBox.Show("Client Successfully Deleted.");
                }
            }
        }

        private void btnpnlscextCancel_Click(object sender, EventArgs e)
        {
            if (btnpnlscextUpdate.Visible == true)
            {
                txtpnlscextFirstName.Text = currentClientFirstName;
                txtpnlscextMidName.Text = currentClientMiddleName;
                txtpnlscextLastName.Text = currentClientLastName;
                txtpnlscextContactNo.Text = currentClientContactNumber;
                txtpnlscextAddress.Text = currentClientAddress;
                EnableEditClient(false);
            }
            else
            {
                ShowMainFormButtons();
                pnlscextEditClient.Hide();
                btnpnlscextUpdate.Hide();
                btnpnlscextDelete.Hide();
                txtpnlscextFirstName.Enabled = false;
                txtpnlscextMidName.Enabled = false;
                txtpnlscextLastName.Enabled = false;
                txtpnlscextContactNo.Enabled = false;
                txtpnlscextAddress.Enabled = false;
            }
        }

        #endregion

        #region Add Books Panel
        private void btnmfAddBooks_Click(object sender, EventArgs e)
        {
            if (!(accountType == "Administrator"))
            {
                MessageBox.Show("You do not have the authority to access this function.");
                return;
            }
            else
            {
                if (pnlmfAddBooks.Visible == false)
                {
                    FillAddBooksCbPub();
                    FillAddBooksCbCat();
                    txtpnlabAccessNo.Text = ("BID" + Properties.Settings.Default.Counter_Access_Number.ToString("D4"));
                    cbpnlabYearPublished.SelectedIndex = 0;
                    cbpnlabVolume.SelectedIndex = 0;
                    txtpnlabPrice.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                    cbpnlabClassification.SelectedIndex = 0;
                    btnpnleCancel.Text = "Done";
                    HideMainFormButtons();
                    this.ActiveControl = txtpnlabBookTitle;
                    ShowPanel(pnlmfAddBooks);
                }
                else
                {
                    ShowMainFormButtons();
                    pnlmfAddBooks.Hide();
                }
            }
        }

        private void FillAddBooksCbPub()
        {
            try
            {
                cbpnlabPublisher.Items.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT book_publishers FROM BookPublishers ORDER BY book_publishers ASC";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        using (OleDbDataReader dbreader = cmd.ExecuteReader())
                        {
                            if (dbreader.HasRows)
                            {
                                while (dbreader.Read())
                                {
                                    cbpnlabPublisher.Items.Add(dbreader["book_publishers"].ToString());
                                }
                                cbpnlabPublisher.Enabled = true;
                                cbpnlabPublisher.SelectedIndex = 0;
                                btnpnlabRemovePubIcon.Show();
                            }
                            else
                            {
                                cbpnlabPublisher.Enabled = false;
                                btnpnlabRemovePubIcon.Hide();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FillAddBooksCbCat()
        {
            try
            {
                cbpnlabCategory.Items.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT book_categories FROM BookCategories ORDER BY book_categories ASC";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        using (OleDbDataReader dbreader = cmd.ExecuteReader())
                        {
                            if (dbreader.HasRows)
                            {
                                while (dbreader.Read())
                                {
                                    cbpnlabCategory.Items.Add(dbreader["book_categories"].ToString());
                                }
                                cbpnlabCategory.Enabled = true;
                                cbpnlabCategory.SelectedIndex = 0;
                                btnpnlabRemoveCatIcon.Show();
                            }
                            else
                            {
                                btnpnlabRemoveCatIcon.Hide();
                                cbpnlabCategory.Enabled = false;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool AddABEBPub(string publisher)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO BookPublishers (book_publishers) VALUES (?)";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("?", publisher);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
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

        private bool AddABEBCat(string category)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO BookCategories (book_categories) VALUES (?)";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("?", category);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
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

        private bool DeleteABEBPub(string publisher)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqluery = "DELETE FROM BookPublishers WHERE book_publishers = ?";
                    using (cmd = new OleDbCommand(sqluery, con))
                    {
                        cmd.Parameters.AddWithValue("?", publisher);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
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

        private bool DeleteABEBCat(string category)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM BookCategories WHERE book_category = ?";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("?", category);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
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

        private int AddBooks(string bookTitle, string bookAuthor, string bookPublisher, int bookYearPublished, int bookVolume, string bookCategory, int bookNumberOfPages, string[] bookClassification, decimal bookPrice, int bookQuantity)
        {
            int bookCount = 0;
            try
            {
                string sqlQuery = "INSERT INTO Books (book_title, author, publisher, year_published, volume, pages, category, classification, price, date_added, status) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (booksAdapter.InsertCommand = new OleDbCommand(sqlQuery, con))
                    {
                        booksAdapter.InsertCommand.Parameters.Clear();
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookTitle);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookAuthor);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookPublisher);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookYearPublished);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookVolume);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookNumberOfPages);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookCategory);
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", bookClassification[0]);
                        booksAdapter.InsertCommand.Parameters.Add("?", OleDbType.Decimal).Value = bookPrice;
                        booksAdapter.InsertCommand.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        booksAdapter.InsertCommand.Parameters.AddWithValue("?", "Available");
                        for (int i = 0; i < bookQuantity; i++)
                        {
                            try
                            {
                                if (booksAdapter.InsertCommand.ExecuteNonQuery() > 0)
                                {
                                    SaveToLog("Add Book", bookTitle);
                                    Properties.Settings.Default.Counter_Access_Number = Properties.Settings.Default.Counter_Access_Number + 1;
                                    Properties.Settings.Default.Save();
                                    Properties.Settings.Default.Reload();
                                    bookCount += 1;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return bookCount;
        }

        private void pnlmfAddBooks_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfAddBooks.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlabPrice_Enter(object sender, EventArgs e)
        {
            txtpnlabPrice_TextChanged(null, null);
        }

        private void txtpnlabPrice_Leave(object sender, EventArgs e)
        {
            if (txtpnlabPrice.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtpnlabPrice.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
            {
                txtpnlabPrice.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                return;
            }
            else
            {
                txtpnlabPrice.Text = Convert.ToDecimal(txtpnlabPrice.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtpnlabQuantity_Leave(object sender, EventArgs e)
        {
            if (txtpnlabQuantity.Text.StartsWith("0"))
            {
                txtpnlabQuantity.Text = txtpnlabQuantity.Text.TrimStart('0');
            }
        }

        private void txtpnlabBookTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlabBookTitle.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '~' && e.KeyChar != '!'
                && e.KeyChar != '@' && e.KeyChar != '#'
                && e.KeyChar != '$' && e.KeyChar != '%'
                && e.KeyChar != '^' && e.KeyChar != '&'
                && e.KeyChar != '*' && e.KeyChar != '('
                && e.KeyChar != ')' && e.KeyChar != '-'
                && e.KeyChar != '_' && e.KeyChar != '='
                && e.KeyChar != '+' && e.KeyChar != ':'
                && e.KeyChar != ';' && e.KeyChar != '\''
                && e.KeyChar != '"' && e.KeyChar != ','
                && e.KeyChar != '.' && e.KeyChar != '?')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9 and Alphanumeric are only allowed.", txtpnlabBookTitle, 5, txtpnlabBookTitle.Height - 1, 3000);
            }
        }

        private void txtpnlabAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlabAuthor.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '~' && e.KeyChar != '!'
                && e.KeyChar != '@' && e.KeyChar != '#'
                && e.KeyChar != '$' && e.KeyChar != '%'
                && e.KeyChar != '^' && e.KeyChar != '&'
                && e.KeyChar != '*' && e.KeyChar != '('
                && e.KeyChar != ')' && e.KeyChar != '-'
                && e.KeyChar != '_' && e.KeyChar != '='
                && e.KeyChar != '+' && e.KeyChar != ':'
                && e.KeyChar != ';' && e.KeyChar != '\''
                && e.KeyChar != '"' && e.KeyChar != ','
                && e.KeyChar != '.' && e.KeyChar != '?')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9 and Alphanumeric are only allowed.", txtpnlabAuthor, 5, txtpnlabAuthor.Height - 1, 3000);
            }
        }

        private void txtpnlabPublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlabPublisher.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '~' && e.KeyChar != '!'
                && e.KeyChar != '@' && e.KeyChar != '#'
                && e.KeyChar != '$' && e.KeyChar != '%'
                && e.KeyChar != '^' && e.KeyChar != '&'
                && e.KeyChar != '*' && e.KeyChar != '('
                && e.KeyChar != ')' && e.KeyChar != '-'
                && e.KeyChar != '_' && e.KeyChar != '='
                && e.KeyChar != '+' && e.KeyChar != ':'
                && e.KeyChar != ';' && e.KeyChar != '\''
                && e.KeyChar != '"' && e.KeyChar != ','
                && e.KeyChar != '.' && e.KeyChar != '?')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9 and Alphanumeric are only allowed.", txtpnlabPublisher, 5, txtpnlabPublisher.Height - 1, 3000);
            }
        }

        private void txtpnlabCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlabCategory.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlabCategory, 5, txtpnlabCategory.Height - 1, 3000);
            }
        }

        private void txtpnlabNumberOfPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlabNumberOfPages, 5, txtpnlabNumberOfPages.Height - 1, 3000);
            }
        }

        private void txtpnlabPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 and (.) are only allowed.", txtpnlabPrice, 5, txtpnlabPrice.Height - 1, 3000);
            }
        }

        private void txtpnlabQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(txtpnlabQuantity.Text.Length) < 1 && e.KeyChar == (char)Keys.D0)
            {
                e.Handled = true;
            }

            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
            }
        }

        private void txtpnlabBookTitle_TextChanged(object sender, EventArgs e)
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

        private void txtpnlabAuthor_TextChanged(object sender, EventArgs e)
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

        private void txtpnlabPublisher_TextChanged(object sender, EventArgs e)
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

        private void txtpnlabCategory_TextChanged(object sender, EventArgs e)
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

        private void txtpnlabPrice_TextChanged(object sender, EventArgs e)
        {
            if (!txtpnlabPrice.Text.StartsWith(cultureCurrencySymbol))
            {
                txtpnlabPrice.Text = cultureCurrencySymbol + txtpnlabPrice.Text;
                txtpnlabPrice.SelectionStart = cultureCurrencySymbol.Length;
            }

            if (txtpnlabPrice.Text == cultureCurrencySymbol || txtpnlabPrice.Text == cultureCurrencySymbol + "0")
            {
                txtpnlabPrice.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void cbpnlabPublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlabYearPublished_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlabVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlabCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlabClassification_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnlabClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabSubClass);
            cbpnlabSubClass.Items.Clear();
            //Library of Congress Classifications
            if (cbpnlabClassification.Text == "A")
            {
                cbpnlabSubClass.Items.Add("A. General Works");
                cbpnlabSubClass.Items.Add("AC. Collections");
                cbpnlabSubClass.Items.Add("AE. Encyclopedias");
                cbpnlabSubClass.Items.Add("AG. Dictionaries & General Reference Works");
                cbpnlabSubClass.Items.Add("AI. Indexes");
                cbpnlabSubClass.Items.Add("AM. Museums");
                cbpnlabSubClass.Items.Add("AN. Newspapers");
                cbpnlabSubClass.Items.Add("AP. Periodicals");
                cbpnlabSubClass.Items.Add("AS. Academies, Societies");
                cbpnlabSubClass.Items.Add("AY. Yearbooks, Almanacs, Business Directories");
                cbpnlabSubClass.Items.Add("AZ. General History of Scholarship & Learning");
            }
            else if (cbpnlabClassification.Text == "B")
            {
                cbpnlabSubClass.Items.Add("B. Philosophy (General)");
                cbpnlabSubClass.Items.Add("BC. Logic");
                cbpnlabSubClass.Items.Add("BD. Speculative Philosophy");
                cbpnlabSubClass.Items.Add("BF. Physcology");
                cbpnlabSubClass.Items.Add("BH. Aesthetics");
                cbpnlabSubClass.Items.Add("BJ. Ethics");
                cbpnlabSubClass.Items.Add("BL. Religions, Mythology, Rationalism");
                cbpnlabSubClass.Items.Add("BM. Judaism");
                cbpnlabSubClass.Items.Add("BP. Islam, Bahaism, Theosophy etc.");
                cbpnlabSubClass.Items.Add("BQ. Buddhism");
                cbpnlabSubClass.Items.Add("BR. Christianity");
                cbpnlabSubClass.Items.Add("BS. The Bible");
                cbpnlabSubClass.Items.Add("BT. Doctrinal Theology");
                cbpnlabSubClass.Items.Add("BV. Practical Theology");
                cbpnlabSubClass.Items.Add("BX. Christian Denominations");
            }
            else if (cbpnlabClassification.Text == "C")
            {
                cbpnlabSubClass.Items.Add("C. Auxiliary Sciences of History");
                cbpnlabSubClass.Items.Add("CB. History of Civilization");
                cbpnlabSubClass.Items.Add("CC. Archaeology");
                cbpnlabSubClass.Items.Add("CD. Diplomatics, Archives, Seals");
                cbpnlabSubClass.Items.Add("CE. Technical Chronology, Calendar");
                cbpnlabSubClass.Items.Add("CJ. Numismatics (Coins, Tokes, Medallions)");
                cbpnlabSubClass.Items.Add("CN. Inscriptions, Epigraphy");
                cbpnlabSubClass.Items.Add("CR. Heraldry");
                cbpnlabSubClass.Items.Add("CS. Genealogy");
                cbpnlabSubClass.Items.Add("CT. Biography");
            }
            else if (cbpnlabClassification.Text == "D")
            {
                cbpnlabSubClass.Items.Add("D. History (General)");
                cbpnlabSubClass.Items.Add("DA. Great Britain");
                cbpnlabSubClass.Items.Add("DAW. Central Europe");
                cbpnlabSubClass.Items.Add("DB. Austria, Liechtenstein, Hungary, Czechoslovakia");
                cbpnlabSubClass.Items.Add("DC. France, Andorra, Monaco");
                cbpnlabSubClass.Items.Add("DD. Germany");
                cbpnlabSubClass.Items.Add("DE. Greco-Roman World");
                cbpnlabSubClass.Items.Add("DF. Greece");
                cbpnlabSubClass.Items.Add("DG. Italy. Malta");
                cbpnlabSubClass.Items.Add("DH. Low Countries. Benelux Countries");
                cbpnlabSubClass.Items.Add("DJ. Netherlands (Holland)");
                cbpnlabSubClass.Items.Add("DJK. Eastern Europe (General)");
                cbpnlabSubClass.Items.Add("DK. Russia, Soviet Union, Former Soviet Republics, Poland");
                cbpnlabSubClass.Items.Add("DL. Northern Europe. Scandinavia");
                cbpnlabSubClass.Items.Add("DP. Spain. Portugal");
                cbpnlabSubClass.Items.Add("DQ. Switzerland");
                cbpnlabSubClass.Items.Add("DR. Balkan Peninsula");
                cbpnlabSubClass.Items.Add("DS. Asia");
                cbpnlabSubClass.Items.Add("DT. Africa");
                cbpnlabSubClass.Items.Add("DU. Oceania (South Seas)");
                cbpnlabSubClass.Items.Add("DX. Romanies");
            }
            else if (cbpnlabClassification.Text == "E")
            {
                cbpnlabSubClass.Items.Add("E. History of America");
            }
            else if (cbpnlabClassification.Text == "F")
            {
                cbpnlabSubClass.Items.Add("F. Local History of the Americas");
            }
            else if (cbpnlabClassification.Text == "G")
            {
                cbpnlabSubClass.Items.Add("G. Geography (General), Atlases, Maps");
                cbpnlabSubClass.Items.Add("GA. Mathematical Geography, Cartography");
                cbpnlabSubClass.Items.Add("GB. Physical Geography");
                cbpnlabSubClass.Items.Add("GC. Oceanography");
                cbpnlabSubClass.Items.Add("GE. Environmental Sciences");
                cbpnlabSubClass.Items.Add("GF. Human Ecology, Anthropogeography");
                cbpnlabSubClass.Items.Add("GN. Anthropology");
                cbpnlabSubClass.Items.Add("GR. Folklore");
                cbpnlabSubClass.Items.Add("GT. Manners and Customs (General)");
                cbpnlabSubClass.Items.Add("GV. Recreation, Leisure");
            }
            else if (cbpnlabClassification.Text == "H")
            {
                cbpnlabSubClass.Items.Add("H. Social sciences (General)");
                cbpnlabSubClass.Items.Add("HA. Statistics");
                cbpnlabSubClass.Items.Add("HB. Economic Theory, Demography");
                cbpnlabSubClass.Items.Add("HC. Economic History & Conditions");
                cbpnlabSubClass.Items.Add("HD. Industries, Land Use, Labor");
                cbpnlabSubClass.Items.Add("HE. Transportation & Communications");
                cbpnlabSubClass.Items.Add("HF. Commerce");
                cbpnlabSubClass.Items.Add("HG. Finance");
                cbpnlabSubClass.Items.Add("HJ. Public Finance");
                cbpnlabSubClass.Items.Add("HM. Sociology (General)");
                cbpnlabSubClass.Items.Add("HN. Social History & Conditions, Social problems, Social Reform");
                cbpnlabSubClass.Items.Add("HQ. The Family. Marriage, Women & Sexuality");
                cbpnlabSubClass.Items.Add("HS. Societies: Secret, Benevolent, etc.");
                cbpnlabSubClass.Items.Add("HT. Communities. Classes, Races");
                cbpnlabSubClass.Items.Add("HV. Social Pathology, Social & Public Welfare, Criminology");
                cbpnlabSubClass.Items.Add("HX. Socialism, Communism, Anarchism");
            }
            else if (cbpnlabClassification.Text == "J")
            {
                cbpnlabSubClass.Items.Add("J. General Legislative & Executive Papers");
                cbpnlabSubClass.Items.Add("JA. Political Science (General)");
                cbpnlabSubClass.Items.Add("JC. Political Theory");
                cbpnlabSubClass.Items.Add("JF. Political Institutions & Public Administration");
                cbpnlabSubClass.Items.Add("JJ. Political Institutions & Public Administration (North America)");
                cbpnlabSubClass.Items.Add("JK. Political Institutions & Public Administration (United States)");
                cbpnlabSubClass.Items.Add("JL. Political Institutions & Public Administration (Canada, Latin America, etc.)");
                cbpnlabSubClass.Items.Add("JN. Political Institutions & Public Administration (Europe)");
                cbpnlabSubClass.Items.Add("JQ. Political Institutions & Public Administration (Asia, Africa, Pacific Area, etc.)");
                cbpnlabSubClass.Items.Add("JS. Local Government, Municipal Government");
                cbpnlabSubClass.Items.Add("JV. Colonies & Colonization, Emigration & Immigration, International Migration");
                cbpnlabSubClass.Items.Add("JX. International Law");
                cbpnlabSubClass.Items.Add("JZ. International Relations");
            }
            else if (cbpnlabClassification.Text == "K")
            {
                cbpnlabSubClass.Items.Add("K. General Law, Comparative & Uniform Law, Jurisprudence");
                cbpnlabSubClass.Items.Add("KB. General Religious Law, Comparative Religious Law, Jurisprudence");
                cbpnlabSubClass.Items.Add("KBM. Jewish Law");
                cbpnlabSubClass.Items.Add("KBP. Islamic Law");
                cbpnlabSubClass.Items.Add("KBR. History of Canon Law");
                cbpnlabSubClass.Items.Add("KBS. Canon Law of Eastern Churches");
                cbpnlabSubClass.Items.Add("KBT. Canon Law of Eastern Rite Churches in Communion with the Holy See of Rome");
                cbpnlabSubClass.Items.Add("KBU. Law of the Roman Catholic Church. The Holy See");
                cbpnlabSubClass.Items.Add("KD/KDK - United Kingdom & Ireland");
                cbpnlabSubClass.Items.Add("KDZ. America, North America");
                cbpnlabSubClass.Items.Add("KE. Canada");
                cbpnlabSubClass.Items.Add("KF. United States");
                cbpnlabSubClass.Items.Add("KG. Latin America, Mexico & Central America, West Indies, Caribbean Area");
                cbpnlabSubClass.Items.Add("KH. South America");
                cbpnlabSubClass.Items.Add("KJ-KKZ. Europe");
                cbpnlabSubClass.Items.Add("KL-KWX. Asia & Eurasia, Africa, Pacific Area, & Antarctica");
                cbpnlabSubClass.Items.Add("KU/KUQ. Law of Australia & New Zealand");
                cbpnlabSubClass.Items.Add("KZ. Law of Nations");
            }
            else if (cbpnlabClassification.Text == "L")
            {
                cbpnlabSubClass.Items.Add("L. Education (General)");
                cbpnlabSubClass.Items.Add("LA. History of Education");
                cbpnlabSubClass.Items.Add("LB. Theory & Practice of Education");
                cbpnlabSubClass.Items.Add("LC. Special Aspects of Education");
                cbpnlabSubClass.Items.Add("LD. Individual Institutions. United States");
                cbpnlabSubClass.Items.Add("LE. Individual Institutions. America (except U.S.)");
                cbpnlabSubClass.Items.Add("LF. Individual Institutions. Europe");
                cbpnlabSubClass.Items.Add("LG. Individual Inst.. Asia, Africa, Indian Ocean Islands, Australia, New Zealand, Pacific Islands");
                cbpnlabSubClass.Items.Add("LH. College & School Magazines & Papers");
                cbpnlabSubClass.Items.Add("LJ. Student Fraternities & Societies, United States");
                cbpnlabSubClass.Items.Add("LT. Textbooks");
            }
            else if (cbpnlabClassification.Text == "M")
            {
                cbpnlabSubClass.Items.Add("M. Music");
                cbpnlabSubClass.Items.Add("ML. Literature on Music");
                cbpnlabSubClass.Items.Add("MT. Instruction & Study");
            }
            else if (cbpnlabClassification.Text == "N")
            {
                cbpnlabSubClass.Items.Add("N. Visual Arts");
                cbpnlabSubClass.Items.Add("NA. Architecture");
                cbpnlabSubClass.Items.Add("NB. Sculpture");
                cbpnlabSubClass.Items.Add("NC. Drawing, Design, Illustration");
                cbpnlabSubClass.Items.Add("ND. Painting");
                cbpnlabSubClass.Items.Add("NE. Print Media");
                cbpnlabSubClass.Items.Add("NK. Decorative Arts");
                cbpnlabSubClass.Items.Add("NX. Arts in General");
            }
            else if (cbpnlabClassification.Text == "P")
            {
                cbpnlabSubClass.Items.Add("P. Philology, Linguistics");
                cbpnlabSubClass.Items.Add("PA. Greek Language & Literature, Latin Language & Literature");
                cbpnlabSubClass.Items.Add("PB. Modern Languages, Celtic Languages & Literature");
                cbpnlabSubClass.Items.Add("PC. Romanic Languages");
                cbpnlabSubClass.Items.Add("PD. Germanic Languages, Scandinavian Languages");
                cbpnlabSubClass.Items.Add("PE. English Language");
                cbpnlabSubClass.Items.Add("PF. West Germanic Languages");
                cbpnlabSubClass.Items.Add("PG. Slavic Languages & Literatures, Baltic Languages, Albanian Language");
                cbpnlabSubClass.Items.Add("PH. Uralic Languages, Basque Language");
                cbpnlabSubClass.Items.Add("PJ. Oriental Languages & Literatures");
                cbpnlabSubClass.Items.Add("PK. Indo-Iranian Languages & Literatures");
                cbpnlabSubClass.Items.Add("PL. Languages & Literatures of Eastern Asia, Africa, Oceania");
                cbpnlabSubClass.Items.Add("PM. Hyperborean, Native American, & Artificial Languages");
                cbpnlabSubClass.Items.Add("PN. Literature (General)");
                cbpnlabSubClass.Items.Add("PQ. French, Italian , Spanish, and Portuguese Literatures");
                cbpnlabSubClass.Items.Add("PR. English Literature");
                cbpnlabSubClass.Items.Add("PS. American Literature");
                cbpnlabSubClass.Items.Add("PT. German, Dutch, Flemish, Afrikaans, Scandinavian, Old Norse, Old Icelandic & Old Norwegian, Modern Icelandic, Faroese, Danish, Norwegian and Swedish Literatures");
                cbpnlabSubClass.Items.Add("PZ. Fiction & Juvenile Belles Lettres");
            }
            else if (cbpnlabClassification.Text == "Q")
            {
                cbpnlabSubClass.Items.Add("Q. Science (General)");
                cbpnlabSubClass.Items.Add("QA. Mathematics");
                cbpnlabSubClass.Items.Add("QB. Astronomy");
                cbpnlabSubClass.Items.Add("QC. Physics");
                cbpnlabSubClass.Items.Add("QD. Chemistry");
                cbpnlabSubClass.Items.Add("QE. Geology");
                cbpnlabSubClass.Items.Add("QH. Natural History, Biology");
                cbpnlabSubClass.Items.Add("QK. Botany");
                cbpnlabSubClass.Items.Add("QL. Zoology");
                cbpnlabSubClass.Items.Add("QM. Human Anatomy");
                cbpnlabSubClass.Items.Add("QP. Physiology");
                cbpnlabSubClass.Items.Add("QR. Microbiology");
            }
            else if (cbpnlabClassification.Text == "R")
            {
                cbpnlabSubClass.Items.Add("R. Medicine (General)");
                cbpnlabSubClass.Items.Add("RA. Public Aspects of Medicine");
                cbpnlabSubClass.Items.Add("RB. Pathology");
                cbpnlabSubClass.Items.Add("RC. Internal Medicine");
                cbpnlabSubClass.Items.Add("RD. Surgery");
                cbpnlabSubClass.Items.Add("RE. Ophthalmology");
                cbpnlabSubClass.Items.Add("RF. Otorhinolaryngology");
                cbpnlabSubClass.Items.Add("RG. Gynecology & Obstetrics");
                cbpnlabSubClass.Items.Add("RJ. Pediatrics");
                cbpnlabSubClass.Items.Add("RK. Dentistry");
                cbpnlabSubClass.Items.Add("RL. Dermatology");
                cbpnlabSubClass.Items.Add("RM. Therapeutics. Pharmacology");
                cbpnlabSubClass.Items.Add("RS. Pharmacy & Materia Medica");
                cbpnlabSubClass.Items.Add("RT. Nursing");
                cbpnlabSubClass.Items.Add("RV. Botanic, Thomsonian, & Eclectic Medicine");
                cbpnlabSubClass.Items.Add("RX. Homeopathy");
                cbpnlabSubClass.Items.Add("RZ. Other Systems of Medicine");
            }
            else if (cbpnlabClassification.Text == "S")
            {
                cbpnlabSubClass.Items.Add("S. Agriculture (General)");
                cbpnlabSubClass.Items.Add("SB. Horticulture, Plant Propagation, Plant Breeding");
                cbpnlabSubClass.Items.Add("SD. Forestry, Arboriculture, Silviculture");
                cbpnlabSubClass.Items.Add("SF. Animal Husbandry, Animal Science");
                cbpnlabSubClass.Items.Add("SH. Aquaculture, Fisheries, Angling");
                cbpnlabSubClass.Items.Add("SK. Hunting");
            }
            else if (cbpnlabClassification.Text == "T")
            {
                cbpnlabSubClass.Items.Add("T. Technology (General)");
                cbpnlabSubClass.Items.Add("TA. Engineering Civil Engineering (General)");
                cbpnlabSubClass.Items.Add("TC. Hydraulic Engineering, Ocean Engineering");
                cbpnlabSubClass.Items.Add("TD. Environmental Technology, Sanitary Engineering");
                cbpnlabSubClass.Items.Add("TE. Highway Engineering, Roads & Pavements");
                cbpnlabSubClass.Items.Add("TF. Railroad Engineering & Operation");
                cbpnlabSubClass.Items.Add("TG. Bridges");
                cbpnlabSubClass.Items.Add("TH. Building Construction");
                cbpnlabSubClass.Items.Add("TJ. Mechanical Engineering & Machinery");
                cbpnlabSubClass.Items.Add("TK. Electrical Engineering, Electronics, Nuclear Engineering");
                cbpnlabSubClass.Items.Add("TL. Motor Vehicles, Aeronautics, Astronautics");
                cbpnlabSubClass.Items.Add("TN. Mining Engineering, Metallurgy");
                cbpnlabSubClass.Items.Add("TP. Chemical Technology");
                cbpnlabSubClass.Items.Add("TR. Photography");
                cbpnlabSubClass.Items.Add("TS. Manufacturing Engineering, Mass production");
                cbpnlabSubClass.Items.Add("TT. Handicrafts, Arts & Crafts");
                cbpnlabSubClass.Items.Add("TX. Home Economics");
            }
            else if (cbpnlabClassification.Text == "U")
            {
                cbpnlabSubClass.Items.Add("U. Military Science (General)");
                cbpnlabSubClass.Items.Add("UA. Armies: Organization, Distribution, Military situation");
                cbpnlabSubClass.Items.Add("UB. Military Administration");
                cbpnlabSubClass.Items.Add("UC. Military Maintenance & Transportation");
                cbpnlabSubClass.Items.Add("UD. Infantry");
                cbpnlabSubClass.Items.Add("UE. Cavalry. Armor");
                cbpnlabSubClass.Items.Add("UF. Artillery");
                cbpnlabSubClass.Items.Add("UG. Military Engineering, Air forces");
                cbpnlabSubClass.Items.Add("UH. Other Military Services");
            }
            else if (cbpnlabClassification.Text == "V")
            {
                cbpnlabSubClass.Items.Add("V. Naval Science (General)");
                cbpnlabSubClass.Items.Add("VA. Navies: Organization, Distribution, Naval Situation");
                cbpnlabSubClass.Items.Add("VB. Naval Administration");
                cbpnlabSubClass.Items.Add("VC. Naval Maintenance");
                cbpnlabSubClass.Items.Add("VD. Naval Seamen");
                cbpnlabSubClass.Items.Add("VE. Marines");
                cbpnlabSubClass.Items.Add("VF. Naval Ordnance");
                cbpnlabSubClass.Items.Add("VG. Minor Services of Navies");
                cbpnlabSubClass.Items.Add("VK. Navigation, Merchant Marine");
                cbpnlabSubClass.Items.Add("VM. Naval Architecture, Shipbuilding, Marine Engineering");
            }
            else if (cbpnlabClassification.Text == "Z")
            {
                cbpnlabSubClass.Items.Add("Z. Books (General), Writing, Paleography, Book industries & Trade, Libraries, Bibliography");
                cbpnlabSubClass.Items.Add("ZA. Information Resources/Materials");
            }
            cbpnlabSubClass.SelectedIndex = 0;
        }

        private void cbpnlabPublisher_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabPublisher);
        }

        private void cbpnlabCategory_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabCategory);
        }

        private void cbpnlabSubClass_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabSubClass);
        }

        private void cbpnlabPublisher_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnlabPublisher.GetItemText(cbpnlabPublisher.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnlabPublisher, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnlabCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnlabCategory.GetItemText(cbpnlabCategory.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnlabCategory, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnlabSubClass_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnlabSubClass.GetItemText(cbpnlabSubClass.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnlabSubClass, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnlabPublisher_DropDown(object sender, EventArgs e)
        {
            if (btnpnlabAddPublisher.Visible == true)
            {
                txtpnlabPublisher.Text = null;
                txtpnlabPublisher.Hide();
                btnpnlabAddPublisher.Hide();
            }
        }

        private void cbpnlabCategory_DropDown(object sender, EventArgs e)
        {
            if (btnpnlabAddCategory.Visible == true)
            {
                txtpnlabCategory.Text = null;
                txtpnlabCategory.Hide();
                btnpnlabAddCategory.Hide();
            }
        }

        private void cbpnlabPublisher_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabPublisher);
            lblpnlabPanelName.Focus();
        }

        private void cbpnlabCategory_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabCategory);
            lblpnlabPanelName.Focus();
        }

        private void cbpnlabSubClass_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlabSubClass);
            lblpnlabPanelName.Focus();
        }

        private void cbpnlabPublisher_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnlabPublisher, cbpnlabPublisher.Text);
        }

        private void cbpnlabCategory_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnlabCategory, cbpnlabCategory.Text);
        }

        private void cbpnlabSubClass_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnlabSubClass, cbpnlabSubClass.Text);
        }

        private void btnpnlabAddPubIcon_Click(object sender, EventArgs e)
        {
            if (btnpnlabAddPublisher.Visible == false)
            {
                txtpnlabPublisher.Show();
                btnpnlabAddPublisher.Show();
            }
            else
            {
                txtpnlabPublisher.Hide();
                btnpnlabAddPublisher.Hide();
            }
        }

        private void btnpnlabAddCatIcon_Click(object sender, EventArgs e)
        {
            if (btnpnlabAddCategory.Visible == false)
            {
                txtpnlabCategory.Visible = true;
                btnpnlabAddCategory.Visible = true;
            }
            else
            {
                txtpnlabCategory.Visible = false;
                btnpnlabAddCategory.Visible = false;
            }
        }

        private void btnpnlabRemovePubIcon_Click(object sender, EventArgs e)
        {
            if (btnpnlabAddPublisher.Visible == true)
            {
                txtpnlabPublisher.Hide();
                btnpnlabAddPublisher.Hide();
            }
            if (MessageBox.Show("Confirm to delete.", "Deleting Publisher", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteABEBPub(cbpnlabPublisher.Text) == true)
                {
                    FillAddBooksCbPub();
                }
            }
        }

        private void btnpnlabRemoveCatIcon_Click(object sender, EventArgs e)
        {
            if (btnpnlabAddCategory.Visible == true)
            {
                txtpnlabCategory.Hide();
                btnpnlabAddCategory.Hide();
            }
            if (MessageBox.Show("Confirm to delete.", "Deleting Publisher", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteABEBCat(cbpnlabCategory.Text) == true)
                {
                    FillAddBooksCbCat();
                }
            }
        }

        private void btnpnlabAddPublisher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnlabPublisher.Text))
            {
                toolTip.Show("Field is currently empty.", txtpnlabPublisher, 5, txtpnlabPublisher.Height - 1, 3000);
                return;
            }
            else
            {
                if (cbpnlabPublisher.FindStringExact(txtpnlabPublisher.Text) == -1)
                {
                    if (AddABEBPub(txtpnlabPublisher.Text))
                    {
                        FillAddBooksCbPub();
                        cbpnlabPublisher.SelectedItem = txtpnlabPublisher.Text;
                        txtpnlabPublisher.Text = null;
                        btnpnlabAddPubIcon_Click(null, null);
                    }
                }
                else
                {
                    txtpnlabPublisher.Text = null;
                    MessageBox.Show("Publisher is already in the list");
                }
            }
        }

        private void btnpnlabAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnlabCategory.Text))
            {
                toolTip.Show("Field is currently empty.", txtpnlabCategory, 5, txtpnlabCategory.Height - 1, 3000);
                return;
            }
            else
            {
                if (cbpnlabPublisher.FindStringExact(txtpnlabPublisher.Text) == -1)
                {
                    if (AddABEBCat(txtpnlabCategory.Text) == true)
                    {
                        FillAddBooksCbCat();
                        cbpnlabCategory.SelectedItem = txtpnlabPublisher.Text;
                        btnpnlabAddCatIcon_Click(null, null);
                        txtpnlabCategory.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Category is already in the list");
                }
            }
        }

        private void btnpnlabSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnlabBookTitle.Text)
                || string.IsNullOrWhiteSpace(txtpnlabAuthor.Text)
                || string.IsNullOrWhiteSpace(txtpnlabNumberOfPages.Text)
                || string.IsNullOrWhiteSpace(txtpnlabPrice.Text)
                || string.IsNullOrWhiteSpace(txtpnlabQuantity.Text)
                || string.IsNullOrEmpty(cbpnlabPublisher.Text)
                || string.IsNullOrEmpty(cbpnlabYearPublished.Text)
                || string.IsNullOrEmpty(cbpnlabVolume.Text)
                || string.IsNullOrEmpty(cbpnlabCategory.Text)
                || string.IsNullOrEmpty(cbpnlabClassification.Text))
            {
                if (string.IsNullOrWhiteSpace(txtpnlabBookTitle.Text))
                {
                    toolTip.Show("Field is currently empty.", txtpnlabBookTitle, 5, txtpnlabBookTitle.Height - 1, 3000);
                }

                if (string.IsNullOrWhiteSpace(txtpnlabAuthor.Text))
                {
                    toolTip1.Show("Field is currently empty.", txtpnlabAuthor, 5, txtpnlabAuthor.Height - 1, 3000);
                }

                if (string.IsNullOrWhiteSpace(txtpnlabNumberOfPages.Text))
                {
                    toolTip2.Show("Field is currently empty.", txtpnlabNumberOfPages, 5, txtpnlabNumberOfPages.Height - 1, 3000);
                }

                if (string.IsNullOrWhiteSpace(txtpnlabPrice.Text))
                {
                    toolTip3.Show("Field is currently empty.", txtpnlabPrice, 5, txtpnlabPrice.Height - 1, 3000);
                }

                if (string.IsNullOrWhiteSpace(txtpnlabQuantity.Text))
                {
                    toolTip4.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }

                if (string.IsNullOrEmpty(cbpnlabPublisher.Text))
                {
                    toolTip5.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }

                if (string.IsNullOrEmpty(cbpnlabYearPublished.Text))
                {
                    toolTip6.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }

                if (string.IsNullOrEmpty(cbpnlabVolume.Text))
                {
                    toolTip7.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }

                if (string.IsNullOrEmpty(cbpnlabCategory.Text))
                {
                    toolTip8.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }

                if (string.IsNullOrEmpty(cbpnlabClassification.Text))
                {
                    toolTip9.Show("Field is currently empty.", txtpnlabQuantity, 5, txtpnlabQuantity.Height - 1, 3000);
                }
                return;
            }
            else
            {
                using (new RunProcess(pnlmfAddBooks))
                {
                    int successAdd = AddBooks(txtpnlabBookTitle.Text.Trim(), txtpnlabAuthor.Text.Trim(), cbpnlabPublisher.Text, Convert.ToInt32(cbpnlabYearPublished.Text), Convert.ToInt32(cbpnlabVolume.Text), cbpnlabCategory.Text, Convert.ToInt32(txtpnlabNumberOfPages.Text), cbpnlabSubClass.Text.Split('.'), Convert.ToDecimal(txtpnlabPrice.Text.Replace(cultureCurrencySymbol, string.Empty)), Convert.ToInt32(txtpnlabQuantity.Text));
                    btnpnlabClear_Click(null, null);
                    FillMainFormDGV();
                    MessageBox.Show("Successfully Added " + successAdd.ToString() + " Books");
                }
            }
        }

        private void btnpnlabClear_Click(object sender, EventArgs e)
        {
            txtpnlabAccessNo.Text = ("BID" + Properties.Settings.Default.Counter_Access_Number.ToString("D4"));
            txtpnlabBookTitle.Text = null;
            txtpnlabAuthor.Text = null;
            txtpnlabPublisher.Text = null;
            txtpnlabCategory.Text = null;
            txtpnlabPrice.Text = null;
            txtpnlabQuantity.Text = null;
            txtpnlabNumberOfPages.Text = null;
            cbpnlabYearPublished.SelectedIndex = 0;
            cbpnlabVolume.SelectedIndex = 0;
            cbpnlabClassification.SelectedIndex = 0;
            dtppnlabDateAdded.Refresh();
        }

        private void btnpnlabCancel_Click(object sender, EventArgs e)
        {
            ShowMainFormButtons();
            pnlmfAddBooks.Hide();
            txtpnlabPublisher.Hide();
            btnpnlabAddPublisher.Hide();
            txtpnlabCategory.Hide();
            btnpnlabAddCategory.Hide();
        }
        #endregion

        #region Edit Books Panel
        private void btnmfEdit_Click(object sender, EventArgs e)
        {
            if (!(accountType == "Administrator"))
            {
                MessageBox.Show("You do not have the authority to access this function.");
            }
            else
            {
                if (pnlmfEdit.Visible == false)
                {
                    FillEditBooksCbPub();
                    FillEditBooksCbCat();
                    HideMainFormButtons();
                    btnpnleEditBook.Enabled = false;
                    pnlecontroldisabled();
                    this.ActiveControl = lblpnlePanelName;
                    ShowPanel(pnlmfEdit);
                }
                else
                {
                    ShowMainFormButtons();
                    pnlmfEdit.Hide();
                }
            }
        }

        private void pnlecontroldisabled()
        {
            txtpnleBookTitle.Enabled = false;
            txtpnleAuthor.Enabled = false;
            cbpnlePublisher.Enabled = false;
            btnpnleAddPubIcon.Enabled = false;
            btnpnleRemovePubIcon.Enabled = false;
            cbpnleYearPublished.Enabled = false;
            cbpnleVolume.Enabled = false;
            cbpnleCategory.Enabled = false;
            btnpnleAddCatIcon.Enabled = false;
            btnpnleRemoveCatIcon.Enabled = false;
            txtpnleNumberOfPages.Enabled = false;
            cbpnleClassification.Enabled = false;
            cbpnleSubClass.Enabled = false;
            txtpnlePrice.Enabled = false;
            cbpnleStatus.Enabled = false;
            cbpnleInformation.Enabled = false;
            btnpnleEditBook.Visible = true;
            btnpnleUpdate.Visible = false;
            btnpnleDelete.Visible = false;
        }
        private void pnlecontrolenabled()
        {
            txtpnleBookTitle.Enabled = true;
            txtpnleAuthor.Enabled = true;
            cbpnlePublisher.Enabled = true;
            btnpnleAddPubIcon.Enabled = true;
            btnpnleRemovePubIcon.Enabled = true;
            cbpnleYearPublished.Enabled = true;
            cbpnleVolume.Enabled = true;
            cbpnleCategory.Enabled = true;
            btnpnleAddCatIcon.Enabled = true;
            btnpnleRemoveCatIcon.Enabled = true;
            txtpnleNumberOfPages.Enabled = true;
            cbpnleClassification.Enabled = true;
            cbpnleSubClass.Enabled = true;
            txtpnlePrice.Enabled = true;
            cbpnleStatus.Enabled = true;
            if (cbpnleStatus.Text == "Unavailable")
            {
                cbpnleInformation.Enabled = true;
            }
            btnpnleEditBook.Hide();
            btnpnleUpdate.Show();
            btnpnleDelete.Show();
        }

        private void FillEditBooksCbPub()
        {
            cbpnlePublisher.Items.Clear();
            try
            {
                string sqlQuery = "SELECT book_publishers FROM BookPublishers ORDER BY book_publishers ASC";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        using (OleDbDataReader dbreader = cmd.ExecuteReader())
                        {
                            if (dbreader.HasRows)
                            {
                                while (dbreader.Read())
                                {
                                    cbpnlePublisher.Items.Add(dbreader["book_publishers"].ToString());
                                }
                                cbpnlePublisher.SelectedIndex = -1;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FillEditBooksCbCat()
        {
            cbpnleCategory.Items.Clear();
            try
            {
                string sqlQuery = "SELECT book_categories FROM BookCategories ORDER BY book_categories ASC";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        OleDbDataReader dbreader = cmd.ExecuteReader();
                        if (dbreader.HasRows)
                        {
                            while (dbreader.Read())
                            {
                                cbpnleCategory.Items.Add(dbreader["book_categories"].ToString());
                            }
                            cbpnleCategory.SelectedIndex = -1;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool UpdateBook(int bookAccessionNumber, string bookTitle, string bookAuthor, string bookPublisher, int bookYearPublished, int bookVolume, string bookCategory, int bookNumberOfPages, string[] bookClassification, decimal bookPrice, string bookStatus, string bookInformation)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "UPDATE Books SET book_title = ?, author = ?, publisher = ?, year_published = ?, volume = ?, category = ?, pages = ?, classification = ?, price = ?, status = ?, information = ?, date_modified = ? WHERE access_num = ?";
                    using (booksAdapter.UpdateCommand = new OleDbCommand(sqlQuery, con))
                    {
                        booksAdapter.UpdateCommand.Parameters.Clear();
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookTitle);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookAuthor);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookPublisher);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookYearPublished);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookVolume);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookCategory);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookNumberOfPages);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookClassification[0]);
                        booksAdapter.UpdateCommand.Parameters.Add("?", OleDbType.Decimal).Value = bookPrice;
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookStatus);
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookInformation);
                        booksAdapter.UpdateCommand.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        booksAdapter.UpdateCommand.Parameters.AddWithValue("?", bookAccessionNumber);

                        if (booksAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Update Book", bookTitle);
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

        private bool DeleteBook(int bookAccessioNumber, string bookTitle)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM Books WHERE access_num = ?";
                    using (booksAdapter.DeleteCommand = new OleDbCommand(sqlQuery, con))
                    {
                        booksAdapter.DeleteCommand.Parameters.Clear();
                        booksAdapter.DeleteCommand.Parameters.AddWithValue("?", bookAccessioNumber);
                        if (MessageBox.Show("Confirm to delete.", "Deleting Book", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (booksAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                            {
                                SaveToLog("Delete Book", bookTitle);
                                return true;
                            }
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

        private void pnlmfEdit_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfEdit.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlePrice_Enter(object sender, EventArgs e)
        {
            txtpnlePrice_TextChanged(null, null);
        }

        private void txtpnlePrice_Leave(object sender, EventArgs e)
        {
            if (txtpnlePrice.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtpnlePrice.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
            {
                txtpnlePrice.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                return;
            }
            else
            {
                txtpnlePrice.Text = Convert.ToDecimal(txtpnlePrice.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtpnleBookTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnleBookTitle.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '~' && e.KeyChar != '!'
                && e.KeyChar != '@' && e.KeyChar != '#'
                && e.KeyChar != '$' && e.KeyChar != '%'
                && e.KeyChar != '^' && e.KeyChar != '&'
                && e.KeyChar != '*' && e.KeyChar != '('
                && e.KeyChar != ')' && e.KeyChar != '-'
                && e.KeyChar != '_' && e.KeyChar != '='
                && e.KeyChar != '+' && e.KeyChar != ':'
                && e.KeyChar != ';' && e.KeyChar != '\''
                && e.KeyChar != '"' && e.KeyChar != ','
                && e.KeyChar != '.' && e.KeyChar != '?')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9 and Alphanumeric are only allowed.", txtpnleBookTitle, 5, txtpnleBookTitle.Height - 1, 3000);
            }
        }

        private void txtpnleAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnleAuthor.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != ','
                && e.KeyChar != '.'
                && e.KeyChar != ':'
                && e.KeyChar != ';')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, (,), (.), (:) and (;) are only allowed.", txtpnleAuthor, 5, txtpnleAuthor.Height - 1, 3000);
            }
        }

        private void txtpnlePublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlePublisher.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != ','
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, (,) and (.) are only allowed.", txtpnlePublisher, 5, txtpnlePublisher.Height - 1, 3000);
            }
        }

        private void txtpnleCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnleCategory.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnleCategory, 5, txtpnleCategory.Height - 1, 3000);
            }
        }

        private void txtpnleNumberOfPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 and are only allowed.", txtpnleNumberOfPages, 5, txtpnleNumberOfPages.Height - 1, 3000);
            }
        }

        private void txtpnlePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 and (.) are only allowed.", txtpnlePrice, 5, txtpnlePrice.Height - 1, 3000);
            }
        }

        private void txtpnleBookTitle_TextChanged(object sender, EventArgs e)
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

        private void txtpnleAuthor_TextChanged(object sender, EventArgs e)
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

        private void txtpnlePublisher_TextChanged(object sender, EventArgs e)
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

        private void txtpnleCategory_TextChanged(object sender, EventArgs e)
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

        private void txtpnlePrice_TextChanged(object sender, EventArgs e)
        {
            if (!txtpnlePrice.Text.StartsWith(cultureCurrencySymbol))
            {
                txtpnlePrice.Text = cultureCurrencySymbol + txtpnlePrice.Text;
                txtpnlePrice.SelectionStart = cultureCurrencySymbol.Length;
            }
            if (txtpnlePrice.Text == cultureCurrencySymbol || txtpnlePrice.Text == cultureCurrencySymbol + "0")
            {
                txtpnlePrice.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void cbpnlePublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleYearPublished_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleClassification_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleSubClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbpnleClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnleSubClass);
            cbpnleSubClass.Items.Clear();
            if (cbpnleClassification.Text == "A")
            {
                cbpnleSubClass.Items.Add("A. General Works");
                cbpnleSubClass.Items.Add("AC. Collections");
                cbpnleSubClass.Items.Add("AE. Encyclopedias");
                cbpnleSubClass.Items.Add("AG. Dictionaries & General Reference Works");
                cbpnleSubClass.Items.Add("AI. Indexes");
                cbpnleSubClass.Items.Add("AM. Museums");
                cbpnleSubClass.Items.Add("AN. Newspapers");
                cbpnleSubClass.Items.Add("AP. Periodicals");
                cbpnleSubClass.Items.Add("AS. Academies, Societies");
                cbpnleSubClass.Items.Add("AY. Yearbooks, Almanacs, Business Directories");
                cbpnleSubClass.Items.Add("AZ. General History of Scholarship & Learning");
            }
            else if (cbpnleClassification.Text == "B")
            {
                cbpnleSubClass.Items.Add("B. Philosophy (General)");
                cbpnleSubClass.Items.Add("BC. Logic");
                cbpnleSubClass.Items.Add("BD. Speculative Philosophy");
                cbpnleSubClass.Items.Add("BF. Physcology");
                cbpnleSubClass.Items.Add("BH. Aesthetics");
                cbpnleSubClass.Items.Add("BJ. Ethics");
                cbpnleSubClass.Items.Add("BL. Religions, Mythology, Rationalism");
                cbpnleSubClass.Items.Add("BM. Judaism");
                cbpnleSubClass.Items.Add("BP. Islam, Bahaism, Theosophy etc.");
                cbpnleSubClass.Items.Add("BQ. Buddhism");
                cbpnleSubClass.Items.Add("BR. Christianity");
                cbpnleSubClass.Items.Add("BS. The Bible");
                cbpnleSubClass.Items.Add("BT. Doctrinal Theology");
                cbpnleSubClass.Items.Add("BV. Practical Theology");
                cbpnleSubClass.Items.Add("BX. Christian Denominations");
            }
            else if (cbpnleClassification.Text == "C")
            {
                cbpnleSubClass.Items.Add("C. Auxiliary Sciences of History");
                cbpnleSubClass.Items.Add("CB. History of Civilization");
                cbpnleSubClass.Items.Add("CC. Archaeology");
                cbpnleSubClass.Items.Add("CD. Diplomatics, Archives, Seals");
                cbpnleSubClass.Items.Add("CE. Technical Chronology, Calendar");
                cbpnleSubClass.Items.Add("CJ. Numismatics (Coins, Tokes, Medallions)");
                cbpnleSubClass.Items.Add("CN. Inscriptions, Epigraphy");
                cbpnleSubClass.Items.Add("CR. Heraldry");
                cbpnleSubClass.Items.Add("CS. Genealogy");
                cbpnleSubClass.Items.Add("CT. Biography");
            }
            else if (cbpnleClassification.Text == "D")
            {
                cbpnleSubClass.Items.Add("D. History (General)");
                cbpnleSubClass.Items.Add("DA. Great Britain");
                cbpnleSubClass.Items.Add("DAW. Central Europe");
                cbpnleSubClass.Items.Add("DB. Austria, Liechtenstein, Hungary, Czechoslovakia");
                cbpnleSubClass.Items.Add("DC. France, Andorra, Monaco");
                cbpnleSubClass.Items.Add("DD. Germany");
                cbpnleSubClass.Items.Add("DE. Greco-Roman World");
                cbpnleSubClass.Items.Add("DF. Greece");
                cbpnleSubClass.Items.Add("DG. Italy. Malta");
                cbpnleSubClass.Items.Add("DH. Low Countries. Benelux Countries");
                cbpnleSubClass.Items.Add("DJ. Netherlands (Holland)");
                cbpnleSubClass.Items.Add("DJK. Eastern Europe (General)");
                cbpnleSubClass.Items.Add("DK. Russia, Soviet Union, Former Soviet Republics, Poland");
                cbpnleSubClass.Items.Add("DL. Northern Europe. Scandinavia");
                cbpnleSubClass.Items.Add("DP. Spain. Portugal");
                cbpnleSubClass.Items.Add("DQ. Switzerland");
                cbpnleSubClass.Items.Add("DR. Balkan Peninsula");
                cbpnleSubClass.Items.Add("DS. Asia");
                cbpnleSubClass.Items.Add("DT. Africa");
                cbpnleSubClass.Items.Add("DU. Oceania (South Seas)");
                cbpnleSubClass.Items.Add("DX. Romanies");
            }
            else if (cbpnleClassification.Text == "E")
            {
                cbpnleSubClass.Items.Add("E. History of America");
            }
            else if (cbpnleClassification.Text == "F")
            {
                cbpnleSubClass.Items.Add("F. Local History of the Americas");
            }
            else if (cbpnleClassification.Text == "G")
            {
                cbpnleSubClass.Items.Add("G. Geography (General), Atlases, Maps");
                cbpnleSubClass.Items.Add("GA. Mathematical Geography, Cartography");
                cbpnleSubClass.Items.Add("GB. Physical Geography");
                cbpnleSubClass.Items.Add("GC. Oceanography");
                cbpnleSubClass.Items.Add("GE. Environmental Sciences");
                cbpnleSubClass.Items.Add("GF. Human Ecology, Anthropogeography");
                cbpnleSubClass.Items.Add("GN. Anthropology");
                cbpnleSubClass.Items.Add("GR. Folklore");
                cbpnleSubClass.Items.Add("GT. Manners and Customs (General)");
                cbpnleSubClass.Items.Add("GV. Recreation, Leisure");
            }
            else if (cbpnleClassification.Text == "H")
            {
                cbpnleSubClass.Items.Add("H. Social sciences (General)");
                cbpnleSubClass.Items.Add("HA. Statistics");
                cbpnleSubClass.Items.Add("HB. Economic Theory, Demography");
                cbpnleSubClass.Items.Add("HC. Economic History & Conditions");
                cbpnleSubClass.Items.Add("HD. Industries, Land Use, Labor");
                cbpnleSubClass.Items.Add("HE. Transportation & Communications");
                cbpnleSubClass.Items.Add("HF. Commerce");
                cbpnleSubClass.Items.Add("HG. Finance");
                cbpnleSubClass.Items.Add("HJ. Public Finance");
                cbpnleSubClass.Items.Add("HM. Sociology (General)");
                cbpnleSubClass.Items.Add("HN. Social History & Conditions, Social problems, Social Reform");
                cbpnleSubClass.Items.Add("HQ. The Family. Marriage, Women & Sexuality");
                cbpnleSubClass.Items.Add("HS. Societies: Secret, Benevolent, etc.");
                cbpnleSubClass.Items.Add("HT. Communities. Classes, Races");
                cbpnleSubClass.Items.Add("HV. Social Pathology, Social & Public Welfare, Criminology");
                cbpnleSubClass.Items.Add("HX. Socialism, Communism, Anarchism");
            }
            else if (cbpnleClassification.Text == "J")
            {
                cbpnleSubClass.Items.Add("J. General Legislative & Executive Papers");
                cbpnleSubClass.Items.Add("JA. Political Science (General)");
                cbpnleSubClass.Items.Add("JC. Political Theory");
                cbpnleSubClass.Items.Add("JF. Political Institutions & Public Administration");
                cbpnleSubClass.Items.Add("JJ. Political Institutions & Public Administration (North America)");
                cbpnleSubClass.Items.Add("JK. Political Institutions & Public Administration (United States)");
                cbpnleSubClass.Items.Add("JL. Political Institutions & Public Administration (Canada, Latin America, etc.)");
                cbpnleSubClass.Items.Add("JN. Political Institutions & Public Administration (Europe)");
                cbpnleSubClass.Items.Add("JQ. Political Institutions & Public Administration (Asia, Africa, Pacific Area, etc.)");
                cbpnleSubClass.Items.Add("JS. Local Government, Municipal Government");
                cbpnleSubClass.Items.Add("JV. Colonies & Colonization, Emigration & Immigration, International Migration");
                cbpnleSubClass.Items.Add("JX. International Law");
                cbpnleSubClass.Items.Add("JZ. International Relations");
            }
            else if (cbpnleClassification.Text == "K")
            {
                cbpnleSubClass.Items.Add("K. General Law, Comparative & Uniform Law, Jurisprudence");
                cbpnleSubClass.Items.Add("KB. General Religious Law, Comparative Religious Law, Jurisprudence");
                cbpnleSubClass.Items.Add("KBM. Jewish Law");
                cbpnleSubClass.Items.Add("KBP. Islamic Law");
                cbpnleSubClass.Items.Add("KBR. History of Canon Law");
                cbpnleSubClass.Items.Add("KBS. Canon Law of Eastern Churches");
                cbpnleSubClass.Items.Add("KBT. Canon Law of Eastern Rite Churches in Communion with the Holy See of Rome");
                cbpnleSubClass.Items.Add("KBU. Law of the Roman Catholic Church. The Holy See");
                cbpnleSubClass.Items.Add("KD/KDK - United Kingdom & Ireland");
                cbpnleSubClass.Items.Add("KDZ. America, North America");
                cbpnleSubClass.Items.Add("KE. Canada");
                cbpnleSubClass.Items.Add("KF. United States");
                cbpnleSubClass.Items.Add("KG. Latin America, Mexico & Central America, West Indies, Caribbean Area");
                cbpnleSubClass.Items.Add("KH. South America");
                cbpnleSubClass.Items.Add("KJ-KKZ. Europe");
                cbpnleSubClass.Items.Add("KL-KWX. Asia & Eurasia, Africa, Pacific Area, & Antarctica");
                cbpnleSubClass.Items.Add("KU/KUQ. Law of Australia & New Zealand");
                cbpnleSubClass.Items.Add("KZ. Law of Nations");
            }
            else if (cbpnleClassification.Text == "L")
            {
                cbpnleSubClass.Items.Add("L. Education (General)");
                cbpnleSubClass.Items.Add("LA. History of Education");
                cbpnleSubClass.Items.Add("LB. Theory & Practice of Education");
                cbpnleSubClass.Items.Add("LC. Special Aspects of Education");
                cbpnleSubClass.Items.Add("LD. Individual Institutions. United States");
                cbpnleSubClass.Items.Add("LE. Individual Institutions. America (except U.S.)");
                cbpnleSubClass.Items.Add("LF. Individual Institutions. Europe");
                cbpnleSubClass.Items.Add("LG. Individual Inst.. Asia, Africa, Indian Ocean Islands, Australia, New Zealand, Pacific Islands");
                cbpnleSubClass.Items.Add("LH. College & School Magazines & Papers");
                cbpnleSubClass.Items.Add("LJ. Student Fraternities & Societies, United States");
                cbpnleSubClass.Items.Add("LT. Textbooks");
            }
            else if (cbpnleClassification.Text == "M")
            {
                cbpnleSubClass.Items.Add("M. Music");
                cbpnleSubClass.Items.Add("ML. Literature on Music");
                cbpnleSubClass.Items.Add("MT. Instruction & Study");
            }
            else if (cbpnleClassification.Text == "N")
            {
                cbpnleSubClass.Items.Add("N. Visual Arts");
                cbpnleSubClass.Items.Add("NA. Architecture");
                cbpnleSubClass.Items.Add("NB. Sculpture");
                cbpnleSubClass.Items.Add("NC. Drawing, Design, Illustration");
                cbpnleSubClass.Items.Add("ND. Painting");
                cbpnleSubClass.Items.Add("NE. Print Media");
                cbpnleSubClass.Items.Add("NK. Decorative Arts");
                cbpnleSubClass.Items.Add("NX. Arts in General");
            }
            else if (cbpnleClassification.Text == "P")
            {
                cbpnleSubClass.Items.Add("P. Philology, Linguistics");
                cbpnleSubClass.Items.Add("PA. Greek Language & Literature, Latin Language & Literature");
                cbpnleSubClass.Items.Add("PB. Modern Languages, Celtic Languages & Literature");
                cbpnleSubClass.Items.Add("PC. Romanic Languages");
                cbpnleSubClass.Items.Add("PD. Germanic Languages, Scandinavian Languages");
                cbpnleSubClass.Items.Add("PE. English Language");
                cbpnleSubClass.Items.Add("PF. West Germanic Languages");
                cbpnleSubClass.Items.Add("PG. Slavic Languages & Literatures, Baltic Languages, Albanian Language");
                cbpnleSubClass.Items.Add("PH. Uralic Languages, Basque Language");
                cbpnleSubClass.Items.Add("PJ. Oriental Languages & Literatures");
                cbpnleSubClass.Items.Add("PK. Indo-Iranian Languages & Literatures");
                cbpnleSubClass.Items.Add("PL. Languages & Literatures of Eastern Asia, Africa, Oceania");
                cbpnleSubClass.Items.Add("PM. Hyperborean, Native American, & Artificial Languages");
                cbpnleSubClass.Items.Add("PN. Literature (General)");
                cbpnleSubClass.Items.Add("PQ. French, Italian , Spanish, and Portuguese Literatures");
                cbpnleSubClass.Items.Add("PR. English Literature");
                cbpnleSubClass.Items.Add("PS. American Literature");
                cbpnleSubClass.Items.Add("PT. German, Dutch, Flemish, Afrikaans, Scandinavian, Old Norse, Old Icelandic & Old Norwegian, Modern Icelandic, Faroese, Danish, Norwegian and Swedish Literatures");
                cbpnleSubClass.Items.Add("PZ. Fiction & Juvenile Belles Lettres");
            }
            else if (cbpnleClassification.Text == "Q")
            {
                cbpnleSubClass.Items.Add("Q. Science (General)");
                cbpnleSubClass.Items.Add("QA. Mathematics");
                cbpnleSubClass.Items.Add("QB. Astronomy");
                cbpnleSubClass.Items.Add("QC. Physics");
                cbpnleSubClass.Items.Add("QD. Chemistry");
                cbpnleSubClass.Items.Add("QE. Geology");
                cbpnleSubClass.Items.Add("QH. Natural History, Biology");
                cbpnleSubClass.Items.Add("QK. Botany");
                cbpnleSubClass.Items.Add("QL. Zoology");
                cbpnleSubClass.Items.Add("QM. Human Anatomy");
                cbpnleSubClass.Items.Add("QP. Physiology");
                cbpnleSubClass.Items.Add("QR. Microbiology");
            }
            else if (cbpnleClassification.Text == "R")
            {
                cbpnleSubClass.Items.Add("R. Medicine (General)");
                cbpnleSubClass.Items.Add("RA. Public Aspects of Medicine");
                cbpnleSubClass.Items.Add("RB. Pathology");
                cbpnleSubClass.Items.Add("RC. Internal Medicine");
                cbpnleSubClass.Items.Add("RD. Surgery");
                cbpnleSubClass.Items.Add("RE. Ophthalmology");
                cbpnleSubClass.Items.Add("RF. Otorhinolaryngology");
                cbpnleSubClass.Items.Add("RG. Gynecology & Obstetrics");
                cbpnleSubClass.Items.Add("RJ. Pediatrics");
                cbpnleSubClass.Items.Add("RK. Dentistry");
                cbpnleSubClass.Items.Add("RL. Dermatology");
                cbpnleSubClass.Items.Add("RM. Therapeutics. Pharmacology");
                cbpnleSubClass.Items.Add("RS. Pharmacy & Materia Medica");
                cbpnleSubClass.Items.Add("RT. Nursing");
                cbpnleSubClass.Items.Add("RV. Botanic, Thomsonian, & Eclectic Medicine");
                cbpnleSubClass.Items.Add("RX. Homeopathy");
                cbpnleSubClass.Items.Add("RZ. Other Systems of Medicine");
            }
            else if (cbpnleClassification.Text == "S")
            {
                cbpnleSubClass.Items.Add("S. Agriculture (General)");
                cbpnleSubClass.Items.Add("SB. Horticulture, Plant Propagation, Plant Breeding");
                cbpnleSubClass.Items.Add("SD. Forestry, Arboriculture, Silviculture");
                cbpnleSubClass.Items.Add("SF. Animal Husbandry, Animal Science");
                cbpnleSubClass.Items.Add("SH. Aquaculture, Fisheries, Angling");
                cbpnleSubClass.Items.Add("SK. Hunting");
            }
            else if (cbpnleClassification.Text == "T")
            {
                cbpnleSubClass.Items.Add("T. Technology (General)");
                cbpnleSubClass.Items.Add("TA. Engineering Civil Engineering (General)");
                cbpnleSubClass.Items.Add("TC. Hydraulic Engineering, Ocean Engineering");
                cbpnleSubClass.Items.Add("TD. Environmental Technology, Sanitary Engineering");
                cbpnleSubClass.Items.Add("TE. Highway Engineering, Roads & Pavements");
                cbpnleSubClass.Items.Add("TF. Railroad Engineering & Operation");
                cbpnleSubClass.Items.Add("TG. Bridges");
                cbpnleSubClass.Items.Add("TH. Building Construction");
                cbpnleSubClass.Items.Add("TJ. Mechanical Engineering & Machinery");
                cbpnleSubClass.Items.Add("TK. Electrical Engineering, Electronics, Nuclear Engineering");
                cbpnleSubClass.Items.Add("TL. Motor Vehicles, Aeronautics, Astronautics");
                cbpnleSubClass.Items.Add("TN. Mining Engineering, Metallurgy");
                cbpnleSubClass.Items.Add("TP. Chemical Technology");
                cbpnleSubClass.Items.Add("TR. Photography");
                cbpnleSubClass.Items.Add("TS. Manufacturing Engineering, Mass production");
                cbpnleSubClass.Items.Add("TT. Handicrafts, Arts & Crafts");
                cbpnleSubClass.Items.Add("TX. Home Economics");
            }
            else if (cbpnleClassification.Text == "U")
            {
                cbpnleSubClass.Items.Add("U. Military Science (General)");
                cbpnleSubClass.Items.Add("UA. Armies: Organization, Distribution, Military situation");
                cbpnleSubClass.Items.Add("UB. Military Administration");
                cbpnleSubClass.Items.Add("UC. Military Maintenance & Transportation");
                cbpnleSubClass.Items.Add("UD. Infantry");
                cbpnleSubClass.Items.Add("UE. Cavalry. Armor");
                cbpnleSubClass.Items.Add("UF. Artillery");
                cbpnleSubClass.Items.Add("UG. Military Engineering, Air forces");
                cbpnleSubClass.Items.Add("UH. Other Military Services");
            }
            else if (cbpnleClassification.Text == "V")
            {
                cbpnleSubClass.Items.Add("V. Naval Science (General)");
                cbpnleSubClass.Items.Add("VA. Navies: Organization, Distribution, Naval Situation");
                cbpnleSubClass.Items.Add("VB. Naval Administration");
                cbpnleSubClass.Items.Add("VC. Naval Maintenance");
                cbpnleSubClass.Items.Add("VD. Naval Seamen");
                cbpnleSubClass.Items.Add("VE. Marines");
                cbpnleSubClass.Items.Add("VF. Naval Ordnance");
                cbpnleSubClass.Items.Add("VG. Minor Services of Navies");
                cbpnleSubClass.Items.Add("VK. Navigation, Merchant Marine");
                cbpnleSubClass.Items.Add("VM. Naval Architecture, Shipbuilding, Marine Engineering");
            }
            else if (cbpnleClassification.Text == "Z")
            {
                cbpnleSubClass.Items.Add("Z. Books (General), Writing, Paleography, Book industries & Trade, Libraries, Bibliography");
                cbpnleSubClass.Items.Add("ZA. Information Resources/Materials");
            }
            cbpnleSubClass.SelectedIndex = 0;
        }

        private void cbpnleSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbpnleSubClass.Enabled == true)
            {
                toolTip.Show(cbpnleSubClass.Text, cbpnleSubClass, 5, cbpnleSubClass.Height - 1, 3000);
            }
        }

        private void cbpnleStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbpnleInformation.Items.Clear();
            cbpnleInformation.Text = null;
            if (cbpnleStatus.Text == "Available")
            {
                cbpnleInformation.Enabled = false;
            }
            else
            {
                if (btnpnleUpdate.Visible == true)
                {
                    cbpnleInformation.Enabled = true;
                }
                else
                {
                    cbpnleInformation.Enabled = false;
                }
                cbpnleInformation.Items.Add("Borrowed");
                cbpnleInformation.Items.Add("Damaged");
                cbpnleInformation.Items.Add("Lost");
                cbpnleInformation.Items.Add("Missing");
            }
        }

        private void cbpnlePublisher_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlePublisher);
        }

        private void cbpnleCategory_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnleCategory);
        }

        private void cbpnleSubClass_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnleSubClass);
        }

        private void cbpnlePublisher_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnlePublisher.GetItemText(cbpnlePublisher.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnlePublisher, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnleCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnleCategory.GetItemText(cbpnleCategory.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnleCategory, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnleSubClass_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = cbpnleSubClass.GetItemText(cbpnleSubClass.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, cbpnleSubClass, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void cbpnlePublisher_DropDown(object sender, EventArgs e)
        {
            if (btnpnleAddPublisher.Visible == true)
            {
                txtpnlePublisher.Text = null;
                txtpnlePublisher.Hide();
                btnpnleAddPublisher.Hide();
            }
        }

        private void cbpnleCategory_DropDown(object sender, EventArgs e)
        {
            if (btnpnleAddCategory.Visible == true)
            {
                txtpnleCategory.Text = null;
                txtpnleCategory.Hide();
                btnpnleAddCategory.Hide();
            }
        }

        private void cbpnlePublisher_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnlePublisher);
        }

        private void cbpnleCategory_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnleCategory);
        }

        private void cbpnleSubClass_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(cbpnleSubClass);
        }

        private void cbpnlePublisher_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnlePublisher, cbpnlePublisher.Text);
        }

        private void cbpnleCategory_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnleCategory, cbpnleCategory.Text);
        }

        private void cbpnleSubClass_MouseHover(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 0;
            toolTip.SetToolTip(cbpnleSubClass, cbpnleSubClass.Text);
        }

        private void btnpnleAddPubIcon_Click(object sender, EventArgs e)
        {
            if (btnpnleAddPublisher.Visible == false)
            {
                txtpnlePublisher.Visible = true;
                btnpnleAddPublisher.Visible = true;
            }
            else
            {
                txtpnlePublisher.Visible = false;
                btnpnleAddPublisher.Visible = false;
            }
        }

        private void btnpnleAddCatIcon_Click(object sender, EventArgs e)
        {
            if (btnpnleAddCategory.Visible == false)
            {
                txtpnleCategory.Visible = true;
                btnpnleAddCategory.Visible = true;
            }
            else
            {
                txtpnleCategory.Visible = false;
                btnpnleAddCategory.Visible = false;
            }
        }

        private void btnpnleRemovePubIcon_Click(object sender, EventArgs e)
        {
            if (btnpnleAddPublisher.Visible == true)
            {
                txtpnlePublisher.Hide();
                btnpnleAddPublisher.Hide();
            }
            if (MessageBox.Show("Confirm to delete.", "Deleting Publisher", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteABEBPub(cbpnlePublisher.Text) == true)
                {
                    FillEditBooksCbPub();
                    if (cbpnlePublisher.FindStringExact(currentBookPublisher) > -1)
                    {
                        cbpnlePublisher.SelectedIndex = cbpnlePublisher.FindStringExact(currentBookPublisher);
                    }
                    else
                    {
                        cbpnlePublisher.Items.Add(currentBookPublisher);
                        cbpnlePublisher.SelectedIndex = cbpnlePublisher.FindStringExact(currentBookPublisher);
                    }
                }
            }
        }

        private void btnpnleRemoveCatIcon_Click(object sender, EventArgs e)
        {
            if (btnpnleAddCategory.Visible == true)
            {
                txtpnleCategory.Hide();
                btnpnleAddCategory.Hide();
            }
            if (MessageBox.Show("Confirm to delete.", "Deleting Category", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteABEBCat(cbpnleCategory.Text) == true)
                {
                    FillEditBooksCbCat();
                    if (cbpnleCategory.FindStringExact(currentBookCategory) > -1)
                    {
                        cbpnleCategory.SelectedIndex = cbpnleCategory.FindStringExact(currentBookCategory);
                    }
                    else
                    {
                        cbpnleCategory.Items.Add(currentBookCategory);
                        cbpnleCategory.SelectedIndex = cbpnleCategory.FindStringExact(currentBookCategory);
                    }
                }
            }
        }

        private void btnpnleAddPublisher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnlePublisher.Text))
            {
                toolTip.Show("Field is currently empty.", txtpnlePublisher, 5, txtpnlePublisher.Height - 1, 3000);
                return;
            }
            else
            {
                if (cbpnlePublisher.FindStringExact(txtpnlePublisher.Text) == -1 || currentBookPublisherExist == false)
                {
                    if (AddABEBPub(txtpnlePublisher.Text))
                    {
                        FillEditBooksCbPub();
                        if (cbpnlePublisher.FindStringExact(currentBookPublisher) > -1)
                        {
                            cbpnlePublisher.SelectedItem = currentBookPublisher;
                        }
                        else
                        {
                            cbpnlePublisher.Items.Add(currentBookPublisher);
                            cbpnlePublisher.SelectedItem = currentBookPublisher;
                        }
                        txtpnlePublisher.Text = null;
                        btnpnleAddPubIcon_Click(null, null);
                    }
                }
                else
                {
                    txtpnlePublisher.Text = null;
                    MessageBox.Show("Publisher is already in the list");
                }
            }
        }

        private void btnpnleAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpnleCategory.Text))
            {
                toolTip.Show("Field is currently empty.", txtpnleCategory, 5, txtpnleCategory.Height - 1, 3000);
                return;
            }
            else
            {
                if (cbpnleCategory.FindStringExact(txtpnleCategory.Text) == -1 || currentBookCategoryExist == false)
                {
                    if (AddABEBPub(txtpnleCategory.Text) == true)
                    {
                        FillEditBooksCbCat();
                        if (cbpnleCategory.FindStringExact(currentBookCategory) > -1)
                        {
                            cbpnleCategory.SelectedItem = currentBookCategory;
                        }
                        else
                        {
                            cbpnleCategory.Items.Add(currentBookCategory);
                            cbpnleCategory.SelectedItem = currentBookCategory;
                        }
                        txtpnleCategory.Text = null;
                        btnpnleAddCatIcon_Click(null, null);
                    }
                }
                else
                {
                    txtpnleCategory.Text = null;
                    MessageBox.Show("Category is already in the list");
                }
            }
        }

        private void btnpnleEditBook_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblpnlePanelName;
            pnlecontrolenabled();
            btnpnleEditBook.Visible = false;
        }

        private void btnpnleUpdate_Click(object sender, EventArgs e)
        {
            if (txtpnleBookTitle.Text == currentBookTitle
                && txtpnleAuthor.Text == currentBookAuthor
                && cbpnlePublisher.Text == currentBookPublisher
                && cbpnleYearPublished.Text == currentBookYearPublished
                && cbpnleVolume.Text == currentBookVolume
                && txtpnleNumberOfPages.Text == currentBookNumberOfPages
                && cbpnleCategory.Text == currentBookCategory
                && cbpnleClassification.Text == currentBookClassification
                && cbpnleSubClass.SelectedIndex == cbpnleSubClass.FindString(currentBookSubclass)
                && txtpnlePrice.Text == currentBookPrice
                && cbpnleStatus.Text == currentBookStatus
                && cbpnleInformation.Text == currentBookInformation)
            {
                MessageBox.Show("No changes were made.");
                return;
            }
            else
            {
                bool processSuccess;
                using (new RunProcess(pnlmfEdit))
                {
                    processSuccess = UpdateBook(currentBookAccessionNumber, txtpnleBookTitle.Text, txtpnleAuthor.Text, cbpnlePublisher.Text, Convert.ToInt32(cbpnleYearPublished.Text), Convert.ToInt32(cbpnleVolume.Text), cbpnleCategory.Text, Convert.ToInt32(txtpnleNumberOfPages.Text), cbpnleSubClass.Text.Split('.'), Convert.ToDecimal(txtpnlePrice.Text.Replace(cultureCurrencySymbol, string.Empty)), cbpnleStatus.Text, cbpnleInformation.Text);
                }
                if (processSuccess)
                {
                    FillMainFormDGV();
                    btnpnleCancel.Text = "Done";
                    btnpnleEditBook.Enabled = false;
                    txtpnleAccessNo.Text = null;
                    txtpnleBookTitle.Text = null;
                    txtpnleAuthor.Text = null;
                    cbpnlePublisher.Text = null;
                    cbpnleYearPublished.Text = null;
                    cbpnleVolume.Text = null;
                    cbpnleCategory.Text = null;
                    txtpnleNumberOfPages.Text = null;
                    cbpnleClassification.SelectedIndexChanged -= cbpnleClassification_SelectedIndexChanged;
                    cbpnleClassification.Text = null;
                    cbpnleSubClass.Text = null;
                    txtpnlePrice.TextChanged -= txtpnlePrice_TextChanged;
                    txtpnlePrice.Text = null;
                    cbpnleStatus.Text = null;
                    cbpnleInformation.Text = null;
                    pnlecontroldisabled();
                    MessageBox.Show("Book Successfully Updated.");
                }
            }
        }

        private void btnpnleDelete_Click(object sender, EventArgs e)
        {
            bool processSuccess;
            using (new RunProcess(pnlmfEdit))
            {
                processSuccess = DeleteBook(currentBookAccessionNumber, currentBookTitle);
            }
            if (processSuccess)
            {

                FillMainFormDGV();
                btnpnleCancel.Text = "Done";
                btnpnleEditBook.Enabled = false;
                txtpnleAccessNo.Text = null;
                txtpnleBookTitle.Text = null;
                txtpnleAuthor.Text = null;
                cbpnlePublisher.Text = null;
                cbpnleYearPublished.Text = null;
                cbpnleVolume.Text = null;
                cbpnleCategory.Text = null;
                txtpnleNumberOfPages.Text = null;
                cbpnleClassification.SelectedIndexChanged -= cbpnleClassification_SelectedIndexChanged;
                cbpnleClassification.Text = null;
                cbpnleSubClass.Text = null;
                txtpnlePrice.TextChanged -= txtpnlePrice_TextChanged;
                txtpnlePrice.Text = null;
                cbpnleStatus.Text = null;
                cbpnleInformation.Text = null;
                pnlecontroldisabled();
                MessageBox.Show("Book Deleted.");
            }
        }

        private void btnpnleCancel_Click(object sender, EventArgs e)
        {
            if (btnpnleUpdate.Visible == true)
            {
                txtpnleAccessNo.Text = "BID" + currentBookAccessionNumber.ToString("D4");
                txtpnleBookTitle.Text = currentBookTitle;
                txtpnleAuthor.Text = currentBookAuthor;
                cbpnlePublisher.SelectedIndex = cbpnlePublisher.FindStringExact(currentBookPublisher);
                cbpnleYearPublished.SelectedIndex = cbpnleYearPublished.FindStringExact(currentBookYearPublished);
                cbpnleVolume.SelectedIndex = cbpnleVolume.FindStringExact(currentBookVolume);
                txtpnleNumberOfPages.Text = currentBookNumberOfPages;
                cbpnleCategory.SelectedIndex = cbpnleCategory.FindStringExact(currentBookCategory);
                cbpnleClassification.SelectedIndex = cbpnleClassification.FindStringExact(currentBookClassification);
                cbpnleSubClass.SelectedIndex = cbpnleSubClass.FindString(currentBookSubclass);
                txtpnlePrice.Text = currentBookPrice;
                cbpnleStatus.SelectedIndex = cbpnleStatus.FindStringExact(currentBookStatus);
                cbpnleInformation.SelectedIndex = cbpnleInformation.FindStringExact(currentBookInformation);
                pnlecontroldisabled();
            }
            else
            {
                ShowMainFormButtons();
                txtpnleAccessNo.Text = null;
                txtpnleBookTitle.Text = null;
                txtpnleAuthor.Text = null;
                cbpnlePublisher.Text = null;
                cbpnleYearPublished.Text = null;
                cbpnleVolume.Text = null;
                cbpnleCategory.Text = null;
                txtpnleNumberOfPages.Text = null;
                cbpnleClassification.SelectedIndexChanged -= cbpnleClassification_SelectedIndexChanged;
                cbpnleClassification.Text = null;
                cbpnleSubClass.Text = null;
                txtpnlePrice.TextChanged -= txtpnlePrice_TextChanged;
                txtpnlePrice.Text = null;
                cbpnleStatus.Text = null;
                cbpnleInformation.Text = null;
                pnlmfEdit.Hide();
                txtpnlePublisher.Hide();
                btnpnleAddPublisher.Hide();
                txtpnleCategory.Hide();
                btnpnleAddCategory.Hide();
            }
        }
        #endregion

        #region Borrow Books Panel
        private void btnmfBorrow_Click(object sender, EventArgs e)
        {
            if (pnlmfBorrow.Visible == false)
            {
                FillBorrowBooksExtDGV();
                dvpnlbbGridView.Columns[0].ValueType = typeof(int);
                ShowPanel(pnlmfBorrow);
                txtpnlbbClientID.Text = null;
                txtpnlbbName.Text = null;
                txtpnlbbContactNumber.Text = null;
                txtpnlbbextName.Text = null;
                txtpnlbbextName_Leave(null, null);
                btnpnlbbAdd.Enabled = false;
                btnpnlbbRemove.Enabled = false;
                btnpnlbbClear.Enabled = false;
                btnpnlbbBorrowBooks.Enabled = false;
                dvpnlbbGridView.Enabled = false;
                btnpnlbbHistory.Enabled = false;
                this.ActiveControl = txtpnlbbClientID;
            }
            else
            {
                pnlmfBorrow.Visible = false;
            }
        }

        private void PopulateBorrowBooksExtDGV(int clientId, string firstName, string middleName, string lastName, string contactNumber)
        {
            object[] row = { clientId, firstName + " " + middleName + " " + lastName, contactNumber };
            dvpnlbbextGridView.Rows.Add(row);
        }

        private void FillBorrowBooksExtDGV()
        {
            try
            {
                dvpnlbbextGridView.Rows.Clear();
                clientsDataTable.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Clients ORDER BY date_registered DESC, date_modified DESC";
                    using (clientsAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        clientsAdapter.Fill(clientsDataTable);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(clientsDataTable))
                {
                    if (dtbreader.HasRows)
                    {
                        btnpnlbbextSearch.Enabled = true;
                        dvpnlbbextGridView.Columns[0].ValueType = typeof(Int32);
                        foreach (DataRow row in clientsDataTable.Rows.Cast<DataRow>().Take(30))
                        {
                            PopulateBorrowBooksExtDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                        }
                    }
                    else
                    {
                        btnpnlbbextSearch.Enabled = false;
                        dvpnlbbextGridView.Rows.Add("0", "NO RECORDS");
                        dvpnlbbextGridView.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvpnlbbextGridView.ClearSelection();
            }
        }

        private void BookTransaction(string clientName, string bookTitle, string transactionType, string transactionInformation, decimal ammountPaid)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO Transactions(client_name, book_title, [transaction], information, ammount_paid, transaction_date) VALUES(?, ?, ?, ?, ?, ?)";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", clientName);
                        cmd.Parameters.AddWithValue("?", bookTitle);
                        cmd.Parameters.AddWithValue("?", transactionType);
                        cmd.Parameters.AddWithValue("?", transactionInformation);
                        cmd.Parameters.Add("?", OleDbType.Decimal).Value = ammountPaid;
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

        private void BookHistory(string bookTable, string clientName, string transactionType, string information)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = string.Format("INSERT INTO {0} (client_name, transaction_type, information, transaction_date) VALUES (?,?,?,?)", bookTable);
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", clientName);
                        cmd.Parameters.AddWithValue("?", transactionType);
                        cmd.Parameters.AddWithValue("?", information);
                        cmd.Parameters.AddWithValue("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void BorrowBook(string clientTable, string bookTable, string clientName, int accessNum, string bookTitle, int days)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = string.Format("INSERT INTO {0} (access_num, book_title, borrow_date, due_date, status, information) VALUES(?, ?, ?, ?, ?, ?)", clientTable);
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", accessNum);
                        cmd.Parameters.AddWithValue("?", bookTitle);
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.ToString());
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.AddDays(days).ToString());
                        cmd.Parameters.AddWithValue("?", "Borrowed");
                        cmd.Parameters.AddWithValue("?", days.ToString() + " Day/s");
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            sqlQuery = "UPDATE Books SET status = ?, information = ?, due_date = ? WHERE access_num = ?";
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", "Unavailable");
                                cmd.Parameters.AddWithValue("?", "Borrowed");
                                cmd.Parameters.AddWithValue("?", OleDbType.Date).Value = DateTime.Parse(DateTime.Now.AddDays(days).ToString());
                                cmd.Parameters.AddWithValue("?", accessNum);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    BookTransaction(clientName, bookTitle, "Borrowed", days.ToString() + " Day/s", 0);
                                    BookHistory(bookTable, clientName, "Borrowed", days.ToString() + " Day/s");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void pnlmfBorrow_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfBorrow.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void pnlbbextViewList_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlbbextViewList.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlbbClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlbbClientID, 5, txtpnlbbClientID.Height - 1, 3000);
            }
        }

        private void txtpnlbbextName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtpnlabCategory.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtpnlabCategory, 5, txtpnlabCategory.Height - 1, 3000);
            }
        }

        private void txtpnlbbextName_TextChanged(object sender, EventArgs e)
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

        private void txtpnlbbextName_Leave(object sender, EventArgs e)
        {
            if (txtpnlbbextName.Text == "")
            {
                txtpnlbbextName.Text = "Enter Name e.g., Juan Dela Cruz";
                txtpnlbbextName.ForeColor = Color.DarkGray;
            }
        }

        private void txtpnlbbextName_Enter(object sender, EventArgs e)
        {
            if (txtpnlbbextName.Text == "Enter Name e.g., Juan Dela Cruz")
            {
                txtpnlbbextName.Text = null;
                txtpnlbbextName.ForeColor = Color.Black;
            }
        }

        private void dvpnlbbGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvpnlbbGridView.SelectedRows.Count> 0 && e.RowIndex != -1)
            {
                int borrowDays =  Convert.ToInt32(dvpnlbbGridView.Rows[e.RowIndex].Cells[2].Value);
                txtpnlbbDueDate.Text = DateTime.Now.AddDays(borrowDays).ToString("MMM/dd/yyyy dddd");
            }
        }

        int borrowBookClientId;
        private void dvpnlbbextGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvpnlbbextGridView.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                borrowBookClientId = Convert.ToInt32(dvpnlbbextGridView.Rows[dvpnlbbextGridView.SelectedRows[0].Index].Cells[0].Value);
                btnpnlbbAdd.Enabled = true;
                btnpnlbbRemove.Enabled = true;
                btnpnlbbClear.Enabled = true;
                dvpnlbbGridView.Enabled = true;
                btnpnlbbHistory.Enabled = true;
                txtpnlbbClientID.Text = borrowBookClientId.ToString();
                txtpnlbbName.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[1]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[2]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[3]).FirstOrDefault();
                txtpnlbbContactNumber.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[4]).FirstOrDefault();
            }
        }

        private void dvpnlbbGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnpnlbbBorrowBooks.Enabled = true;
            DataGridViewComboBoxCell cbc = dvpnlbbGridView.Rows[e.RowIndex].Cells[2] as DataGridViewComboBoxCell;
            string[] days = Enumerable.Range(1, 30).Cast<object>().Select(n => n.ToString()).ToArray();
            cbc.Items.AddRange(days);
            dvpnlbbGridView.Rows[e.RowIndex].Cells[2].Value = cbc.Items[0];
        }

        private void dvpnlbbGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dvpnlbbextGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dvpnlbbextGridView.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dvpnlbbextGridView.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void dvpnlbbGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvpnlbbGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                dvpnlbbGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dvpnlbbGridView.EndEdit();
            }
        }

        private void dvpnlbbGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dvpnlbbGridView_CellClick(sender, e);
        }

        private void dvpnlbbGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).FlatStyle = FlatStyle.Popup;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void btnpnlbbFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpnlbbClientID.Text))
            {
                if (clientsDataTable.Rows.Find(txtpnlbbClientID.Text) != null)
                {
                    toolTip.Hide(txtpnlbbClientID);
                    btnpnlbbAdd.Enabled = true;
                    btnpnlbbRemove.Enabled = true;
                    btnpnlbbClear.Enabled = true;
                    dvpnlbbGridView.Enabled = true;
                    btnpnlbbHistory.Enabled = true;
                    borrowBookClientId = Convert.ToInt32(txtpnlbbClientID.Text);
                    txtpnlbbName.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[1]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[2]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[3]).FirstOrDefault();
                    txtpnlbbContactNumber.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == borrowBookClientId select (string)dr[4]).FirstOrDefault();
                }
                else
                {
                    toolTip.Show("Client Not Foud.", txtpnlbbClientID, 5, txtpnlbbClientID.Height - 1, 2000);
                    btnpnlbbAdd.Enabled = false;
                    btnpnlbbRemove.Enabled = false;
                    btnpnlbbClear.Enabled = false;
                    txtpnlbbName.Text = null;
                    txtpnlbbContactNumber.Text = null;
                    return;
                }
            }
            else
            {
                toolTip.Show("Field is currently empty.", txtpnlbbClientID, 5, txtpnlbbClientID.Height - 1, 3000);
            }

        }

        private void btnpnlbbViewList_Click(object sender, EventArgs e)
        {
            HideMainFormButtons();
            dvpnlbbextGridView.ClearSelection();
            pnlbbextViewList.Visible = true;
        }

        private void btnpnlbbAdd_Click(object sender, EventArgs e)
        {
            if (dvpnlbbGridView.RowCount < Properties.Settings.Default.Maximum_Book && dvmfGridView.SelectedRows.Count > 0 && (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (string)dr[12]).FirstOrDefault() == "Available")
            {

                bool itemExist = dvpnlbbGridView.Rows.Cast<DataGridViewRow>().Count(row => Convert.ToInt32(row.Cells[0].Value) == (from DataRow dr in booksDataTable.Rows where (int)dr[0] == Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value) select (int)dr[0]).FirstOrDefault()) > 0;
                if (!itemExist)
                {
                    int accessionNumber = Convert.ToInt32(dvmfGridView.Rows[dvmfGridView.SelectedRows[0].Index].Cells[0].Value);
                    dvpnlbbGridView.Rows.Add((from DataRow dr in booksDataTable.Rows where (int)dr[0] == accessionNumber select (int)dr[0]).FirstOrDefault().ToString(), (from DataRow dr in booksDataTable.Rows where (int)dr[0] == accessionNumber select (string)dr[1]).FirstOrDefault().ToString(), null);
                    dvpnlbbGridView.ClearSelection();
                }
            }
        }

        private void btnpnlbbRemove_Click(object sender, EventArgs e)
        {
            if (dvpnlbbGridView.SelectedRows.Count > 0)
            {
                dvpnlbbGridView.Rows.Remove(dvpnlbbGridView.Rows[dvpnlbbGridView.SelectedRows[0].Index]);
            }
        }

        private void btnpnlbbClear_Click(object sender, EventArgs e)
        {
            dvpnlbbGridView.Rows.Clear();
        }

        private void btnpnlbbHistory_Click(object sender, EventArgs e)
        {
            string clientTable = string.Format("CID{0}",borrowBookClientId.ToString("D4"));
            string clientName = txtpnlbbName.Text;
            using (new RunProcess(pnlmfReturn, false))
            {
                ClientHistoryForm chf = new ClientHistoryForm(clientTable, clientName);
                chf.ShowDialog();
            }
        }

        private void btnpnlbbBorrowBooks_Click(object sender, EventArgs e)
        {
            using (new RunProcess(pnlmfBorrow))
            {
                try
                {
                    if (dvpnlbbGridView.Rows.Count > 0)
                    {

                        string clientTable = "CID" + borrowBookClientId.ToString("D4");
                        int Borrowed = 0;
                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            string sqlQuery = "";
                            if (!con.TableExists(clientTable))
                            {
                                con.Open();
                                sqlQuery = string.Format("CREATE TABLE {0} ([transact_id] AUTOINCREMENT PRIMARY KEY, [access_num] INTEGER, [book_title] TEXT, [borrow_date] DATETIME, [due_date] DATETIME, [status] TEXT,[information] TEXT)", clientTable);
                                using (cmd = new OleDbCommand(sqlQuery, con))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            sqlQuery = string.Format("SELECT COUNT (*) FROM {0} WHERE status = 'Borrowed'", clientTable);
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                Borrowed = (int)cmd.ExecuteScalar();
                            }
                        }

                        if(dvpnlbbGridView.Rows.Count > Properties.Settings.Default.Maximum_Book - Borrowed)
                        {
                            if (Properties.Settings.Default.Maximum_Book - Borrowed == 0)
                            {
                                MessageBox.Show(string.Format("The client already have {0} items currently borrowed.", Properties.Settings.Default.Maximum_Book.ToString()));
                            }
                            else
                            {
                                MessageBox.Show(string.Format("The current client can only borrow {0} books, remove {1} item/s in the list.", Convert.ToInt32(Properties.Settings.Default.Maximum_Book - Borrowed).ToString(), Convert.ToInt32(dvpnlbbGridView.Rows.Count - (Properties.Settings.Default.Maximum_Book - Borrowed))));
                            }
                            return;
                        }

                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            foreach (DataGridViewRow row in dvpnlbbGridView.Rows)
                            {
                                string bookTable = "BID" + Convert.ToInt32(row.Cells[0].Value).ToString("D4");
                                if (!con.TableExists(bookTable))
                                {
                                    con.Open();
                                    string sqlQuery = string.Format("CREATE TABLE {0} ([history_id] AUTOINCREMENT PRIMARY KEY, [client_name] TEXT, [transaction_type] TEXT, [information] TEXT, [transaction_date] DATETIME)", bookTable);
                                    using (cmd = new OleDbCommand(sqlQuery, con))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    con.Close();
                                }
                                BorrowBook(clientTable, bookTable, txtpnlbbName.Text, Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(), Convert.ToInt32(row.Cells[2].Value.ToString()));
                            }
                        }
                        dvpnlbbGridView.Rows.Clear();
                        btnmfReset_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("List is currently empty.");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnpnlbbCancel_Click(object sender, EventArgs e)
        {
            ShowMainFormButtons();
            dvpnlbbGridView.Rows.Clear();
            pnlmfBorrow.Visible = false;
            pnlbbextViewList.Visible = false;
        }

        private void btnpnlbbextSearch_Click(object sender, EventArgs e)
        {
            dvpnlbbextGridView.Rows.Clear();
            foreach (DataRow row in clientsDataTable.Select("first_name LIKE '" + txtpnlbbextName.Text + "%' OR middle_name LIKE '" + txtpnlbbextName.Text + "%' OR last_name LIKE '" + txtpnlbbextName.Text + "%'", "first_name ASC").Cast<DataRow>().Take(30))
            {
                PopulateBorrowBooksExtDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
        }

        private void btnpnlbbextReset_Click(object sender, EventArgs e)
        {
            FillBorrowBooksExtDGV();
        }

        private void btnpnlbbextDone_Click(object sender, EventArgs e)
        {
            FillBorrowBooksExtDGV();
            ShowMainFormButtons();
            pnlbbextViewList.Hide();
        }
        #endregion

        #region Return Books Panel
        private void btnmfReturn_Click(object sender, EventArgs e)
        {
            if (pnlmfReturn.Visible == false)
            {
                FillReturnBooksExtDGV();
                pnlmfAddClient.Visible = false;
                pnlmfSearchClient.Visible = false;
                pnlmfAddBooks.Visible = false;
                pnlmfEdit.Visible = false;
                pnlmfBorrow.Visible = false;
                pnlmfReturn.Visible = true;
                txtpnlrbClientID.Text = null;
                txtpnlrbName.Text = null;
                txtpnlrbContactNumber.Text = null;
                txtpnlrbextName.Text = null;
                txtpnlrbextName_Leave(null, null);
                btnpnlrbReturnBooks.Enabled = false;
                AddHeaderChkb(dvpnlrbGridView);
                dvpnlrbGridView.Enabled = false;
                pnlrbchkb.Checked = false;
                pnlrbchkb.CheckedChanged -= pnlrbchkb_CheckedChanged;
                pnlrbchkb.CheckedChanged += pnlrbchkb_CheckedChanged;
                this.ActiveControl = txtpnlrbClientID;

            }
            else
            {
                pnlmfReturn.Visible = false;
            }
        }

        /// <summary>
        /// Computes the overdue using the local value set and days
        /// </summary>
        /// <param name="days"></param>
        /// <returns>The ammount</returns>
        private decimal ComputeOverdue(int days)
        {
            decimal dailyFee = Properties.Settings.Default.Daily_Fee;
            decimal maximumFee = Properties.Settings.Default.Maximum_Fee;
            decimal overdueFee = (dailyFee * days);
            overdueFee = (overdueFee >= maximumFee ? maximumFee : overdueFee);
            return overdueFee;
        }
        /// <summary>
        /// Computation for the Damaged or Lost return type
        /// </summary>
        /// <param name="accessNum"></param>
        /// <param name="returnType"></param>
        /// <returns>The ammount></returns>
        private decimal ComputeMisc(int accessNum, string returnType)
        {
            string damageType = Properties.Settings.Default.Damaged_Type;
            decimal damagedFee = Properties.Settings.Default.Damaged_Fee;
            string lostType = Properties.Settings.Default.Lost_Type;
            decimal lostFee = Properties.Settings.Default.Lost_Fee;
            decimal miscFee = 0;
            decimal bookPrice = Convert.ToDecimal((from DataRow dr in booksDataTable.Rows where (int)dr[0] == accessNum select (decimal)dr[9]).FirstOrDefault().ToString().Replace(cultureCurrencySymbol, string.Empty));
            if (returnType == "Return")
            {
                miscFee = 0;
            }
            else if (returnType == "Damaged")
            {
                if (damageType == "Percentage")
                {
                    miscFee = damagedFee / 100 * bookPrice;
                }
                else
                {
                    miscFee = damagedFee;
                }
            }
            else
            {
                if (lostType == "Book Price")
                {
                    miscFee = bookPrice;
                }
                else
                {
                    miscFee = lostFee;
                }
            }
            return miscFee;
        }

        private void displayAmmount()
        {
            //Update and display the total ammount to be paid when the user checked the checkboxcell of a row
            decimal currentAmmount = 0;
            foreach (DataGridViewRow row in dvpnlrbGridView.Rows)
            {
                //DataGridViewCheckBoxCell chkbc = (DataGridViewCheckBoxCell)row.Cells[4].Value;
                if ((bool)row.Cells[4].Value == true)
                {
                    if (row.Cells[3].Value.ToString() == "Lost")
                    {
                        currentAmmount += Convert.ToDecimal(row.Cells[6].Value);
                    }
                    else
                    {
                        currentAmmount += Convert.ToDecimal(row.Cells[5].Value) + Convert.ToDecimal(row.Cells[6].Value);
                    }
                }
            }
            txtpnlrbAmmountDue.Text = currentAmmount.ToString("C2", CultureInfo.CurrentCulture);
        }

        private void PopulateReturnBooksExtDGV(int clientId, string first_name, string middle_name, string last_name, string contact_number)
        {
            object[] row = { clientId, first_name + " " + middle_name + " " + last_name, contact_number };
            dvpnlrbextGridView.Rows.Add(row);
        }

        private void PopulateReturnBooksDGV(int transactId, int accessNum, string bookTitle, decimal overdue)
        {
            object[] row = { transactId, accessNum, bookTitle, null, false, overdue, 0 };
            dvpnlrbGridView.Rows.Add(row);
        }

        private void FillReturnBooksExtDGV()
        {
            try
            {
                dvpnlrbextGridView.Rows.Clear();
                clientsDataTable.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Clients ORDER BY date_registered DESC, date_modified DESC";
                    using (clientsAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        clientsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        clientsAdapter.Fill(clientsDataTable);
                    }
                }
                DataTableReader dtbreader = new DataTableReader(clientsDataTable);
                if (dtbreader.HasRows)
                {
                    dtbreader.Close();
                    btnpnlrbextSearch.Enabled = true;
                    dvpnlrbextGridView.Columns[0].ValueType = typeof(Int32);
                    dvpnlrbextGridView.SuspendLayout();
                    foreach (DataRow row in clientsDataTable.Rows.Cast<DataRow>().Take(30))
                    {
                        PopulateReturnBooksExtDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    }
                    dvpnlrbextGridView.ResumeLayout();
                    dvpnlrbextGridView.Enabled = true;
                }
                else
                {
                    btnpnlrbextSearch.Enabled = false;
                    dvpnlrbextGridView.Rows.Add("0", "NO RECORDS");
                    dvpnlrbextGridView.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvpnlrbextGridView.ClearSelection();
            }
        }

        private void FillReturnBooksDGV()
        {
            try
            {
                dvpnlrbGridView.Rows.Clear();
                clientsBooksDataTable.Clear();
                dvpnlrbGridView.RowsAdded -= dvpnlrbGridView_RowsAdded;
                pnlrbchkb.CheckedChanged -= pnlrbchkb_CheckedChanged;
                pnlrbchkb.Checked = false;
                pnlrbchkb.CheckedChanged += pnlrbchkb_CheckedChanged;
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    if (con.TableExists("CID" + returnBooksClientId.ToString("D4")))
                    {
                        string sqlQuery = "SELECT * FROM " + "CID" + returnBooksClientId.ToString("D4") + " WHERE status = 'Borrowed'";
                        using (clientBooksAdapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                        {
                            clientBooksAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                            clientBooksAdapter.Fill(clientsBooksDataTable);
                        }
                        using (DataTableReader dtbreader = new DataTableReader(clientsBooksDataTable))
                        {
                            if (dtbreader.HasRows)
                            {
                                btnpnlrbReturnBooks.Enabled = true;
                                dvpnlrbGridView.Columns[1].ValueType = typeof(int);
                                dvpnlrbGridView.Columns[5].ValueType = typeof(decimal);
                                dvpnlrbGridView.Columns[6].ValueType = typeof(decimal);
                                DateTime return_date = DateTime.Parse(DateTime.Now.ToString());
                                dvpnlrbGridView.Enabled = true;
                                dvpnlrbGridView.RowsAdded += dvpnlrbGridView_RowsAdded;
                                foreach (DataRow row in clientsBooksDataTable.Rows)
                                {
                                    DateTime due_date = DateTime.Parse(row[4].ToString());
                                    decimal overdue_ammount = 0;
                                    if (return_date.Date < due_date.Date)
                                    {
                                        overdue_ammount = 0;
                                    }
                                    else
                                    {
                                        int days = (return_date.Date - due_date.Date).Days;
                                        overdue_ammount = ComputeOverdue(days);
                                    }
                                    PopulateReturnBooksDGV(Convert.ToInt32(row[0].ToString()), Convert.ToInt32(row[1].ToString()), row[2].ToString(), overdue_ammount);
                                }
                            }
                            else
                            {
                                btnpnlrbReturnBooks.Enabled = false;
                                dvpnlrbGridView.Rows.Add(null, null, "NO RECORDS");
                                dvpnlrbGridView.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        btnpnlrbReturnBooks.Enabled = false;
                        dvpnlrbGridView.Rows.Add(null, null, "NO RECORDS");
                        dvpnlrbGridView.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dvpnlrbGridView.ClearSelection();
            }
        }

        private void ReturnBook(string clientTable, int transactionId, string clientName, int accessionNumber, string bookTitle, string returnType, string bookStatus, string status, string bookInformation, string information, decimal ammountPaid)
        {
            try
            {
                string sqlQuery = "UPDATE " + clientTable + " SET status = ?, information = ? WHERE transact_id = ?";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", status);
                        cmd.Parameters.AddWithValue("?", information);
                        cmd.Parameters.AddWithValue("?", transactionId);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            sqlQuery = returnType != "Lost" ? "UPDATE Books SET status = ?, information = ?, due_date = ? WHERE access_num = ?" : "UPDATE Books SET status = ?, information = ? WHERE access_num = ?";
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", bookStatus);
                                cmd.Parameters.AddWithValue("?", bookInformation);
                                if (returnType != "Lost") cmd.Parameters.AddWithValue("?", DBNull.Value);
                                cmd.Parameters.AddWithValue("?", accessionNumber);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    BookTransaction(clientName, bookTitle, returnType, information, ammountPaid);
                                    BookHistory("BID" + accessionNumber.ToString("D4"), clientName, "Borrowed", information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void pnlmfReturn_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlmfReturn.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void pnlrbextViewList_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.FromArgb(125, 64, 64, 0);
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int thickness = 1;
            ControlPaint.DrawBorder(e.Graphics, this.pnlrbextViewList.ClientRectangle, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs, col, thickness, bbs);
        }

        private void txtpnlrbClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtpnlrbClientID, 5, txtpnlrbClientID.Height - 1, 3000);
            }
        }

        private void txtpnlrbextName_Leave(object sender, EventArgs e)
        {
            if (txtpnlrbextName.Text == "")
            {
                txtpnlrbextName.Text = "Enter Name e.g., Juan Dela Cruz";
                txtpnlrbextName.ForeColor = Color.DarkGray;
            }
        }

        private void txtpnlrbextName_Enter(object sender, EventArgs e)
        {
            if (txtpnlrbextName.Text == "Enter Name e.g., Juan Dela Cruz")
            {
                txtpnlrbextName.Text = null;
                txtpnlrbextName.ForeColor = Color.Black;
            }
        }

        private void txtpnlbbName_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = pnlmfReturn;
        }

        private void txtpnlbbContactNumber_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = pnlmfReturn;
        }

        int returnBooksClientId;
        private void dvpnlrbextGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvpnlrbextGridView.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                returnBooksClientId = Convert.ToInt32(dvpnlrbextGridView.Rows[dvpnlrbextGridView.SelectedRows[0].Index].Cells[0].Value);
                txtpnlrbClientID.Text = returnBooksClientId.ToString();
                txtpnlrbName.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[1]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[2]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[3]).FirstOrDefault();
                txtpnlrbContactNumber.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[4]).FirstOrDefault();
                FillReturnBooksDGV();
            }
        }

        private void dvpnlrbGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dvpnlrbGridView.Rows[e.RowIndex].Cells[3];
            string[] days = { "Damaged", "Lost", "Return" };
            cbc.Items.AddRange(days);
            dvpnlrbGridView.Rows[e.RowIndex].Cells[3].Value = cbc.Items[2];
        }

        private void dvpnlrbGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dvpnlrbGridView.IsCurrentCellDirty)
            {
                dvpnlrbGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dvpnlrbGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Computation of the sum of the values of each rows of columns overdue and misc
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 4) && e.RowIndex != -1)
            {
                DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dvpnlrbGridView.Rows[e.RowIndex].Cells[3];
                if (cbc != null)
                {
                    dvpnlrbGridView.Rows[e.RowIndex].Cells[6].Value = ComputeMisc(Convert.ToInt32(dvpnlrbGridView.Rows[e.RowIndex].Cells[1].Value), cbc.Value.ToString());
                }
                //If all checkboxcell is checked, the column header checkbox will be checked
                bool allChecked = true;
                foreach (DataGridViewRow row in dvpnlrbGridView.Rows)
                {
                    DataGridViewCheckBoxCell chkbc = (DataGridViewCheckBoxCell)row.Cells[4];
                    if ((bool)chkbc.Value != true)
                    {
                        allChecked = false;
                        break;
                    }
                }
                pnlrbchkb.CheckedChanged -= pnlrbchkb_CheckedChanged;
                pnlrbchkb.Checked = allChecked == true ? true : false;
                pnlrbchkb.CheckedChanged += pnlrbchkb_CheckedChanged;
                displayAmmount();
            }
        }

        CheckBox pnlrbchkb = new CheckBox();
        private void AddHeaderChkb(DataGridView dgv)
        {
            pnlrbchkb.Size = new Size(15, 15);
            pnlrbchkb.Padding = new Padding(0);
            pnlrbchkb.Margin = new Padding(0);
            pnlrbchkb.Text = "";
            dgv.Controls.Add(pnlrbchkb);
            Rectangle chkbRectangle = dgv.GetCellDisplayRectangle(0, -1, true);
            pnlrbchkb.Location = new Point(380, 12);
        }

        private void pnlrbchkb_CheckedChanged(object sender, EventArgs e)
        {
            dvpnlrbGridView.CellValueChanged -= dvpnlrbGridView_CellValueChanged;
            foreach (DataGridViewRow row in dvpnlrbGridView.Rows)
            {
                DataGridViewCheckBoxCell chkbc = (DataGridViewCheckBoxCell)row.Cells[4];
                chkbc.Value = !(pnlrbchkb.Checked == true ? false : (bool)chkbc.Value);
            }
            dvpnlrbGridView.CellValueChanged += dvpnlrbGridView_CellValueChanged;
            dvpnlrbGridView.EndEdit();
            displayAmmount();
        }

        private void btnpnlrbFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpnlrbClientID.Text))
            {
                returnBooksClientId = Convert.ToInt32(txtpnlrbClientID.Text);
                if (clientsDataTable.Rows.Find(returnBooksClientId) != null)
                {
                    toolTip.Hide(txtpnlrbClientID);
                    txtpnlrbName.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[1]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[2]).FirstOrDefault() + " " + (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[3]).FirstOrDefault();
                    txtpnlrbContactNumber.Text = (from DataRow dr in clientsDataTable.Rows where (int)dr[0] == returnBooksClientId select (string)dr[4]).FirstOrDefault();
                    FillReturnBooksDGV();
                }
                else
                {
                    toolTip.Show("Client Not Found.", txtpnlrbClientID, 5, txtpnlrbClientID.Height - 1, 2000);
                    dvpnlrbGridView.Rows.Clear();
                    txtpnlrbName.Text = null;
                    txtpnlrbContactNumber.Text = null;
                }
            }
            else
            {
                toolTip.Show("Field is currently empty.", txtpnlrbClientID, 5, txtpnlrbClientID.Height - 1, 3000);
            }
        }

        private void btnpnlrbViewList_Click(object sender, EventArgs e)
        {
            HideMainFormButtons();
            pnlrbextViewList.Visible = true;
        }

        private void btnpnlrbReturnBooks_Click(object sender, EventArgs e)
        {
            dvpnlrbGridView.ShowCellToolTips = false;
            foreach (DataGridViewRow row in dvpnlrbGridView.Rows)
            {
                if (row.Cells[3].Value == null)
                {
                    var curCell = row.Cells[3];
                    var cellRect = dvpnlrbGridView.GetCellDisplayRectangle(row.Cells[3].ColumnIndex, row.Cells[3].RowIndex, false);
                    toolTip.Show("Field is currently empty.", dvpnlrbGridView, cellRect.X + curCell.Size.Width / 2, cellRect.Y + curCell.Size.Height / 2, 3000);
                    return;
                }
            }
            bool hasChecked = dvpnlrbGridView.Rows.Cast<DataGridViewRow>().Count(row => (bool)row.Cells[4].Value == true) > 0;
            if (hasChecked)
            {
                string transactionReturnType = null;
                string transactionStatus = null;
                string transactionBookStatus = null;
                string transactionInformation = null;
                string transactionBookInformation = null;
                DateTime borrowDate;
                DateTime returnDate = DateTime.Parse(DateTime.Now.ToString());
                using (new RunProcess(pnlmfReturn))
                {
                    foreach (DataGridViewRow row in dvpnlrbGridView.Rows)
                    {
                        if ((bool)row.Cells[4].Value == true)
                        {
                            borrowDate = DateTime.Parse((from DataRow dr in clientsBooksDataTable.Rows where (int)dr[0] == Convert.ToInt32(row.Cells[0].Value) select (DateTime)dr[3]).FirstOrDefault().ToString());
                            int days = Convert.ToInt32((borrowDate.Date - returnDate.Date).TotalDays) + 1;
                            if (row.Cells[3].Value.ToString() == "Return")
                            {
                                transactionReturnType = "Returned";
                                transactionStatus = transactionReturnType;
                                transactionBookStatus = "Available";
                                transactionInformation = days.ToString() + " Day/s";
                                transactionBookInformation = "";
                            }
                            else if (row.Cells[3].Value.ToString() == "Damaged")
                            {
                                transactionReturnType = row.Cells[3].Value.ToString();
                                transactionStatus = "Borrowed";
                                transactionBookStatus = "Unavailable";
                                transactionInformation = days.ToString() + " Day/s";
                                transactionBookInformation = transactionInformation;
                            }
                            else if (row.Cells[3].Value.ToString() == "Lost")
                            {
                                transactionReturnType = row.Cells[3].Value.ToString();
                                transactionStatus = "Borrowed";
                                transactionBookStatus = "Unavailable";
                                transactionInformation = days.ToString() + " Day/s";
                                transactionBookInformation = transactionInformation;
                            }
                            ReturnBook("CID" + returnBooksClientId.ToString("D4"), Convert.ToInt32(row.Cells[0].Value), txtpnlrbName.Text, Convert.ToInt32(row.Cells[1].Value), row.Cells[2].Value.ToString(), transactionReturnType, transactionBookStatus, transactionStatus, transactionBookInformation, transactionInformation, Convert.ToDecimal(row.Cells[5].Value) + Convert.ToDecimal(row.Cells[6].Value));
                        }
                    }
                    btnmfReset_Click(null, null);
                    FillReturnBooksDGV();
                    pnlrbchkb.Checked = false;
                }
            }
            else
            {
                var curCell = dvpnlrbGridView.Rows[0].Cells[4];
                var cellRect = dvpnlrbGridView.GetCellDisplayRectangle(dvpnlrbGridView.Rows[0].Cells[4].ColumnIndex, dvpnlrbGridView.Rows[0].Cells[4].RowIndex, false);
                toolTip.Show("Check at least one item.", dvpnlrbGridView, cellRect.X + curCell.Size.Width / 2, cellRect.Y + curCell.Size.Height / 2, 3000);
                return;
            }

        }

        private void btnpnlrbDone_Click(object sender, EventArgs e)
        {
            dvpnlrbGridView.Rows.Clear();
            ShowMainFormButtons();
            pnlmfReturn.Visible = false;
            pnlrbextViewList.Visible = false;
        }

        private void btnpnlrbextSearch_Click(object sender, EventArgs e)
        {
            dvpnlrbextGridView.Rows.Clear();
            foreach (DataRow row in clientsDataTable.Select("first_name LIKE '" + txtpnlrbextName.Text + "%' OR middle_name LIKE '" + txtpnlrbextName.Text + "%' OR last_name LIKE '" + txtpnlrbextName.Text + "%'", "first_name ASC").Cast<DataRow>().Take(30))
            {
                PopulateReturnBooksExtDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
        }

        private void btnpnlrbextReset_Click(object sender, EventArgs e)
        {
            FillReturnBooksExtDGV();
        }

        private void btnpnlrbextDone_Click(object sender, EventArgs e)
        {
            btnpnlrbextReset_Click(null, null);
            ShowMainFormButtons();
            pnlrbextViewList.Visible = false;
        }
        #endregion
    }
}