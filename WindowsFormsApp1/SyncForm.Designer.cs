namespace WindowsFormsApp1
{
    partial class SyncForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStripProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MenuListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DuplicateListBox = new System.Windows.Forms.ListBox();
            this.File1Textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DuplicagteMoveButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NotFoundListBox = new System.Windows.Forms.ListBox();
            this.AllNotFoundDeleteButton = new System.Windows.Forms.Button();
            this.NotFoundDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStripProgressBar1);
            this.splitContainer2.Panel1.Controls.Add(this.toolStripStatusLabel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1008, 641);
            this.splitContainer2.SplitterDistance = 62;
            this.splitContainer2.TabIndex = 3;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(3, 6);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(1002, 23);
            this.toolStripProgressBar1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = true;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(12, 32);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 19);
            this.toolStripStatusLabel1.TabIndex = 0;
            this.toolStripStatusLabel1.Text = "同期実行中";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MenuListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 575);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 1;
            // 
            // MenuListBox
            // 
            this.MenuListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuListBox.FormattingEnabled = true;
            this.MenuListBox.ItemHeight = 12;
            this.MenuListBox.Items.AddRange(new object[] {
            "同期結果",
            "同一ファイル",
            "ファイルが存在しない本"});
            this.MenuListBox.Location = new System.Drawing.Point(0, 0);
            this.MenuListBox.Name = "MenuListBox";
            this.MenuListBox.Size = new System.Drawing.Size(160, 575);
            this.MenuListBox.TabIndex = 0;
            this.MenuListBox.SelectedIndexChanged += new System.EventHandler(this.MenuListBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DuplicateListBox);
            this.groupBox2.Controls.Add(this.File1Textbox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DuplicagteMoveButton);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(20, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 318);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "同一ファイル";
            this.groupBox2.Visible = false;
            // 
            // DuplicateListBox
            // 
            this.DuplicateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DuplicateListBox.FormattingEnabled = true;
            this.DuplicateListBox.ItemHeight = 12;
            this.DuplicateListBox.Location = new System.Drawing.Point(6, 54);
            this.DuplicateListBox.Name = "DuplicateListBox";
            this.DuplicateListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DuplicateListBox.Size = new System.Drawing.Size(773, 52);
            this.DuplicateListBox.TabIndex = 0;
            this.DuplicateListBox.SelectedIndexChanged += new System.EventHandler(this.DuplicateListBox_SelectedIndexChanged);
            // 
            // File1Textbox
            // 
            this.File1Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.File1Textbox.Location = new System.Drawing.Point(87, 112);
            this.File1Textbox.Name = "File1Textbox";
            this.File1Textbox.ReadOnly = true;
            this.File1Textbox.Size = new System.Drawing.Size(244, 19);
            this.File1Textbox.TabIndex = 6;
            this.File1Textbox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "同じファイルが既に登録されています。";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "登録済ファイル";
            // 
            // DuplicagteMoveButton
            // 
            this.DuplicagteMoveButton.Location = new System.Drawing.Point(8, 30);
            this.DuplicagteMoveButton.Name = "DuplicagteMoveButton";
            this.DuplicagteMoveButton.Size = new System.Drawing.Size(137, 23);
            this.DuplicagteMoveButton.TabIndex = 2;
            this.DuplicagteMoveButton.Text = "同一ファイルを移動";
            this.DuplicagteMoveButton.UseVisualStyleBackColor = true;
            this.DuplicagteMoveButton.Click += new System.EventHandler(this.DuplicateMoveButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(621, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 200);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(398, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "同期結果";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 73);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ResultTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 47);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "同期結果";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTextBox.Location = new System.Drawing.Point(3, 3);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(634, 41);
            this.ResultTextBox.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ErrorTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(640, 47);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "エラー";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTextBox.Location = new System.Drawing.Point(3, 3);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorTextBox.Size = new System.Drawing.Size(634, 41);
            this.ErrorTextBox.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NotFoundListBox);
            this.groupBox3.Controls.Add(this.AllNotFoundDeleteButton);
            this.groupBox3.Controls.Add(this.NotFoundDeleteButton);
            this.groupBox3.Location = new System.Drawing.Point(14, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(644, 159);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ファイルが存在しない本";
            this.groupBox3.Visible = false;
            // 
            // NotFoundListBox
            // 
            this.NotFoundListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotFoundListBox.FormattingEnabled = true;
            this.NotFoundListBox.ItemHeight = 12;
            this.NotFoundListBox.Location = new System.Drawing.Point(6, 47);
            this.NotFoundListBox.Name = "NotFoundListBox";
            this.NotFoundListBox.Size = new System.Drawing.Size(632, 88);
            this.NotFoundListBox.TabIndex = 0;
            this.NotFoundListBox.SelectedIndexChanged += new System.EventHandler(this.NotFoundListBox_SelectedIndexChanged);
            // 
            // AllNotFoundDeleteButton
            // 
            this.AllNotFoundDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AllNotFoundDeleteButton.Location = new System.Drawing.Point(563, 18);
            this.AllNotFoundDeleteButton.Name = "AllNotFoundDeleteButton";
            this.AllNotFoundDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.AllNotFoundDeleteButton.TabIndex = 2;
            this.AllNotFoundDeleteButton.Text = "すべて削除";
            this.AllNotFoundDeleteButton.UseVisualStyleBackColor = true;
            this.AllNotFoundDeleteButton.Click += new System.EventHandler(this.AllNotFoundDeleteButton_Click);
            // 
            // NotFoundDeleteButton
            // 
            this.NotFoundDeleteButton.Location = new System.Drawing.Point(6, 18);
            this.NotFoundDeleteButton.Name = "NotFoundDeleteButton";
            this.NotFoundDeleteButton.Size = new System.Drawing.Size(121, 23);
            this.NotFoundDeleteButton.TabIndex = 1;
            this.NotFoundDeleteButton.Text = "選択した本を削除";
            this.NotFoundDeleteButton.UseVisualStyleBackColor = true;
            this.NotFoundDeleteButton.Click += new System.EventHandler(this.NotFoundDeleteButton_Click);
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.splitContainer2);
            this.Name = "SyncForm";
            this.Text = "よむこ[同期]";
            this.Load += new System.EventHandler(this.SyncForm_Load);
            this.Shown += new System.EventHandler(this.SyncForm_Shown);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox MenuListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox DuplicateListBox;
        private System.Windows.Forms.TextBox File1Textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DuplicagteMoveButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox NotFoundListBox;
        private System.Windows.Forms.Button AllNotFoundDeleteButton;
        private System.Windows.Forms.Button NotFoundDeleteButton;
    }
}

