using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.SimpleBackup
{
    internal class ComparisonFunctions
    {
        public static bool CompareFileSizes(string fileName1, string fileName2)
        {
            // http://www.daveoncsharp.com/2009/07/file-comparison-in-csharp-part-1/

            bool fileSizeEqual = true;

            // Create System.IO.FileInfo objects for both files
            FileInfo fileInfo1 = new FileInfo(fileName1);
            FileInfo fileInfo2 = new FileInfo(fileName2);

            // Compare file sizes
            if (fileInfo1.Length != fileInfo2.Length)
            {
                // File sizes are not equal therefore files are not identical
                fileSizeEqual = false;
            }

            return fileSizeEqual;
        }


        public static bool CompareFileBytes(string fileName1, string fileName2)
        {
            // http://www.daveoncsharp.com/2009/07/file-comparison-in-csharp-part-2/

            // Compare file sizes before continuing. 
            // If sizes are equal then compare bytes.
            if (CompareFileSizes(fileName1, fileName2))
            {
                int file1byte = 0;
                int file2byte = 0;

                // Open a System.IO.FileStream for each file.
                // Note: With the 'using' keyword the streams 
                // are closed automatically.
                using (FileStream fileStream1 = new FileStream(fileName1, FileMode.Open),
                                  fileStream2 = new FileStream(fileName2, FileMode.Open))
                {
                    // Read and compare a byte from each file until a
                    // non-matching set of bytes is found or the end of
                    // file is reached.
                    do
                    {
                        file1byte = fileStream1.ReadByte();
                        file2byte = fileStream2.ReadByte();
                    }
                    while ((file1byte == file2byte) && (file1byte != -1));
                }

                return ((file1byte - file2byte) == 0);
            }
            else
            {
                return false;
            }
        }

        private static bool CompareFileHashes(string fileName1, string fileName2)
        {
            // http://www.daveoncsharp.com/2009/07/file-comparison-in-csharp-part-3/

            // Compare file sizes before continuing. 
            // If sizes are equal then compare bytes.
            if (CompareFileSizes(fileName1, fileName2))
            {
                // Create an instance of System.Security.Cryptography.HashAlgorithm
                HashAlgorithm hash = HashAlgorithm.Create();

                // Declare byte arrays to store our file hashes
                byte[] fileHash1;
                byte[] fileHash2;

                // Open a System.IO.FileStream for each file.
                // Note: With the 'using' keyword the streams 
                // are closed automatically.
                using (FileStream fileStream1 = new FileStream(fileName1, FileMode.Open),
                                  fileStream2 = new FileStream(fileName2, FileMode.Open))
                {
                    // Compute file hashes
                    fileHash1 = hash.ComputeHash(fileStream1);
                    fileHash2 = hash.ComputeHash(fileStream2);
                }

                return BitConverter.ToString(fileHash1) == BitConverter.ToString(fileHash2);
            }
            else
            {
                return false;
            }
        }
    }
}
