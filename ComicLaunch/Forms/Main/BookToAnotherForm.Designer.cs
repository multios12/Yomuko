namespace ComicLaunch.Forms.Main
{
    partial class BookToAnotherForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookToAnotherForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ShelfListBox = new System.Windows.Forms.ListBox();
            this.FolderListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "移動先本棚";
            // 
            // ShelfListBox
            // 
            this.ShelfListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ShelfListBox.FormattingEnabled = true;
            this.ShelfListBox.ItemHeight = 20;
            this.ShelfListBox.Location = new System.Drawing.Point(16, 32);
            this.ShelfListBox.Name = "ShelfListBox";
            this.ShelfListBox.Size = new System.Drawing.Size(252, 264);
            this.ShelfListBox.TabIndex = 1;
            this.ShelfListBox.SelectedIndexChanged += new System.EventHandler(this.ShelfListBox_SelectedIndexChanged);
            // 
            // FolderListBox
            // 
            this.FolderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderListBox.Enabled = false;
            this.FolderListBox.FormattingEnabled = true;
            this.FolderListBox.ItemHeight = 20;
            this.FolderListBox.Location = new System.Drawing.Point(274, 32);
            this.FolderListBox.Name = "FolderListBox";
            this.FolderListBox.Size = new System.Drawing.Size(496, 264);
            this.FolderListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "移動先フォルダ";
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartButton.Location = new System.Drawing.Point(249, 314);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(286, 40);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "ファイルの移動開始";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // BookToAnotherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FolderListBox);
            this.Controls.Add(this.ShelfListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BookToAnotherForm";
            this.Text = "BookToAnotherForm";
            this.Load += new System.EventHandler(this.BookToAnotherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ShelfListBox;
        private System.Windows.Forms.ListBox FolderListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartButton;
    }
}