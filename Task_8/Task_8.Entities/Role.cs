using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class Role
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Role(int id, string name)
        {
            Id = id;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name can't be null or empty");
            }
            Name = name;
        }
    }
}
