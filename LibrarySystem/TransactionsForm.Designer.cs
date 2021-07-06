namespace LibrarySystem
{
    partial class TransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            this.btntfReset = new System.Windows.Forms.Button();
            this.btntfDone = new System.Windows.Forms.Button();
            this.btntfDeleteTransactions = new System.Windows.Forms.Button();
            this.btntfSearch = new System.Windows.Forms.Button();
            this.cbtfSearchby = new System.Windows.Forms.ComboBox();
            this.txttfSearchbox = new System.Windows.Forms.TextBox();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.dvtfGridView = new System.Windows.Forms.DataGridView();
            this.coltfNumbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfVisitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfAmmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltfDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtfSearchbyExt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvtfGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btntfReset
            // 
            this.btntfReset.BackColor = System.Drawing.Color.Transparent;
            this.btntfReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntfReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntfReset.Location = new System.Drawing.Point(1006, 13);
            this.btntfReset.Name = "btntfReset";
            this.btntfReset.Size = new System.Drawing.Size(93, 21);
            this.btntfReset.TabIndex = 17;
            this.btntfReset.Text = "Reset Result";
            this.btntfReset.UseVisualStyleBackColor = false;
            this.btntfReset.Click += new System.EventHandler(this.btntfReset_Click);
            // 
            // btntfDone
            // 
            this.btntfDone.BackColor = System.Drawing.Color.Transparent;
            this.btntfDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntfDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntfDone.Location = new System.Drawing.Point(1024, 571);
            this.btntfDone.Name = "btntfDone";
            this.btntfDone.Size = new System.Drawing.Size(75, 23);
            this.btntfDone.TabIndex = 16;
            this.btntfDone.Text = "Done";
            this.btntfDone.UseVisualStyleBackColor = false;
            this.btntfDone.Click += new System.EventHandler(this.btntfDone_Click);
            // 
            // btntfDeleteTransactions
            // 
            this.btntfDeleteTransactions.BackColor = System.Drawing.Color.Transparent;
            this.btntfDeleteTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntfDeleteTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntfDeleteTransactions.Location = new System.Drawing.Point(12, 571);
            this.btntfDeleteTransactions.Name = "btntfDeleteTransactions";
            this.btntfDeleteTransactions.Size = new System.Drawing.Size(112, 23);
            this.btntfDeleteTransactions.TabIndex = 14;
            this.btntfDeleteTransactions.Text = "Clear Transactions";
            this.btntfDeleteTransactions.UseVisualStyleBackColor = false;
            this.btntfDeleteTransactions.Click += new System.EventHandler(this.btntfDeleteTransactions_Click);
            // 
            // btntfSearch
            // 
            this.btntfSearch.BackColor = System.Drawing.Color.Transparent;
            this.btntfSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntfSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntfSearch.Location = new System.Drawing.Point(927, 13);
            this.btntfSearch.Name = "btntfSearch";
            this.btntfSearch.Size = new System.Drawing.Size(75, 21);
            this.btntfSearch.TabIndex = 13;
            this.btntfSearch.Text = "Search";
            this.btntfSearch.UseVisualStyleBackColor = false;
            this.btntfSearch.Click += new System.EventHandler(this.btntfSearch_Click);
            // 
            // cbtfSearchby
            // 
            this.cbtfSearchby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtfSearchby.FormattingEnabled = true;
            this.cbtfSearchby.Items.AddRange(new object[] {
            "Search by Book Title",
            "Search by Date",
            "Search by Transaction",
            "Search by Visitor"});
            this.cbtfSearchby.Location = new System.Drawing.Point(796, 13);
            this.cbtfSearchby.Name = "cbtfSearchby";
            this.cbtfSearchby.Size = new System.Drawing.Size(127, 21);
            this.cbtfSearchby.TabIndex = 12;
            this.cbtfSearchby.SelectedIndexChanged += new System.EventHandler(this.cbtfSearchby_SelectedIndexChanged);
            this.cbtfSearchby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbtfSearchby_KeyPress);
            // 
            // txttfSearchbox
            // 
            this.txttfSearchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttfSearchbox.Location = new System.Drawing.Point(527, 13);
            this.txttfSearchbox.Name = "txttfSearchbox";
            this.txttfSearchbox.Size = new System.Drawing.Size(268, 21);
            this.txttfSearchbox.TabIndex = 11;
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTransactions.Location = new System.Drawing.Point(7, 8);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(148, 25);
            this.lblTransactions.TabIndex = 9;
            this.lblTransactions.Text = "Transactions";
            // 
            // dvtfGridView
            // 
            this.dvtfGridView.AllowUserToAddRows = false;
            this.dvtfGridView.AllowUserToDeleteRows = false;
            this.dvtfGridView.AllowUserToResizeColumns = false;
            this.dvtfGridView.AllowUserToResizeRows = false;
            this.dvtfGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvtfGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvtfGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dvtfGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvtfGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltfNumbering,
            this.coltfVisitorName,
            this.coltfBookTitle,
            this.coltfTransaction,
            this.coltfInformation,
            this.coltfAmmountPaid,
            this.coltfDate});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvtfGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvtfGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.dvtfGridView.Location = new System.Drawing.Point(12, 40);
            this.dvtfGridView.MultiSelect = false;
            this.dvtfGridView.Name = "dvtfGridView";
            this.dvtfGridView.ReadOnly = true;
            this.dvtfGridView.RowHeadersVisible = false;
            this.dvtfGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvtfGridView.Size = new System.Drawing.Size(1087, 523);
            this.dvtfGridView.TabIndex = 19;
            // 
            // coltfNumbering
            // 
            this.coltfNumbering.FillWeight = 15F;
            this.coltfNumbering.HeaderText = "#";
            this.coltfNumbering.Name = "coltfNumbering";
            this.coltfNumbering.ReadOnly = true;
            // 
            // coltfVisitorName
            // 
            this.coltfVisitorName.FillWeight = 80F;
            this.coltfVisitorName.HeaderText = "Visitor Name";
            this.coltfVisitorName.Name = "coltfVisitorName";
            this.coltfVisitorName.ReadOnly = true;
            // 
            // coltfBookTitle
            // 
            this.coltfBookTitle.FillWeight = 140F;
            this.coltfBookTitle.HeaderText = "Book Title";
            this.coltfBookTitle.Name = "coltfBookTitle";
            this.coltfBookTitle.ReadOnly = true;
            // 
            // coltfTransaction
            // 
            this.coltfTransaction.FillWeight = 40F;
            this.coltfTransaction.HeaderText = "Transaction";
            this.coltfTransaction.Name = "coltfTransaction";
            this.coltfTransaction.ReadOnly = true;
            // 
            // coltfInformation
            // 
            this.coltfInformation.FillWeight = 40F;
            this.coltfInformation.HeaderText = "Information";
            this.coltfInformation.Name = "coltfInformation";
            this.coltfInformation.ReadOnly = true;
            // 
            // coltfAmmountPaid
            // 
            this.coltfAmmountPaid.FillWeight = 40F;
            this.coltfAmmountPaid.HeaderText = "Ammount Paid";
            this.coltfAmmountPaid.Name = "coltfAmmountPaid";
            this.coltfAmmountPaid.ReadOnly = true;
            // 
            // coltfDate
            // 
            this.coltfDate.FillWeight = 60F;
            this.coltfDate.HeaderText = "Date";
            this.coltfDate.Name = "coltfDate";
            this.coltfDate.ReadOnly = true;
            // 
            // cbtfSearchbyExt
            // 
            this.cbtfSearchbyExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtfSearchbyExt.FormattingEnabled = true;
            this.cbtfSearchbyExt.Location = new System.Drawing.Point(674, 13);
            this.cbtfSearchbyExt.Name = "cbtfSearchbyExt";
            this.cbtfSearchbyExt.Size = new System.Drawing.Size(121, 21);
            this.cbtfSearchbyExt.TabIndex = 20;
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 603);
            this.Controls.Add(this.cbtfSearchbyExt);
            this.Controls.Add(this.btntfReset);
            this.Controls.Add(this.btntfDone);
            this.Controls.Add(this.btntfDeleteTransactions);
            this.Controls.Add(this.btntfSearch);
            this.Controls.Add(this.cbtfSearchby);
            this.Controls.Add(this.txttfSearchbox);
            this.Controls.Add(this.lblTransactions);
            this.Controls.Add(this.dvtfGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransactionsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dvtfGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntfReset;
        private System.Windows.Forms.Button btntfDone;
        private System.Windows.Forms.Button btntfDeleteTransactions;
        private System.Windows.Forms.Button btntfSearch;
        private System.Windows.Forms.ComboBox cbtfSearchby;
        private System.Windows.Forms.TextBox txttfSearchbox;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.DataGridView dvtfGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfNumbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfVisitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfAmmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltfDate;
        private System.Windows.Forms.ComboBox cbtfSearchbyExt;
    }
}