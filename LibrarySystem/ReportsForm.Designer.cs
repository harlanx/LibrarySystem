namespace LibrarySystem
{
    partial class ReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.BooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportDataSource = new LibrarySystem.reportDataSource();
            this.btnrfLoad = new System.Windows.Forms.Button();
            this.cbrfReportType = new System.Windows.Forms.ComboBox();
            this.btnrfDone = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.BooksTableAdapter = new LibrarySystem.reportDataSourceTableAdapters.BooksTableAdapter();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.BooksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BooksBindingSource
            // 
            this.BooksBindingSource.DataMember = "Books";
            this.BooksBindingSource.DataSource = this.reportDataSource;
            // 
            // reportDataSource
            // 
            this.reportDataSource.DataSetName = "reportDataSource";
            this.reportDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnrfLoad
            // 
            this.btnrfLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrfLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnrfLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrfLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnrfLoad.Location = new System.Drawing.Point(496, 7);
            this.btnrfLoad.Name = "btnrfLoad";
            this.btnrfLoad.Size = new System.Drawing.Size(75, 23);
            this.btnrfLoad.TabIndex = 1;
            this.btnrfLoad.Text = "Load";
            this.btnrfLoad.UseVisualStyleBackColor = false;
            this.btnrfLoad.Click += new System.EventHandler(this.btnrfLoad_Click);
            // 
            // cbrfReportType
            // 
            this.cbrfReportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbrfReportType.FormattingEnabled = true;
            this.cbrfReportType.Items.AddRange(new object[] {
            "Books",
            "Books(Count)",
            "Clients",
            "Transactions"});
            this.cbrfReportType.Location = new System.Drawing.Point(386, 7);
            this.cbrfReportType.Name = "cbrfReportType";
            this.cbrfReportType.Size = new System.Drawing.Size(104, 21);
            this.cbrfReportType.TabIndex = 2;
            this.cbrfReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbrfReportType_KeyPress);
            // 
            // btnrfDone
            // 
            this.btnrfDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrfDone.BackColor = System.Drawing.Color.Transparent;
            this.btnrfDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrfDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnrfDone.Location = new System.Drawing.Point(578, 7);
            this.btnrfDone.Name = "btnrfDone";
            this.btnrfDone.Size = new System.Drawing.Size(75, 23);
            this.btnrfDone.TabIndex = 3;
            this.btnrfDone.Text = "Done";
            this.btnrfDone.UseVisualStyleBackColor = false;
            this.btnrfDone.Click += new System.EventHandler(this.btnrfDone_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.BackColor = System.Drawing.Color.Transparent;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblReports.Location = new System.Drawing.Point(4, 5);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(94, 25);
            this.lblReports.TabIndex = 4;
            this.lblReports.Text = "Reports";
            // 
            // BooksTableAdapter
            // 
            this.BooksTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.BackColor = System.Drawing.SystemColors.Window;
            this.reportViewer.Location = new System.Drawing.Point(9, 36);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(644, 436);
            this.reportViewer.TabIndex = 5;
            // 
            // ReportsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(662, 484);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.btnrfDone);
            this.Controls.Add(this.cbrfReportType);
            this.Controls.Add(this.btnrfLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ReportsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.BooksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnrfLoad;
        private System.Windows.Forms.ComboBox cbrfReportType;
        private System.Windows.Forms.Button btnrfDone;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.BindingSource BooksBindingSource;
        private reportDataSource reportDataSource;
        private reportDataSourceTableAdapters.BooksTableAdapter BooksTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}