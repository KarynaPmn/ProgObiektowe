using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_krt.Classes
{
    internal class Parking
    {
        // Utwórz klasę Parking, która reprezentuje parking samochodowy.
        // Klasa ta powinna mieć następujące właściwości: 
        // Name (nazwa parkingu), Cars (tablica samochodów, które znajdują się na parkingu).

        public string Name {  get; set; }
        public Car[] Cars { get; set; }
        public Car c {  get; set; }

        // Klasa ta powinna mieć również następujące metody:
        // AddCar, która dodaje samochód do pierwszego wolnego miejsca na parkingu
        // (lub wyświetla komunikat, że nie ma wolnych miejsc), 

        public void AddCar(Car c_p)
        {
            bool flaga = false;
            for (int i = 0; i < Cars.Length; i++) 
            { 
                if (Cars[i] == null)
                {
                    Console.WriteLine($"\nTwój samochód jest zaparkowany na {i} miejscu.");
                    Cars[i] = c_p;
                    flaga = true;
                    break;
                }
            }
            if (!flaga)
                Console.WriteLine("\nNa parkingu nie ma wolnych miejsc.");
        }

        // RemoveCar, która usuwa samochód z podanego indeksu miejsca na parkingu
        // (lub wyświetla komunikat, że podany indeks jest nieprawidłowy lub miejsce jest puste), 

        public void RemoveCar(int indeks)
        {
            if (Cars[indeks] != null)
            {
                Console.WriteLine("\nSamochod jest usunięty z parkingu.");
                Cars[indeks] = null;
            }
            else if (Cars[indeks] == null)
                    Console.WriteLine("\nPodane miejsce jest puste.");
            
        }

        // ShowCars, która wyświetla informacje o wszystkich samochodach na parkingu
        // (lub informuje, że miejsce jest wolne).

        public void ShowCars()
        {
            for (int i = 0; i < Cars.Length; i++)
            {
                if (Cars[i] != null)
                    Cars[i].ShowInformation();                
                else
                    Console.WriteLine("\nMiejsce jest puste.");
            }
        }

    }
}
