namespace Yomuko.Forms.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SaveClickEventArgs
    {
        public SaveClickEventArgs(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
