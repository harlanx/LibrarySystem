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
    public partial class FeesForm : Form
    {
        static string conString = Properties.Settings.Default.SJCLibrarySystemConnectionString;
        string cultureCurrencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        ToolTip toolTip = new ToolTip();

        public FeesForm()
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

        int currentMaximumBook;
        decimal currentDailyFee;
        decimal currentMaximumFee;
        string currentDamagedFeeType;
        decimal currentDamagedFee;
        string currentLostFeeType;
        decimal currentLostFee;
        private void FeesForm_Load(object sender, EventArgs e)
        {
            currentMaximumBook = Properties.Settings.Default.Maximum_Book;
            currentDailyFee = Properties.Settings.Default.Daily_Fee;
            currentMaximumFee = Properties.Settings.Default.Maximum_Fee;
            currentDamagedFeeType = Properties.Settings.Default.Damaged_Type;
            currentDamagedFee = Properties.Settings.Default.Damaged_Fee;
            currentLostFeeType = Properties.Settings.Default.Lost_Type;
            currentLostFee = Properties.Settings.Default.Lost_Fee;

            cbffLostFeeType.SelectedIndexChanged -= cbffLostFeeType_SelectedIndexChanged;
            cbffDamagedFeeType.SelectedIndexChanged -= cbffDamagedFeeType_SelectedIndexChanged;
            if (string.IsNullOrEmpty(Properties.Settings.Default.Damaged_Type.ToString()))
            {
                cbffDamagedFeeType.SelectedIndex = 0;
            }
            else
            {
                cbffDamagedFeeType.SelectedItem = Properties.Settings.Default.Damaged_Type;
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Lost_Type.ToString()))
            {
                cbffLostFeeType.SelectedIndex = 0;
            }
            else 
            {
                cbffLostFeeType.SelectedItem = Properties.Settings.Default.Lost_Type;
            }
            txtMaximumBook.Text = Properties.Settings.Default.Maximum_Book.ToString();
            txtffDaily.Text = Properties.Settings.Default.Daily_Fee.ToString("C2", CultureInfo.CurrentCulture);
            txtffMaximum.Text = Properties.Settings.Default.Maximum_Fee.ToString("C2", CultureInfo.CurrentCulture);
            if (cbffDamagedFeeType.Text == "Percentage")
            {
                txtffDamagedFee.Text = Convert.ToDecimal(Properties.Settings.Default.Damaged_Fee).ToString("F2") + "%";
            }
            else
            {
                txtffDamagedFee.Text = Properties.Settings.Default.Damaged_Fee.ToString("C2", CultureInfo.CurrentCulture);
            }
            txtffLostFee.Text = Properties.Settings.Default.Lost_Fee.ToString("C2", CultureInfo.CurrentCulture);
            txtMaximumBook.Enabled = false;
            txtffDaily.Enabled = false;
            txtffMaximum.Enabled = false;
            txtffDamagedFee.Enabled = false;
            txtffLostFee.Enabled = false;
            cbffDamagedFeeType.Enabled = false;
            cbffLostFeeType.Enabled = false;
            btnffEdit.Text = "Edit";
            btnffDone.Text = "Done";
        }

        private void FeesForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return;
            using (LinearGradientBrush gradientBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.DodgerBlue, Color.LightCyan, 60))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }
        private void txtMaximumBook_Enter(object sender, EventArgs e)
        {
            txtMaximumBook_TextChanged(null, null);
        }

        private void txtffDaily_Enter(object sender, EventArgs e)
        {
            txtffDaily_TextChanged(null, null);
        }

        private void txtffMaximum_Enter(object sender, EventArgs e)
        {
            txtffMaximum_TextChanged(null, null);
        }

        private void txtffDamagedFee_Enter(object sender, EventArgs e)
        {
            txtffDamagedFee_TextChanged(null, null);
        }

        private void txtffLostFee_Enter(object sender, EventArgs e)
        {
            txtffLostFee_TextChanged(null, null);
        }

        private void txtMaximumBook_Leave(object sender, EventArgs e)
        {
            if (txtMaximumBook.Text.Trim('0') == string.Empty)
            {
                txtMaximumBook.Text = "1";
            }
        }

        private void txtffDaily_Leave(object sender, EventArgs e)
        {
            if (txtffDaily.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtffDaily.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
            {
                txtffDaily.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                return;
            }
            else
            {
                txtffDaily.Text = Convert.ToDecimal(txtffDaily.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtffMaximum_Leave(object sender, EventArgs e)
        {
            if (txtffMaximum.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtffMaximum.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
            {
                txtffMaximum.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                return;
            }
            else
            {
                txtffMaximum.Text = Convert.ToDecimal(txtffMaximum.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtffDamagedFee_Leave(object sender, EventArgs e)
        {
            if (cbffDamagedFeeType.Text == "Percentage")
            {
                if (txtffDamagedFee.Text.Replace(@"%", string.Empty).Trim('0') == "." || txtffDamagedFee.Text.Replace(@"%", string.Empty).Trim('0') == string.Empty)
                {
                    txtffDamagedFee.Text = "0%";
                    return;
                }
                else
                {
                    txtffDamagedFee.Text = Convert.ToDecimal(txtffDamagedFee.Text.Replace("%", string.Empty)).ToString("F2") + "%";
                }
            }
            if (cbffDamagedFeeType.Text == "Specific")
            {
                if (txtffDamagedFee.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtffDamagedFee.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
                {
                    txtffDamagedFee.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                    return;
                }
                else
                {
                    txtffDamagedFee.Text = Convert.ToDecimal(txtffDamagedFee.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
                }
            }
        }

        private void txtffLostFee_Leave(object sender, EventArgs e)
        {
            if (txtffLostFee.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == "." || txtffLostFee.Text.Replace(cultureCurrencySymbol, string.Empty).Trim('0') == string.Empty)
            {
                txtffLostFee.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                return;
            }
            else
            {
                txtffLostFee.Text = Convert.ToDecimal(txtffLostFee.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')).ToString("C2", CultureInfo.CurrentCulture);
            }
        }


        private void txtMaximumBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9 are only allowed.", txtMaximumBook, 5, txtMaximumBook.Height - 1, 3000);
            }
        }

        private void txtffDaily_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != ',')
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9, (.) and (,) are only allowed.", txtffDaily, 5, txtffDaily.Height - 1, 3000);
            }
        }

        private void txtffMaximum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != ',')
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9, (.) and (,) are only allowed.", txtffMaximum, 5, txtffMaximum.Height - 1, 3000);
            }
        }

        private void txtffDamagedFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbffDamagedFeeType.Text == "Percentage")
            {
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsDigit(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back
                    && e.KeyChar != '.')
                {
                    e.Handled = true;
                    toolTip.Show("Numbers 0-9, and (.) are only allowed.", txtffDamagedFee, 5, txtffDamagedFee.Height - 1, 3000);
                }
            }
            else
            {
                if (!(char.IsControl(e.KeyChar))
                    && !(char.IsDigit(e.KeyChar))
                    && e.KeyChar != (char)Keys.Back
                    && e.KeyChar != '.'
                    && e.KeyChar != ',')
                {
                    e.Handled = true;
                    toolTip.Show("Numbers 0-9, (.) and (,) are only allowed.", txtffDamagedFee, 5, txtffDamagedFee.Height - 1, 3000);
                }
            }

        }

        private void txtffLostFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != '.'
                && e.KeyChar != ',')
            {
                e.Handled = true;
                toolTip.Show("Numbers 0-9, (.) and (,) are only allowed.", txtffLostFee, 5, txtffLostFee.Height - 1, 3000);
            }
        }


        private void txtMaximumBook_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtMaximumBook.Text) > 50)
            {
                toolTip.Show("Cannot exceed 50", txtMaximumBook, 5, txtMaximumBook.Height - 1, 3000);
                txtMaximumBook.Text = "50";
            }
        }

        private void txtffDaily_TextChanged(object sender, EventArgs e)
        {
            if (!txtffDaily.Text.StartsWith(cultureCurrencySymbol))
            {
                txtffDaily.Text = cultureCurrencySymbol + txtffDaily.Text;
                txtffDaily.SelectionStart = cultureCurrencySymbol.Length;
            }
            if (txtffDaily.Text == cultureCurrencySymbol || txtffDaily.Text == cultureCurrencySymbol + "0")
            {
                txtffDaily.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtffMaximum_TextChanged(object sender, EventArgs e)
        {
            if (!txtffMaximum.Text.StartsWith(cultureCurrencySymbol))
            {
                txtffMaximum.Text = cultureCurrencySymbol + txtffMaximum.Text;
                txtffMaximum.SelectionStart = cultureCurrencySymbol.Length;
            }
            if (txtffMaximum.Text == cultureCurrencySymbol || txtffMaximum.Text == cultureCurrencySymbol + "0")
            {
                txtffMaximum.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtffDamagedFee_TextChanged(object sender, EventArgs e)
        {
            if (cbffDamagedFeeType.Text == "Percentage")
            {
                if (!txtffDamagedFee.Text.EndsWith("%"))
                {
                    txtffDamagedFee.Text = txtffDamagedFee.Text + "%";
                    txtffDamagedFee.SelectionStart = txtffDamagedFee.Text.Length;
                }
                if (txtffDamagedFee.Text == "%" || txtffDamagedFee.Text == "0%")
                {
                    txtffDamagedFee.Text = "0.00%";
                }
            }
            else
            {
                if (!txtffDamagedFee.Text.StartsWith(cultureCurrencySymbol))
                {
                    txtffDamagedFee.Text = cultureCurrencySymbol + txtffDamagedFee.Text;
                    txtffDamagedFee.SelectionStart = cultureCurrencySymbol.Length;
                }
                if (txtffDamagedFee.Text == cultureCurrencySymbol || txtffDamagedFee.Text == cultureCurrencySymbol + "0")
                {
                    txtffMaximum.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
                }
            }
        }

        private void txtffLostFee_TextChanged(object sender, EventArgs e)
        {
            if (!txtffLostFee.Text.StartsWith(cultureCurrencySymbol))
            {
                txtffLostFee.Text = cultureCurrencySymbol + txtffLostFee.Text;
                txtffLostFee.SelectionStart = cultureCurrencySymbol.Length;
            }
            if (txtffLostFee.Text == cultureCurrencySymbol || txtffLostFee.Text == cultureCurrencySymbol + "0")
            {
                txtffLostFee.Text = 0m.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void cbffDamagedFeeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbffLostFeeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbffDamagedFeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formattedString = Convert.ToDecimal(txtffDamagedFee.Text.Replace(@"%", string.Empty).Replace(cultureCurrencySymbol, string.Empty)).ToString();
            if (cbffDamagedFeeType.Text == "Percentage")
            {
                txtffDamagedFee.Text = Convert.ToDecimal(Convert.ToDecimal(formattedString)).ToString("F2") + "%";
            }
            else
            {
                txtffDamagedFee.Text = Convert.ToDecimal(formattedString).ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void btnffEdit_Click(object sender, EventArgs e)
        {
            if (btnffEdit.Text == "Edit")
            {
                btnffEdit.Text = "Save";
                btnffDone.Text = "Cancel";
                txtMaximumBook.Enabled = true;
                txtffDaily.Enabled = true;
                txtffMaximum.Enabled = true;
                txtffDamagedFee.Enabled = true;
                cbffDamagedFeeType.Enabled = true;
                cbffLostFeeType.Enabled = true;
                cbffLostFeeType.SelectedIndexChanged += cbffLostFeeType_SelectedIndexChanged;
                cbffDamagedFeeType.SelectedIndexChanged += cbffDamagedFeeType_SelectedIndexChanged;
                if (cbffLostFeeType.Text == "Book Price")
                {
                    txtffLostFee.Enabled = false;
                }
                else
                {
                    txtffLostFee.Enabled = true;
                }
            }
            else
            {
                if (currentMaximumBook == Convert.ToInt32(txtMaximumBook.Text)
                    && currentDailyFee == Convert.ToDecimal(txtffDaily.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'))
                    && currentMaximumFee == Convert.ToDecimal(txtffMaximum.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'))
                    && currentDamagedFeeType == cbffDamagedFeeType.Text
                    && currentDamagedFee == Convert.ToDecimal(txtffDamagedFee.Text.Replace(cultureCurrencySymbol, string.Empty).Replace(@"%", string.Empty).TrimStart('0'))
                    && currentLostFeeType == cbffLostFeeType.Text
                    && currentLostFee == Convert.ToDecimal(txtffLostFee.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0')))
                {
                    MessageBox.Show("No changes were made.");
                    FeesForm_Load(null, null);
                    return;
                }
                else
                {
                    Properties.Settings.Default.Maximum_Book = Convert.ToInt32(txtMaximumBook.Text);
                    Properties.Settings.Default.Daily_Fee = Convert.ToDecimal(txtffDaily.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'));
                    Properties.Settings.Default.Maximum_Fee = Convert.ToDecimal(txtffMaximum.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'));
                    Properties.Settings.Default.Damaged_Type = cbffDamagedFeeType.Text;
                    if (cbffDamagedFeeType.Text == "Percentage")
                    {
                        Properties.Settings.Default.Damaged_Fee = Convert.ToDecimal(txtffDamagedFee.Text.Replace(@"%", string.Empty));
                    }
                    else
                    {
                        Properties.Settings.Default.Damaged_Fee = Convert.ToDecimal(txtffDamagedFee.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'));
                    }
                    Properties.Settings.Default.Lost_Type = cbffLostFeeType.Text;
                    Properties.Settings.Default.Lost_Fee = Convert.ToDecimal(txtffLostFee.Text.Replace(cultureCurrencySymbol, string.Empty).TrimStart('0'));
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    SaveToLog("Update Fees", "------");
                    FeesForm_Load(null, null);
                }
            }
        }

        private void btnffDone_Click(object sender, EventArgs e)
        {
            if (btnffDone.Text == "Cancel")
            {
                btnffEdit.Text = "Edit";
                btnffDone.Text = "Done";
                FeesForm_Load(null, null);
            }
            else
            {
                this.Close();
            }
        }

        private void cbffLostFeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbffLostFeeType.Text == "Book Price")
            {
                txtffLostFee.Enabled = false;
            }
            else
            {
                txtffLostFee.Enabled = true;
            }
        }
    }
}
