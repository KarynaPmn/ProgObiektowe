using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KarynaPomin_g2.cs.Klasy
{
//    5. Dodaj pole do zwierzęcia, które będzie zawierało 5 cech charakterystycznych dla
//      danego gatunku, które następnie będzie można wybrać przypisując je do zwierzęcia.
//      Zmodyfikuj metodę GetInfo()

    enum Cechy
    {
        ryba,
        pies,
        kot, 
        gryzonie,
        chomik
    }

    internal class Animal
    {
//        1. Utwórz klasę Animal, która będzie zawierać następujące pola: string Name, string
//        Species, string Color, ushort Age, float Weight, Person Owner.

        public string Name { get; set; }
        public string Species { get; set; }
        public string Color { get; set; }
        public ushort Age { get; set; }
        public float Weight { get; set; }
        public Person Owner { get; set; }

//        2. Dodaj do klasy Animal metodę GetInfo(), która zwróci łańcuch znaków zawierający
//          informacje o zwierzęciu i jego właścicielu w formacie: Imię: ………, gatunek: ………, 
//          kolor: …., wiek: {Age} lat(a), waga: {Weight} kg, właściciel: …………(imię). ………….(nazwisko), data urodzenia: ……………………

        public void GetInfo()
        {
            Console.Write($"Imię: {Name}, ");
            Console.Write($"gatunek: {Species}, ");
            Console.Write($"kolor: {Color}, ");
            Console.Write($"wiek: {Age}, ");
            Console.Write($"waga: {Weight}, ");
            Console.Write($"właściciel: {Owner}, ");
            Console.Write($"waga: {Weight}, ");
            Console.Write($"charakterystyka: {},");
            Console.Write($"data urodzenia: {}."); // data
        }

    }
}
