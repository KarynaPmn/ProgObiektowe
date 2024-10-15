using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zwirzątka_spr.classes;

namespace zwirzątka_spr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name  = "Karl";
            p1.LastName = "Pupkin";
            p1.DateBirth = new DateTime(2007,01,03);          
            p1.PetNames = new List<string> { "kaka", "kiki", "koka" };

            Animal aK1 = new Animal();
            aK1.Name = "kaka";
            aK1.Age = 1;
            aK1.Color = "pink";
            aK1.Species = "rats";
            aK1.Weight = 2;
            aK1.Owner = p1;
            aK1.Characteristics = new List<string> { "enargiczny", "mały", "ogoniasty"};

            aK1.GetInfo();

            Console.WriteLine($"Do właściciela {p1.Name} {p1.LastName} należą: ");
            foreach (var pet in p1.PetNames)
            {
                Console.Write(pet + ", ");
            }
            Console.WriteLine();
            Console.WriteLine(p1.DateBirth.ToLongDateString());

            Console.ReadKey();
            
        }
    }
}
