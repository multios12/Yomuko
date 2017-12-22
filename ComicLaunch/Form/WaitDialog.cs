namespace ComicLaunch.Form
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>処理状況表示ダイアログ</summary>
    public partial class WaitDialog : Form
    {
        /// <summary>中止フラグ</summary>
        private bool aborting = false;

        /// <summary>ダイアログ表示中フラグ</summary>
        private bool showing = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WaitDialog()
        {
            this.InitializeComponent();
        }

        #region パブリックプロパティ

        /// <summary>
        /// 処理がキャンセル（中止）されているかどうかを示す値を取得します。<br />
        /// キャンセルされた場合はtrue。それ以外はfalse。
        /// </summary>
        public bool IsAborting
        {
            get
            {
                return this.aborting;
            }
        }

        /// <summary>
        /// メインメッセージのテキストを設定します。<br />
        /// 処理の概要を表示する。<br />
        /// 例えば、ファイルの転送を行っているなら、「ファイルを転送しています……」のように表示する。
        /// </summary>
        public string MainMessage
        {
            set
            {
                this.mainMessageLabel.Text = value;
            }
        }

        /// <summary>
        /// サブメッセージのテキストを設定します。<br />
        /// 詳細な処理内容を表示する。<br />
        /// 例えば、ファイル転送なら、転送中の個別のファイル名（「readme.htm」「contents.htm」など）を表示する。
        /// </summary>
        public string SubMessage
        {
            set
            {
                this.detailMessageLabel.Text = value;
            }
        }

        /// <summary>
        /// 進行状況メッセージのテキストを設定する。<br />
        /// 処理の進行状況として、「何件分の何件が終わったのか」「全体の何％が終わったのか」などを表示する。
        /// </summary>
        public string ProgressMessage
        {
            set
            {
                this.progressLabel.Text = value;
            }
        }

        /// <summary>
        /// 進行状況メーターの現在位置を設定します。<br />
        /// 例えば、処理に200の工数があった場合、現在その200の工数の中のどの位置にいるかを示す値。<br />
        /// 既定値は「0」。
        /// </summary>
        public int ProgressValue
        {
            set
            {
                this.progressBar.Value = value;
            }
        }

        /// <summary>
        /// 進行状況メーターの範囲の最大値を設定します。<br />
        /// 処理に200の工数があるなら「200」になる。
        /// 既定値は「100」。
        /// </summary>
        public int ProgressMax
        {
            set
            {
                this.progressBar.Maximum = value;
            }
        }

        /// <summary>
        /// 進行状況メーターの範囲の最小値を設定する。
        /// 既定値は「0」。
        /// </summary>
        public int ProgressMin
        {
            set
            {
                this.progressBar.Minimum = value;
            }
        }

        /// <summary>
        /// PerformStepメソッドを呼び出したときに、進行状況メーターの現在位置を進める量（ProgressValueの増分値）を設定する。
        /// 処理工数が200で、5つの工数が終わった段階で進行状況メーターを更新したい場合は「5」にする。
        /// 既定値は「10」。
        /// </summary>
        public int ProgressStep
        {
            set
            {
                this.progressBar.Step = value;
            }
        }

        /// <summary>
        /// 進行状況メーターの現在位置（ProgressValue）をProgressStepプロパティの量だけ進める。
        /// </summary>
        public void PerformStep()
        {
            this.progressBar.PerformStep();
        }
        #endregion

        /// <summary>
        /// Showメソッド
        /// </summary>
        public new void Show()
        {
            // 変数の初期化
            this.DialogResult = DialogResult.OK;
            this.aborting = false;

            base.Show();
            this.showing = true;
        }

        /// <summary>
        /// Closeメソッド
        /// </summary>
        public new void Close()
        {
            this.showing = false;
            base.Close();
        }

        /// <summary>
        /// ShowDialogメソッド（WaitDialogクラスでは、ShowDialogメソッドは使用不可）
        /// </summary>
        /// <returns>必ず、Abortが返されます。</returns>
        private new DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }

        #region イベント

        /// <summary>
        /// キャンセル・ボタンが押されたときの処理
        /// 処理を途中でキャンセル（中断）する。
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            // 中止処理
            this.Abort();
        }

        /// <summary>
        /// ダイアログが閉じられるときの処理
        /// 右上の［閉じる］ボタンが押された場合には、
        /// ［キャンセル］ボタンと同じように、処理を途中でキャンセル（中断）する。
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void WaitDialog_Closing(object sender, CancelEventArgs e)
        {
            if (this.showing == true)
            {
                // ダイアログ表示中なので中止（キャンセル）処理を実行
                this.Abort();

                // まだダイアログは閉じない
                e.Cancel = true;
            }
            else
            {
                // フォームは閉じられるところので素直に閉じる
                e.Cancel = false;
            }
        }
        #endregion

        /// <summary>
        /// 中止（キャンセル）処理
        /// </summary>
        private void Abort()
        {
            this.aborting = true;
            this.DialogResult = DialogResult.Abort;
        }
    }
}
