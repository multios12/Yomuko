namespace ComicLaunch.Form
{
    partial class SelectForm : System.Windows.Forms.Form
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
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SelectListView = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsBookList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddButton = new System.Windows.Forms.Button();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.CreateButton = new System.Windows.Forms.Button();
            this.cmsBookList.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectListView
            // 
            this.SelectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.SelectListView.ContextMenuStrip = this.cmsBookList;
            this.SelectListView.FullRowSelect = true;
            this.SelectListView.GridLines = true;
            this.SelectListView.Location = new System.Drawing.Point(18, 13);
            this.SelectListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectListView.Name = "SelectListView";
            this.SelectListView.Size = new System.Drawing.Size(938, 484);
            this.SelectListView.TabIndex = 0;
            this.SelectListView.UseCompatibleStateImageBehavior = false;
            this.SelectListView.View = System.Windows.Forms.View.Details;
            this.SelectListView.DoubleClick += new System.EventHandler(this.SelectListView_DoubleClick);
            this.SelectListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectListView_KeyDown);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "本棚";
            this.ColumnHeader1.Width = 326;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "ファイル";
            this.ColumnHeader2.Width = 470;
            // 
            // cmsBookList
            // 
            this.cmsBookList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBookList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteMenuItem});
            this.cmsBookList.Name = "cmsBookList";
            this.cmsBookList.Size = new System.Drawing.Size(99, 26);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(98, 22);
            this.DeleteMenuItem.Text = "削除";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(770, 510);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(189, 48);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "本棚ファイル読み込み";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // dlgFile
            // 
            this.dlgFile.DefaultExt = "bls";
            this.dlgFile.Filter = "本棚ファイル(*.bls)|*.bls|すべてのファイル(*.*)|*.*";
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateButton.Location = new System.Drawing.Point(18, 510);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(189, 48);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.Text = "本棚ファイルの作成";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 578);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SelectListView);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選択";
            this.Load += new System.EventHandler(this.Form_Load);
            this.cmsBookList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ListView SelectListView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ContextMenuStrip cmsBookList;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
    }
}
