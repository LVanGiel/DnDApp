using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.streaming.Base
{
    internal class BaseStream
    {
        string basepath = FileSystem.Current.AppDataDirectory;
        internal void CreateFileCheck(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {

                }
            }
        }
    }
}
