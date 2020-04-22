namespace Yomuko.Forms.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Yomuko.Book;
    using Yomuko.Shelf;

    public partial class FileNamePanel : UserControl
    {
        private BookModel model;

        public FileNamePanel()
        {
            this.InitializeComponent();
        }

        public delegate void SaveClickEventHandler(SaveClickEventArgs e);

        public event SaveClickEventHandler SaveClick;

        public void SetFilePath(string filePath)
        {
            this.model = new BookModel(filePath);
            this.NameTextBox1.Text = this.model.Type;
            this.NameTextBox2.Text = this.model.Junle;
            this.NameTextBox3.Text = this.model.Writer;
            this.NameTextBox4.Text = this.model.Title;
            this.NameTextBox5.Text = this.model.No;
            this.NameTextBox6.Text = this.model.ReleaseDate;
            this.NameTextBox7.Text = this.model.SubTitle;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var name = button.Name.Replace("ClearButton", string.Empty);
            name = $"NameTextBox{name}";
            var control = this.FindControlByFieldName(name);
            control.Text = string.Empty;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var index = int.Parse(button.Name.Replace("ChangeButton", string.Empty));

            var name1 = $"NameTextBox{index}";
            var textBox1 = this.FindControlByFieldName(name1);
            var name2 = $"NameTextBox{index + 1}";
            var textBox2 = this.FindControlByFieldName(name2);

            var text = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = text;
        }

        /// <summary>
        /// フォームに配置されているコントロールを名前で探す
        /// （フォームクラスのフィールドをフィールド名で探す）
        /// </summary>
        /// <param name="name">コントロール（フィールド）の名前</param>
        /// <returns>見つかった時は、コントロールのオブジェクト。
        /// 見つからなかった時は、null(VB.NETではNothing)。</returns>
        private Control FindControlByFieldName(string name)
        {
            Type t = this.GetType();

            FieldInfo fi = t.GetField(
                name,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            return (Control)fi?.GetValue(this);
        }

        private void FileNamePanel_Load(object sender, EventArgs e)
        {
            var lists1 = Properties.Settings.Default.NameText1.Split('\r');
            this.NameTextBox1.Items.AddRange(lists1);
            var lists2 = Properties.Settings.Default.NameText2.Split('\r');
            this.NameTextBox2.Items.AddRange(lists2);
            var lists3 = Properties.Settings.Default.NameText3.Split('\r');
            this.NameTextBox3.Items.AddRange(lists3);
            var lists4 = Properties.Settings.Default.NameText4.Split('\r');
            this.NameTextBox4.Items.AddRange(lists4);
            var lists7 = Properties.Settings.Default.NameText7.Split('\r');
            this.NameTextBox7.Items.AddRange(lists7);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.model.Type = this.NameTextBox1.Text;
            this.model.Junle = this.NameTextBox2.Text;
            this.model.Writer = this.NameTextBox3.Text;
            this.model.Title = this.NameTextBox4.Text;
            this.model.No = this.NameTextBox5.Text;
            this.model.ReleaseDate = this.NameTextBox6.Text;
            this.model.SubTitle = this.NameTextBox7.Text;

            var value1 = this.CreateList(this.NameTextBox1.Items, this.model.Type);
            Properties.Settings.Default.NameText1 = value1;
            var value2 = this.CreateList(this.NameTextBox2.Items, this.model.Junle);
            Properties.Settings.Default.NameText2 = value2;
            var value3 = this.CreateList(this.NameTextBox3.Items, this.model.Writer);
            Properties.Settings.Default.NameText3 = value3;
            var value4 = this.CreateList(this.NameTextBox4.Items, this.model.Title);
            Properties.Settings.Default.NameText4 = value4;
            var value5 = this.CreateList(this.NameTextBox7.Items, this.model.SubTitle);
            Properties.Settings.Default.NameText7 = value5;
            Properties.Settings.Default.Save();

            var fileNameList = new FileNameList();
            fileNameList.Initialize();
            fileNameList.ChangeFileName(this.model);

            var args = new SaveClickEventArgs(this.model.FilePath);
            this.SaveClick(args);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var args = new SaveClickEventArgs(this.model.FilePath);
            this.SaveClick(args);
        }

        private string CreateList(ComboBox.ObjectCollection collection, string value)
        {
            var list1 = collection.Cast<string>().Where(v => v != value);
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim();
                list1 = list1.Prepend(value);
                list1 = list1.Take(5);
            }

            return string.Join("\r", list1);
        }

        private void NameTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Down) {

            }
        }
    }
}
