using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        private static readonly Random rand = new Random();
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public Author(string name, string surname)
        {
            Id = rand.Next(1000, 9999);
            Name = name;
            Surname = surname;
        }

        public override string ToString() => $"{Name} {Surname}";
    }

}
