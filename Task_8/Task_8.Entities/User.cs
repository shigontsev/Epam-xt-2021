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

        public User(Guid id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name string cannot be null!");
            DateOfBirth = dateOfBirth;
        }

        //public User(string name, DateTime dateOfBirth)
        //{
        //    Id = Guid.NewGuid();
        //    Name = name ?? throw new ArgumentNullException(nameof(name), "Name string cannot be null!");
        //    DateOfBirth = dateOfBirth;
        //}

        public void Edit(string newName, DateTime newDateOfBirth)
        {
            if (newName is null)
            {
                throw new ArgumentNullException(nameof(newName), "Name string cannot be null!");
            }
            if (newDateOfBirth > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(newDateOfBirth), "New DateOfBirth cannot be upper than current Date!");
            }

            Name = newName;
            DateOfBirth = newDateOfBirth;
        }

        public void EditName(string newName)
        {
            if (newName is null)
            {
                throw new ArgumentNullException(nameof(newName), "Name string cannot be null!");
            }
            Name = newName;
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
