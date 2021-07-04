using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class Award
    {        
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public Award(Guid id, string title)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title string cannot be null!");
        }

        //public Award(string title)
        //{
        //    Id = Guid.NewGuid();
        //    Title = title ?? throw new ArgumentNullException(nameof(title), "Title string cannot be null!");
        //}

        public void EditTitel(string newTitle)
        {
            Title = newTitle ?? throw new ArgumentNullException(nameof(newTitle), "Title string cannot be null!");
        }
    }
}
