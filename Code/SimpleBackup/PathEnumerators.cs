using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.SimpleBackup
{
    internal class PathEnumerators
    {
        public static List<string> ShowAllFoldersUnder(string path)
        {
            List<string> folders = new List<string>();

            try
            {
                if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        folders.Add(folder);
                        folders.AddRange(ShowAllFoldersUnder(folder));
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            return folders;
        }
    }
}
