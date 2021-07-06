namespace LibrarySystem
{
    partial class ForgotPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            this.txtfpUsername = new System.Windows.Forms.TextBox();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.btnfpSearch = new System.Windows.Forms.Button();
            this.lnklblfpContact = new System.Windows.Forms.LinkLabel();
            this.txtfpA = new System.Windows.Forms.TextBox();
            this.lblfpSQ = new System.Windows.Forms.Label();
            this.lblfpQ = new System.Windows.Forms.Label();
            this.btnfpSubmit = new System.Windows.Forms.Button();
            this.btnfpClear = new System.Windows.Forms.Button();
            this.btnfpCancel = new System.Windows.Forms.Button();
            this.lblfpUsername = new System.Windows.Forms.Label();
            this.txtfpFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfpAuthority = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtfpUsername
            // 
            this.txtfpUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfpUsername.ForeColor = System.Drawing.Color.DarkGray;
            this.txtfpUsername.Location = new System.Drawing.Point(89, 40);
            this.txtfpUsername.Name = "txtfpUsername";
            this.txtfpUsername.Size = new System.Drawing.Size(153, 20);
            this.txtfpUsername.TabIndex = 0;
            this.txtfpUsername.Text = "Enter Your Username";
            this.txtfpUsername.Enter += new System.EventHandler(this.txtfpUsername_Enter);
            this.txtfpUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfpUsername_KeyPress);
            this.txtfpUsername.Leave += new System.EventHandler(this.txtfpUsername_Leave);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.Location = new System.Drawing.Point(8, 9);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(189, 25);
            this.lblForgotPassword.TabIndex = 1;
            this.lblForgotPassword.Text = "Forgot Password";
            // 
            // btnfpSearch
            // 
            this.btnfpSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnfpSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfpSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnfpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfpSearch.Location = new System.Drawing.Point(248, 39);
            this.btnfpSearch.Name = "btnfpSearch";
            this.btnfpSearch.Size = new System.Drawing.Size(75, 23);
            this.btnfpSearch.TabIndex = 1;
            this.btnfpSearch.Text = "Search";
            this.btnfpSearch.UseVisualStyleBackColor = false;
            this.btnfpSearch.Click += new System.EventHandler(this.btnfpSearch_Click);
            // 
            // lnklblfpContact
            // 
            this.lnklblfpContact.AutoSize = true;
            this.lnklblfpContact.BackColor = System.Drawing.Color.Transparent;
            this.lnklblfpContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnklblfpContact.Location = new System.Drawing.Point(253, 9);
            this.lnklblfpContact.Name = "lnklblfpContact";
            this.lnklblfpContact.Size = new System.Drawing.Size(107, 13);
            this.lnklblfpContact.TabIndex = 7;
            this.lnklblfpContact.TabStop = true;
            this.lnklblfpContact.Text = "Contact Administrator";
            this.lnklblfpContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblfpContact_LinkClicked);
            // 
            // txtfpA
            // 
            this.txtfpA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfpA.ForeColor = System.Drawing.Color.DarkGray;
            this.txtfpA.Location = new System.Drawing.Point(13, 187);
            this.txtfpA.Name = "txtfpA";
            this.txtfpA.Size = new System.Drawing.Size(346, 20);
            this.txtfpA.TabIndex = 2;
            this.txtfpA.Text = "Type In Your Answer";
            this.txtfpA.Enter += new System.EventHandler(this.txtfpA_Enter);
            this.txtfpA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfpA_KeyPress);
            this.txtfpA.Leave += new System.EventHandler(this.txtfpA_Leave);
            // 
            // lblfpSQ
            // 
            this.lblfpSQ.AutoSize = true;
            this.lblfpSQ.BackColor = System.Drawing.Color.Transparent;
            this.lblfpSQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfpSQ.Location = new System.Drawing.Point(10, 132);
            this.lblfpSQ.Name = "lblfpSQ";
            this.lblfpSQ.Size = new System.Drawing.Size(206, 15);
            this.lblfpSQ.TabIndex = 6;
            this.lblfpSQ.Text = "Answer Your Security Question.";
            // 
            // lblfpQ
            // 
            this.lblfpQ.AutoSize = true;
            this.lblfpQ.BackColor = System.Drawing.Color.Transparent;
            this.lblfpQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblfpQ.Location = new System.Drawing.Point(10, 154);
            this.lblfpQ.Name = "lblfpQ";
            this.lblfpQ.Size = new System.Drawing.Size(0, 15);
            this.lblfpQ.TabIndex = 8;
            // 
            // btnfpSubmit
            // 
            this.btnfpSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnfpSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfpSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnfpSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfpSubmit.Location = new System.Drawing.Point(13, 220);
            this.btnfpSubmit.Name = "btnfpSubmit";
            this.btnfpSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnfpSubmit.TabIndex = 3;
            this.btnfpSubmit.Text = "Submit";
            this.btnfpSubmit.UseVisualStyleBackColor = false;
            this.btnfpSubmit.Click += new System.EventHandler(this.btnfpSubmit_Click);
            // 
            // btnfpClear
            // 
            this.btnfpClear.BackColor = System.Drawing.Color.Transparent;
            this.btnfpClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfpClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnfpClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfpClear.Location = new System.Drawing.Point(146, 220);
            this.btnfpClear.Name = "btnfpClear";
            this.btnfpClear.Size = new System.Drawing.Size(75, 23);
            this.btnfpClear.TabIndex = 4;
            this.btnfpClear.Text = "Clear";
            this.btnfpClear.UseVisualStyleBackColor = false;
            this.btnfpClear.Click += new System.EventHandler(this.btnfpClear_Click);
            // 
            // btnfpCancel
            // 
            this.btnfpCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnfpCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnfpCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfpCancel.Location = new System.Drawing.Point(284, 220);
            this.btnfpCancel.Name = "btnfpCancel";
            this.btnfpCancel.Size = new System.Drawing.Size(75, 23);
            this.btnfpCancel.TabIndex = 6;
            this.btnfpCancel.Text = "Cancel";
            this.btnfpCancel.UseVisualStyleBackColor = false;
            this.btnfpCancel.Click += new System.EventHandler(this.btnfpCancel_Click);
            // 
            // lblfpUsername
            // 
            this.lblfpUsername.AutoSize = true;
            this.lblfpUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblfpUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfpUsername.Location = new System.Drawing.Point(10, 41);
            this.lblfpUsername.Name = "lblfpUsername";
            this.lblfpUsername.Size = new System.Drawing.Size(73, 15);
            this.lblfpUsername.TabIndex = 13;
            this.lblfpUsername.Text = "Username";
            // 
            // txtfpFullName
            // 
            this.txtfpFullName.BackColor = System.Drawing.SystemColors.Control;
            this.txtfpFullName.Enabled = false;
            this.txtfpFullName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtfpFullName.Location = new System.Drawing.Point(89, 70);
            this.txtfpFullName.Name = "txtfpFullName";
            this.txtfpFullName.ReadOnly = true;
            this.txtfpFullName.Size = new System.Drawing.Size(233, 20);
            this.txtfpFullName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Full Name";
            // 
            // txtfpAuthority
            // 
            this.txtfpAuthority.BackColor = System.Drawing.SystemColors.Control;
            this.txtfpAuthority.Enabled = false;
            this.txtfpAuthority.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtfpAuthority.Location = new System.Drawing.Point(89, 99);
            this.txtfpAuthority.Name = "txtfpAuthority";
            this.txtfpAuthority.ReadOnly = true;
            this.txtfpAuthority.Size = new System.Drawing.Size(153, 20);
            this.txtfpAuthority.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Authority";
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 257);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfpAuthority);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfpFullName);
            this.Controls.Add(this.lblfpUsername);
            this.Controls.Add(this.btnfpCancel);
            this.Controls.Add(this.btnfpClear);
            this.Controls.Add(this.btnfpSubmit);
            this.Controls.Add(this.lblfpQ);
            this.Controls.Add(this.lblfpSQ);
            this.Controls.Add(this.txtfpA);
            this.Controls.Add(this.lnklblfpContact);
            this.Controls.Add(this.btnfpSearch);
            this.Controls.Add(this.lblForgotPassword);
            this.Controls.Add(this.txtfpUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.ForPassForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ForPassForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfpUsername;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Button btnfpSearch;
        private System.Windows.Forms.LinkLabel lnklblfpContact;
        private System.Windows.Forms.TextBox txtfpA;
        private System.Windows.Forms.Label lblfpSQ;
        private System.Windows.Forms.Label lblfpQ;
        private System.Windows.Forms.Button btnfpSubmit;
        private System.Windows.Forms.Button btnfpClear;
        private System.Windows.Forms.Button btnfpCancel;
        private System.Windows.Forms.Label lblfpUsername;
        private System.Windows.Forms.TextBox txtfpFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfpAuthority;
        private System.Windows.Forms.Label label2;
    }
}