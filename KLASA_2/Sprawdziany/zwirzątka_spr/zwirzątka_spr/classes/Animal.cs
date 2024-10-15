using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace zwirzątka_spr.classes
{
    internal class Animal
    {
        //1. Utwórz klasę Animal, która będzie zawierać następujące pola: string Name, string
        //Species, string Color, ushort Age, float Weight, Person Owner.

        //2. Dodaj do klasy Animal metodę GetInfo(), która zwróci łańcuch znaków zawierający 
        // informacje o zwierzęciu i jego właścicielu w formacie: Imię: ………, gatunek: ………, 
        //kolor: …., wiek: {Age} lat(a), waga: {Weight} kg,
        //właściciel: …………(imię). ………….(nazwisko), data urodzenia: ……………………

        //5. Dodaj pole do zwierzęcia, które będzie zawierało 5 cech charakterystycznych dla
        //danego gatunku, które następnie będzie można wybrać przypisując je do zwierzęcia.
        //Zmodyfikuj metodę GetInfo()

        public string Name { get; set; }

        public string Species { get; set; }

        public string Color { get; set; }

        public ushort Age { get; set; }

        public float Weight { get; set; }

        public Person Owner { get; set; }

        public List<string> Characteristics { get; set; }


        public void GetInfo()
        {
            string characteristics = string.Join(", ", Characteristics);
            Console.WriteLine($"Imię: {Name}, ");
            Console.WriteLine($"Garunek: {Species}, ");
            Console.WriteLine($"Kolor: {Color}, ");
            Console.WriteLine($"Lata: {Age}, ");
            Console.WriteLine($"Waga: {Weight}, ");
            Console.WriteLine($"Właściciel: {Owner.Name} {Owner.LastName}, ");
            Console.WriteLine($"Charakterystyka: {characteristics}");

        }
    }
}
