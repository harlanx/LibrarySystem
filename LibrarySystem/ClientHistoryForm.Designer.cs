namespace LibrarySystem
{
    partial class ClientHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientHistoryForm));
            this.lblClientTransactionHistory = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.dgvchfHistoryList = new System.Windows.Forms.DataGridView();
            this.access_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvchfHistoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientTransactionHistory
            // 
            this.lblClientTransactionHistory.AutoSize = true;
            this.lblClientTransactionHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblClientTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientTransactionHistory.Location = new System.Drawing.Point(6, 6);
            this.lblClientTransactionHistory.Name = "lblClientTransactionHistory";
            this.lblClientTransactionHistory.Size = new System.Drawing.Size(285, 25);
            this.lblClientTransactionHistory.TabIndex = 0;
            this.lblClientTransactionHistory.Text = "Client Transaction History";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoEllipsis = true;
            this.lblClientName.BackColor = System.Drawing.Color.Transparent;
            this.lblClientName.Location = new System.Drawing.Point(290, 9);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(358, 15);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvchfHistoryList
            // 
            this.dgvchfHistoryList.AllowUserToAddRows = false;
            this.dgvchfHistoryList.AllowUserToDeleteRows = false;
            this.dgvchfHistoryList.AllowUserToResizeColumns = false;
            this.dgvchfHistoryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvchfHistoryList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvchfHistoryList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvchfHistoryList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvchfHistoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvchfHistoryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.access_num,
            this.book_title,
            this.transaction,
            this.due_date});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvchfHistoryList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvchfHistoryList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvchfHistoryList.Location = new System.Drawing.Point(12, 34);
            this.dgvchfHistoryList.MultiSelect = false;
            this.dgvchfHistoryList.Name = "dgvchfHistoryList";
            this.dgvchfHistoryList.ReadOnly = true;
            this.dgvchfHistoryList.RowHeadersVisible = false;
            this.dgvchfHistoryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvchfHistoryList.Size = new System.Drawing.Size(636, 355);
            this.dgvchfHistoryList.TabIndex = 2;
            // 
            // access_num
            // 
            this.access_num.FillWeight = 15.92543F;
            this.access_num.HeaderText = "Access No.";
            this.access_num.Name = "access_num";
            this.access_num.ReadOnly = true;
            // 
            // book_title
            // 
            this.book_title.FillWeight = 55.56148F;
            this.book_title.HeaderText = "Book Title";
            this.book_title.Name = "book_title";
            this.book_title.ReadOnly = true;
            // 
            // transaction
            // 
            this.transaction.FillWeight = 13.89037F;
            this.transaction.HeaderText = "Transaction";
            this.transaction.Name = "transaction";
            this.transaction.ReadOnly = true;
            // 
            // due_date
            // 
            this.due_date.FillWeight = 26.66951F;
            this.due_date.HeaderText = "Due Date";
            this.due_date.Name = "due_date";
            this.due_date.ReadOnly = true;
            // 
            // ClientHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 401);
            this.Controls.Add(this.dgvchfHistoryList);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.lblClientTransactionHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.ClientHistoryForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClientHistoryForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvchfHistoryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientTransactionHistory;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.DataGridView dgvchfHistoryList;
        private System.Windows.Forms.DataGridViewTextBoxColumn access_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn due_date;
    }
}