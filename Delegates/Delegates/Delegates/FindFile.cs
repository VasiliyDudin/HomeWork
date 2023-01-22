using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class FindFile
    {
        private string path;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public delegate void EventHandler(object sender, EventArgs FileArgs);

        public event EventHandler<FileArgs> FileFound;

        public void Find()
        {
            bool isCont = true;
            FileInfo[] files = null;
            if (Directory.Exists(path))
            {
                DirectoryInfo Dir = new DirectoryInfo(path);
                files = Dir.GetFiles();
                foreach (FileInfo fi in files)
                {
                    EventHandler<FileArgs> handler = FileFound;
                    FileArgs Args = new FileArgs(fi.FullName);
                    handler?.Invoke(this, Args);
                    if (Args.Cancel)
                        break;
                }
            }
        }
    }

    public class FileArgs : EventArgs
    {
        public string FoundFile;
        public bool Cancel;
        public FileArgs(string fileName)
        {
            FoundFile = fileName;
            Cancel = false;
        }
    }
}
