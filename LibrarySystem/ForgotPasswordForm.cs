using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class ForgotPasswordForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        ToolTip toolTip = new ToolTip();

        public ForgotPasswordForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void SaveToLog(string action_type, string action_information)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlquery = "INSERT INTO Logs (account_name, action_type, action_information, action_date) VALUES (?, ?, ?, ?)";
                    using (cmd = new OleDbCommand(sqlquery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", accountName);
                        cmd.Parameters.AddWithValue("?", action_type);
                        cmd.Parameters.AddWithValue("?", action_information);
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

        private void ForPassForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblForgotPassword;
            this.btnfpSubmit.Enabled = false;
            txtfpA.Enabled = false;
        }

        private void ForPassForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void txtfpUsername_Leave(object sender, EventArgs e)
        {
            if (txtfpUsername.Text == "")
            {
                txtfpUsername.Text = "Enter Your Username";
                txtfpUsername.ForeColor = Color.DarkGray;
            }
        }

        private void txtfpUsername_Enter(object sender, EventArgs e)
        {
            if (txtfpUsername.Text == "Enter Your Username")
            {
                txtfpUsername.Text = null;
                txtfpUsername.ForeColor = Color.Black;
            }
        }

        private void txtfpA_Leave(object sender, EventArgs e)
        {
            if (txtfpA.Text == "")
            {
                txtfpA.Text = "Type In Your Answer";
                txtfpA.ForeColor = Color.DarkGray;
            }
        }

        private void txtfpA_Enter(object sender, EventArgs e)
        {
            if (txtfpA.Text == "Type In Your Answer")
            {
                txtfpA.Text = null;
                txtfpA.ForeColor = Color.Black;
            }

        }

        private void txtfpUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z and 0-9 are only allowed.", txtfpUsername, 5, txtfpUsername.Height - 1, 3000);
            }
        }

        private void txtfpA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z and 0-9 are only allowed.", txtfpA, 5, txtfpA.Height - 1, 3000);
            }
        }

        int userId;
        string accountName;
        private void btnfpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlquery = "SELECT COUNT(*) FROM Users WHERE username = ?";
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    using (cmd = new OleDbCommand(sqlquery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", txtfpUsername.Text);
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            sqlquery = "SELECT user_id, first_name, middle_name, last_name, authority, security_question FROM Users WHERE username = ?";
                            using (cmd = new OleDbCommand(sqlquery, con))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", txtfpUsername.Text);
                                using (OleDbDataReader dbreader = cmd.ExecuteReader())
                                {
                                    while (dbreader.Read())
                                    {
                                        userId = Convert.ToInt32(dbreader["user_id"]);
                                        txtfpFullName.Text = (dbreader["first_name"].ToString() + " " + dbreader["middle_name"].ToString() + " " + dbreader["last_name"].ToString());
                                        accountName = txtfpFullName.Text;
                                        txtfpAuthority.Text = dbreader["authority"].ToString();
                                        lblfpQ.Text = dbreader["security_question"].ToString();
                                    }
                                }
                                MessageBox.Show("Answer the security question to retrieve your password.");
                                this.btnfpSubmit.Enabled = true;
                                txtfpA.Enabled = true;
                            }
                        }
                        else
                        {
                            toolTip.Show("User Not Found", txtfpUsername, 5, txtfpUsername.Height - 1, 3000);
                            txtfpFullName.Text = null;
                            txtfpAuthority.Text = null;
                            txtfpA.Text = null;
                            txtfpA_Leave(sender, e);
                            txtfpA.Enabled = false;
                            lblfpQ.Text = null;
                            this.btnfpSubmit.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnfpSubmit_Click(object sender, EventArgs e)
        {
            if (txtfpA.Text == null || txtfpA.Text == "Type In Your Answer")
            {
                toolTip.Show("Field is currently empty.", txtfpA, 5, txtfpA.Height - 1, 3000);
            }
            else
            {
                try
                {
                    string sqlquery = "SELECT Count(*) FROM Users WHERE security_answer LIKE ?";
                    using (OleDbConnection con = new OleDbConnection(conString))
                    {
                        con.Open();
                        using (cmd = new OleDbCommand(sqlquery, con))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("?", txtfpA.Text);
                            if ((int)cmd.ExecuteScalar() > 0)
                            {
                                sqlquery = "SELECT password FROM Users WHERE user_id = ?";
                                using (cmd = new OleDbCommand(sqlquery, con))
                                {
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("?", userId);
                                    string retrieved_password = null;
                                    using (OleDbDataReader dbreader = cmd.ExecuteReader())
                                    {
                                        while (dbreader.Read())
                                        {
                                            retrieved_password = dbreader["password"].ToString();
                                        }
                                    }
                                    SaveToLog("Retrieve Password", "Success");
                                    MessageBox.Show("Your Password is: " + retrieved_password);
                                }
                            }
                            else
                            {
                                SaveToLog("Retrieve Password", "Failed");
                                toolTip.Show("Security answer did not match", txtfpA, 5, txtfpA.Height - 1, 3000);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void btnfpClear_Click(object sender, EventArgs e)
        {
            txtfpUsername.Text = null;
            txtfpUsername_Leave(sender, e);
            txtfpFullName.Text = null;
            txtfpAuthority.Text = null;
            txtfpA.Text = null;
            txtfpA_Leave(sender, e);
            lblfpQ.Text = null;
            this.btnfpSubmit.Enabled = false;
        }

        private void btnfpCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblfpContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("E-mail: stisanjose@gmail.com" + "\n" + "Contact Number: 0926525xxxx", "Contact Administrator", MessageBoxButtons.OK);
        }
    }
}
