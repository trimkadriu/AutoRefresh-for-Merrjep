namespace Auto_Refresh_for_MerrJep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrlOfPost = new System.Windows.Forms.TextBox();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgwList = new System.Windows.Forms.DataGridView();
            this.UrlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveUrl = new System.Windows.Forms.Button();
            this.btnServerUrlConf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL of post:";
            // 
            // txtUrlOfPost
            // 
            this.txtUrlOfPost.Location = new System.Drawing.Point(78, 14);
            this.txtUrlOfPost.MaxLength = 1024;
            this.txtUrlOfPost.Name = "txtUrlOfPost";
            this.txtUrlOfPost.Size = new System.Drawing.Size(321, 20);
            this.txtUrlOfPost.TabIndex = 1;
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.Location = new System.Drawing.Point(405, 12);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(81, 23);
            this.btnAddUrl.TabIndex = 3;
            this.btnAddUrl.Text = "Add in list";
            this.btnAddUrl.UseVisualStyleBackColor = true;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(428, 227);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(169, 47);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgwList
            // 
            this.dgwList.AllowUserToAddRows = false;
            this.dgwList.AllowUserToDeleteRows = false;
            this.dgwList.AllowUserToResizeColumns = false;
            this.dgwList.AllowUserToResizeRows = false;
            this.dgwList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UrlColumn,
            this.StatusColumn});
            this.dgwList.Location = new System.Drawing.Point(15, 41);
            this.dgwList.Name = "dgwList";
            this.dgwList.ReadOnly = true;
            this.dgwList.RowHeadersVisible = false;
            this.dgwList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwList.Size = new System.Drawing.Size(582, 177);
            this.dgwList.TabIndex = 5;
            // 
            // UrlColumn
            // 
            this.UrlColumn.HeaderText = "URL of Post";
            this.UrlColumn.Name = "UrlColumn";
            this.UrlColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(127, 228);
            this.txtPassword.MaxLength = 64;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(182, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password of the post:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time for Auto Refresh:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(127, 254);
            this.txtTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.txtTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(147, 20);
            this.txtTime.TabIndex = 7;
            this.txtTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "(min)";
            // 
            // btnRemoveUrl
            // 
            this.btnRemoveUrl.Location = new System.Drawing.Point(492, 12);
            this.btnRemoveUrl.Name = "btnRemoveUrl";
            this.btnRemoveUrl.Size = new System.Drawing.Size(105, 23);
            this.btnRemoveUrl.TabIndex = 11;
            this.btnRemoveUrl.Text = "Remove Selected";
            this.btnRemoveUrl.UseVisualStyleBackColor = true;
            this.btnRemoveUrl.Click += new System.EventHandler(this.btnRemoveUrl_Click);
            // 
            // btnServerUrlConf
            // 
            this.btnServerUrlConf.Location = new System.Drawing.Point(315, 227);
            this.btnServerUrlConf.Name = "btnServerUrlConf";
            this.btnServerUrlConf.Size = new System.Drawing.Size(107, 47);
            this.btnServerUrlConf.TabIndex = 13;
            this.btnServerUrlConf.Text = "API Server URL\r\n[ configure ]";
            this.btnServerUrlConf.UseVisualStyleBackColor = true;
            this.btnServerUrlConf.Click += new System.EventHandler(this.btnServerUrlConf_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 290);
            this.Controls.Add(this.btnServerUrlConf);
            this.Controls.Add(this.btnRemoveUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgwList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAddUrl);
            this.Controls.Add(this.txtUrlOfPost);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoRefresh for MerrJep.com © 2014 by Trim Kadriu";
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrlOfPost;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgwList;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveUrl;
        private System.Windows.Forms.Button btnServerUrlConf;
    }
}

