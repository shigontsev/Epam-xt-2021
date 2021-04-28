using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Task_4._1
{
    public class Log
    {
        [JsonInclude]
        public Guid Id { get; set; }

        [JsonInclude]
        public DateTime Date { get; set; }

        [JsonInclude]
        public LogType Type { get; set; }

        [JsonInclude]
        public string OldPath { get; set; }

        [JsonInclude]
        public string Path { get; set; }

        [JsonIgnore]
        public string Content { get; set; }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, new string[]
                {
                    $"Id = {Id}",
                    $"Date = {Date}",
                    $"Type = {Type}",
                    OldPath == null? null : $"OldPath = {OldPath}",
                    $"Path = {Path}",
                    Content == null? null : $"Content = {Content}"
                });
        }
    }
}
