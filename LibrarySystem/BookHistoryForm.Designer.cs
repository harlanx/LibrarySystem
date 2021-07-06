namespace LibrarySystem
{
    partial class BookHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookHistoryForm));
            this.lblBookTransactionHistory = new System.Windows.Forms.Label();
            this.dgvbhfHistoryList = new System.Windows.Forms.DataGridView();
            this.history_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblbhfBookTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbhfHistoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookTransactionHistory
            // 
            this.lblBookTransactionHistory.AutoSize = true;
            this.lblBookTransactionHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblBookTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblBookTransactionHistory.Location = new System.Drawing.Point(6, 6);
            this.lblBookTransactionHistory.Name = "lblBookTransactionHistory";
            this.lblBookTransactionHistory.Size = new System.Drawing.Size(277, 25);
            this.lblBookTransactionHistory.TabIndex = 0;
            this.lblBookTransactionHistory.Text = "Book Transaction History";
            // 
            // dgvbhfHistoryList
            // 
            this.dgvbhfHistoryList.AllowUserToAddRows = false;
            this.dgvbhfHistoryList.AllowUserToDeleteRows = false;
            this.dgvbhfHistoryList.AllowUserToResizeColumns = false;
            this.dgvbhfHistoryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbhfHistoryList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvbhfHistoryList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvbhfHistoryList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvbhfHistoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbhfHistoryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.history_id,
            this.client_name,
            this.status,
            this.information,
            this.date});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbhfHistoryList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbhfHistoryList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvbhfHistoryList.Location = new System.Drawing.Point(12, 34);
            this.dgvbhfHistoryList.MultiSelect = false;
            this.dgvbhfHistoryList.Name = "dgvbhfHistoryList";
            this.dgvbhfHistoryList.ReadOnly = true;
            this.dgvbhfHistoryList.RowHeadersVisible = false;
            this.dgvbhfHistoryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbhfHistoryList.Size = new System.Drawing.Size(636, 355);
            this.dgvbhfHistoryList.TabIndex = 1;
            // 
            // history_id
            // 
            this.history_id.HeaderText = "ID";
            this.history_id.Name = "history_id";
            this.history_id.ReadOnly = true;
            this.history_id.Visible = false;
            // 
            // client_name
            // 
            this.client_name.FillWeight = 120F;
            this.client_name.HeaderText = "Client Name";
            this.client_name.Name = "client_name";
            this.client_name.ReadOnly = true;
            // 
            // status
            // 
            this.status.FillWeight = 30F;
            this.status.HeaderText = "Transaction";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // information
            // 
            this.information.FillWeight = 30F;
            this.information.HeaderText = "Information";
            this.information.Name = "information";
            this.information.ReadOnly = true;
            // 
            // date
            // 
            this.date.FillWeight = 80F;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // lblbhfBookTitle
            // 
            this.lblbhfBookTitle.AutoEllipsis = true;
            this.lblbhfBookTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblbhfBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbhfBookTitle.Location = new System.Drawing.Point(290, 9);
            this.lblbhfBookTitle.Name = "lblbhfBookTitle";
            this.lblbhfBookTitle.Size = new System.Drawing.Size(358, 15);
            this.lblbhfBookTitle.TabIndex = 2;
            this.lblbhfBookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BookHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 401);
            this.Controls.Add(this.lblbhfBookTitle);
            this.Controls.Add(this.dgvbhfHistoryList);
            this.Controls.Add(this.lblBookTransactionHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.BookHistoryFormcs_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BookHistoryFormcs_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbhfHistoryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookTransactionHistory;
        private System.Windows.Forms.DataGridView dgvbhfHistoryList;
        private System.Windows.Forms.Label lblbhfBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn history_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn information;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
    }
}