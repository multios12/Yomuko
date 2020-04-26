namespace Yomuko.Forms.Viewer
{
    partial class ViewerForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
            this.pictureList1 = new Yomuko.Forms.Viewer.PictureList();
            this.SuspendLayout();
            // 
            // pictureList1
            // 
            this.pictureList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureList1.IsEnabledSideFilePanel = false;
            this.pictureList1.IsVisibledFileList = false;
            this.pictureList1.Location = new System.Drawing.Point(0, 0);
            this.pictureList1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureList1.Name = "pictureList1";
            this.pictureList1.PageSize = Yomuko.PageSizeConstants.Fit;
            this.pictureList1.Size = new System.Drawing.Size(887, 561);
            this.pictureList1.TabIndex = 0;
            this.pictureList1.ArchiveClosed += new System.EventHandler(this.PictureList1_ArchiveClosed);
            this.pictureList1.ArchiveMoved += new System.EventHandler<Yomuko.Forms.Viewer.ArchiveMovedEventArgs>(this.PictureList1_ArchiveMoved);
            // 
            // ViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 561);
            this.Controls.Add(this.pictureList1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public PictureList pictureList1;
    }
}

