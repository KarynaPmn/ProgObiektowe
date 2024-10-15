using konstruktor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konstruktor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Person p3 = new Person("Karl");
            Person p4 = new Person("Grim", "Salvo");
            Person p5 = new Person("Bronia", "Smok", 357);
            Person p6 = new Person("Bronia", "Smok", 357, 158);

            // Wyświetlenie wartości właściwości
            Console.WriteLine(p1.GetData());
            Console.WriteLine(p2.GetData());
            Console.WriteLine(p3.GetData());
            Console.WriteLine(p4.GetData());
            Console.WriteLine(p5.GetData());
            Console.WriteLine(p6.GetData());


            // Wyświetlenie liczby obiektów klasy Person
            Console.WriteLine("List obiektów klasy Person: {0}", Person.Counter); // 7 obiektów

            Console.ReadKey();
        }
    }
}
