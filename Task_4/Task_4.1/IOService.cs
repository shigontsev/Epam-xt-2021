using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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
            //catch (IOException e) //bad solution
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32) //Description of HResult down by page
            {
                return true;
            }
            catch (FileNotFoundException)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(10));
                return true;
            }

            //file is not locked
            return false;
        }

        public static string ReadAllText(string path)
        {
            string content = "";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] streamByte= new byte[stream.Length];
                stream.Read(streamByte, 0, streamByte.Length);

                content = Encoding.Default.GetString(streamByte);
            }
            return content;
        }

        //Discrioption value HResult:
        //https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-erref/0642cb2f-2075-4469-918c-4441e69c548a

        //IOException: The process cannot access the file 'file path' because it is being used by another process
        //https://stackoverflow.com/questions/26741191/ioexception-the-process-cannot-access-the-file-file-path-because-it-is-being
        //https://docs.microsoft.com/en-us/dotnet/standard/io/handling-io-errors

    }
}
