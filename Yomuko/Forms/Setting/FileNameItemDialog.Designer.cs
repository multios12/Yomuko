namespace Yomuko.Forms.Setting
{
    using System.Windows.Forms;

    partial class FileNameItemDialog : Form
    {

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
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
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.SplitterComboBox = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.FieldTypeComboBox = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtValueDetail = new System.Windows.Forms.TextBox();
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
            this.TableLayoutPanel1.Location = new System.Drawing.Point(226, 138);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(219, 45);
            this.TableLayoutPanel1.TabIndex = 3;
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
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(114, 5);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 35);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "キャンセル";
            // 
            // SplitterComboBox
            // 
            this.SplitterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SplitterComboBox.FormattingEnabled = true;
            this.SplitterComboBox.Location = new System.Drawing.Point(21, 40);
            this.SplitterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SplitterComboBox.Name = "SplitterComboBox";
            this.SplitterComboBox.Size = new System.Drawing.Size(180, 28);
            this.SplitterComboBox.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 15);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 20);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "区切り記号";
            // 
            // FieldTypeComboBox
            // 
            this.FieldTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FieldTypeComboBox.FormattingEnabled = true;
            this.FieldTypeComboBox.Location = new System.Drawing.Point(242, 40);
            this.FieldTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FieldTypeComboBox.Name = "FieldTypeComboBox";
            this.FieldTypeComboBox.Size = new System.Drawing.Size(180, 28);
            this.FieldTypeComboBox.TabIndex = 1;
            this.FieldTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ValueComboBox_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(238, 15);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(24, 20);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "値";
            // 
            // txtValueDetail
            // 
            this.txtValueDetail.Location = new System.Drawing.Point(242, 83);
            this.txtValueDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValueDetail.Name = "txtValueDetail";
            this.txtValueDetail.Size = new System.Drawing.Size(180, 32);
            this.txtValueDetail.TabIndex = 3;
            // 
            // FileNameItemDialog
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(464, 202);
            this.Controls.Add(this.txtValueDetail);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.FieldTypeComboBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.SplitterComboBox);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileNameItemDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgFileNameItems";
            this.Load += new System.EventHandler(this.FileNameItemDialog_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public TableLayoutPanel TableLayoutPanel1;
        public Button OK_Button;
        public Button Cancel_Button;
        public ComboBox SplitterComboBox;
        public Label Label1;
        public ComboBox FieldTypeComboBox;
        public Label Label2;
        public TextBox txtValueDetail;
    }
}
