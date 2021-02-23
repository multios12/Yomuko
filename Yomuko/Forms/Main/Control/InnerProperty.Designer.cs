namespace Yomuko.Forms.Main.Control
{
    partial class InnerProperty
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BookTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJunle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SubTitleTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboWriter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.SaleDateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FavoriteCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.cboTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNO = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePath.Location = new System.Drawing.Point(59, 10);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(528, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.TabStop = false;
            this.txtFilePath.Text = "G:\\一般コミック\\その他\\(一般コミック) aaaaaa.zip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ファイル";
            // 
            // txtHash
            // 
            this.txtHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHash.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHash.Location = new System.Drawing.Point(59, 40);
            this.txtHash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size(528, 20);
            this.txtHash.TabIndex = 3;
            this.txtHash.TabStop = false;
            this.txtHash.Text = "a2a2cdd35f220e318bbbe6b2f0a95838";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ハッシュ";
            // 
            // BookTypeComboBox
            // 
            this.BookTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.BookTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BookTypeComboBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.BookTypeComboBox.Location = new System.Drawing.Point(59, 70);
            this.BookTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BookTypeComboBox.Name = "BookTypeComboBox";
            this.BookTypeComboBox.Size = new System.Drawing.Size(120, 28);
            this.BookTypeComboBox.TabIndex = 0;
            this.BookTypeComboBox.Text = "一般コミック";
            this.BookTypeComboBox.TextChanged += new System.EventHandler(this.InnerProperty_TextChanged);
            this.BookTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.BookTypeComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "種類";
            // 
            // txtJunle
            // 
            this.txtJunle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtJunle.Location = new System.Drawing.Point(256, 70);
            this.txtJunle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJunle.Name = "txtJunle";
            this.txtJunle.Size = new System.Drawing.Size(120, 28);
            this.txtJunle.TabIndex = 1;
            this.txtJunle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.txtJunle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "ジャンル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "ｻﾌﾞﾀｲﾄﾙ";
            // 
            // SubTitleTextBox
            // 
            this.SubTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubTitleTextBox.Location = new System.Drawing.Point(74, 145);
            this.SubTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubTitleTextBox.Name = "SubTitleTextBox";
            this.SubTitleTextBox.Size = new System.Drawing.Size(302, 27);
            this.SubTitleTextBox.TabIndex = 5;
            this.SubTitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.SubTitleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "著者";
            // 
            // cboWriter
            // 
            this.cboWriter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWriter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboWriter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboWriter.FormattingEnabled = true;
            this.cboWriter.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboWriter.Location = new System.Drawing.Point(437, 70);
            this.cboWriter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboWriter.Name = "cboWriter";
            this.cboWriter.Size = new System.Drawing.Size(150, 28);
            this.cboWriter.TabIndex = 2;
            this.cboWriter.Text = "あいうえおかきくけこ";
            this.cboWriter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.cboWriter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "出版社";
            // 
            // cboPublisher
            // 
            this.cboPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPublisher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboPublisher.Location = new System.Drawing.Point(437, 145);
            this.cboPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(150, 28);
            this.cboPublisher.TabIndex = 6;
            this.cboPublisher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.cboPublisher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(213, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "メモ";
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(272, 182);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(315, 63);
            this.txtMemo.TabIndex = 9;
            this.txtMemo.Text = "9";
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // SaleDateTextBox
            // 
            this.SaleDateTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SaleDateTextBox.Location = new System.Drawing.Point(59, 182);
            this.SaleDateTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaleDateTextBox.Mask = "0000/00/00";
            this.SaleDateTextBox.Name = "SaleDateTextBox";
            this.SaleDateTextBox.Size = new System.Drawing.Size(111, 27);
            this.SaleDateTextBox.TabIndex = 7;
            this.SaleDateTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.SaleDateTextBox.ValidatingType = typeof(System.DateTime);
            this.SaleDateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.SaleDateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 185);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "発売日";
            // 
            // FavoriteCheckBox
            // 
            this.FavoriteCheckBox.AutoSize = true;
            this.FavoriteCheckBox.Location = new System.Drawing.Point(12, 219);
            this.FavoriteCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FavoriteCheckBox.Name = "FavoriteCheckBox";
            this.FavoriteCheckBox.Size = new System.Drawing.Size(95, 24);
            this.FavoriteCheckBox.TabIndex = 8;
            this.FavoriteCheckBox.Text = "お気に入り";
            this.FavoriteCheckBox.UseVisualStyleBackColor = true;
            this.FavoriteCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.FavoriteCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // AutoSaveCheckBox
            // 
            this.AutoSaveCheckBox.AutoSize = true;
            this.AutoSaveCheckBox.Location = new System.Drawing.Point(12, 11);
            this.AutoSaveCheckBox.Name = "AutoSaveCheckBox";
            this.AutoSaveCheckBox.Size = new System.Drawing.Size(159, 24);
            this.AutoSaveCheckBox.TabIndex = 2;
            this.AutoSaveCheckBox.Text = "ファイル名を自動変更";
            this.AutoSaveCheckBox.UseVisualStyleBackColor = true;
            this.AutoSaveCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.AutoSaveCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(4, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 35);
            this.button3.TabIndex = 0;
            this.button3.Text = "OK(&F11)";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(0, 8);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 35);
            this.button4.TabIndex = 1;
            this.button4.Text = "キャンセル";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.AutoSaveCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 45);
            this.panel1.TabIndex = 100;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NoButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(368, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 40);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_Button.BackColor = System.Drawing.SystemColors.Control;
            this.OK_Button.Location = new System.Drawing.Point(5, 5);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 30);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "保存(&F11)";
            this.OK_Button.UseVisualStyleBackColor = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // NoButton
            // 
            this.NoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoButton.BackColor = System.Drawing.SystemColors.Control;
            this.NoButton.Location = new System.Drawing.Point(115, 5);
            this.NoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(100, 30);
            this.NoButton.TabIndex = 1;
            this.NoButton.Text = "閉じる(&F2)";
            this.NoButton.UseVisualStyleBackColor = false;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // cboTitle
            // 
            this.cboTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboTitle.Location = new System.Drawing.Point(59, 108);
            this.cboTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTitle.Name = "cboTitle";
            this.cboTitle.Size = new System.Drawing.Size(462, 27);
            this.cboTitle.TabIndex = 3;
            this.cboTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.cboTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "タイトル";
            // 
            // txtNO
            // 
            this.txtNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNO.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNO.Location = new System.Drawing.Point(529, 108);
            this.txtNO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNO.Name = "txtNO";
            this.txtNO.Size = new System.Drawing.Size(58, 27);
            this.txtNO.TabIndex = 4;
            this.txtNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.txtNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            // 
            // InnerProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FavoriteCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SaleDateTextBox);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPublisher);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboWriter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SubTitleTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJunle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BookTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Name = "InnerProperty";
            this.Size = new System.Drawing.Size(600, 300);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerProperty_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerProperty_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BookTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtJunle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SubTitleTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboWriter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPublisher;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.MaskedTextBox SaleDateTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox FavoriteCheckBox;
        private System.Windows.Forms.CheckBox AutoSaveCheckBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox cboTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNO;
    }
}
