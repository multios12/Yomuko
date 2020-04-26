namespace Yomuko.Forms
{

    public class SaveClickEventArgs
    {
        public SaveClickEventArgs(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
