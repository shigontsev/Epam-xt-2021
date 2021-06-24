using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class User
    {        
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public User(string name, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name string cannot be null!");
            DateOfBirth = dateOfBirth;
        }

        public void EditName(string newName)
        {
            Name = newName ?? throw new ArgumentNullException(nameof(newName), "Name string cannot be null!");
        }

        public void EditDateOfBirth(DateTime newDateOfBirth)
        {
            if (newDateOfBirth > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(newDateOfBirth), "New DateOfBirth cannot be upper than current Date!");
            }
            DateOfBirth = newDateOfBirth;
        }
    }
}
