namespace LibrarySystem
{
    partial class AccountListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountListForm));
            this.lblAccountList = new System.Windows.Forms.Label();
            this.btnalfDone = new System.Windows.Forms.Button();
            this.txtalfCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtalfNewPassword = new System.Windows.Forms.TextBox();
            this.txtalfConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblalfCurrentPassword = new System.Windows.Forms.Label();
            this.lblalfNewPassword = new System.Windows.Forms.Label();
            this.lblalfConfirmPassword = new System.Windows.Forms.Label();
            this.btnalfChangePassword = new System.Windows.Forms.Button();
            this.lblalfMiddleName = new System.Windows.Forms.Label();
            this.lblalfFirstName = new System.Windows.Forms.Label();
            this.txtalfMiddleName = new System.Windows.Forms.TextBox();
            this.txtalfFirstName = new System.Windows.Forms.TextBox();
            this.btnalfDeleteAccount = new System.Windows.Forms.Button();
            this.txtalfContactNumber = new System.Windows.Forms.TextBox();
            this.txtalfLastName = new System.Windows.Forms.TextBox();
            this.lblalfContactNumber = new System.Windows.Forms.Label();
            this.lblalfLastName = new System.Windows.Forms.Label();
            this.lblalfAuthority = new System.Windows.Forms.Label();
            this.cbalfAuthority = new System.Windows.Forms.ComboBox();
            this.btnalfEditAccount = new System.Windows.Forms.Button();
            this.lblalfTip = new System.Windows.Forms.Label();
            this.btnalfUpdate = new System.Windows.Forms.Button();
            this.btnalfCancel = new System.Windows.Forms.Button();
            this.btnalfcpUpdate = new System.Windows.Forms.Button();
            this.btnalfcpCancel = new System.Windows.Forms.Button();
            this.dgvalfAccountList = new System.Windows.Forms.DataGridView();
            this.colalfdvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colalfdvUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colalfdvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colalfdvContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colalfdvAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvalfAccountList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountList
            // 
            this.lblAccountList.AutoSize = true;
            this.lblAccountList.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAccountList.Location = new System.Drawing.Point(6, 6);
            this.lblAccountList.Name = "lblAccountList";
            this.lblAccountList.Size = new System.Drawing.Size(142, 25);
            this.lblAccountList.TabIndex = 1;
            this.lblAccountList.Text = "Account List";
            // 
            // btnalfDone
            // 
            this.btnalfDone.BackColor = System.Drawing.Color.Transparent;
            this.btnalfDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfDone.Location = new System.Drawing.Point(539, 331);
            this.btnalfDone.Name = "btnalfDone";
            this.btnalfDone.Size = new System.Drawing.Size(104, 20);
            this.btnalfDone.TabIndex = 3;
            this.btnalfDone.Text = "Done";
            this.btnalfDone.UseVisualStyleBackColor = false;
            this.btnalfDone.Click += new System.EventHandler(this.btnalfDone_Click);
            // 
            // txtalfCurrentPassword
            // 
            this.txtalfCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfCurrentPassword.Location = new System.Drawing.Point(119, 227);
            this.txtalfCurrentPassword.Name = "txtalfCurrentPassword";
            this.txtalfCurrentPassword.PasswordChar = '*';
            this.txtalfCurrentPassword.Size = new System.Drawing.Size(120, 20);
            this.txtalfCurrentPassword.TabIndex = 4;
            this.txtalfCurrentPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfCurrentPassword_KeyPress);
            // 
            // txtalfNewPassword
            // 
            this.txtalfNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfNewPassword.Location = new System.Drawing.Point(119, 257);
            this.txtalfNewPassword.Name = "txtalfNewPassword";
            this.txtalfNewPassword.PasswordChar = '*';
            this.txtalfNewPassword.Size = new System.Drawing.Size(120, 20);
            this.txtalfNewPassword.TabIndex = 5;
            this.txtalfNewPassword.TextChanged += new System.EventHandler(this.txtalfNewPassword_TextChanged);
            this.txtalfNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfNewPassword_KeyPress);
            // 
            // txtalfConfirmPassword
            // 
            this.txtalfConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfConfirmPassword.Location = new System.Drawing.Point(119, 287);
            this.txtalfConfirmPassword.Name = "txtalfConfirmPassword";
            this.txtalfConfirmPassword.PasswordChar = '*';
            this.txtalfConfirmPassword.Size = new System.Drawing.Size(120, 20);
            this.txtalfConfirmPassword.TabIndex = 6;
            this.txtalfConfirmPassword.TextChanged += new System.EventHandler(this.txtalfConfirmPassword_TextChanged);
            this.txtalfConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfConfirmPassword_KeyPress);
            // 
            // lblalfCurrentPassword
            // 
            this.lblalfCurrentPassword.AutoSize = true;
            this.lblalfCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblalfCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfCurrentPassword.Location = new System.Drawing.Point(8, 230);
            this.lblalfCurrentPassword.Name = "lblalfCurrentPassword";
            this.lblalfCurrentPassword.Size = new System.Drawing.Size(106, 13);
            this.lblalfCurrentPassword.TabIndex = 8;
            this.lblalfCurrentPassword.Text = "Current Password";
            // 
            // lblalfNewPassword
            // 
            this.lblalfNewPassword.AutoSize = true;
            this.lblalfNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblalfNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfNewPassword.Location = new System.Drawing.Point(8, 260);
            this.lblalfNewPassword.Name = "lblalfNewPassword";
            this.lblalfNewPassword.Size = new System.Drawing.Size(90, 13);
            this.lblalfNewPassword.TabIndex = 9;
            this.lblalfNewPassword.Text = "New Password";
            // 
            // lblalfConfirmPassword
            // 
            this.lblalfConfirmPassword.AutoSize = true;
            this.lblalfConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblalfConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfConfirmPassword.Location = new System.Drawing.Point(8, 290);
            this.lblalfConfirmPassword.Name = "lblalfConfirmPassword";
            this.lblalfConfirmPassword.Size = new System.Drawing.Size(107, 13);
            this.lblalfConfirmPassword.TabIndex = 10;
            this.lblalfConfirmPassword.Text = "Confirm Password";
            // 
            // btnalfChangePassword
            // 
            this.btnalfChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnalfChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfChangePassword.Location = new System.Drawing.Point(118, 318);
            this.btnalfChangePassword.Name = "btnalfChangePassword";
            this.btnalfChangePassword.Size = new System.Drawing.Size(120, 29);
            this.btnalfChangePassword.TabIndex = 2;
            this.btnalfChangePassword.Text = "Change Password";
            this.btnalfChangePassword.UseVisualStyleBackColor = false;
            this.btnalfChangePassword.Click += new System.EventHandler(this.btnalfChangePassword_Click);
            // 
            // lblalfMiddleName
            // 
            this.lblalfMiddleName.AutoSize = true;
            this.lblalfMiddleName.BackColor = System.Drawing.Color.Transparent;
            this.lblalfMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfMiddleName.Location = new System.Drawing.Point(293, 256);
            this.lblalfMiddleName.Name = "lblalfMiddleName";
            this.lblalfMiddleName.Size = new System.Drawing.Size(80, 13);
            this.lblalfMiddleName.TabIndex = 12;
            this.lblalfMiddleName.Text = "Middle Name";
            // 
            // lblalfFirstName
            // 
            this.lblalfFirstName.AutoSize = true;
            this.lblalfFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblalfFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfFirstName.Location = new System.Drawing.Point(293, 230);
            this.lblalfFirstName.Name = "lblalfFirstName";
            this.lblalfFirstName.Size = new System.Drawing.Size(67, 13);
            this.lblalfFirstName.TabIndex = 11;
            this.lblalfFirstName.Text = "First Name";
            // 
            // txtalfMiddleName
            // 
            this.txtalfMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfMiddleName.Location = new System.Drawing.Point(381, 252);
            this.txtalfMiddleName.Name = "txtalfMiddleName";
            this.txtalfMiddleName.Size = new System.Drawing.Size(148, 20);
            this.txtalfMiddleName.TabIndex = 15;
            this.txtalfMiddleName.TextChanged += new System.EventHandler(this.txtalfMiddleName_TextChanged);
            this.txtalfMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfMiddleName_KeyPress);
            // 
            // txtalfFirstName
            // 
            this.txtalfFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfFirstName.Location = new System.Drawing.Point(381, 226);
            this.txtalfFirstName.Name = "txtalfFirstName";
            this.txtalfFirstName.Size = new System.Drawing.Size(148, 20);
            this.txtalfFirstName.TabIndex = 14;
            this.txtalfFirstName.TextChanged += new System.EventHandler(this.txtalfFirstName_TextChanged);
            this.txtalfFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfFirstName_KeyPress);
            // 
            // btnalfDeleteAccount
            // 
            this.btnalfDeleteAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnalfDeleteAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfDeleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfDeleteAccount.Location = new System.Drawing.Point(539, 252);
            this.btnalfDeleteAccount.Name = "btnalfDeleteAccount";
            this.btnalfDeleteAccount.Size = new System.Drawing.Size(104, 20);
            this.btnalfDeleteAccount.TabIndex = 16;
            this.btnalfDeleteAccount.Text = "Delete Account";
            this.btnalfDeleteAccount.UseVisualStyleBackColor = false;
            this.btnalfDeleteAccount.Click += new System.EventHandler(this.btnalfDeleteAccount_Click);
            // 
            // txtalfContactNumber
            // 
            this.txtalfContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfContactNumber.Location = new System.Drawing.Point(381, 304);
            this.txtalfContactNumber.MaxLength = 11;
            this.txtalfContactNumber.Name = "txtalfContactNumber";
            this.txtalfContactNumber.Size = new System.Drawing.Size(148, 20);
            this.txtalfContactNumber.TabIndex = 20;
            this.txtalfContactNumber.TextChanged += new System.EventHandler(this.txtalfContactNumber_TextChanged);
            this.txtalfContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfContactNumber_KeyPress);
            // 
            // txtalfLastName
            // 
            this.txtalfLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtalfLastName.Location = new System.Drawing.Point(381, 278);
            this.txtalfLastName.Name = "txtalfLastName";
            this.txtalfLastName.Size = new System.Drawing.Size(148, 20);
            this.txtalfLastName.TabIndex = 19;
            this.txtalfLastName.TextChanged += new System.EventHandler(this.txtalfLastName_TextChanged);
            this.txtalfLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtalfLastName_KeyPress);
            // 
            // lblalfContactNumber
            // 
            this.lblalfContactNumber.AutoSize = true;
            this.lblalfContactNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblalfContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfContactNumber.Location = new System.Drawing.Point(293, 308);
            this.lblalfContactNumber.Name = "lblalfContactNumber";
            this.lblalfContactNumber.Size = new System.Drawing.Size(75, 13);
            this.lblalfContactNumber.TabIndex = 18;
            this.lblalfContactNumber.Text = "Contact No.";
            // 
            // lblalfLastName
            // 
            this.lblalfLastName.AutoSize = true;
            this.lblalfLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblalfLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfLastName.Location = new System.Drawing.Point(293, 282);
            this.lblalfLastName.Name = "lblalfLastName";
            this.lblalfLastName.Size = new System.Drawing.Size(67, 13);
            this.lblalfLastName.TabIndex = 17;
            this.lblalfLastName.Text = "Last Name";
            // 
            // lblalfAuthority
            // 
            this.lblalfAuthority.AutoSize = true;
            this.lblalfAuthority.BackColor = System.Drawing.Color.Transparent;
            this.lblalfAuthority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfAuthority.Location = new System.Drawing.Point(293, 334);
            this.lblalfAuthority.Name = "lblalfAuthority";
            this.lblalfAuthority.Size = new System.Drawing.Size(57, 13);
            this.lblalfAuthority.TabIndex = 21;
            this.lblalfAuthority.Text = "Authority";
            // 
            // cbalfAuthority
            // 
            this.cbalfAuthority.FormattingEnabled = true;
            this.cbalfAuthority.Items.AddRange(new object[] {
            "Administrator",
            "Librarian"});
            this.cbalfAuthority.Location = new System.Drawing.Point(381, 330);
            this.cbalfAuthority.Name = "cbalfAuthority";
            this.cbalfAuthority.Size = new System.Drawing.Size(148, 21);
            this.cbalfAuthority.TabIndex = 22;
            this.cbalfAuthority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbalfAuthority_KeyPress);
            // 
            // btnalfEditAccount
            // 
            this.btnalfEditAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnalfEditAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfEditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfEditAccount.Location = new System.Drawing.Point(539, 226);
            this.btnalfEditAccount.Name = "btnalfEditAccount";
            this.btnalfEditAccount.Size = new System.Drawing.Size(104, 20);
            this.btnalfEditAccount.TabIndex = 23;
            this.btnalfEditAccount.Text = "Edit Account";
            this.btnalfEditAccount.UseVisualStyleBackColor = false;
            this.btnalfEditAccount.Click += new System.EventHandler(this.btnalfEditAccount_Click);
            // 
            // lblalfTip
            // 
            this.lblalfTip.AutoSize = true;
            this.lblalfTip.BackColor = System.Drawing.Color.Transparent;
            this.lblalfTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalfTip.Location = new System.Drawing.Point(525, 24);
            this.lblalfTip.Name = "lblalfTip";
            this.lblalfTip.Size = new System.Drawing.Size(118, 13);
            this.lblalfTip.TabIndex = 24;
            this.lblalfTip.Text = "Double click to select...";
            // 
            // btnalfUpdate
            // 
            this.btnalfUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnalfUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfUpdate.Location = new System.Drawing.Point(539, 278);
            this.btnalfUpdate.Name = "btnalfUpdate";
            this.btnalfUpdate.Size = new System.Drawing.Size(104, 20);
            this.btnalfUpdate.TabIndex = 25;
            this.btnalfUpdate.Text = "Update";
            this.btnalfUpdate.UseVisualStyleBackColor = false;
            this.btnalfUpdate.Click += new System.EventHandler(this.btnalfUpdate_Click);
            // 
            // btnalfCancel
            // 
            this.btnalfCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnalfCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfCancel.Location = new System.Drawing.Point(539, 304);
            this.btnalfCancel.Name = "btnalfCancel";
            this.btnalfCancel.Size = new System.Drawing.Size(104, 20);
            this.btnalfCancel.TabIndex = 26;
            this.btnalfCancel.Text = "Cancel";
            this.btnalfCancel.UseVisualStyleBackColor = false;
            this.btnalfCancel.Click += new System.EventHandler(this.btnalfCancel_Click);
            // 
            // btnalfcpUpdate
            // 
            this.btnalfcpUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnalfcpUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfcpUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfcpUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfcpUpdate.Location = new System.Drawing.Point(118, 318);
            this.btnalfcpUpdate.Name = "btnalfcpUpdate";
            this.btnalfcpUpdate.Size = new System.Drawing.Size(58, 29);
            this.btnalfcpUpdate.TabIndex = 27;
            this.btnalfcpUpdate.Text = "Update";
            this.btnalfcpUpdate.UseVisualStyleBackColor = false;
            this.btnalfcpUpdate.Click += new System.EventHandler(this.btnalfcpUpdate_Click);
            // 
            // btnalfcpCancel
            // 
            this.btnalfcpCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnalfcpCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnalfcpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnalfcpCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnalfcpCancel.Location = new System.Drawing.Point(180, 318);
            this.btnalfcpCancel.Name = "btnalfcpCancel";
            this.btnalfcpCancel.Size = new System.Drawing.Size(58, 29);
            this.btnalfcpCancel.TabIndex = 28;
            this.btnalfcpCancel.Text = "Cancel";
            this.btnalfcpCancel.UseVisualStyleBackColor = false;
            this.btnalfcpCancel.Click += new System.EventHandler(this.btnalfcpCancel_Click);
            // 
            // dgvalfAccountList
            // 
            this.dgvalfAccountList.AllowUserToAddRows = false;
            this.dgvalfAccountList.AllowUserToDeleteRows = false;
            this.dgvalfAccountList.AllowUserToResizeColumns = false;
            this.dgvalfAccountList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvalfAccountList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvalfAccountList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvalfAccountList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvalfAccountList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvalfAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvalfAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colalfdvID,
            this.colalfdvUsername,
            this.colalfdvName,
            this.colalfdvContactNumber,
            this.colalfdvAuthority});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvalfAccountList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvalfAccountList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvalfAccountList.Location = new System.Drawing.Point(7, 37);
            this.dgvalfAccountList.MultiSelect = false;
            this.dgvalfAccountList.Name = "dgvalfAccountList";
            this.dgvalfAccountList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvalfAccountList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvalfAccountList.RowHeadersVisible = false;
            this.dgvalfAccountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvalfAccountList.Size = new System.Drawing.Size(636, 181);
            this.dgvalfAccountList.TabIndex = 29;
            this.dgvalfAccountList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvalfAccountList_CellDoubleClick);
            // 
            // colalfdvID
            // 
            this.colalfdvID.FillWeight = 20F;
            this.colalfdvID.HeaderText = "ID";
            this.colalfdvID.Name = "colalfdvID";
            this.colalfdvID.ReadOnly = true;
            // 
            // colalfdvUsername
            // 
            this.colalfdvUsername.FillWeight = 80F;
            this.colalfdvUsername.HeaderText = "Username";
            this.colalfdvUsername.Name = "colalfdvUsername";
            this.colalfdvUsername.ReadOnly = true;
            // 
            // colalfdvName
            // 
            this.colalfdvName.FillWeight = 120F;
            this.colalfdvName.HeaderText = "Name";
            this.colalfdvName.Name = "colalfdvName";
            this.colalfdvName.ReadOnly = true;
            // 
            // colalfdvContactNumber
            // 
            this.colalfdvContactNumber.HeaderText = "Contact Number";
            this.colalfdvContactNumber.Name = "colalfdvContactNumber";
            this.colalfdvContactNumber.ReadOnly = true;
            // 
            // colalfdvAuthority
            // 
            this.colalfdvAuthority.HeaderText = "Authority";
            this.colalfdvAuthority.Name = "colalfdvAuthority";
            this.colalfdvAuthority.ReadOnly = true;
            // 
            // AccountListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 360);
            this.Controls.Add(this.dgvalfAccountList);
            this.Controls.Add(this.btnalfCancel);
            this.Controls.Add(this.btnalfUpdate);
            this.Controls.Add(this.lblalfTip);
            this.Controls.Add(this.btnalfEditAccount);
            this.Controls.Add(this.cbalfAuthority);
            this.Controls.Add(this.lblalfAuthority);
            this.Controls.Add(this.txtalfContactNumber);
            this.Controls.Add(this.txtalfLastName);
            this.Controls.Add(this.lblalfContactNumber);
            this.Controls.Add(this.lblalfLastName);
            this.Controls.Add(this.btnalfDeleteAccount);
            this.Controls.Add(this.txtalfMiddleName);
            this.Controls.Add(this.txtalfFirstName);
            this.Controls.Add(this.lblalfMiddleName);
            this.Controls.Add(this.lblalfFirstName);
            this.Controls.Add(this.lblalfConfirmPassword);
            this.Controls.Add(this.lblalfNewPassword);
            this.Controls.Add(this.lblalfCurrentPassword);
            this.Controls.Add(this.txtalfConfirmPassword);
            this.Controls.Add(this.txtalfNewPassword);
            this.Controls.Add(this.txtalfCurrentPassword);
            this.Controls.Add(this.btnalfDone);
            this.Controls.Add(this.lblAccountList);
            this.Controls.Add(this.btnalfChangePassword);
            this.Controls.Add(this.btnalfcpCancel);
            this.Controls.Add(this.btnalfcpUpdate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AccountListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.AccountListForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AccountListForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvalfAccountList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAccountList;
        private System.Windows.Forms.Button btnalfDone;
        private System.Windows.Forms.TextBox txtalfCurrentPassword;
        private System.Windows.Forms.TextBox txtalfNewPassword;
        private System.Windows.Forms.TextBox txtalfConfirmPassword;
        private System.Windows.Forms.Label lblalfCurrentPassword;
        private System.Windows.Forms.Label lblalfNewPassword;
        private System.Windows.Forms.Label lblalfConfirmPassword;
        private System.Windows.Forms.Button btnalfChangePassword;
        private System.Windows.Forms.Label lblalfMiddleName;
        private System.Windows.Forms.Label lblalfFirstName;
        private System.Windows.Forms.TextBox txtalfMiddleName;
        private System.Windows.Forms.TextBox txtalfFirstName;
        private System.Windows.Forms.Button btnalfDeleteAccount;
        private System.Windows.Forms.TextBox txtalfContactNumber;
        private System.Windows.Forms.TextBox txtalfLastName;
        private System.Windows.Forms.Label lblalfContactNumber;
        private System.Windows.Forms.Label lblalfLastName;
        private System.Windows.Forms.Label lblalfAuthority;
        private System.Windows.Forms.ComboBox cbalfAuthority;
        private System.Windows.Forms.Button btnalfEditAccount;
        private System.Windows.Forms.Label lblalfTip;
        private System.Windows.Forms.Button btnalfUpdate;
        private System.Windows.Forms.Button btnalfCancel;
        private System.Windows.Forms.Button btnalfcpUpdate;
        private System.Windows.Forms.Button btnalfcpCancel;
        private System.Windows.Forms.DataGridView dgvalfAccountList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colalfdvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colalfdvUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colalfdvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colalfdvContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colalfdvAuthority;
    }
}