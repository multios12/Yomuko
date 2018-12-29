namespace ComicLaunch.Forms.Setting
{

    public partial class SettingForm : System.Windows.Forms.Form
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
            System.Windows.Forms.ColumnHeader ColumnHeader1;
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.BaseFolderTextBox = new System.Windows.Forms.TextBox();
            this.DuplicateCheckBox = new System.Windows.Forms.CheckBox();
            this.txtBookListName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.DuplicateFolderChangeButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.DuplicateFolderTextBox = new System.Windows.Forms.TextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.FileNameInitializeButton = new System.Windows.Forms.Button();
            this.FileNameDownButton = new System.Windows.Forms.Button();
            this.FileNameUpButton = new System.Windows.Forms.Button();
            this.FileNameDeleteButton = new System.Windows.Forms.Button();
            this.FileNameAddButton = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameListBox = new System.Windows.Forms.ListBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.CollectSubTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.ColumnListView = new System.Windows.Forms.ListView();
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDownButton = new System.Windows.Forms.Button();
            this.ColumnUpButton = new System.Windows.Forms.Button();
            this.ColumnDeleteButton = new System.Windows.Forms.Button();
            this.ColumnAddButton = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.AutoSaveCheckBox = new System.Windows.Forms.CheckBox();
            ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "種類";
            ColumnHeader1.Width = 120;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(609, 567);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.AutoSaveCheckBox);
            this.TabPage1.Controls.Add(this.BaseFolderTextBox);
            this.TabPage1.Controls.Add(this.DuplicateCheckBox);
            this.TabPage1.Controls.Add(this.txtBookListName);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.DuplicateFolderChangeButton);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.DuplicateFolderTextBox);
            this.TabPage1.Location = new System.Drawing.Point(4, 29);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage1.Size = new System.Drawing.Size(601, 534);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "本棚";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // BaseFolderTextBox
            // 
            this.BaseFolderTextBox.Location = new System.Drawing.Point(48, 114);
            this.BaseFolderTextBox.Name = "BaseFolderTextBox";
            this.BaseFolderTextBox.ReadOnly = true;
            this.BaseFolderTextBox.Size = new System.Drawing.Size(511, 32);
            this.BaseFolderTextBox.TabIndex = 14;
            // 
            // DuplicateCheckBox
            // 
            this.DuplicateCheckBox.AutoSize = true;
            this.DuplicateCheckBox.Location = new System.Drawing.Point(46, 388);
            this.DuplicateCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DuplicateCheckBox.Name = "DuplicateCheckBox";
            this.DuplicateCheckBox.Size = new System.Drawing.Size(223, 24);
            this.DuplicateCheckBox.TabIndex = 13;
            this.DuplicateCheckBox.Text = "重複するファイルは移動する";
            this.DuplicateCheckBox.UseVisualStyleBackColor = true;
            this.DuplicateCheckBox.CheckedChanged += new System.EventHandler(this.DuplicateCheckBox_CheckedChanged);
            // 
            // txtBookListName
            // 
            this.txtBookListName.Location = new System.Drawing.Point(46, 47);
            this.txtBookListName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBookListName.Name = "txtBookListName";
            this.txtBookListName.Size = new System.Drawing.Size(511, 32);
            this.txtBookListName.TabIndex = 6;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(44, 22);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 20);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "本棚の名前";
            // 
            // DuplicateFolderChangeButton
            // 
            this.DuplicateFolderChangeButton.Enabled = false;
            this.DuplicateFolderChangeButton.Location = new System.Drawing.Point(447, 412);
            this.DuplicateFolderChangeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DuplicateFolderChangeButton.Name = "DuplicateFolderChangeButton";
            this.DuplicateFolderChangeButton.Size = new System.Drawing.Size(112, 38);
            this.DuplicateFolderChangeButton.TabIndex = 1;
            this.DuplicateFolderChangeButton.Text = "参照";
            this.DuplicateFolderChangeButton.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(44, 89);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(159, 20);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "本棚のベースフォルダ";
            // 
            // DuplicateFolderTextBox
            // 
            this.DuplicateFolderTextBox.Enabled = false;
            this.DuplicateFolderTextBox.Location = new System.Drawing.Point(46, 415);
            this.DuplicateFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DuplicateFolderTextBox.Name = "DuplicateFolderTextBox";
            this.DuplicateFolderTextBox.Size = new System.Drawing.Size(400, 32);
            this.DuplicateFolderTextBox.TabIndex = 1;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.FileNameInitializeButton);
            this.TabPage2.Controls.Add(this.FileNameDownButton);
            this.TabPage2.Controls.Add(this.FileNameUpButton);
            this.TabPage2.Controls.Add(this.FileNameDeleteButton);
            this.TabPage2.Controls.Add(this.FileNameAddButton);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.Label4);
            this.TabPage2.Controls.Add(this.FileNameTextBox);
            this.TabPage2.Controls.Add(this.FileNameListBox);
            this.TabPage2.Location = new System.Drawing.Point(4, 29);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage2.Size = new System.Drawing.Size(601, 534);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "ファイル名";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // FileNameInitializeButton
            // 
            this.FileNameInitializeButton.Location = new System.Drawing.Point(476, 390);
            this.FileNameInitializeButton.Name = "FileNameInitializeButton";
            this.FileNameInitializeButton.Size = new System.Drawing.Size(111, 30);
            this.FileNameInitializeButton.TabIndex = 5;
            this.FileNameInitializeButton.Text = "初期化";
            this.FileNameInitializeButton.UseVisualStyleBackColor = true;
            // 
            // FileNameDownButton
            // 
            this.FileNameDownButton.Location = new System.Drawing.Point(476, 297);
            this.FileNameDownButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameDownButton.Name = "FileNameDownButton";
            this.FileNameDownButton.Size = new System.Drawing.Size(112, 38);
            this.FileNameDownButton.TabIndex = 4;
            this.FileNameDownButton.Text = "下へ";
            this.FileNameDownButton.UseVisualStyleBackColor = true;
            this.FileNameDownButton.Click += new System.EventHandler(this.FileNameDownButton_Click);
            // 
            // FileNameUpButton
            // 
            this.FileNameUpButton.Location = new System.Drawing.Point(476, 233);
            this.FileNameUpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameUpButton.Name = "FileNameUpButton";
            this.FileNameUpButton.Size = new System.Drawing.Size(112, 38);
            this.FileNameUpButton.TabIndex = 4;
            this.FileNameUpButton.Text = "上へ";
            this.FileNameUpButton.UseVisualStyleBackColor = true;
            this.FileNameUpButton.Click += new System.EventHandler(this.FileNameUpButton_Click);
            // 
            // FileNameDeleteButton
            // 
            this.FileNameDeleteButton.Location = new System.Drawing.Point(476, 158);
            this.FileNameDeleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameDeleteButton.Name = "FileNameDeleteButton";
            this.FileNameDeleteButton.Size = new System.Drawing.Size(112, 38);
            this.FileNameDeleteButton.TabIndex = 4;
            this.FileNameDeleteButton.Text = "削除";
            this.FileNameDeleteButton.UseVisualStyleBackColor = true;
            this.FileNameDeleteButton.Click += new System.EventHandler(this.FileNameDeleteButton_Click);
            // 
            // FileNameAddButton
            // 
            this.FileNameAddButton.Location = new System.Drawing.Point(476, 110);
            this.FileNameAddButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameAddButton.Name = "FileNameAddButton";
            this.FileNameAddButton.Size = new System.Drawing.Size(112, 38);
            this.FileNameAddButton.TabIndex = 4;
            this.FileNameAddButton.Text = "追加";
            this.FileNameAddButton.UseVisualStyleBackColor = true;
            this.FileNameAddButton.Click += new System.EventHandler(this.FileNameAddButton_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 85);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(159, 20);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "ファイル名のサンプル";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 12);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(159, 20);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "ファイル名のサンプル";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(12, 37);
            this.FileNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(574, 32);
            this.FileNameTextBox.TabIndex = 2;
            // 
            // FileNameListBox
            // 
            this.FileNameListBox.FormattingEnabled = true;
            this.FileNameListBox.ItemHeight = 20;
            this.FileNameListBox.Location = new System.Drawing.Point(15, 110);
            this.FileNameListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileNameListBox.Name = "FileNameListBox";
            this.FileNameListBox.Size = new System.Drawing.Size(450, 404);
            this.FileNameListBox.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.CollectSubTitleCheckBox);
            this.TabPage3.Controls.Add(this.ColumnListView);
            this.TabPage3.Controls.Add(this.ColumnDownButton);
            this.TabPage3.Controls.Add(this.ColumnUpButton);
            this.TabPage3.Controls.Add(this.ColumnDeleteButton);
            this.TabPage3.Controls.Add(this.ColumnAddButton);
            this.TabPage3.Controls.Add(this.Label6);
            this.TabPage3.Location = new System.Drawing.Point(4, 29);
            this.TabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage3.Size = new System.Drawing.Size(601, 534);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "リスト表示";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // CollectSubTitleCheckBox
            // 
            this.CollectSubTitleCheckBox.AutoSize = true;
            this.CollectSubTitleCheckBox.Location = new System.Drawing.Point(12, 488);
            this.CollectSubTitleCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CollectSubTitleCheckBox.Name = "CollectSubTitleCheckBox";
            this.CollectSubTitleCheckBox.Size = new System.Drawing.Size(373, 24);
            this.CollectSubTitleCheckBox.TabIndex = 10;
            this.CollectSubTitleCheckBox.Text = "サブタイトルと巻数をタイトルにまとめて表示する";
            this.CollectSubTitleCheckBox.UseVisualStyleBackColor = true;
            // 
            // ColumnListView
            // 
            this.ColumnListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ColumnHeader1,
            this.ColumnHeader2});
            this.ColumnListView.Location = new System.Drawing.Point(12, 30);
            this.ColumnListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColumnListView.Name = "ColumnListView";
            this.ColumnListView.Size = new System.Drawing.Size(450, 446);
            this.ColumnListView.TabIndex = 9;
            this.ColumnListView.UseCompatibleStateImageBehavior = false;
            this.ColumnListView.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "幅";
            // 
            // ColumnDownButton
            // 
            this.ColumnDownButton.Location = new System.Drawing.Point(472, 217);
            this.ColumnDownButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColumnDownButton.Name = "ColumnDownButton";
            this.ColumnDownButton.Size = new System.Drawing.Size(112, 38);
            this.ColumnDownButton.TabIndex = 7;
            this.ColumnDownButton.Text = "下へ";
            this.ColumnDownButton.UseVisualStyleBackColor = true;
            this.ColumnDownButton.Click += new System.EventHandler(this.ColumnDownButton_Click);
            // 
            // ColumnUpButton
            // 
            this.ColumnUpButton.Location = new System.Drawing.Point(472, 153);
            this.ColumnUpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColumnUpButton.Name = "ColumnUpButton";
            this.ColumnUpButton.Size = new System.Drawing.Size(112, 38);
            this.ColumnUpButton.TabIndex = 8;
            this.ColumnUpButton.Text = "上へ";
            this.ColumnUpButton.UseVisualStyleBackColor = true;
            this.ColumnUpButton.Click += new System.EventHandler(this.ColumnUpButton_Click);
            // 
            // ColumnDeleteButton
            // 
            this.ColumnDeleteButton.Location = new System.Drawing.Point(472, 78);
            this.ColumnDeleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColumnDeleteButton.Name = "ColumnDeleteButton";
            this.ColumnDeleteButton.Size = new System.Drawing.Size(112, 38);
            this.ColumnDeleteButton.TabIndex = 5;
            this.ColumnDeleteButton.Text = "削除";
            this.ColumnDeleteButton.UseVisualStyleBackColor = true;
            this.ColumnDeleteButton.Click += new System.EventHandler(this.ColumnDeleteButton_Click);
            // 
            // ColumnAddButton
            // 
            this.ColumnAddButton.Location = new System.Drawing.Point(472, 30);
            this.ColumnAddButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColumnAddButton.Name = "ColumnAddButton";
            this.ColumnAddButton.Size = new System.Drawing.Size(112, 38);
            this.ColumnAddButton.TabIndex = 6;
            this.ColumnAddButton.Text = "追加";
            this.ColumnAddButton.UseVisualStyleBackColor = true;
            this.ColumnAddButton.Click += new System.EventHandler(this.ColumnAddButton_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(9, 5);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(159, 20);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "書籍一覧に表示する列";
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(132, 577);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(112, 38);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(368, 577);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(112, 38);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "キャンセル";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AutoSaveCheckBox
            // 
            this.AutoSaveCheckBox.AutoSize = true;
            this.AutoSaveCheckBox.Checked = global::ComicLaunch.Properties.Settings.Default.IsAutoSave;
            this.AutoSaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSaveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ComicLaunch.Properties.Settings.Default, "IsAutoSave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AutoSaveCheckBox.Location = new System.Drawing.Point(48, 152);
            this.AutoSaveCheckBox.Name = "AutoSaveCheckBox";
            this.AutoSaveCheckBox.Size = new System.Drawing.Size(313, 24);
            this.AutoSaveCheckBox.TabIndex = 15;
            this.AutoSaveCheckBox.Text = "プロパティ変更時にファイル名を自動変更";
            this.AutoSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 635);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.TabControl1);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.TabControl TabControl1;
        public System.Windows.Forms.TabPage TabPage1;
        public System.Windows.Forms.TabPage TabPage2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.FolderBrowserDialog dlgFolder;
        public System.Windows.Forms.Button butOK;
        public System.Windows.Forms.Button butCancel;
        public System.Windows.Forms.TextBox txtBookListName;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Button FileNameDownButton;
        public System.Windows.Forms.Button FileNameUpButton;
        public System.Windows.Forms.Button FileNameDeleteButton;
        public System.Windows.Forms.Button FileNameAddButton;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.TextBox FileNameTextBox;
        public System.Windows.Forms.ListBox FileNameListBox;
        public System.Windows.Forms.TabPage TabPage3;
        public System.Windows.Forms.Button ColumnDownButton;
        public System.Windows.Forms.Button ColumnUpButton;
        public System.Windows.Forms.Button ColumnDeleteButton;
        public System.Windows.Forms.Button ColumnAddButton;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.ListView ColumnListView;
        public System.Windows.Forms.ColumnHeader ColumnHeader2;
        public System.Windows.Forms.CheckBox DuplicateCheckBox;
        public System.Windows.Forms.Button DuplicateFolderChangeButton;
        public System.Windows.Forms.TextBox DuplicateFolderTextBox;
        public System.Windows.Forms.CheckBox CollectSubTitleCheckBox;
        public System.Windows.Forms.Button FileNameInitializeButton;
        private System.Windows.Forms.TextBox BaseFolderTextBox;
        private System.Windows.Forms.CheckBox AutoSaveCheckBox;
    }
}
