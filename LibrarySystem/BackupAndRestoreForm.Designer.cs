namespace LibrarySystem
{
    partial class BackupAndRestoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupAndRestoreForm));
            this.lblBackup = new System.Windows.Forms.Label();
            this.lblRestore = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.btnCreateDatabaseBackup = new System.Windows.Forms.Button();
            this.btnRestoreDatabase = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBackup
            // 
            this.lblBackup.AutoSize = true;
            this.lblBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackup.Location = new System.Drawing.Point(95, 9);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(90, 25);
            this.lblBackup.TabIndex = 0;
            this.lblBackup.Text = "Backup";
            this.lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestore
            // 
            this.lblRestore.AutoSize = true;
            this.lblRestore.BackColor = System.Drawing.Color.Transparent;
            this.lblRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestore.Location = new System.Drawing.Point(95, 94);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(94, 25);
            this.lblRestore.TabIndex = 1;
            this.lblRestore.Text = "Restore";
            this.lblRestore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(12, 37);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(173, 20);
            this.txtDestination.TabIndex = 2;
            // 
            // btnDestination
            // 
            this.btnDestination.BackColor = System.Drawing.Color.Transparent;
            this.btnDestination.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestination.Location = new System.Drawing.Point(193, 37);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(75, 21);
            this.btnDestination.TabIndex = 3;
            this.btnDestination.Text = "Destination";
            this.btnDestination.UseVisualStyleBackColor = false;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // btnCreateDatabaseBackup
            // 
            this.btnCreateDatabaseBackup.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateDatabaseBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateDatabaseBackup.Location = new System.Drawing.Point(12, 61);
            this.btnCreateDatabaseBackup.Name = "btnCreateDatabaseBackup";
            this.btnCreateDatabaseBackup.Size = new System.Drawing.Size(256, 23);
            this.btnCreateDatabaseBackup.TabIndex = 4;
            this.btnCreateDatabaseBackup.Text = "Create Database Backup";
            this.btnCreateDatabaseBackup.UseVisualStyleBackColor = false;
            this.btnCreateDatabaseBackup.Click += new System.EventHandler(this.btnCreateDatabaseBackup_Click);
            // 
            // btnRestoreDatabase
            // 
            this.btnRestoreDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnRestoreDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestoreDatabase.Location = new System.Drawing.Point(12, 147);
            this.btnRestoreDatabase.Name = "btnRestoreDatabase";
            this.btnRestoreDatabase.Size = new System.Drawing.Size(256, 23);
            this.btnRestoreDatabase.TabIndex = 7;
            this.btnRestoreDatabase.Text = "Restore Database";
            this.btnRestoreDatabase.UseVisualStyleBackColor = false;
            this.btnRestoreDatabase.Click += new System.EventHandler(this.btnRestoreDatabase_Click);
            // 
            // btnSource
            // 
            this.btnSource.BackColor = System.Drawing.Color.Transparent;
            this.btnSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.Location = new System.Drawing.Point(193, 123);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(75, 21);
            this.btnSource.TabIndex = 6;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = false;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Enabled = false;
            this.txtSource.Location = new System.Drawing.Point(12, 123);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(173, 20);
            this.txtSource.TabIndex = 5;
            // 
            // BackupAndRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 188);
            this.Controls.Add(this.btnRestoreDatabase);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.btnCreateDatabaseBackup);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.lblRestore);
            this.Controls.Add(this.lblBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupAndRestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Jose City Library";
            this.Load += new System.EventHandler(this.BackupAndRestoreForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BackupAndRestoreForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.Label lblRestore;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Button btnCreateDatabaseBackup;
        private System.Windows.Forms.Button btnRestoreDatabase;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.TextBox txtSource;
    }
}