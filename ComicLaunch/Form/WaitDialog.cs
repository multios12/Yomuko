namespace ComicLaunch.Form
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>�����󋵕\���_�C�A���O</summary>
    public partial class WaitDialog : Form
    {
        /// <summary>���~�t���O</summary>
        private bool aborting = false;

        /// <summary>�_�C�A���O�\�����t���O</summary>
        private bool showing = false;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public WaitDialog()
        {
            this.InitializeComponent();
        }

        #region �p�u���b�N�v���p�e�B

        /// <summary>
        /// �������L�����Z���i���~�j����Ă��邩�ǂ����������l���擾���܂��B<br />
        /// �L�����Z�����ꂽ�ꍇ��true�B����ȊO��false�B
        /// </summary>
        public bool IsAborting
        {
            get
            {
                return this.aborting;
            }
        }

        /// <summary>
        /// ���C�����b�Z�[�W�̃e�L�X�g��ݒ肵�܂��B<br />
        /// �����̊T�v��\������B<br />
        /// �Ⴆ�΁A�t�@�C���̓]�����s���Ă���Ȃ�A�u�t�@�C����]�����Ă��܂��c�c�v�̂悤�ɕ\������B
        /// </summary>
        public string MainMessage
        {
            set
            {
                this.mainMessageLabel.Text = value;
            }
        }

        /// <summary>
        /// �T�u���b�Z�[�W�̃e�L�X�g��ݒ肵�܂��B<br />
        /// �ڍׂȏ������e��\������B<br />
        /// �Ⴆ�΁A�t�@�C���]���Ȃ�A�]�����̌ʂ̃t�@�C�����i�ureadme.htm�v�ucontents.htm�v�Ȃǁj��\������B
        /// </summary>
        public string SubMessage
        {
            set
            {
                this.detailMessageLabel.Text = value;
            }
        }

        /// <summary>
        /// �i�s�󋵃��b�Z�[�W�̃e�L�X�g��ݒ肷��B<br />
        /// �����̐i�s�󋵂Ƃ��āA�u�������̉������I������̂��v�u�S�̂̉������I������̂��v�Ȃǂ�\������B
        /// </summary>
        public string ProgressMessage
        {
            set
            {
                this.progressLabel.Text = value;
            }
        }

        /// <summary>
        /// �i�s�󋵃��[�^�[�̌��݈ʒu��ݒ肵�܂��B<br />
        /// �Ⴆ�΁A������200�̍H�����������ꍇ�A���݂���200�̍H���̒��̂ǂ̈ʒu�ɂ��邩�������l�B<br />
        /// ����l�́u0�v�B
        /// </summary>
        public int ProgressValue
        {
            set
            {
                this.progressBar.Value = value;
            }
        }

        /// <summary>
        /// �i�s�󋵃��[�^�[�͈̔͂̍ő�l��ݒ肵�܂��B<br />
        /// ������200�̍H��������Ȃ�u200�v�ɂȂ�B
        /// ����l�́u100�v�B
        /// </summary>
        public int ProgressMax
        {
            set
            {
                this.progressBar.Maximum = value;
            }
        }

        /// <summary>
        /// �i�s�󋵃��[�^�[�͈̔͂̍ŏ��l��ݒ肷��B
        /// ����l�́u0�v�B
        /// </summary>
        public int ProgressMin
        {
            set
            {
                this.progressBar.Minimum = value;
            }
        }

        /// <summary>
        /// PerformStep���\�b�h���Ăяo�����Ƃ��ɁA�i�s�󋵃��[�^�[�̌��݈ʒu��i�߂�ʁiProgressValue�̑����l�j��ݒ肷��B
        /// �����H����200�ŁA5�̍H�����I������i�K�Ői�s�󋵃��[�^�[���X�V�������ꍇ�́u5�v�ɂ���B
        /// ����l�́u10�v�B
        /// </summary>
        public int ProgressStep
        {
            set
            {
                this.progressBar.Step = value;
            }
        }

        /// <summary>
        /// �i�s�󋵃��[�^�[�̌��݈ʒu�iProgressValue�j��ProgressStep�v���p�e�B�̗ʂ����i�߂�B
        /// </summary>
        public void PerformStep()
        {
            this.progressBar.PerformStep();
        }
        #endregion

        /// <summary>
        /// Show���\�b�h
        /// </summary>
        public new void Show()
        {
            // �ϐ��̏�����
            this.DialogResult = DialogResult.OK;
            this.aborting = false;

            base.Show();
            this.showing = true;
        }

        /// <summary>
        /// Close���\�b�h
        /// </summary>
        public new void Close()
        {
            this.showing = false;
            base.Close();
        }

        /// <summary>
        /// ShowDialog���\�b�h�iWaitDialog�N���X�ł́AShowDialog���\�b�h�͎g�p�s�j
        /// </summary>
        /// <returns>�K���AAbort���Ԃ���܂��B</returns>
        private new DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }

        #region �C�x���g

        /// <summary>
        /// �L�����Z���E�{�^���������ꂽ�Ƃ��̏���
        /// ������r���ŃL�����Z���i���f�j����B
        /// </summary>
        /// <param name="sender">�������I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            // ���~����
            this.Abort();
        }

        /// <summary>
        /// �_�C�A���O��������Ƃ��̏���
        /// �E��́m����n�{�^���������ꂽ�ꍇ�ɂ́A
        /// �m�L�����Z���n�{�^���Ɠ����悤�ɁA������r���ŃL�����Z���i���f�j����B
        /// </summary>
        /// <param name="sender">�������I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        private void WaitDialog_Closing(object sender, CancelEventArgs e)
        {
            if (this.showing == true)
            {
                // �_�C�A���O�\�����Ȃ̂Œ��~�i�L�����Z���j���������s
                this.Abort();

                // �܂��_�C�A���O�͕��Ȃ�
                e.Cancel = true;
            }
            else
            {
                // �t�H�[���͕�����Ƃ���̂őf���ɕ���
                e.Cancel = false;
            }
        }
        #endregion

        /// <summary>
        /// ���~�i�L�����Z���j����
        /// </summary>
        private void Abort()
        {
            this.aborting = true;
            this.DialogResult = DialogResult.Abort;
        }
    }
}
