using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.SimpleBackup
{
    // http://www.daveoncsharp.com/2009/07/file-comparison-in-csharp-part-1/

    public class Backup
    {
        public Backup(string sourceDirectory, string targetDirectory)
        {
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
        }

        public string SourceDirectory { get; private set; }
        public string TargetDirectory { get; private set; }
    }
}
