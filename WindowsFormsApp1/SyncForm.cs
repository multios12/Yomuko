namespace WindowsFormsApp1
{
    using System;
    using System.Windows.Forms;

    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();
        }

        private void SyncForm_Load(object sender, EventArgs e)
        {
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox3.Dock = DockStyle.Fill;
            this.MenuListBox.SelectedIndex = 0;
        }

        private void SyncForm_Shown(object sender, EventArgs e)
        {

        }

        private void MenuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)MenuListBox.SelectedItem == "同期結果")
            {
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;

            }
            else if ((string)MenuListBox.SelectedItem == "同一ファイル")
            {
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = true;
                this.groupBox3.Visible = false;

            }
            else if ((string)MenuListBox.SelectedItem == "ファイルが存在しない本")
            {
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = true;
            }
        }

        private void DuplicateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectAllDuplicateButton_Click(object sender, EventArgs e)
        {

        }

        private void DuplicateMoveButton_Click(object sender, EventArgs e)
        {

        }

        private void NotFoundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllNotFoundDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void NotFoundDeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
