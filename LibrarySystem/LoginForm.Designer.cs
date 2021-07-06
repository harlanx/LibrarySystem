namespace LibrarySystem
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtlfUser = new System.Windows.Forms.TextBox();
            this.txtlfPass = new System.Windows.Forms.TextBox();
            this.lblLoginAccount = new System.Windows.Forms.Label();
            this.btnlfLogin = new System.Windows.Forms.Button();
            this.btnlfCancel = new System.Windows.Forms.Button();
            this.lnklbllfFP = new System.Windows.Forms.LinkLabel();
            this.lbllfUsername = new System.Windows.Forms.Label();
            this.lbllfPassword = new System.Windows.Forms.Label();
            this.chkbRememberMe = new System.Windows.Forms.CheckBox();
            this.txtlfPassHidden = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.LoginTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtlfUser
            // 
            this.txtlfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlfUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlfUser.ForeColor = System.Drawing.Color.DarkGray;
            this.txtlfUser.Location = new System.Drawing.Point(97, 40);
            this.txtlfUser.Name = "txtlfUser";
            this.txtlfUser.Size = new System.Drawing.Size(225, 22);
            this.txtlfUser.TabIndex = 1;
            this.txtlfUser.Text = "Enter Username";
            this.txtlfUser.Enter += new System.EventHandler(this.txtlfUser_Enter);
            this.txtlfUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlfUser_KeyPress);
            this.txtlfUser.Leave += new System.EventHandler(this.txtlfUser_Leave);
            // 
            // txtlfPass
            // 
            this.txtlfPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlfPass.ForeColor = System.Drawing.Color.DarkGray;
            this.txtlfPass.Location = new System.Drawing.Point(97, 79);
            this.txtlfPass.Name = "txtlfPass";
            this.txtlfPass.Size = new System.Drawing.Size(196, 22);
            this.txtlfPass.TabIndex = 8;
            this.txtlfPass.Text = "Enter Password";
            // 
            // lblLoginAccount
            // 
            this.lblLoginAccount.AutoSize = true;
            this.lblLoginAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginAccount.Location = new System.Drawing.Point(87, 6);
            this.lblLoginAccount.Name = "lblLoginAccount";
            this.lblLoginAccount.Size = new System.Drawing.Size(162, 25);
            this.lblLoginAccount.TabIndex = 0;
            this.lblLoginAccount.Text = "Login Account";
            this.lblLoginAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnlfLogin
            // 
            this.btnlfLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnlfLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlfLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnlfLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnlfLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlfLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlfLogin.Location = new System.Drawing.Point(134, 121);
            this.btnlfLogin.Name = "btnlfLogin";
            this.btnlfLogin.Size = new System.Drawing.Size(75, 23);
            this.btnlfLogin.TabIndex = 5;
            this.btnlfLogin.Text = "Login";
            this.btnlfLogin.UseVisualStyleBackColor = false;
            this.btnlfLogin.Click += new System.EventHandler(this.btnlfLogin_Click);
            // 
            // btnlfCancel
            // 
            this.btnlfCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnlfCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlfCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnlfCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnlfCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnlfCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlfCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlfCancel.Location = new System.Drawing.Point(247, 121);
            this.btnlfCancel.Name = "btnlfCancel";
            this.btnlfCancel.Size = new System.Drawing.Size(75, 23);
            this.btnlfCancel.TabIndex = 6;
            this.btnlfCancel.Text = "Cancel";
            this.btnlfCancel.UseVisualStyleBackColor = false;
            this.btnlfCancel.Click += new System.EventHandler(this.btnlfCancel_Click);
            // 
            // lnklbllfFP
            // 
            this.lnklbllfFP.AutoSize = true;
            this.lnklbllfFP.BackColor = System.Drawing.Color.Transparent;
            this.lnklbllfFP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnklbllfFP.Location = new System.Drawing.Point(234, 152);
            this.lnklbllfFP.Name = "lnklbllfFP";
            this.lnklbllfFP.Size = new System.Drawing.Size(92, 13);
            this.lnklbllfFP.TabIndex = 7;
            this.lnklbllfFP.TabStop = true;
            this.lnklbllfFP.Text = "Forgot Password?";
            this.lnklbllfFP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbllfFP_LinkClicked);
            // 
            // lbllfUsername
            // 
            this.lbllfUsername.AutoSize = true;
            this.lbllfUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbllfUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbllfUsername.Location = new System.Drawing.Point(10, 42);
            this.lbllfUsername.Name = "lbllfUsername";
            this.lbllfUsername.Size = new System.Drawing.Size(81, 17);
            this.lbllfUsername.TabIndex = 10;
            this.lbllfUsername.Text = "Username";
            // 
            // lbllfPassword
            // 
            this.lbllfPassword.AutoSize = true;
            this.lbllfPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbllfPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllfPassword.Location = new System.Drawing.Point(10, 79);
            this.lbllfPassword.Name = "lbllfPassword";
            this.lbllfPassword.Size = new System.Drawing.Size(76, 16);
            this.lbllfPassword.TabIndex = 9;
            this.lbllfPassword.Text = "Password";
            this.lbllfPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkbRememberMe
            // 
            this.chkbRememberMe.AutoSize = true;
            this.chkbRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.chkbRememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbRememberMe.Location = new System.Drawing.Point(13, 127);
            this.chkbRememberMe.Name = "chkbRememberMe";
            this.chkbRememberMe.Size = new System.Drawing.Size(95, 17);
            this.chkbRememberMe.TabIndex = 4;
            this.chkbRememberMe.Text = "Remember Me";
            this.chkbRememberMe.UseVisualStyleBackColor = false;
            // 
            // txtlfPassHidden
            // 
            this.txtlfPassHidden.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtlfPassHidden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlfPassHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlfPassHidden.ForeColor = System.Drawing.Color.DarkGray;
            this.txtlfPassHidden.Location = new System.Drawing.Point(97, 79);
            this.txtlfPassHidden.Name = "txtlfPassHidden";
            this.txtlfPassHidden.PasswordChar = '*';
            this.txtlfPassHidden.Size = new System.Drawing.Size(196, 22);
            this.txtlfPassHidden.TabIndex = 2;
            this.txtlfPassHidden.Text = "Enter Password";
            this.txtlfPassHidden.Enter += new System.EventHandler(this.txtlfPassHidden_Enter);
            this.txtlfPassHidden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlfPassHidden_KeyPress);
            this.txtlfPassHidden.Leave += new System.EventHandler(this.txtlfPassHidden_Leave);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BackgroundImage = global::LibrarySystem.Properties.Resources.ESP;
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.ForeColor = System.Drawing.Color.Transparent;
            this.btnShow.Location = new System.Drawing.Point(292, 79);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(30, 22);
            this.btnShow.TabIndex = 3;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseDown);
            this.btnShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnShow_MouseUp);
            // 
            // LoginTimer
            // 
            this.LoginTimer.Enabled = true;
            this.LoginTimer.Interval = 1;
            this.LoginTimer.Tick += new System.EventHandler(this.LoginTimer_Tick);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnlfLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnlfCancel;
            this.ClientSize = new System.Drawing.Size(334, 177);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.chkbRememberMe);
            this.Controls.Add(this.lbllfPassword);
            this.Controls.Add(this.lbllfUsername);
            this.Controls.Add(this.lnklbllfFP);
            this.Controls.Add(this.btnlfCancel);
            this.Controls.Add(this.btnlfLogin);
            this.Controls.Add(this.lblLoginAccount);
            this.Controls.Add(this.txtlfUser);
            this.Controls.Add(this.txtlfPassHidden);
            this.Controls.Add(this.txtlfPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtlfUser;
        private System.Windows.Forms.TextBox txtlfPass;
        private System.Windows.Forms.Label lblLoginAccount;
        private System.Windows.Forms.Button btnlfLogin;
        private System.Windows.Forms.Button btnlfCancel;
        private System.Windows.Forms.LinkLabel lnklbllfFP;
        private System.Windows.Forms.Label lbllfUsername;
        private System.Windows.Forms.Label lbllfPassword;
        private System.Windows.Forms.CheckBox chkbRememberMe;
        private System.Windows.Forms.TextBox txtlfPassHidden;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Timer LoginTimer;
    }
}

