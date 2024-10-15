using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziedziczenie
{
    internal class Program
    {
        // typ wyliczeniowy dla paliwa
        public enum FuelType
        {
            Petrol, // benzyna
            Diesel, // olej napędowy
            Electric // elektryczny
        }

        public class Vehicle
        {
            public string Brand {  get; set; }
            public string Model { get; set; }
            public double Fuel { get; private set; } // poziom paliwa
            public FuelType FuelType { get; set; } // typ paliwa
            public ushort Speed { get; set; } // aktualna prędkość pojazdu
            public virtual void StartEngine()
            {
                Console.WriteLine("\nSilnik samochodu uruchomiony.");
            }

            public virtual void StopEngine()
            {
                Console.WriteLine("\nSilnik samochodu zatrzymany.");
            }

            public void Refuel(double amount)
            {
                Fuel += amount;
                Console.WriteLine("\nZatankowano {amount} litra paliwa w pojeździe.");
            }
        }

        public class Car : Vehicle
        {
            public byte NumberOfDoors { get; set; }
            public int CurrentGear { get; set; } // aktualny bieg
            public int MaxGear { get; set; } // maksymalny bieg
            public bool IsAutomatic { get; set; } // czy skrznia jest automatyczna
            public override void StartEngine()
            {
                Console.WriteLine("\nSilnik samochodu uruchomiony.");
            }

            public override void StopEngine()
            {
                Console.WriteLine("\nSilnik samochodu zatrzymany.");
            }

            // metoda do zmiany biegów
            public void ChangeGear(byte gear) 
            { 
                if (!IsAutomatic)
                {
                    if (gear > MaxGear || gear < 0)
                        Console.WriteLine("\nNie prawidłowy bieg.");
                    else
                    {
                        CurrentGear = gear;
                        Console.WriteLine($"\nZmiana biegu na {gear}");
                    }
                }
                else
                {
                    Console.WriteLine("\nTen samochód ma automatyczną skrzynię biegów.");
                }
            }

            private void AutomaticGearChange(int speed)
            {
                if (IsAutomatic)
                {
                    if (speed < 20)                   
                        CurrentGear = 1;
                    else if (speed > 20 && speed  < 40)
                        CurrentGear = 2;
                    else
                        CurrentGear = 3;
                    Console.WriteLine($"\nAutomatyczna zmiana biegu na {CurrentGear} dla prędkości {speed} km/h.");
                }
                else
                {
                    Console.WriteLine("\nManualna skrzynia biegu.");
                }
            }
        }


        static void Main(string[] args)
        {
            Vehicle v = new Vehicle();
            v.Brand = "Lamborghini";

            Console.WriteLine(v.Brand);
            Console.WriteLine("Pojazd: ");
            v.StartEngine();

            Car car = new Car();
            car.Brand = "Fiat";
            Console.WriteLine("\n\n" + car.Brand);
            car.NumberOfDoors = 4;
            v.StartEngine();

            Car car1 = new Car { Brand = "Toyota", Model = "Supra", NumberOfDoors = 4, FuelType = FuelType.Petrol, MaxGear = 5, IsAutomatic = false};


            Console.ReadKey();
        }
    }
}
