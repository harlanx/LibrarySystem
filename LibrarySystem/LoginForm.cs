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
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class LoginForm : Form
    {
        public static string accountName;
        public static string accountType;
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        ToolTip toolTip = new ToolTip();
        ToolTip toolTip1 = new ToolTip();
        public LoginForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Init_Data();
        }

        #region SQL Query Tester Function
        private void queryTester()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM AppSettings";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        using (OleDbDataReader dbreader = cmd.ExecuteReader())
                        {
                            while (dbreader.Read())
                            {
                                Console.WriteLine(dbreader["remember_me"].ToString());
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
        #endregion

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
                        cmd.Parameters.AddWithValue("?", accountName);
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

        private void IsDateBehind()
        {
            if (Properties.Settings.Default.Last_Date.ToString() != "01/01/0001 12:00:00 AM" && DateTime.Now <= Properties.Settings.Default.Last_Date)
            {
                if (MessageBox.Show("Current date and time is less than the last saved date and time, continue?", "Date and Time Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    return;
                }
                else
                {
                    Environment.Exit(0);
                }
            }

        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Focuses on the Form Label at the top to prevent default focusing on username textbox
            this.ActiveControl = lblLoginAccount;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                if (con.IsAvailable())
                {
                    IsDateBehind();
                }
                else
                {
                    MessageBox.Show("Database Connection Problem. Please Contact Administrator");
                }
            }
            toolTip.Hide(txtlfUser);
            toolTip.Hide(txtlfPassHidden);
        }

        private void txtlfUser_Leave(object sender, EventArgs e)
        {
            if (txtlfUser.Text == "")
            {
                txtlfUser.Text = "Enter Username";
                txtlfUser.ForeColor = Color.DarkGray;
            }
        }

        private void txtlfUser_Enter(object sender, EventArgs e)
        {
            if (txtlfUser.Text == "Enter Username")
            {
                txtlfUser.Text = null;
                txtlfUser.ForeColor = Color.Black;
            }
        }

        private void txtlfPassHidden_Leave(object sender, EventArgs e)
        {
            if (txtlfPassHidden.Text == "")
            {
                txtlfPassHidden.Text = "Enter Password";
                txtlfPassHidden.ForeColor = Color.DarkGray;
            }
        }

        private void txtlfPassHidden_Enter(object sender, EventArgs e)
        {
            if (txtlfPassHidden.Text == "Enter Password")
            {
                txtlfPassHidden.Text = null;
                txtlfPassHidden.ForeColor = Color.Black;
            }
        }

        private void txtlfUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtlfUser, 5, txtlfUser.Height - 1, 3000);
            }
        }

        private void txtlfPassHidden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtlfPassHidden, 5, txtlfPassHidden.Height - 1, 3000);
            }
        }

        /// <summary>
        /// Populate the textboxes on the next run using the store/cached information of the last user successfully logged in
        /// </summary>
        private void Init_Data()
        {
            if (Properties.Settings.Default.RestoredFlag == true)
            {
                try
                {
                    using (OleDbConnection con = new OleDbConnection(conString))
                    {
                        con.Open();
                        string sqlQuery = "SELECT * FROM AppSettings WHERE setting_id = 1";
                        using (cmd = new OleDbCommand(sqlQuery, con))
                        {
                            using (OleDbDataReader dbreader = cmd.ExecuteReader())
                            {
                                while (dbreader.Read())
                                {
                                    Properties.Settings.Default.LoginUserName = dbreader["login_username"].ToString();
                                    Properties.Settings.Default.LoginPassword = dbreader["login_password"].ToString();
                                    Properties.Settings.Default.RememberMe = Convert.ToBoolean(dbreader["remember_me"].ToString().ToLower());
                                    Properties.Settings.Default.Counter_Access_Number = Convert.ToInt32(dbreader["accession_number"].ToString());
                                    Properties.Settings.Default.Counter_Client_ID = Convert.ToInt32(dbreader["client_id"].ToString());
                                    Properties.Settings.Default.Daily_Fee = Convert.ToDecimal(dbreader["daily_fee"].ToString());
                                    Properties.Settings.Default.Maximum_Fee = Convert.ToDecimal(dbreader["maximum_fee"].ToString());
                                    Properties.Settings.Default.Damaged_Type = dbreader["damaged_type"].ToString();
                                    Properties.Settings.Default.Damaged_Fee = Convert.ToDecimal(dbreader["damaged_fee"].ToString());
                                    Properties.Settings.Default.Lost_Type = dbreader["lost_type"].ToString();
                                    Properties.Settings.Default.Lost_Fee = Convert.ToDecimal(dbreader["lost_fee"].ToString());
                                    Properties.Settings.Default.Maximum_Book = Convert.ToInt32(dbreader["maximum_book"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    Properties.Settings.Default.RestoredFlag = false;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
            }

            if (Properties.Settings.Default.LoginUserName != string.Empty)
            {
                if (Properties.Settings.Default.RememberMe == true)
                {
                    txtlfUser.Text = Properties.Settings.Default.LoginUserName;
                    txtlfUser.ForeColor = Color.Black;
                    txtlfPass.Text = Properties.Settings.Default.LoginPassword;
                    txtlfPassHidden.Text = Properties.Settings.Default.LoginPassword;
                    chkbRememberMe.Checked = true;
                }
            }
        }

        /// <summary>
        /// Store the current information and configuration in the application.
        /// </summary>
        private void Save_Data()
        {
            if (chkbRememberMe.Checked)
            {
                Properties.Settings.Default.LoginUserName = txtlfUser.Text;
                Properties.Settings.Default.LoginPassword = txtlfPass.Text;
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.LoginUserName = "";
                Properties.Settings.Default.LoginPassword = "";
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
        }

        //Show Password
        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            txtlfPassHidden.Hide();
            if (txtlfPass.Text == "Enter Password")
            {
                txtlfPass.ForeColor = Color.DarkGray;
            }
            else
            {
                txtlfPass.ForeColor = Color.Black;
            }
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            txtlfPassHidden.Show();
        }

        private void LoginTimer_Tick(object sender, EventArgs e)
        {
            txtlfPass.Text = txtlfPassHidden.Text;
        }
 
        public void btnlfLogin_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtlfUser.Text) || txtlfUser.Text == "Enter Username")
                || (string.IsNullOrWhiteSpace(txtlfPassHidden.Text) || txtlfPassHidden.Text == "Enter Password"))
            {
                if (string.IsNullOrWhiteSpace(txtlfUser.Text) || txtlfUser.Text == "Enter Username")
                {
                    toolTip.Show("Field is currently empty", txtlfUser, 5, txtlfUser.Height - 1, 3000);
                }

                if (string.IsNullOrWhiteSpace(txtlfPassHidden.Text) || txtlfPassHidden.Text == "Enter Password")
                {
                    toolTip1.Show("Field is currently empty", txtlfPassHidden, 5, txtlfPassHidden.Height - 1, 3000);
                }
                return;
            }
            else
            {
                IsDateBehind();
                //Check if the credentials are administrator.
                if ((txtlfUser.Text == "JHEHM2019") && (txtlfPass.Text == "JHEHM2019"))
                {
                    toolTip.Hide(txtlfUser);
                    accountName = "STI San Jose";
                    accountType = "Administrator";
                    SaveToLog("Login", "Success");
                    Save_Data();
                    //FormClosing -= LoginForm_FormClosing;
                    using (new RunProcess(this))
                    {
                        MainForm mnfrm = new MainForm();
                        mnfrm.ShowDialog();
                    }
                }
                //If not, the codes bellow it will check for the users in the database.
                else
                {
                    try
                    {
                        //With the using block the connection is automatically disposed and closed
                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            //Open connection to the database
                            con.Open();
                            string sqlQuery = "SELECT COUNT(*) FROM Users WHERE username = ?";
                            //Create the command using the string query
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                //Clear the current parameter collection since the command is a global variable
                                cmd.Parameters.Clear();
                                //Assigning the parameter value.
                                cmd.Parameters.AddWithValue("?", txtlfUser.Text);
                                //The ExecuteScalar will return a single row and column of the matched item.
                                if ((int)cmd.ExecuteScalar() > 0)
                                {
                                    sqlQuery = "SELECT first_name, last_name, authority FROM Users WHERE username = ?";
                                    using (cmd = new OleDbCommand(sqlQuery, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", txtlfUser.Text);
                                        using (OleDbDataReader dbreader = cmd.ExecuteReader())
                                        {
                                            //Assign the values for the variable while the reader reads the result of the query
                                            while (dbreader.Read())
                                            {
                                                accountName = dbreader["first_name"].ToString() + " " + dbreader["last_name"].ToString();
                                                accountType = dbreader["authority"].ToString();
                                            }
                                        }
                                    }
                                    sqlQuery = "SELECT COUNT(*) FROM Users WHERE username = ? AND [password] = ?";
                                    using (cmd = new OleDbCommand(sqlQuery, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", txtlfUser.Text);
                                        cmd.Parameters.AddWithValue("?", txtlfPassHidden.Text);
                                        if ((int)cmd.ExecuteScalar() > 0)
                                        {
                                            toolTip.Hide(txtlfUser);
                                            //Call the save method of remember me function
                                            Save_Data();
                                            SaveToLog("Login", "Success");
                                            using (new RunProcess(this))
                                            {
                                                // Creating new instance on the mainform
                                                MainForm mnfrm = new MainForm();
                                                //Showing the Main Form
                                                mnfrm.ShowDialog();
                                            }
                                        }
                                        //Username exist but the password is wrong
                                        else
                                        {
                                            SaveToLog("Login", "Failed");
                                            toolTip.Hide(txtlfUser);
                                            toolTip.Show("Wrong Password, Please Re-Enter", txtlfPassHidden, 5, txtlfPassHidden.Height - 1, 3000);
                                        }
                                    }
                                }
                                //The user tries to login with username that doesn't exist in the database.
                                else
                                {
                                    txtlfPassHidden.Text = null;
                                    txtlfPassHidden_Leave(sender, e);
                                    toolTip.Hide(txtlfPassHidden);
                                    toolTip.Show("User not foud", txtlfUser, 5, txtlfUser.Height - 1, 3000);
                                }
                            }
                        }
                    }
                    //Handles the errors/exceptions produced by the OleDb Operations
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }

        private void lnklbllfFP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (new RunProcess(this, false))
            {
                ForgotPasswordForm fpfrm = new ForgotPasswordForm();
                fpfrm.ShowDialog();
            }
        }

        private void btnlfCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Last_Date = DateTime.Now;
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Exit Login?", "Exiting Program", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.Last_Date = DateTime.Now;
                    Properties.Settings.Default.Save();
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
    }
}
