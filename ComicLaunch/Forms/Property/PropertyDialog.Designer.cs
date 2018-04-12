namespace ComicLaunch.Form
{
    public partial class PropertyDialog : System.Windows.Forms.Form
    {

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                archiveBook.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Windows フォーム デザイナで必要です。
        private System.ComponentModel.IContainer components = null;

        // メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
        // Windows フォーム デザイナを使用して変更できます。  
        // コード エディタを使って変更しないでください。
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.cboTitle = new System.Windows.Forms.TextBox();
            this.cboWriter = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblWriter = new System.Windows.Forms.Label();
            this.txtJunle = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.SaleDateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.txtNO = new System.Windows.Forms.TextBox();
            this.lblPhotographer = new System.Windows.Forms.Label();
            this.cboPhotographer = new System.Windows.Forms.ComboBox();
            this.BookTypeComboBox = new System.Windows.Forms.ComboBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.AnalyzeFileNameButton = new System.Windows.Forms.Button();
            this.FavoriteCheckBox = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SubTitleTextBox = new System.Windows.Forms.TextBox();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.CoverIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.CompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverIndexUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.NoButton, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(546, 548);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(219, 45);
            this.TableLayoutPanel1.TabIndex = 13;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(4, 5);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 35);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // NoButton
            // 
            this.NoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NoButton.Location = new System.Drawing.Point(114, 5);
            this.NoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(100, 35);
            this.NoButton.TabIndex = 1;
            this.NoButton.Text = "キャンセル";
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // cboTitle
            // 
            this.cboTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboTitle.Location = new System.Drawing.Point(93, 132);
            this.cboTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTitle.Name = "cboTitle";
            this.cboTitle.Size = new System.Drawing.Size(469, 24);
            this.cboTitle.TabIndex = 1;
            // 
            // cboWriter
            // 
            this.cboWriter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboWriter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboWriter.FormattingEnabled = true;
            this.cboWriter.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboWriter.Location = new System.Drawing.Point(93, 210);
            this.cboWriter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboWriter.Name = "cboWriter";
            this.cboWriter.Size = new System.Drawing.Size(258, 26);
            this.cboWriter.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(24, 137);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 18);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "タイトル";
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(24, 215);
            this.lblWriter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(38, 18);
            this.lblWriter.TabIndex = 4;
            this.lblWriter.Text = "著者";
            // 
            // txtJunle
            // 
            this.txtJunle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtJunle.Location = new System.Drawing.Point(501, 253);
            this.txtJunle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJunle.Name = "txtJunle";
            this.txtJunle.Size = new System.Drawing.Size(258, 26);
            this.txtJunle.TabIndex = 8;
            this.txtJunle.Enter += new System.EventHandler(this.JunleComboBox_Enter);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Location = new System.Drawing.Point(508, 470);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 18);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "表紙";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 77);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 18);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "本の種類";
            // 
            // cboPublisher
            // 
            this.cboPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPublisher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboPublisher.Location = new System.Drawing.Point(93, 253);
            this.cboPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(258, 26);
            this.cboPublisher.TabIndex = 7;
            this.cboPublisher.Enter += new System.EventHandler(this.PublisherComboBox_Enter);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(22, 307);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 18);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "発売日";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(26, 380);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(29, 18);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "メモ";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(106, 375);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(391, 121);
            this.txtMemo.TabIndex = 11;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(22, 20);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(50, 18);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "ファイル";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePath.Location = new System.Drawing.Point(93, 15);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(500, 17);
            this.txtFilePath.TabIndex = 14;
            this.txtFilePath.TabStop = false;
            // 
            // txtHash
            // 
            this.txtHash.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHash.Location = new System.Drawing.Point(93, 508);
            this.txtHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size(670, 17);
            this.txtHash.TabIndex = 12;
            this.txtHash.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(26, 508);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(52, 18);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "ハッシュ";
            // 
            // SaleDateTextBox
            // 
            this.SaleDateTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SaleDateTextBox.Location = new System.Drawing.Point(93, 298);
            this.SaleDateTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaleDateTextBox.Mask = "0000/00/00";
            this.SaleDateTextBox.Name = "SaleDateTextBox";
            this.SaleDateTextBox.Size = new System.Drawing.Size(121, 24);
            this.SaleDateTextBox.TabIndex = 9;
            this.SaleDateTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.SaleDateTextBox.ValidatingType = typeof(System.DateTime);
            this.SaleDateTextBox.Leave += new System.EventHandler(this.SaleDateTextBox_LostFocus);
            // 
            // txtNO
            // 
            this.txtNO.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNO.Location = new System.Drawing.Point(621, 135);
            this.txtNO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNO.Name = "txtNO";
            this.txtNO.Size = new System.Drawing.Size(48, 24);
            this.txtNO.TabIndex = 2;
            // 
            // lblPhotographer
            // 
            this.lblPhotographer.AutoSize = true;
            this.lblPhotographer.Location = new System.Drawing.Point(432, 215);
            this.lblPhotographer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhotographer.Name = "lblPhotographer";
            this.lblPhotographer.Size = new System.Drawing.Size(53, 18);
            this.lblPhotographer.TabIndex = 4;
            this.lblPhotographer.Text = "撮影者";
            // 
            // cboPhotographer
            // 
            this.cboPhotographer.FormattingEnabled = true;
            this.cboPhotographer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboPhotographer.Location = new System.Drawing.Point(502, 210);
            this.cboPhotographer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPhotographer.Name = "cboPhotographer";
            this.cboPhotographer.Size = new System.Drawing.Size(256, 26);
            this.cboPhotographer.TabIndex = 6;
            // 
            // BookTypeComboBox
            // 
            this.BookTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.BookTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BookTypeComboBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.BookTypeComboBox.Location = new System.Drawing.Point(94, 72);
            this.BookTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BookTypeComboBox.Name = "BookTypeComboBox";
            this.BookTypeComboBox.Size = new System.Drawing.Size(180, 26);
            this.BookTypeComboBox.TabIndex = 0;
            this.BookTypeComboBox.Enter += new System.EventHandler(this.BookTypeComboBox_Enter);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(22, 258);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(53, 18);
            this.Label10.TabIndex = 4;
            this.Label10.Text = "出版社";
            // 
            // AnalyzeFileNameButton
            // 
            this.AnalyzeFileNameButton.Location = new System.Drawing.Point(602, 7);
            this.AnalyzeFileNameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AnalyzeFileNameButton.Name = "AnalyzeFileNameButton";
            this.AnalyzeFileNameButton.Size = new System.Drawing.Size(158, 75);
            this.AnalyzeFileNameButton.TabIndex = 14;
            this.AnalyzeFileNameButton.Text = "ﾌｧｲﾙ名からﾌﾟﾛﾊﾟﾃｨを取得";
            this.AnalyzeFileNameButton.UseVisualStyleBackColor = true;
            this.AnalyzeFileNameButton.Click += new System.EventHandler(this.AnalyzeFileNameButton_Click);
            // 
            // FavoriteCheckBox
            // 
            this.FavoriteCheckBox.AutoSize = true;
            this.FavoriteCheckBox.Location = new System.Drawing.Point(94, 340);
            this.FavoriteCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FavoriteCheckBox.Name = "FavoriteCheckBox";
            this.FavoriteCheckBox.Size = new System.Drawing.Size(90, 22);
            this.FavoriteCheckBox.TabIndex = 10;
            this.FavoriteCheckBox.Text = "お気に入り";
            this.FavoriteCheckBox.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 173);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 18);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "ｻﾌﾞﾀｲﾄﾙ";
            // 
            // SubTitleTextBox
            // 
            this.SubTitleTextBox.Location = new System.Drawing.Point(93, 168);
            this.SubTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubTitleTextBox.Name = "SubTitleTextBox";
            this.SubTitleTextBox.Size = new System.Drawing.Size(576, 24);
            this.SubTitleTextBox.TabIndex = 4;
            // 
            // picCover
            // 
            this.picCover.BackColor = System.Drawing.SystemColors.Control;
            this.picCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCover.Location = new System.Drawing.Point(624, 298);
            this.picCover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(134, 199);
            this.picCover.TabIndex = 18;
            this.picCover.TabStop = false;
            this.picCover.WaitOnLoad = true;
            // 
            // CoverIndexUpDown
            // 
            this.CoverIndexUpDown.Location = new System.Drawing.Point(550, 467);
            this.CoverIndexUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CoverIndexUpDown.Name = "CoverIndexUpDown";
            this.CoverIndexUpDown.Size = new System.Drawing.Size(64, 24);
            this.CoverIndexUpDown.TabIndex = 12;
            this.CoverIndexUpDown.ValueChanged += new System.EventHandler(this.CoverIndexUpDown_ValueChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(432, 258);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(53, 18);
            this.Label9.TabIndex = 4;
            this.Label9.Text = "ジャンル";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(598, 137);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(23, 18);
            this.Label11.TabIndex = 3;
            this.Label11.Text = "巻";
            // 
            // CompleteCheckBox
            // 
            this.CompleteCheckBox.AutoSize = true;
            this.CompleteCheckBox.Location = new System.Drawing.Point(693, 135);
            this.CompleteCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CompleteCheckBox.Name = "CompleteCheckBox";
            this.CompleteCheckBox.Size = new System.Drawing.Size(57, 22);
            this.CompleteCheckBox.TabIndex = 3;
            this.CompleteCheckBox.Text = "完結";
            this.CompleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // PropertyDialog
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.NoButton;
            this.ClientSize = new System.Drawing.Size(782, 613);
            this.Controls.Add(this.CoverIndexUpDown);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.SubTitleTextBox);
            this.Controls.Add(this.CompleteCheckBox);
            this.Controls.Add(this.FavoriteCheckBox);
            this.Controls.Add(this.AnalyzeFileNameButton);
            this.Controls.Add(this.BookTypeComboBox);
            this.Controls.Add(this.txtNO);
            this.Controls.Add(this.SaleDateTextBox);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cboPublisher);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtJunle);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.lblPhotographer);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cboPhotographer);
            this.Controls.Add(this.cboWriter);
            this.Controls.Add(this.cboTitle);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[プロパティ]";
            this.Load += new System.EventHandler(this.PropertyDialog_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverIndexUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        public System.Windows.Forms.Button OK_Button;
        public System.Windows.Forms.Button NoButton;
        public System.Windows.Forms.TextBox cboTitle;
        public System.Windows.Forms.ComboBox cboWriter;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lblWriter;
        public System.Windows.Forms.ComboBox txtJunle;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox cboPublisher;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox txtMemo;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.TextBox txtFilePath;
        public System.Windows.Forms.TextBox txtHash;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.MaskedTextBox SaleDateTextBox;
        public System.Windows.Forms.TextBox txtNO;
        public System.Windows.Forms.Label lblPhotographer;
        public System.Windows.Forms.ComboBox cboPhotographer;
        public System.Windows.Forms.ComboBox BookTypeComboBox;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Button AnalyzeFileNameButton;
        public System.Windows.Forms.CheckBox FavoriteCheckBox;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox SubTitleTextBox;
        public System.Windows.Forms.PictureBox picCover;
        public System.Windows.Forms.NumericUpDown CoverIndexUpDown;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.CheckBox CompleteCheckBox;
    }
}
