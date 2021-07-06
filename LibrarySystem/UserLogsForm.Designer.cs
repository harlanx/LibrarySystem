namespace LibrarySystem
{
    partial class UserLogsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogsForm));
            this.lblUserLogs = new System.Windows.Forms.Label();
            this.txtulfSearchbox = new System.Windows.Forms.TextBox();
            this.cbulfSearchby = new System.Windows.Forms.ComboBox();
            this.btnulfSearch = new System.Windows.Forms.Button();
            this.btnulfDeleteLogs = new System.Windows.Forms.Button();
            this.btnulfSaveLogs = new System.Windows.Forms.Button();
            this.btnulfDone = new System.Windows.Forms.Button();
            this.btnulfReset = new System.Windows.Forms.Button();
            this.dvulfGridView = new System.Windows.Forms.DataGridView();
            this.coldgvNumbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldgvAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldgvAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldgvInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldgvDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvulfGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserLogs
            // 
            this.lblUserLogs.AutoSize = true;
            this.lblUserLogs.BackColor = System.Drawing.Color.Transparent;
            this.lblUserLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblUserLogs.Location = new System.Drawing.Point(7, 6);
            this.lblUserLogs.Name = "lblUserLogs";
            this.lblUserLogs.Size = new System.Drawing.Size(119, 25);
            this.lblUserLogs.TabIndex = 0;
            this.lblUserLogs.Text = "User Logs";
            // 
            // txtulfSearchbox
            // 
            this.txtulfSearchbox.Location = new System.Drawing.Point(132, 11);
            this.txtulfSearchbox.Name = "txtulfSearchbox";
            this.txtulfSearchbox.Size = new System.Drawing.Size(189, 20);
            this.txtulfSearchbox.TabIndex = 2;
            // 
            // cbulfSearchby
            // 
            this.cbulfSearchby.FormattingEnabled = true;
            this.cbulfSearchby.Items.AddRange(new object[] {
            "Search by Action",
            "Search by User"});
            this.cbulfSearchby.Location = new System.Drawing.Point(325, 11);
            this.cbulfSearchby.Name = "cbulfSearchby";
            this.cbulfSearchby.Size = new System.Drawing.Size(121, 21);
            this.cbulfSearchby.TabIndex = 3;
            // 
            // btnulfSearch
            // 
            this.btnulfSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnulfSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnulfSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnulfSearch.Location = new System.Drawing.Point(450, 11);
            this.btnulfSearch.Name = "btnulfSearch";
            this.btnulfSearch.Size = new System.Drawing.Size(75, 21);
            this.btnulfSearch.TabIndex = 4;
            this.btnulfSearch.Text = "Search";
            this.btnulfSearch.UseVisualStyleBackColor = false;
            this.btnulfSearch.Click += new System.EventHandler(this.btnulfSearch_Click);
            // 
            // btnulfDeleteLogs
            // 
            this.btnulfDeleteLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnulfDeleteLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnulfDeleteLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnulfDeleteLogs.Location = new System.Drawing.Point(12, 427);
            this.btnulfDeleteLogs.Name = "btnulfDeleteLogs";
            this.btnulfDeleteLogs.Size = new System.Drawing.Size(75, 23);
            this.btnulfDeleteLogs.TabIndex = 5;
            this.btnulfDeleteLogs.Text = "Clear Logs";
            this.btnulfDeleteLogs.UseVisualStyleBackColor = false;
            this.btnulfDeleteLogs.Click += new System.EventHandler(this.btnulfDeleteLogs_Click);
            // 
            // btnulfSaveLogs
            // 
            this.btnulfSaveLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnulfSaveLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnulfSaveLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnulfSaveLogs.Location = new System.Drawing.Point(452, 426);
            this.btnulfSaveLogs.Name = "btnulfSaveLogs";
            this.btnulfSaveLogs.Size = new System.Drawing.Size(89, 23);
            this.btnulfSaveLogs.TabIndex = 6;
            this.btnulfSaveLogs.Text = "Save to Text";
            this.btnulfSaveLogs.UseVisualStyleBackColor = false;
            this.btnulfSaveLogs.Click += new System.EventHandler(this.btnulfSaveLogs_Click);
            // 
            // btnulfDone
            // 
            this.btnulfDone.BackColor = System.Drawing.Color.Transparent;
            this.btnulfDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnulfDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnulfDone.Location = new System.Drawing.Point(547, 426);
            this.btnulfDone.Name = "btnulfDone";
            this.btnulfDone.Size = new System.Drawing.Size(75, 23);
            this.btnulfDone.TabIndex = 7;
            this.btnulfDone.Text = "Done";
            this.btnulfDone.UseVisualStyleBackColor = false;
            this.btnulfDone.Click += new System.EventHandler(this.btnulfDone_Click);
            // 
            // btnulfReset
            // 
            this.btnulfReset.BackColor = System.Drawing.Color.Transparent;
            this.btnulfReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnulfReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnulfReset.Location = new System.Drawing.Point(529, 11);
            this.btnulfReset.Name = "btnulfReset";
            this.btnulfReset.Size = new System.Drawing.Size(93, 21);
            this.btnulfReset.TabIndex = 8;
            this.btnulfReset.Text = "Reset Result";
            this.btnulfReset.UseVisualStyleBackColor = false;
            this.btnulfReset.Click += new System.EventHandler(this.btnulfReset_Click);
            // 
            // dvulfGridView
            // 
            this.dvulfGridView.AllowUserToAddRows = false;
            this.dvulfGridView.AllowUserToDeleteRows = false;
            this.dvulfGridView.AllowUserToResizeColumns = false;
            this.dvulfGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvulfGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvulfGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dvulfGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvulfGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvulfGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coldgvNumbering,
            this.coldgvAccountName,
            this.coldgvAction,
            this.coldgvInformation,
            this.coldgvDateTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvulfGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvulfGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.dvulfGridView.Location = new System.Drawing.Point(12, 38);
            this.dvulfGridView.MultiSelect = false;
            this.dvulfGridView.Name = "dvulfGridView";
            this.dvulfGridView.ReadOnly = true;
            this.dvulfGridView.RowHeadersVisible = false;
            this.dvulfGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvulfGridView.Size = new System.Drawing.Size(610, 385);
            this.dvulfGridView.TabIndex = 9;
            // 
            // coldgvNumbering
            // 
            this.coldgvNumbering.FillWeight = 25F;
            this.coldgvNumbering.HeaderText = "#";
            this.coldgvNumbering.Name = "coldgvNumbering";
            this.coldgvNumbering.ReadOnly = true;
            // 
            // coldgvAccountName
            // 
            this.coldgvAccountName.HeaderText = "Account Name";
            this.coldgvAccountName.Name = "coldgvAccountName";
            this.coldgvAccountName.ReadOnly = true;
            // 
            // coldgvAction
            // 
            this.coldgvAction.HeaderText = "Action";
            this.coldgvAction.Name = "coldgvAction";
            this.coldgvAction.ReadOnly = true;
            // 
            // coldgvInformation
            // 
            this.coldgvInformation.HeaderText = "Information";
            this.coldgvInformation.Name = "coldgvInformation";
            this.coldgvInformation.ReadOnly = true;
            // 
            // coldgvDateTime
            // 
            this.coldgvDateTime.HeaderText = "Date and Time";
            this.coldgvDateTime.Name = "coldgvDateTime";
            this.coldgvDateTime.ReadOnly = true;
            // 
            // UserLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 454);
            this.Controls.Add(this.dvulfGridView);
            this.Controls.Add(this.btnulfReset);
            this.Controls.Add(this.btnulfDone);
            this.Controls.Add(this.btnulfSaveLogs);
            this.Controls.Add(this.btnulfDeleteLogs);
            this.Controls.Add(this.btnulfSearch);
            this.Controls.Add(this.cbulfSearchby);
            this.Controls.Add(this.txtulfSearchbox);
            this.Controls.Add(this.lblUserLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserLogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.UserLogsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserLogsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dvulfGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserLogs;
        private System.Windows.Forms.TextBox txtulfSearchbox;
        private System.Windows.Forms.ComboBox cbulfSearchby;
        private System.Windows.Forms.Button btnulfSearch;
        private System.Windows.Forms.Button btnulfDeleteLogs;
        private System.Windows.Forms.Button btnulfSaveLogs;
        private System.Windows.Forms.Button btnulfDone;
        private System.Windows.Forms.Button btnulfReset;
        private System.Windows.Forms.DataGridView dvulfGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldgvNumbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldgvAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldgvAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldgvInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldgvDateTime;
    }
}