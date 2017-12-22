namespace ComicLaunch.Form
{
    public partial class CreateBookListDialog
    {

        // Windows フォーム デザイナで必要です。
        private System.ComponentModel.IContainer components = null;

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
        // Windows フォーム デザイナを使用して変更できます。  
        // コード エディタを使って変更しないでください。
        private void InitializeComponent()
        {
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.OKButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.dlgFile = new System.Windows.Forms.SaveFileDialog();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(534, 120);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(94, 39);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "参照";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 96);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(98, 20);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "ファイルパス";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 8);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 20);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "タイトル";
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(18, 123);
            this.FilePathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(514, 32);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(18, 35);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(599, 32);
            this.TitleTextBox.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.OKButton, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.cButton, 1, 0);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(415, 199);
            this.TableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(219, 45);
            this.TableLayoutPanel2.TabIndex = 4;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Location = new System.Drawing.Point(4, 5);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 35);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "作成";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cButton
            // 
            this.cButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cButton.Location = new System.Drawing.Point(114, 5);
            this.cButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(100, 35);
            this.cButton.TabIndex = 1;
            this.cButton.Text = "キャンセル";
            this.cButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dlgFile
            // 
            this.dlgFile.DefaultExt = "bls";
            this.dlgFile.Filter = "ファイル(*.bls)|*.bls|すべてのファイル(*.*)|*.*";
            // 
            // CreateBookListDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cButton;
            this.ClientSize = new System.Drawing.Size(645, 248);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TableLayoutPanel2);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateBookListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "本棚ファイルの新規作成";
            this.TableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cButton;
        private System.Windows.Forms.SaveFileDialog dlgFile;
    }
}
