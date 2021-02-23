namespace Yomuko.Forms.Main
{

    public partial class SelectChangeForm
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboValue = new System.Windows.Forms.ComboBox();
            this.FieldTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SearchCombobox = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(490, 203);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(261, 45);
            this.TableLayoutPanel1.TabIndex = 3;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(5, 5);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(120, 35);
            this.OK_Button.TabIndex = 3;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(135, 5);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(120, 35);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(16, 130);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 25);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "置換後";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 43);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 25);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "項目";
            // 
            // cboValue
            // 
            this.cboValue.FormattingEnabled = true;
            this.cboValue.Location = new System.Drawing.Point(86, 125);
            this.cboValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboValue.Name = "cboValue";
            this.cboValue.Size = new System.Drawing.Size(670, 33);
            this.cboValue.TabIndex = 2;
            // 
            // FieldTypeComboBox
            // 
            this.FieldTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FieldTypeComboBox.FormattingEnabled = true;
            this.FieldTypeComboBox.Items.AddRange(new object[] {
            "タイトル",
            "著者",
            "出版社",
            "ジャンル",
            "メモ",
            "種類",
            "撮影者",
            "掲載誌"});
            this.FieldTypeComboBox.Location = new System.Drawing.Point(86, 38);
            this.FieldTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FieldTypeComboBox.Name = "FieldTypeComboBox";
            this.FieldTypeComboBox.Size = new System.Drawing.Size(670, 33);
            this.FieldTypeComboBox.TabIndex = 0;
            this.FieldTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.FieldComboBox_SelectedIndexChanged);
            // 
            // SearchCombobox
            // 
            this.SearchCombobox.FormattingEnabled = true;
            this.SearchCombobox.Location = new System.Drawing.Point(86, 82);
            this.SearchCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchCombobox.Name = "SearchCombobox";
            this.SearchCombobox.Size = new System.Drawing.Size(670, 33);
            this.SearchCombobox.TabIndex = 1;
            this.SearchCombobox.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(16, 87);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(69, 25);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "置換前";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(16, 168);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(677, 25);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "※置換前を指定しない場合、項目の内容が置換後の文字列に一括変更されます";
            // 
            // SelectChangeForm
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(770, 267);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.SearchCombobox);
            this.Controls.Add(this.cboValue);
            this.Controls.Add(this.FieldTypeComboBox);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectChangeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "項目の一括変更";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox cboValue;
        public System.Windows.Forms.ComboBox FieldTypeComboBox;
        public System.Windows.Forms.ComboBox SearchCombobox;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
    }
}
