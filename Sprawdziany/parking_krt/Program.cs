using parking_krt.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace parking_krt
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Utwórz typ wyliczenia Color, który zawiera pięć kolorów: Red, Blue, Green, Black, White.

            // Utwórz obiekty typu Car dla trzech różnych samochodów, używając inicjalizatorów obiektów.
            Car c1 = new Car();
            c1.Year = new DateTime(1987);
            c1.Brand = "Brand 1";
            c1.Model = "Model 1";
            c1.Color = Colors.White;

            Car c2 = new Car();
            c2.Year = new DateTime(1999);
            c2.Brand = "Brand 2";
            c2.Model = "Model 2";
            c2.Color = Colors.Red;

            Car c3 = new Car();
            c3.Year = new DateTime(2004);
            c3.Brand = "Brand 3";
            c3.Model = "Model 3";
            c3.Color = Colors.Blue;


            // Utwórz obiekt typu Parking dla parkingu o nazwie Center i pięciu miejscach, używając inicjalizatora obiektów.
            Parking Center = new Parking();
            Center.Cars = new Car[5];

            // Dodaj trzy samochody do parkingu, używając metody AddCar.
            Center.AddCar(c1);
            Center.AddCar(c2);
            Center.AddCar(c3);

            // Wyświetl informacje o wszystkich samochodach na parkingu, używając metody ShowCars.
            c1.ShowInformation();
            c2.ShowInformation();
            c3.ShowInformation();

            // Usuń samochód z drugiego miejsca na parkingu, używając metody RemoveCar.
            Center.RemoveCar(1);

            // Wyświetl informacje o wszystkich samochodach na parkingu po usunięciu, używając metody ShowCars.
            Center.ShowCars();

            Console.ReadKey();
        }
    }
}
