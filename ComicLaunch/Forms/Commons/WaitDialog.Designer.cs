namespace ComicLaunch.Forms.Common
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Forms;

    public partial class WaitDialog : Form
    {
        /// <summary>コンテナ</summary>
        private IContainer components = null;

        #region  Windows フォーム デザイナで生成されたコード 
        /// <summary>
        /// Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
        /// </summary>
        /// <param name="disposing">詳細</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        /// <summary>フォームを初期化します。</summary>
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.noButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.detailMessageLabel = new System.Windows.Forms.Label();
            this.mainMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noButton
            // 
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.noButton.Location = new System.Drawing.Point(176, 120);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(88, 23);
            this.noButton.TabIndex = 9;
            this.noButton.Text = "キャンセル";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 88);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(408, 23);
            this.progressBar.TabIndex = 8;
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(16, 64);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(408, 16);
            this.progressLabel.TabIndex = 7;
            this.progressLabel.Text = "進捗メッセージ";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detailMessageLabel
            // 
            this.detailMessageLabel.Location = new System.Drawing.Point(16, 40);
            this.detailMessageLabel.Name = "detailMessageLabel";
            this.detailMessageLabel.Size = new System.Drawing.Size(408, 16);
            this.detailMessageLabel.TabIndex = 6;
            this.detailMessageLabel.Text = "サブ・メッセージ";
            this.detailMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMessageLabel
            // 
            this.mainMessageLabel.Location = new System.Drawing.Point(16, 16);
            this.mainMessageLabel.Name = "mainMessageLabel";
            this.mainMessageLabel.Size = new System.Drawing.Size(408, 16);
            this.mainMessageLabel.TabIndex = 5;
            this.mainMessageLabel.Text = "メイン・メッセージ";
            this.mainMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 25);
            this.ClientSize = new System.Drawing.Size(465, 184);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.detailMessageLabel);
            this.Controls.Add(this.mainMessageLabel);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "実行中・・・";
            this.ResumeLayout(false);

        }

        /// <summary>キャンセルボタン</summary>
        private Button noButton;

        /// <summary>プログレスバー</summary>
        private ProgressBar progressBar;

        /// <summary>進捗情報ラベル</summary>
        private Label progressLabel;

        /// <summary>詳細ラベル</summary>
        private Label detailMessageLabel;

        /// <summary>概要ラベル</summary>
        private Label mainMessageLabel;
    }
}
