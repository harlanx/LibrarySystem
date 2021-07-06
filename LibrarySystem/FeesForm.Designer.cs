namespace LibrarySystem
{
    partial class FeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesForm));
            this.lblOverdueFee = new System.Windows.Forms.Label();
            this.lblffDaily = new System.Windows.Forms.Label();
            this.txtffDaily = new System.Windows.Forms.TextBox();
            this.txtffMaximum = new System.Windows.Forms.TextBox();
            this.lblffMaximum = new System.Windows.Forms.Label();
            this.lblDamagedFee = new System.Windows.Forms.Label();
            this.lblLostFee = new System.Windows.Forms.Label();
            this.txtffDamagedFee = new System.Windows.Forms.TextBox();
            this.cbffDamagedFeeType = new System.Windows.Forms.ComboBox();
            this.cbffLostFeeType = new System.Windows.Forms.ComboBox();
            this.txtffLostFee = new System.Windows.Forms.TextBox();
            this.btnffDone = new System.Windows.Forms.Button();
            this.btnffEdit = new System.Windows.Forms.Button();
            this.lblMaximumBook = new System.Windows.Forms.Label();
            this.txtMaximumBook = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblOverdueFee
            // 
            this.lblOverdueFee.AutoSize = true;
            this.lblOverdueFee.BackColor = System.Drawing.Color.Transparent;
            this.lblOverdueFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverdueFee.Location = new System.Drawing.Point(37, 60);
            this.lblOverdueFee.Name = "lblOverdueFee";
            this.lblOverdueFee.Size = new System.Drawing.Size(98, 16);
            this.lblOverdueFee.TabIndex = 0;
            this.lblOverdueFee.Text = "Overdue Fee";
            // 
            // lblffDaily
            // 
            this.lblffDaily.AutoSize = true;
            this.lblffDaily.BackColor = System.Drawing.Color.Transparent;
            this.lblffDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblffDaily.Location = new System.Drawing.Point(11, 83);
            this.lblffDaily.Name = "lblffDaily";
            this.lblffDaily.Size = new System.Drawing.Size(42, 16);
            this.lblffDaily.TabIndex = 1;
            this.lblffDaily.Text = "Daily:";
            // 
            // txtffDaily
            // 
            this.txtffDaily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtffDaily.Location = new System.Drawing.Point(82, 81);
            this.txtffDaily.Name = "txtffDaily";
            this.txtffDaily.Size = new System.Drawing.Size(74, 20);
            this.txtffDaily.TabIndex = 2;
            this.txtffDaily.TextChanged += new System.EventHandler(this.txtffDaily_TextChanged);
            this.txtffDaily.Enter += new System.EventHandler(this.txtffDaily_Enter);
            this.txtffDaily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtffDaily_KeyPress);
            this.txtffDaily.Leave += new System.EventHandler(this.txtffDaily_Leave);
            // 
            // txtffMaximum
            // 
            this.txtffMaximum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtffMaximum.Location = new System.Drawing.Point(82, 107);
            this.txtffMaximum.Name = "txtffMaximum";
            this.txtffMaximum.Size = new System.Drawing.Size(74, 20);
            this.txtffMaximum.TabIndex = 4;
            this.txtffMaximum.TextChanged += new System.EventHandler(this.txtffMaximum_TextChanged);
            this.txtffMaximum.Enter += new System.EventHandler(this.txtffMaximum_Enter);
            this.txtffMaximum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtffMaximum_KeyPress);
            this.txtffMaximum.Leave += new System.EventHandler(this.txtffMaximum_Leave);
            // 
            // lblffMaximum
            // 
            this.lblffMaximum.AutoSize = true;
            this.lblffMaximum.BackColor = System.Drawing.Color.Transparent;
            this.lblffMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblffMaximum.Location = new System.Drawing.Point(11, 109);
            this.lblffMaximum.Name = "lblffMaximum";
            this.lblffMaximum.Size = new System.Drawing.Size(68, 16);
            this.lblffMaximum.TabIndex = 3;
            this.lblffMaximum.Text = "Maximum:";
            // 
            // lblDamagedFee
            // 
            this.lblDamagedFee.AutoSize = true;
            this.lblDamagedFee.BackColor = System.Drawing.Color.Transparent;
            this.lblDamagedFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamagedFee.Location = new System.Drawing.Point(33, 139);
            this.lblDamagedFee.Name = "lblDamagedFee";
            this.lblDamagedFee.Size = new System.Drawing.Size(107, 16);
            this.lblDamagedFee.TabIndex = 5;
            this.lblDamagedFee.Text = "Damaged Fee";
            // 
            // lblLostFee
            // 
            this.lblLostFee.AutoSize = true;
            this.lblLostFee.BackColor = System.Drawing.Color.Transparent;
            this.lblLostFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLostFee.Location = new System.Drawing.Point(51, 186);
            this.lblLostFee.Name = "lblLostFee";
            this.lblLostFee.Size = new System.Drawing.Size(68, 16);
            this.lblLostFee.TabIndex = 6;
            this.lblLostFee.Text = "Lost Fee";
            // 
            // txtffDamagedFee
            // 
            this.txtffDamagedFee.Location = new System.Drawing.Point(94, 161);
            this.txtffDamagedFee.Name = "txtffDamagedFee";
            this.txtffDamagedFee.Size = new System.Drawing.Size(69, 20);
            this.txtffDamagedFee.TabIndex = 8;
            this.txtffDamagedFee.TextChanged += new System.EventHandler(this.txtffDamagedFee_TextChanged);
            this.txtffDamagedFee.Enter += new System.EventHandler(this.txtffDamagedFee_Enter);
            this.txtffDamagedFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtffDamagedFee_KeyPress);
            this.txtffDamagedFee.Leave += new System.EventHandler(this.txtffDamagedFee_Leave);
            // 
            // cbffDamagedFeeType
            // 
            this.cbffDamagedFeeType.FormattingEnabled = true;
            this.cbffDamagedFeeType.Items.AddRange(new object[] {
            "Percentage",
            "Specific"});
            this.cbffDamagedFeeType.Location = new System.Drawing.Point(6, 160);
            this.cbffDamagedFeeType.Name = "cbffDamagedFeeType";
            this.cbffDamagedFeeType.Size = new System.Drawing.Size(83, 21);
            this.cbffDamagedFeeType.TabIndex = 9;
            this.cbffDamagedFeeType.SelectedIndexChanged += new System.EventHandler(this.cbffDamagedFeeType_SelectedIndexChanged);
            this.cbffDamagedFeeType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbffDamagedFeeType_KeyPress);
            // 
            // cbffLostFeeType
            // 
            this.cbffLostFeeType.FormattingEnabled = true;
            this.cbffLostFeeType.Items.AddRange(new object[] {
            "Book Price",
            "Specific Price"});
            this.cbffLostFeeType.Location = new System.Drawing.Point(26, 205);
            this.cbffLostFeeType.Name = "cbffLostFeeType";
            this.cbffLostFeeType.Size = new System.Drawing.Size(118, 21);
            this.cbffLostFeeType.TabIndex = 10;
            this.cbffLostFeeType.SelectedIndexChanged += new System.EventHandler(this.cbffLostFeeType_SelectedIndexChanged);
            this.cbffLostFeeType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbffLostFeeType_KeyPress);
            // 
            // txtffLostFee
            // 
            this.txtffLostFee.Location = new System.Drawing.Point(34, 233);
            this.txtffLostFee.Name = "txtffLostFee";
            this.txtffLostFee.Size = new System.Drawing.Size(100, 20);
            this.txtffLostFee.TabIndex = 11;
            this.txtffLostFee.TextChanged += new System.EventHandler(this.txtffLostFee_TextChanged);
            this.txtffLostFee.Enter += new System.EventHandler(this.txtffLostFee_Enter);
            this.txtffLostFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtffLostFee_KeyPress);
            this.txtffLostFee.Leave += new System.EventHandler(this.txtffLostFee_Leave);
            // 
            // btnffDone
            // 
            this.btnffDone.BackColor = System.Drawing.Color.Transparent;
            this.btnffDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnffDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnffDone.Location = new System.Drawing.Point(87, 265);
            this.btnffDone.Name = "btnffDone";
            this.btnffDone.Size = new System.Drawing.Size(65, 23);
            this.btnffDone.TabIndex = 12;
            this.btnffDone.Text = "Done";
            this.btnffDone.UseVisualStyleBackColor = false;
            this.btnffDone.Click += new System.EventHandler(this.btnffDone_Click);
            // 
            // btnffEdit
            // 
            this.btnffEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnffEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnffEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnffEdit.Location = new System.Drawing.Point(16, 265);
            this.btnffEdit.Name = "btnffEdit";
            this.btnffEdit.Size = new System.Drawing.Size(65, 23);
            this.btnffEdit.TabIndex = 13;
            this.btnffEdit.Text = "Edit";
            this.btnffEdit.UseVisualStyleBackColor = false;
            this.btnffEdit.Click += new System.EventHandler(this.btnffEdit_Click);
            // 
            // lblMaximumBook
            // 
            this.lblMaximumBook.AutoSize = true;
            this.lblMaximumBook.BackColor = System.Drawing.Color.Transparent;
            this.lblMaximumBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximumBook.Location = new System.Drawing.Point(30, 8);
            this.lblMaximumBook.Name = "lblMaximumBook";
            this.lblMaximumBook.Size = new System.Drawing.Size(112, 16);
            this.lblMaximumBook.TabIndex = 14;
            this.lblMaximumBook.Text = "Maximum Book";
            // 
            // txtMaximumBook
            // 
            this.txtMaximumBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaximumBook.Location = new System.Drawing.Point(64, 29);
            this.txtMaximumBook.Name = "txtMaximumBook";
            this.txtMaximumBook.Size = new System.Drawing.Size(39, 20);
            this.txtMaximumBook.TabIndex = 15;
            this.txtMaximumBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaximumBook.TextChanged += new System.EventHandler(this.txtMaximumBook_TextChanged);
            this.txtMaximumBook.Enter += new System.EventHandler(this.txtMaximumBook_Enter);
            this.txtMaximumBook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaximumBook_KeyPress);
            this.txtMaximumBook.Leave += new System.EventHandler(this.txtMaximumBook_Leave);
            // 
            // FeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 298);
            this.Controls.Add(this.txtMaximumBook);
            this.Controls.Add(this.lblMaximumBook);
            this.Controls.Add(this.btnffEdit);
            this.Controls.Add(this.btnffDone);
            this.Controls.Add(this.txtffLostFee);
            this.Controls.Add(this.cbffLostFeeType);
            this.Controls.Add(this.cbffDamagedFeeType);
            this.Controls.Add(this.txtffDamagedFee);
            this.Controls.Add(this.lblLostFee);
            this.Controls.Add(this.lblDamagedFee);
            this.Controls.Add(this.txtffMaximum);
            this.Controls.Add(this.lblffMaximum);
            this.Controls.Add(this.txtffDaily);
            this.Controls.Add(this.lblffDaily);
            this.Controls.Add(this.lblOverdueFee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.FeesForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FeesForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverdueFee;
        private System.Windows.Forms.Label lblffDaily;
        private System.Windows.Forms.TextBox txtffDaily;
        private System.Windows.Forms.TextBox txtffMaximum;
        private System.Windows.Forms.Label lblffMaximum;
        private System.Windows.Forms.Label lblDamagedFee;
        private System.Windows.Forms.Label lblLostFee;
        private System.Windows.Forms.TextBox txtffDamagedFee;
        private System.Windows.Forms.ComboBox cbffDamagedFeeType;
        private System.Windows.Forms.ComboBox cbffLostFeeType;
        private System.Windows.Forms.TextBox txtffLostFee;
        private System.Windows.Forms.Button btnffDone;
        private System.Windows.Forms.Button btnffEdit;
        private System.Windows.Forms.Label lblMaximumBook;
        private System.Windows.Forms.TextBox txtMaximumBook;
    }
}