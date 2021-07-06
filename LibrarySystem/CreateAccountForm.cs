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
    public partial class CreateAccountForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd = new OleDbCommand();
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

        public CreateAccountForm()
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

        private void CreateAccForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblCreateAccount;
            cbcaAuthority.SelectedIndex = 0;
            txtcaContactNumber.TextChanged -= txtcaContactNumber_TextChanged;
        }

        private void CreateAccForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void txtcaUsername_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaUsername);
            if (txtcaUsername.Text == "")
            {
                txtcaUsername.Text = "Enter Your Username";
                txtcaUsername.ForeColor = Color.DarkGray;
            }
        }

        private void txtcaPassword_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaPassword);
            if (txtcaPassword.Text == "")
            {
                txtcaPassword.Text = "Enter Your Password";
                txtcaPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtcaCPass_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaCPass);
            if (txtcaCPass.Text == "")
            {
                txtcaCPass.Text = "Enter Your Password";
                txtcaCPass.ForeColor = Color.DarkGray;
            }
        }

        private void txtcaFirstName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaFirstName);
            if (txtcaFirstName.Text == "")
            {
                txtcaFirstName.Text = "Enter Your First Name";
                txtcaFirstName.ForeColor = Color.DarkGray;
            }
            txtcaFirstName.Text = txtcaFirstName.Text.Trim();
        }

        private void txtcaMiddleName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaMiddleName);
            if (txtcaMiddleName.Text == "")
            {
                txtcaMiddleName.Text = "Enter Your Middle Name";
                txtcaMiddleName.ForeColor = Color.DarkGray;
            }
            txtcaMiddleName.Text = txtcaMiddleName.Text.Trim();
        }

        private void txtcaLastName_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaLastName);
            if (txtcaLastName.Text == "")
            {
                txtcaLastName.Text = "Enter Your Last Name";
                txtcaLastName.ForeColor = Color.DarkGray;
            }
            txtcaLastName.Text = txtcaLastName.Text.Trim();
        }

        private void txtcaContactNumber_Leave(object sender, EventArgs e)
        {
            txtcaContactNumber.TextChanged -= txtcaContactNumber_TextChanged;
            toolTip.Hide(txtcaContactNumber);
            if (txtcaContactNumber.Text == "" || txtcaContactNumber.Text.Equals("09"))
            {
                txtcaContactNumber.Text = "Enter Your Contact Number";
                txtcaContactNumber.ForeColor = Color.DarkGray;
            }
        }

        private void txtcaQ_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaQ);
            if (txtcaQ.Text == "")
            {
                txtcaQ.Text = "Type In Your Security Question?";
                txtcaQ.ForeColor = Color.DarkGray;
            }
            txtcaQ.Text = txtcaQ.Text.Trim();
            if (!(txtcaQ.Text.EndsWith("?")))
            {
                txtcaQ.Text = txtcaQ.Text + "?";
            }
            if (char.IsLower(txtcaQ.Text[0]))
            {
                txtcaQ.Text = txtcaQ.Text.FirstCharToUpper();
            }
        }

        private void txtcaA_Leave(object sender, EventArgs e)
        {
            toolTip.Hide(txtcaA);
            if (txtcaA.Text == "")
            {
                txtcaA.Text = "Type In Your Answer to the Security Question";
                txtcaA.ForeColor = Color.DarkGray;
            }
            txtcaQ.Text = txtcaQ.Text.Trim();
        }

        private void txtcaUsername_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(txtcaUsername);
            if (txtcaUsername.Text == "Enter Your Username")
            {
                txtcaUsername.Text = null;
                txtcaUsername.ForeColor = Color.Black;
            }
        }

        private void txtcaPassword_Enter(object sender, EventArgs e)
        {
            toolTip2.Hide(txtcaPassword);
            if (txtcaPassword.Text == "Enter Your Password")
            {
                txtcaPassword.Text = null;
                txtcaPassword.ForeColor = Color.Black;
            }
        }

        private void txtcaCPass_Enter(object sender, EventArgs e)
        {
            toolTip3.Hide(txtcaCPass);
            if (txtcaCPass.Text == "Enter Your Password")
            {
                txtcaCPass.Text = null;
                txtcaCPass.ForeColor = Color.Black;
            }
        }

        private void txtcaFirstName_Enter(object sender, EventArgs e)
        {
            toolTip4.Hide(txtcaFirstName);
            if (txtcaFirstName.Text == "Enter Your First Name")
            {
                txtcaFirstName.Text = null;
                txtcaFirstName.ForeColor = Color.Black;
            }
        }

        private void txtcaMiddleName_Enter(object sender, EventArgs e)
        {
            toolTip5.Hide(txtcaMiddleName);
            if (txtcaMiddleName.Text == "Enter Your Middle Name")
            {
                txtcaMiddleName.Text = null;
                txtcaMiddleName.ForeColor = Color.Black;
            }
        }

        private void txtcaLastName_Enter(object sender, EventArgs e)
        {
            toolTip6.Hide(txtcaLastName);
            if (txtcaLastName.Text == "Enter Your Last Name")
            {
                txtcaLastName.Text = null;
                txtcaLastName.ForeColor = Color.Black;
            }
        }
        private void txtcaContactNumber_Enter(object sender, EventArgs e)
        {
            toolTip7.Hide(txtcaContactNumber);
            txtcaContactNumber.TextChanged += txtcaContactNumber_TextChanged;
            if (txtcaContactNumber.Text == "Enter Your Contact Number")
            {
                txtcaContactNumber.Text = "09";
                txtcaContactNumber.ForeColor = Color.Black;
            }
            txtcaContactNumber.SelectionStart = txtcaContactNumber.Text.Length;
        }

        private void txtcaQ_Enter(object sender, EventArgs e)
        {
            toolTip8.Hide(txtcaQ);
            if (txtcaQ.Text == "Type In Your Security Question?")
            {
                txtcaQ.Text = null;
                txtcaQ.ForeColor = Color.Black;
            }
        }

        private void txtcaA_Enter(object sender, EventArgs e)
        {
            toolTip9.Hide(txtcaA);
            if (txtcaA.Text == "Type In Your Answer to the Security Question")
            {
                txtcaA.Text = null;
                txtcaA.ForeColor = Color.Black;
            }
        }

        private void txtcaUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtcaUsername, 5, txtcaUsername.Height - 1, 3000);
            }
        }

        private void txtcaPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtcaPassword, 5, txtcaPassword.Height - 1, 3000);
            }
        }

        private void txtcaCPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtcaCPass, 5, txtcaCPass.Height - 1, 3000);
            }
        }

        private void cbcaAuthority_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtcaFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcaFirstName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtcaFirstName, 5, txtcaFirstName.Height - 1, 3000);
            }
        }

        private void txtcaMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcaMiddleName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtcaMiddleName, 5, txtcaMiddleName.Height - 1, 3000);
            }
        }

        private void txtcaLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcaLastName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtcaLastName, 5, txtcaLastName.Height - 1, 3000);
            }
        }

        private void txtcaContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtcaContactNumber, 5, txtcaContactNumber.Height - 1, 3000);
            }
        }

        private void txtcaQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcaQ.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '?'
                && e.KeyChar != ','
                && e.KeyChar != '.')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, (?), (,) and (.) are only allowed.", txtcaQ, 5, txtcaQ.Height - 1, 3000);
            }
        }

        private void txtcaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcaA.Text.Length == 0 && e.KeyChar == ' ')
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
                toolTip.Show("Characters a-z, A-Z, 0-9, (,) and (.) are only allowed.", txtcaA, 5, txtcaA.Height - 1, 3000);
            }
        }

        private void txtcaUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtcaUsername.Text.Length > 1 && txtcaUsername.Text.Length < 5)
            {
                toolTip.Show("Username is too short.", txtcaUsername, 5, txtcaUsername.Height - 1);
            }
            else
            {
                toolTip.Hide(txtcaPassword);
            }
        }

        private void txtcaPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtcaPassword.Text.Length > 1 && txtcaPassword.Text.Length < 5)
            {
                toolTip.Show("Password is too short.", txtcaPassword, 5, txtcaPassword.Height - 1);
            }
            else
            {
                toolTip.Hide(txtcaPassword);
            }
        }

        private void txtcaCPass_TextChanged(object sender, EventArgs e)
        {
            if (txtcaCPass.Text != txtcaPassword.Text)
            {
                toolTip.Show("Password does not match.", txtcaCPass, 5, txtcaCPass.Height - 1);
            }
            else
            {
                toolTip.Hide(txtcaCPass);
            }
        }

        private void txtcaFirstName_TextChanged(object sender, EventArgs e)
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

        private void txtcaMiddleName_TextChanged(object sender, EventArgs e)
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

        private void txtcaLastName_TextChanged(object sender, EventArgs e)
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

        private void txtcaContactNumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtcaContactNumber.Text.StartsWith("09"))
            {
                txtcaContactNumber.Text = "09";
                txtcaContactNumber.SelectionStart = txtcaContactNumber.Text.Length;
            }
        }

        private void txtcaQ_TextChanged(object sender, EventArgs e)
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

        private void txtcaA_TextChanged(object sender, EventArgs e)
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

        private void btncaCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblcaContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("E-mail: stisanjose@gmail.com" + "\n" + "Contact Number: 0926525xxxx", "Contact Administrator", MessageBoxButtons.OK);
        }

        private void btncaSubmit_Click(object sender, EventArgs e)
        {
            if ((txtcaUsername.Text == "Enter Your Username")
                || (txtcaPassword.Text == "Enter Your Password" || txtcaPassword.Text.Length <= 4)
                || (txtcaCPass.Text == "Enter Your Password")
                || (string.IsNullOrWhiteSpace(txtcaFirstName.Text) || txtcaFirstName.Text == "Enter Your First Name")
                || (string.IsNullOrWhiteSpace(txtcaMiddleName.Text) || txtcaMiddleName.Text == "Enter Your Middle Name")
                || (string.IsNullOrWhiteSpace(txtcaLastName.Text) || txtcaLastName.Text == "Enter Your Last Name")
                || (txtcaContactNumber.Text == "Enter Your Contact Number")
                || (txtcaContactNumber.Text.Length <= 10)
                || (string.IsNullOrWhiteSpace(txtcaQ.Text) || txtcaQ.Text == "Type In Your Security Question")
                || (string.IsNullOrWhiteSpace(txtcaA.Text) || txtcaA.Text == "Type In Your Answer to the Security Question"))
            {
                if (txtcaUsername.Text == "Enter Your Username")
                {
                    toolTip1.Show("Field is currently empty", txtcaUsername, 5, txtcaUsername.Height - 1, 3000);
                }
                if (txtcaPassword.Text == "Enter Your Password")
                {
                    toolTip2.Show("Field is currently empty.", txtcaPassword, 5, txtcaPassword.Height - 1, 3000);
                }
                if (txtcaPassword.Text.Length <= 4)
                {
                    toolTip2.Show("Password is too weak.", txtcaPassword, 5, txtcaPassword.Height - 1, 3000);
                }
                if (txtcaCPass.Text == "Enter Your Password")
                {
                    toolTip3.Show("Field is currently empty.", txtcaCPass, 5, txtcaCPass.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtcaFirstName.Text) || txtcaFirstName.Text == "Enter Your First Name")
                {
                    toolTip4.Show("Field is currently empty.", txtcaFirstName, 5, txtcaFirstName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtcaMiddleName.Text) || txtcaMiddleName.Text == "Enter Your Middle Name")
                {
                    toolTip5.Show("Field is currently empty.", txtcaMiddleName, 5, txtcaMiddleName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtcaLastName.Text) || txtcaLastName.Text == "Enter Your Last Name")
                {
                    toolTip6.Show("Field is currently empty.", txtcaLastName, 5, txtcaLastName.Height - 1, 3000);
                }
                if (txtcaContactNumber.Text == "Enter Your Contact Number")
                {
                    toolTip7.Show("Field is currently empty.", txtcaContactNumber, 5, txtcaContactNumber.Height - 1, 3000);
                }
                if (txtcaContactNumber.Text.Length <= 10)
                {
                    toolTip7.Show("Type in your 11 digit number e.g., 0935631xxxx", txtcaContactNumber, 5, txtcaContactNumber.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtcaQ.Text) || txtcaQ.Text == "Type In Your Security Question")
                {
                    toolTip8.Show("Field is currently empty.", txtcaQ, 5, txtcaQ.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtcaA.Text) || txtcaA.Text == "Type In Your Answer to the Security Question")
                {
                    toolTip9.Show("Field is currently empty.", txtcaA, 5, txtcaA.Height - 1, 3000);
                }
                return;
            }
            else
            {
                using (new RunProcess(this))
                {
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            con.Open();
                            string sqlQuery = "SELECT COUNT(*) FROM Users WHERE username = ?";
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", txtcaUsername.Text);
                                if ((int)cmd.ExecuteScalar() > 0)
                                {
                                    toolTip.Show("Username already exist.", txtcaUsername, 5, txtcaUsername.Height - 1, 3000);
                                    return;
                                }
                                else
                                {
                                    sqlQuery = "INSERT INTO Users (username, [password], first_name, middle_name, last_name, authority, contact_number, security_question, security_answer) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                                    using (cmd = new OleDbCommand(sqlQuery, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", txtcaUsername.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaPassword.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaFirstName.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaMiddleName.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaLastName.Text);
                                        cmd.Parameters.AddWithValue("?", cbcaAuthority.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaContactNumber.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaQ.Text);
                                        cmd.Parameters.AddWithValue("?", txtcaA.Text);
                                        if (cmd.ExecuteNonQuery() > 0)
                                        {
                                            SaveToLog("Add User", txtcaUsername.Text);
                                            btncaClear_Click(null, null);
                                            MessageBox.Show("User Successfully Added.");
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
            }

        }

        private void btncaClear_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lblCreateAccount;
            txtcaUsername.Text = null;
            txtcaPassword.Text = null;
            txtcaCPass.Text = null;
            txtcaFirstName.Text = null;
            txtcaMiddleName.Text = null;
            txtcaLastName.Text = null;
            txtcaContactNumber.TextChanged -= txtcaContactNumber_TextChanged;
            txtcaContactNumber.Text = null;
            txtcaQ.Text = null;
            txtcaA.Text = null;
            txtcaUsername_Leave(null, null);
            txtcaPassword_Leave(null, null);
            txtcaCPass_Leave(null, null);
            txtcaFirstName_Leave(null, null);
            txtcaMiddleName_Leave(null, null);
            txtcaLastName_Leave(null, null);
            txtcaContactNumber_Leave(null, null);
            txtcaQ_Leave(null, null);
            txtcaA_Leave(null, null);
            cbcaAuthority.SelectedIndex = 0;
        }
    }
}
