namespace SqlToCode
{
    partial class MainForm
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
            this.lblConnect = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.lblPreview = new System.Windows.Forms.Label();
            this.tbPreview = new System.Windows.Forms.RichTextBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbClassname = new System.Windows.Forms.TextBox();
            this.lblClassname = new System.Windows.Forms.Label();
            this.chNormalizeColumnNames = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSqlQuery = new System.Windows.Forms.RichTextBox();
            this.lblSqlQuery = new System.Windows.Forms.Label();
            this.lblFileNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(7, 15);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(47, 13);
            this.lblConnect.TabIndex = 0;
            this.lblConnect.Text = "Connect";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnectionString.Location = new System.Drawing.Point(66, 12);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(641, 20);
            this.tbConnectionString.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(713, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(66, 38);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(641, 20);
            this.tbOutput.TabIndex = 4;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(7, 41);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "Output";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(713, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCode.Location = new System.Drawing.Point(567, 65);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(221, 23);
            this.btnGenerateCode.TabIndex = 6;
            this.btnGenerateCode.Text = "&Generate C# Class";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(7, 4);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(45, 13);
            this.lblPreview.TabIndex = 7;
            this.lblPreview.Text = "Preview";
            // 
            // tbPreview
            // 
            this.tbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPreview.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbPreview.Location = new System.Drawing.Point(3, 21);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(792, 199);
            this.tbPreview.TabIndex = 8;
            this.tbPreview.Text = "";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.BackColor = System.Drawing.Color.Yellow;
            this.lblWait.Location = new System.Drawing.Point(9, 432);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(0, 13);
            this.lblWait.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbClassname);
            this.splitContainer1.Panel1.Controls.Add(this.lblClassname);
            this.splitContainer1.Panel1.Controls.Add(this.chNormalizeColumnNames);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbSqlQuery);
            this.splitContainer1.Panel1.Controls.Add(this.lblSqlQuery);
            this.splitContainer1.Panel1.Controls.Add(this.tbConnectionString);
            this.splitContainer1.Panel1.Controls.Add(this.lblConnect);
            this.splitContainer1.Panel1.Controls.Add(this.btnConnect);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerateCode);
            this.splitContainer1.Panel1.Controls.Add(this.lblOutput);
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.tbOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblFileNote);
            this.splitContainer1.Panel2.Controls.Add(this.tbPreview);
            this.splitContainer1.Panel2.Controls.Add(this.lblPreview);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 10;
            // 
            // tbClassname
            // 
            this.tbClassname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClassname.Location = new System.Drawing.Point(66, 66);
            this.tbClassname.Name = "tbClassname";
            this.tbClassname.Size = new System.Drawing.Size(345, 20);
            this.tbClassname.TabIndex = 14;
            // 
            // lblClassname
            // 
            this.lblClassname.AutoSize = true;
            this.lblClassname.Location = new System.Drawing.Point(7, 69);
            this.lblClassname.Name = "lblClassname";
            this.lblClassname.Size = new System.Drawing.Size(58, 13);
            this.lblClassname.TabIndex = 13;
            this.lblClassname.Text = "Classname";
            // 
            // chNormalizeColumnNames
            // 
            this.chNormalizeColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chNormalizeColumnNames.AutoSize = true;
            this.chNormalizeColumnNames.Checked = true;
            this.chNormalizeColumnNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chNormalizeColumnNames.Location = new System.Drawing.Point(415, 69);
            this.chNormalizeColumnNames.Name = "chNormalizeColumnNames";
            this.chNormalizeColumnNames.Size = new System.Drawing.Size(146, 17);
            this.chNormalizeColumnNames.TabIndex = 12;
            this.chNormalizeColumnNames.Text = "&Normalize Column Names";
            this.chNormalizeColumnNames.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(63, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "(any used script will affect your data, do not use insert, delete or update unles" +
    "s you want it to happens)";
            // 
            // tbSqlQuery
            // 
            this.tbSqlQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSqlQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbSqlQuery.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbSqlQuery.Location = new System.Drawing.Point(0, 123);
            this.tbSqlQuery.Name = "tbSqlQuery";
            this.tbSqlQuery.Size = new System.Drawing.Size(797, 100);
            this.tbSqlQuery.TabIndex = 10;
            this.tbSqlQuery.Text = "";
            // 
            // lblSqlQuery
            // 
            this.lblSqlQuery.AutoSize = true;
            this.lblSqlQuery.Location = new System.Drawing.Point(7, 107);
            this.lblSqlQuery.Name = "lblSqlQuery";
            this.lblSqlQuery.Size = new System.Drawing.Size(59, 13);
            this.lblSqlQuery.TabIndex = 9;
            this.lblSqlQuery.Text = "SQL Query";
            // 
            // lblFileNote
            // 
            this.lblFileNote.AutoSize = true;
            this.lblFileNote.ForeColor = System.Drawing.Color.Green;
            this.lblFileNote.Location = new System.Drawing.Point(58, 4);
            this.lblFileNote.Name = "lblFileNote";
            this.lblFileNote.Size = new System.Drawing.Size(0, 13);
            this.lblFileNote.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::SqlToCode.Properties.Resources.sqlicon;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "SQL to Code";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.RichTextBox tbPreview;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox tbSqlQuery;
        private System.Windows.Forms.Label lblSqlQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chNormalizeColumnNames;
        private System.Windows.Forms.Label lblClassname;
        private System.Windows.Forms.TextBox tbClassname;
        private System.Windows.Forms.Label lblFileNote;
    }
}

