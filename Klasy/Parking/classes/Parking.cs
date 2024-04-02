using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Parking.classes
{
    internal class Parking
    {
        // Klasa ta powinna mieć również następujące metody:
        // ShowCars, która wyświetla informacje o wszystkich samochodach na parkingu(lub informuje, że miejsce jest wolne).
        // Utwórz obiekty typu Car dla trzech różnych samochodów, używając inicjalizatorów obiektów.
        // Utwórz obiekt typu Parking dla parkingu o nazwie Center i pięciu miejscach, używając inicjalizatora obiektów.

        public string[] Name {  get; set; }
        public int[] Cars { get; set; }

        int cars = 0;

        public void AddCar(bool flaga)
        {
            if (flaga)
                cars++;
            else
                Console.WriteLine("Nie ma miejsca na parkingu.");
        }

        public void RemoveCar(int indx)
        {
            if (indx == 0)
                Console.WriteLine("Nie ma samochodu o podanym indeksie.");
            else
                cars--;
        }

        public void ShowCars()
        {
            if (cars == 0)
                Console.WriteLine("Parking jest pusty.");
            else
            {
                for (int i = 0; i < cars; i++)
                {
                    Car c = new Car();
                    Console.WriteLine($"Brand: {c.GetBrend()}");
                }
            }
        }

    }
}
