using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4._1
{
    public class Log
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public LogType Type { get; set; }

        public string Path { get; set; }

        public string Content;
    }
}
