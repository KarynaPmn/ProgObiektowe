using Parking.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car();
            c1.Brand = "Marka";
            Console.WriteLine(c1.GetBrend());

            // Utwórz klasę Parking, która reprezentuje parking samochodowy. Klasa ta powinna mieć następujące właściwości: 
            // Name(nazwa parkingu), Cars(tablica samochodów, które znajdują się na parkingu).Klasa ta powinna mieć również następujące metody: AddCar, która dodaje samochód do pierwszego wolnego miejsca na parkingu(lub wyświetla komunikat, że nie ma wolnych miejsc), RemoveCar, która usuwa samochód z podanego indeksu miejsca na parkingu(lub wyświetla komunikat, że podany indeks jest nieprawidłowy lub miejsce jest puste), ShowCars, która wyświetla informacje o wszystkich samochodach na parkingu(lub informuje, że miejsce jest wolne).
            // Utwórz obiekty typu Car dla trzech różnych samochodów, używając inicjalizatorów obiektów.
            // Utwórz obiekt typu Parking dla parkingu o nazwie Center i pięciu miejscach, używając inicjalizatora obiektów.
            // Dodaj trzy samochody do parkingu, używając metody AddCar.
            // Wyświetl informacje o wszystkich samochodach na parkingu, używając metody ShowCars.
            // Usuń samochód z drugiego miejsca na parkingu, używając metody RemoveCar.
            // Wyświetl informacje o wszystkich samochodach na parkingu po usunięciu, używając metody ShowCars.


        }
    }
}
