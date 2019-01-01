namespace Yomuko.Forms.Setting
{
    partial class ColumnDialog : System.Windows.Forms.Form
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButoon = new System.Windows.Forms.Button();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OkButton, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.CancelButoon, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(236, 115);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(219, 45);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OkButton.Location = new System.Drawing.Point(4, 5);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 35);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // CancelButoon
            // 
            this.CancelButoon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButoon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButoon.Location = new System.Drawing.Point(114, 5);
            this.CancelButoon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButoon.Name = "CancelButoon";
            this.CancelButoon.Size = new System.Drawing.Size(100, 35);
            this.CancelButoon.TabIndex = 1;
            this.CancelButoon.Text = "キャンセル";
            this.CancelButoon.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(18, 60);
            this.TypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(430, 28);
            this.TypeComboBox.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 35);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 20);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "項目";
            // 
            // ColumnDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButoon;
            this.ClientSize = new System.Drawing.Size(472, 178);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColumnDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "列の選択";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        public System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.Button CancelButoon;
        public System.Windows.Forms.ComboBox TypeComboBox;
        public System.Windows.Forms.Label Label1;
    }
}