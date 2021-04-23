using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_4._1
{
    public class IOService
    {
        public static string ReadFile(string path)
        {
            string resulte;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                resulte = sr.ReadToEnd();
            }
            return resulte;
        }

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
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
