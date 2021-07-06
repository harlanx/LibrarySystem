namespace LibrarySystem
{
    partial class ClientsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.btncfReset = new System.Windows.Forms.Button();
            this.btncfDone = new System.Windows.Forms.Button();
            this.btncfSearch = new System.Windows.Forms.Button();
            this.cbcfSearchby = new System.Windows.Forms.ComboBox();
            this.txtcfSearchbox = new System.Windows.Forms.TextBox();
            this.lblClientList = new System.Windows.Forms.Label();
            this.dgvcfClientList = new System.Windows.Forms.DataGridView();
            this.colvfdvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvfdvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvfdvContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvfdvAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvfdvDateRegistered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvfdvDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcfClientList)).BeginInit();
            this.SuspendLayout();
            // 
            // btncfReset
            // 
            this.btncfReset.BackColor = System.Drawing.Color.Transparent;
            this.btncfReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncfReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncfReset.Location = new System.Drawing.Point(1008, 13);
            this.btncfReset.Name = "btncfReset";
            this.btncfReset.Size = new System.Drawing.Size(93, 21);
            this.btncfReset.TabIndex = 27;
            this.btncfReset.Text = "Reset Result";
            this.btncfReset.UseVisualStyleBackColor = false;
            this.btncfReset.Click += new System.EventHandler(this.btncfReset_Click);
            // 
            // btncfDone
            // 
            this.btncfDone.BackColor = System.Drawing.Color.Transparent;
            this.btncfDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncfDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncfDone.Location = new System.Drawing.Point(1026, 571);
            this.btncfDone.Name = "btncfDone";
            this.btncfDone.Size = new System.Drawing.Size(75, 23);
            this.btncfDone.TabIndex = 26;
            this.btncfDone.Text = "Done";
            this.btncfDone.UseVisualStyleBackColor = false;
            this.btncfDone.Click += new System.EventHandler(this.btncfDone_Click);
            // 
            // btncfSearch
            // 
            this.btncfSearch.BackColor = System.Drawing.Color.Transparent;
            this.btncfSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncfSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncfSearch.Location = new System.Drawing.Point(929, 13);
            this.btncfSearch.Name = "btncfSearch";
            this.btncfSearch.Size = new System.Drawing.Size(75, 21);
            this.btncfSearch.TabIndex = 23;
            this.btncfSearch.Text = "Search";
            this.btncfSearch.UseVisualStyleBackColor = false;
            this.btncfSearch.Click += new System.EventHandler(this.btncfSearch_Click);
            // 
            // cbcfSearchby
            // 
            this.cbcfSearchby.FormattingEnabled = true;
            this.cbcfSearchby.Items.AddRange(new object[] {
            "Search by ID No.",
            "Search by Name"});
            this.cbcfSearchby.Location = new System.Drawing.Point(804, 13);
            this.cbcfSearchby.Name = "cbcfSearchby";
            this.cbcfSearchby.Size = new System.Drawing.Size(121, 21);
            this.cbcfSearchby.TabIndex = 22;
            this.cbcfSearchby.SelectedIndexChanged += new System.EventHandler(this.cbcfSearchby_SelectedIndexChanged);
            this.cbcfSearchby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbcfSearchby_KeyPress);
            // 
            // txtcfSearchbox
            // 
            this.txtcfSearchbox.ForeColor = System.Drawing.Color.DarkGray;
            this.txtcfSearchbox.Location = new System.Drawing.Point(532, 13);
            this.txtcfSearchbox.Name = "txtcfSearchbox";
            this.txtcfSearchbox.Size = new System.Drawing.Size(268, 20);
            this.txtcfSearchbox.TabIndex = 21;
            this.txtcfSearchbox.Text = "Type In Client Information";
            this.txtcfSearchbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcfSearchbox.TextChanged += new System.EventHandler(this.txtcfSearchbox_TextChanged);
            this.txtcfSearchbox.Enter += new System.EventHandler(this.txtcfSearchbox_Enter);
            this.txtcfSearchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcfSearchbox_KeyPress);
            this.txtcfSearchbox.Leave += new System.EventHandler(this.txtcfSearchbox_Leave);
            // 
            // lblClientList
            // 
            this.lblClientList.AutoSize = true;
            this.lblClientList.BackColor = System.Drawing.Color.Transparent;
            this.lblClientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblClientList.Location = new System.Drawing.Point(12, 8);
            this.lblClientList.Name = "lblClientList";
            this.lblClientList.Size = new System.Drawing.Size(118, 25);
            this.lblClientList.TabIndex = 19;
            this.lblClientList.Text = "Client List";
            // 
            // dgvcfClientList
            // 
            this.dgvcfClientList.AllowUserToAddRows = false;
            this.dgvcfClientList.AllowUserToDeleteRows = false;
            this.dgvcfClientList.AllowUserToResizeColumns = false;
            this.dgvcfClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcfClientList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvcfClientList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvcfClientList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvcfClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcfClientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colvfdvID,
            this.colvfdvName,
            this.colvfdvContactNumber,
            this.colvfdvAddress,
            this.colvfdvDateRegistered,
            this.colvfdvDateModified});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcfClientList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcfClientList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvcfClientList.Location = new System.Drawing.Point(12, 40);
            this.dgvcfClientList.MultiSelect = false;
            this.dgvcfClientList.Name = "dgvcfClientList";
            this.dgvcfClientList.ReadOnly = true;
            this.dgvcfClientList.RowHeadersVisible = false;
            this.dgvcfClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcfClientList.Size = new System.Drawing.Size(1089, 523);
            this.dgvcfClientList.TabIndex = 28;
            this.dgvcfClientList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcfClientList_CellDoubleClick);
            // 
            // colvfdvID
            // 
            this.colvfdvID.FillWeight = 15F;
            this.colvfdvID.HeaderText = "ID";
            this.colvfdvID.Name = "colvfdvID";
            this.colvfdvID.ReadOnly = true;
            // 
            // colvfdvName
            // 
            this.colvfdvName.HeaderText = "Name";
            this.colvfdvName.Name = "colvfdvName";
            this.colvfdvName.ReadOnly = true;
            // 
            // colvfdvContactNumber
            // 
            this.colvfdvContactNumber.FillWeight = 60F;
            this.colvfdvContactNumber.HeaderText = "Contact Number";
            this.colvfdvContactNumber.Name = "colvfdvContactNumber";
            this.colvfdvContactNumber.ReadOnly = true;
            // 
            // colvfdvAddress
            // 
            this.colvfdvAddress.FillWeight = 170F;
            this.colvfdvAddress.HeaderText = "Address";
            this.colvfdvAddress.Name = "colvfdvAddress";
            this.colvfdvAddress.ReadOnly = true;
            // 
            // colvfdvDateRegistered
            // 
            this.colvfdvDateRegistered.FillWeight = 70F;
            this.colvfdvDateRegistered.HeaderText = "Date Registered";
            this.colvfdvDateRegistered.Name = "colvfdvDateRegistered";
            this.colvfdvDateRegistered.ReadOnly = true;
            // 
            // colvfdvDateModified
            // 
            this.colvfdvDateModified.FillWeight = 70F;
            this.colvfdvDateModified.HeaderText = "Date Modified";
            this.colvfdvDateModified.Name = "colvfdvDateModified";
            this.colvfdvDateModified.ReadOnly = true;
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 603);
            this.Controls.Add(this.dgvcfClientList);
            this.Controls.Add(this.btncfReset);
            this.Controls.Add(this.btncfDone);
            this.Controls.Add(this.btncfSearch);
            this.Controls.Add(this.cbcfSearchby);
            this.Controls.Add(this.txtcfSearchbox);
            this.Controls.Add(this.lblClientList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClientsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcfClientList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btncfReset;
        private System.Windows.Forms.Button btncfDone;
        private System.Windows.Forms.Button btncfSearch;
        private System.Windows.Forms.ComboBox cbcfSearchby;
        private System.Windows.Forms.TextBox txtcfSearchbox;
        private System.Windows.Forms.Label lblClientList;
        private System.Windows.Forms.DataGridView dgvcfClientList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvDateRegistered;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvfdvDateModified;
    }
}