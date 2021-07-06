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
    public partial class AccountListForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataTable dtb = new DataTable();

        ToolTip toolTip = new ToolTip();
        ToolTip toolTip1 = new ToolTip();
        ToolTip toolTip2 = new ToolTip();
        ToolTip toolTip3 = new ToolTip();

        public AccountListForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FillAccountListDGV();
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

        private void PopulateAccountListDGV(int userId, string userName, string firstName, string middleName, string lastName, string contactNumber, string userAuthority)
        {
            object[] row = { userId.ToString("D4"), userName, firstName + " " + middleName + " " + lastName, contactNumber, userAuthority };
            dgvalfAccountList.Rows.Add(row);
        }

        private void FillAccountListDGV()
        {
            try
            {
                dgvalfAccountList.Rows.Clear();
                dtb.Rows.Clear();
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM Users";
                    using (adapter.SelectCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(dtb);
                    }
                }
                using (DataTableReader dtbreader = new DataTableReader(dtb))
                {
                    if (dtbreader.HasRows)
                    {
                        dgvalfAccountList.Columns[0].ValueType = typeof(Int32);
                        foreach (DataRow row in dtb.Rows)
                        {
                            PopulateAccountListDGV(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                        }
                        dgvalfAccountList.Enabled = true;
                    }
                    else
                    {
                        dgvalfAccountList.Rows.Add("0", "NO RECORDS");
                        dgvalfAccountList.Enabled = false;
                        btnalfEditAccount.Enabled = false;
                        btnalfDeleteAccount.Enabled = false;
                        btnalfChangePassword.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dgvalfAccountList.ClearSelection();
            }
        }

        private bool UpdateUserInfo(int userId, string firstName, string middleName, string lastName, string contactNumber, string userAuthority)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "UPDATE Users SET first_name = ?, middle_name = ?, last_name = ?, contact_number = ?, authority = ? WHERE user_id = ?";
                    using (adapter.UpdateCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.UpdateCommand.Parameters.Clear();
                        adapter.UpdateCommand.Parameters.AddWithValue("?", firstName);
                        adapter.UpdateCommand.Parameters.AddWithValue("?", middleName);
                        adapter.UpdateCommand.Parameters.AddWithValue("?", lastName);
                        adapter.UpdateCommand.Parameters.AddWithValue("?", contactNumber);
                        adapter.UpdateCommand.Parameters.AddWithValue("?", userAuthority);
                        adapter.UpdateCommand.Parameters.AddWithValue("?", userId);
                        if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Update User", currentUserName);
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

        private void UpdatePassword(int userId)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "SELECT Count(*) FROM Users WHERE [password] = ? AND user_id = ?";
                    using (cmd = new OleDbCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", txtalfCurrentPassword.Text);
                        cmd.Parameters.AddWithValue("?", userId);
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            sqlQuery = "SELECT [password] FROM Users WHERE [password] = ? AND user_id = ?";
                            using (cmd = new OleDbCommand(sqlQuery, con))
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("?", txtalfCurrentPassword.Text);
                                cmd.Parameters.AddWithValue("?", userId);
                                string current_password = null;
                                using (OleDbDataReader dbreader = cmd.ExecuteReader())
                                {
                                    while (dbreader.Read())
                                    {
                                        current_password = dbreader["password"].ToString();
                                    }
                                }
                                if (current_password != txtalfNewPassword.Text)
                                {
                                    sqlQuery = "UPDATE Users SET [password] = ? WHERE [password] = ? AND user_id = ?";
                                    using (cmd = new OleDbCommand(sqlQuery, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("?", txtalfNewPassword.Text);
                                        cmd.Parameters.AddWithValue("?", txtalfCurrentPassword.Text);
                                        cmd.Parameters.AddWithValue("?", userId);
                                        if (cmd.ExecuteNonQuery() > 0)
                                        {
                                            SaveToLog("Update Password", currentUserName);
                                            ClearPasswordTxt();
                                            HidePasswordInfoBtns();
                                            dgvalfAccountList.ClearSelection();
                                            MessageBox.Show("Password Successfully Changed");
                                        }
                                    }
                                }
                                else
                                {
                                    toolTip.Show("New Password and Current Password are the Same", txtalfNewPassword, 5, txtalfNewPassword.Height - 1, 3000);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            toolTip.Show("Wrong Current Password", txtalfCurrentPassword, 5, txtalfCurrentPassword.Height - 1, 3000);
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

        private bool DeleteAccount(int userId)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM Users WHERE user_id = ?";
                    using (adapter.DeleteCommand = new OleDbCommand(sqlQuery, con))
                    {
                        adapter.DeleteCommand.Parameters.Clear();
                        adapter.DeleteCommand.Parameters.AddWithValue("?", userId);
                        if (adapter.DeleteCommand.ExecuteNonQuery() > 0)
                        {
                            SaveToLog("Delete User", currentUserName);
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

        private void ClearUserInfoTxt()
        {
            txtalfContactNumber.TextChanged -= txtalfContactNumber_TextChanged;
            txtalfFirstName.Text = null;
            txtalfMiddleName.Text = null;
            txtalfLastName.Text = null;
            txtalfContactNumber.Text = null;
            cbalfAuthority.SelectedIndex = -1;
        }

        private void ClearPasswordTxt()
        {
            txtalfCurrentPassword.Text = null;
            txtalfNewPassword.Text = null;
            txtalfConfirmPassword.Text = null;
        }

        private void EnableUserInfoTxt()
        {
            txtalfFirstName.Enabled = true;
            txtalfMiddleName.Enabled = true;
            txtalfLastName.Enabled = true;
            txtalfContactNumber.Enabled = true;
            cbalfAuthority.Enabled = true;
        }

        private void EnablePasswordTxt()
        {
            txtalfCurrentPassword.Enabled = true;
            txtalfNewPassword.Enabled = true;
            txtalfConfirmPassword.Enabled = true;
        }

        private void DisableUserInfoTxt()
        {
            txtalfFirstName.Enabled = false;
            txtalfMiddleName.Enabled = false;
            txtalfLastName.Enabled = false;
            txtalfContactNumber.Enabled = false;
            cbalfAuthority.Enabled = false;
        }

        private void DisablePasswordTxt()
        {
            txtalfCurrentPassword.Enabled = false;
            txtalfNewPassword.Enabled = false;
            txtalfConfirmPassword.Enabled = false;
        }

        private void EnableDefaultButtons()
        {
            btnalfEditAccount.Enabled = true;
            btnalfChangePassword.Enabled = true;
        }

        private void DisableDefaultButtons()
        {
            btnalfEditAccount.Enabled = false;
            btnalfChangePassword.Enabled = false;
        }

        private void ShowUserInfoBtns()
        {
            EnableUserInfoTxt();
            btnalfDeleteAccount.Visible = true;
            btnalfUpdate.Visible = true;
            btnalfCancel.Visible = true;
        }

        private void HideUserInfoBtns()
        {
            DisableUserInfoTxt();
            btnalfDeleteAccount.Visible = false;
            btnalfUpdate.Visible = false;
            btnalfCancel.Visible = false;
        }

        private void ShowPasswordInfoBtns()
        {
            EnablePasswordTxt();
            btnalfcpUpdate.Visible = true;
            btnalfcpCancel.Visible = true;
            btnalfChangePassword.Visible = false;
        }

        private void HidePasswordInfoBtns()
        {
            DisablePasswordTxt();
            btnalfcpUpdate.Visible = false;
            btnalfcpCancel.Visible = false;
            btnalfChangePassword.Visible = true;
        }

        private void AccountListForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            DisableUserInfoTxt();
            DisableDefaultButtons();
            DisablePasswordTxt();
            dgvalfAccountList.ClearSelection();
            btnalfcpUpdate.Visible = false;
            btnalfcpCancel.Visible = false;
            btnalfDeleteAccount.Visible = false;
            btnalfUpdate.Visible = false;
            btnalfCancel.Visible = false;
        }

        private void txtalfFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtalfFirstName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtalfFirstName, 5, txtalfFirstName.Height - 1, 3000);
            }
        }

        private void txtalfMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtalfMiddleName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtalfMiddleName, 5, txtalfMiddleName.Height - 1, 3000);
            }
        }

        private void txtalfLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtalfLastName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetter(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                toolTip.Show("Characters a-z and A-Z are only allowed.", txtalfLastName, 5, txtalfLastName.Height - 1, 3000);
            }
        }

        private void txtalfContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtalfContactNumber, 5, txtalfContactNumber.Height - 1, 3000);
            }
        }

        private void cbalfAuthority_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtalfCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtalfCurrentPassword, 5, txtalfCurrentPassword.Height - 1, 3000);
            }
        }

        private void txtalfNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtalfNewPassword, 5, txtalfNewPassword.Height - 1, 3000);
            }
        }

        private void txtalfConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsLetterOrDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != '_')
            {
                e.Handled = true;
                toolTip.Show("Characters a-z, A-Z, 0-9, _ and . are only allowed.", txtalfConfirmPassword, 5, txtalfConfirmPassword.Height - 1, 3000);
            }
        }

        private void txtalfFirstName_TextChanged(object sender, EventArgs e)
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

        private void txtalfMiddleName_TextChanged(object sender, EventArgs e)
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

        private void txtalfLastName_TextChanged(object sender, EventArgs e)
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

        private void txtalfContactNumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtalfContactNumber.Text.StartsWith("09"))
            {
                txtalfContactNumber.Text = "09";
                txtalfContactNumber.SelectionStart = txtalfContactNumber.Text.Length;
            }
        }

        private void txtalfNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtalfNewPassword.Text.Length > 1 && txtalfNewPassword.Text.Length < 5)
            {
                toolTip.Show("Password is too short.", txtalfNewPassword, 5, txtalfNewPassword.Height - 1);
            }
            else
            {
                toolTip.Hide(txtalfNewPassword);
            }
        }

        private void txtalfConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtalfConfirmPassword.Text != txtalfNewPassword.Text)
            {
                toolTip.Show("Password does not match.", txtalfConfirmPassword, 5, txtalfConfirmPassword.Height - 1);
            }
            else
            {
                toolTip.Hide(txtalfConfirmPassword);
            }
        }

        int currentUserId;
        string currentUserName;
        string currentFirstName;
        string currentMiddleName;
        string currentLastName;
        string currentContactNumber;
        string currentUserAuthority;
        private void dgvalfAccountList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvalfAccountList.SelectedRows.Count > 0 && e.RowIndex != -1)
            {
                HidePasswordInfoBtns();
                HideUserInfoBtns();
                EnableDefaultButtons();
                txtalfContactNumber.TextChanged -= txtalfContactNumber_TextChanged;
                txtalfContactNumber.TextChanged += txtalfContactNumber_TextChanged;
                currentUserId = Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value);
                currentUserName = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[1]).FirstOrDefault();
                currentFirstName = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[3]).FirstOrDefault();
                currentMiddleName = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[4]).FirstOrDefault();
                currentLastName = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[5]).FirstOrDefault();
                currentContactNumber = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[6]).FirstOrDefault();
                currentUserAuthority = (from DataRow dr in dtb.Rows where (int)dr[0] == Convert.ToInt32(dgvalfAccountList.Rows[dgvalfAccountList.SelectedRows[0].Index].Cells[0].Value) select (string)dr[7]).FirstOrDefault();
                txtalfFirstName.Text = currentFirstName;
                txtalfMiddleName.Text = currentMiddleName;
                txtalfLastName.Text = currentLastName;
                txtalfContactNumber.Text = currentContactNumber;
                cbalfAuthority.SelectedIndex = cbalfAuthority.FindString(currentUserAuthority);
            }
        }

        private void dvalfGridView_SelectionChanged(object sender, EventArgs e)
        {
            HidePasswordInfoBtns();
            HideUserInfoBtns();
        }

        private void btnalfChangePassword_Click(object sender, EventArgs e)
        {
            EnablePasswordTxt();
            ShowPasswordInfoBtns();
        }

        private void btnalfcpUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtalfCurrentPassword.Text)
                || (string.IsNullOrEmpty(txtalfNewPassword.Text) || (!string.IsNullOrEmpty(txtalfNewPassword.Text) && txtalfNewPassword.Text.Length <= 4))
                || (string.IsNullOrEmpty(txtalfConfirmPassword.Text) || (!string.IsNullOrEmpty(txtalfConfirmPassword.Text) && txtalfConfirmPassword.Text != txtalfNewPassword.Text)))
            {
                if (string.IsNullOrEmpty(txtalfCurrentPassword.Text))
                {
                    toolTip.Show("Field is currently empty.", txtalfCurrentPassword, 5, txtalfCurrentPassword.Height - 1, 3000);
                }
                if (string.IsNullOrEmpty(txtalfNewPassword.Text))
                {
                    toolTip1.Show("Field is currently empty.", txtalfNewPassword, 5, txtalfNewPassword.Height - 1, 3000);
                }
                if (!string.IsNullOrEmpty(txtalfNewPassword.Text) && txtalfNewPassword.Text.Length <= 4)
                {
                    toolTip1.Show("Password is too weak.", txtalfNewPassword, 5, txtalfNewPassword.Height - 1, 3000);
                }
                if (string.IsNullOrEmpty(txtalfConfirmPassword.Text))
                {
                    toolTip2.Show("Field is currently empty.", txtalfConfirmPassword, 5, txtalfConfirmPassword.Height - 1, 3000);
                }
                if (!string.IsNullOrEmpty(txtalfConfirmPassword.Text) && txtalfConfirmPassword.Text != txtalfNewPassword.Text)
                {
                    toolTip2.Show("Password does not match.", txtalfConfirmPassword, 5, txtalfConfirmPassword.Height - 1, 3000);
                }
                return;
            }
            else
            {
                using (new RunProcess(this))
                {
                    UpdatePassword(currentUserId);
                }
            }

        }

        private void btnalfcpCancel_Click(object sender, EventArgs e)
        {
            ClearPasswordTxt();
            DisablePasswordTxt();
            HidePasswordInfoBtns();
        }

        private void btnalfDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete.", "Deleting User", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool processSuccess;
                using (new RunProcess(this))
                {
                    processSuccess = DeleteAccount(currentUserId);
                }
                if (processSuccess)
                {
                    FillAccountListDGV();
                    ClearUserInfoTxt();
                    HideUserInfoBtns();
                    DisableDefaultButtons();
                    MessageBox.Show("User Successfully Deleted.");
                }
            }
        }

        private void btnalfEditAccount_Click(object sender, EventArgs e)
        {
            if (dgvalfAccountList.CurrentCell.Selected == true)
            {
                ShowUserInfoBtns();
            }
        }

        private void btnalfUpdate_Click(object sender, EventArgs e)
        {
            if (txtalfFirstName.Text == currentFirstName
                && txtalfMiddleName.Text == currentMiddleName
                && txtalfLastName.Text == currentLastName
                && txtalfContactNumber.Text == currentContactNumber
                && cbalfAuthority.Text == currentUserAuthority)
            {
                MessageBox.Show("No changes were made.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtalfFirstName.Text)
                || string.IsNullOrWhiteSpace(txtalfMiddleName.Text)
                || string.IsNullOrWhiteSpace(txtalfLastName.Text)
                || (txtalfContactNumber.Text.Length <= 10))
            {
                if (string.IsNullOrWhiteSpace(txtalfFirstName.Text))
                {
                    toolTip.Show("Field is currently empty.", txtalfFirstName, 5, txtalfFirstName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtalfMiddleName.Text))
                {
                    toolTip1.Show("Field is currently empty.", txtalfMiddleName, 5, txtalfMiddleName.Height - 1, 3000);
                }
                if (string.IsNullOrWhiteSpace(txtalfLastName.Text))
                {
                    toolTip2.Show("Field is currently empty.", txtalfLastName, 5, txtalfLastName.Height - 1, 3000);
                }
                if (txtalfContactNumber.Text.Length <= 10)
                {
                    toolTip3.Show("Type in your 11 digit number e.g., 0935631xxxx", txtalfContactNumber, 5, txtalfContactNumber.Height - 1, 3000);
                }
                return;
            }
            else
            {
                bool processSuccess;
                using (new RunProcess(this))
                {
                   processSuccess = UpdateUserInfo(currentUserId, txtalfFirstName.Text, txtalfMiddleName.Text, txtalfLastName.Text, txtalfContactNumber.Text, cbalfAuthority.Text);
                }
                if (processSuccess)
                {
                    FillAccountListDGV();
                    ClearUserInfoTxt();
                    HideUserInfoBtns();
                    DisableDefaultButtons();
                    dgvalfAccountList.ClearSelection();
                    MessageBox.Show("User Data Successfully Updated.");
                }
            }
        }

        private void btnalfCancel_Click(object sender, EventArgs e)
        {
            HideUserInfoBtns();
            txtalfFirstName.Text = currentFirstName;
            txtalfMiddleName.Text = currentMiddleName;
            txtalfLastName.Text = currentLastName;
            txtalfContactNumber.Text = currentContactNumber;
            cbalfAuthority.SelectedItem = currentUserAuthority;
        }

        private void btnalfDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
