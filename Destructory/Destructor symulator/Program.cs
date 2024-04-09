using Destructor_symulator.Classes;
using System;
using System.Collections.Generic;

namespace Destructor_symulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Dictionary<int, Car> carDictionary = new Dictionary<int, Car>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu symulatora jazdy samochochodem.");
                Console.WriteLine("1. Dodaj samochód.");
                Console.WriteLine("2. Wyświetl listę samochodów.");
                Console.WriteLine("3. Jedź samochodem..");
                Console.WriteLine("4. Symuluj losowe uszkodzenie");
                Console.WriteLine("5. Zezłomój samochód");
                Console.WriteLine("6. Wyjście.");
                Console.Write("Wybierz opcję od 1 do 6: ");

                int choice = int.Parse(Console.ReadLine());

                switch(choice) 
                {
                    case 1:
                        Console.Write("Podaj markę: ");
                        string brand = Console.ReadLine();
                        Console.Write("Podaj model: ");
                        string model = Console.ReadLine();
                        Car newCar = new Car(brand, model);
                        cars.Add(newCar);
                        carDictionary[cars.Count] = newCar;
                        Console.WriteLine($"Dodano samochód {brand} {model}.");
                        break;
                    case 2:
                        Console.WriteLine("Lista samochodów");
                        foreach (Car car in cars)
                            Console.WriteLine($"{car.Brand} {car.Model}");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Podaj numer samochodu do jazdy: ");
                        int carNumber = int.Parse(Console.ReadLine());
                        if (carDictionary.TryGetValue(carNumber, out Car selectedCar))                        
                            selectedCar.Drive();                        
                        else                        
                            Console.WriteLine("\nNieprawidłowy numer samochodu."); 
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Podaj numer samochodu do symulacji uszkodzeń: ");
                        int damageCarNumber = int.Parse(Console.ReadLine());
                        if (carDictionary.TryGetValue(damageCarNumber, out Car damagedCar))                        
                            damagedCar.SimulateRandomDamage();
                        else
                            Console.WriteLine("Nieprawidłowy numer samochodu.");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Podaj numer samochodu do zezłomowania: ");
                        int scrappedCarNumber = int.Parse(Console.ReadLine());
                        if (carDictionary.TryGetValue(scrappedCarNumber, out Car scrappedCar))
                        {
                            //scrappedCar = null;
                            //GC.Collect();
                            cars.RemoveAt(0); // działa ale błędnie
                            Console.WriteLine($"Samochód {scrappedCarNumber} został zezłomowany.");
                        }
                        //cars.Remove(cars[scrappedCarNumber]);
                        //carDictionary[scrappedCarNumber] = null;
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Zamykanie symulatora");
                        Console.ReadKey(true);
                        return;
                    default:
                        break;
                }

            }
        }
    }
}
