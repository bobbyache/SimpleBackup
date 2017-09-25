using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.SimpleBackupTests
{
    /*
        Must dbl check if source is external drive... Drive identifier and label.

        For each directory or file.
        Check source files against target files...
         1.  What is new
         2. What is deleted
         3. What has changed

        Change base folder of source.
        Change base folder of target.

        Navigate directory and file system of source to backup only requested paths. Perhaps backup 
        recursive directory or only chosen files.

        So check folder to select all files. Unselect folder to select none. But then select each 
        file directly.

        Checking adds to master list that can also have items removed.

        Each directory has folders and files.

        If a target folder doesnt have a matching source folder... Then that target folder and all its 
        contents should be marked for deletion.

        If a target file exists but does not have a corresponding source file... Then the source file 
        has been deleted and so shpuld the target file.

        Any target folders that do not map to corresponding directories in the currently 

        http://www.blackwasp.co.uk/folderrecursion.aspx https://msdn.microsoft.com/en-us/library/dd413232.aspx

        https://www.codeproject.com/Articles/38959/A-Faster-Directory-Enumerator

        https://stackoverflow.com/questions/8745215/best-way-to-resolve-file-path-too-long-exception

        https://stackoverflow.com/questions/12747132/pathtoolongexception-c-sharp-4-5


        https://social.msdn.microsoft.com/Forums/vstudio/en-US/f6943b02-92f1-46c2-a961-27f20d8d691a/detect-external-harddrive-connect-and-get-drive-letter?forum=csharpgeneral

        https://www.google.co.za/amp/s/tempuzfugit.wordpress.com/2007/10/08/external-storage-unit-detection-with-c-in-net-usb-card-readers-etc/amp/

        https://stackoverflow.com/questions/10186277/how-to-get-drive-information-by-volume-id


        https://stackoverflow.com/questions/4084402/get-hard-disk-serial-number

    */
    [TestFixture]
    class TestBench
    {
        [Test]
        public void TestIt()
        {
            Assert.IsTrue(true);
        }
    }
}
