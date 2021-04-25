using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_4._1
{
    public class IOService
    {
        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
