using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4._1
{
    public class InfoState
    {
        public InfoState(DateTime date, string path)
        {
            Date = date;
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public DateTime Date { get; private set; }
        public string Path { get; private set; }
    }
}
