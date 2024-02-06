using KarynaPomin_g2.cs.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarynaPomin_g2.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Tomek";
            person1.LastName = "Pierwszy";
            person1.DateOfBirth = new DateTime(02, 10, 1989);

            string[] NameAnimals = { "Kotek", "Marysia" };
            person1.NamesIfAnimals = NameAnimals;


        }
    }
}
