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

        public string OldPath { get; set; }

        public string Path { get; set; }

        public string Content;

        //public Log(Guid id, DateTime date, LogType type, string oldPath, string path, string content)
        //{
        //    Id = id;
        //    Date = date;
        //    Type = type;
        //    OldPath = oldPath ?? throw new ArgumentNullException(nameof(oldPath));
        //    Path = path ?? throw new ArgumentNullException(nameof(path));
        //    Content = content ?? throw new ArgumentNullException(nameof(content));
        //}

        public override string ToString()
        {
            return string.Join(Environment.NewLine, new string[]
                {
                    $"Id = {Id}",
                    $"Date = {Date}",
                    $"Type = {Type}",
                    OldPath == null? null : $"OldPath = {OldPath}",
                    $"Path = {Path}",
                    $"Content = {Content}"
                });
        }
    }
}
