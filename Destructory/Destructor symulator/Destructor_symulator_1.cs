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
                DisplayMenu();

                int choice = GetUserInput();

                switch(choice) 
                {
                    case 1:
                        AddCar(cars, carDictionary);
                        break;
                    case 2:
                        DisplayCars(carDictionary);
                        break;
                    case 3:
                        DisplayCars(carDictionary);
                        DriveCar(carDictionary);
                        break;
                    case 4:
                        DisplayCars(carDictionary);
                        if (carDictionary.Count != 0)
                            SimulateRandomDamage(carDictionary);
                        SimulateRandomDamage(carDictionary);
                        break;
                    case 5:
                        DisplayCars(carDictionary);
                        ScrapCar(cars, carDictionary);                        
                        break;
                    case 6:
                        Console.WriteLine("Zamykanie symulatora");
                        return;
                    default:
                        break;
                }
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu.");
                Console.ReadKey();
            }
        }

        private static int GetUserInput(Dictionary<int, Car> carDictionary = null)
        {
            int input;
            while (true)
            {
                Console.Write("Podaj wartość (int): ");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (carDictionary == null || carDictionary.ContainsKey(input))
                        return input;
                    Console.WriteLine("\nNumer samochodu nie istnieje w słowniku.\n");
                }
                else
                    Console.WriteLine("Nieprawidłowy format.");
            }

        }

        private static void AddCar(List<Car> cars, Dictionary<int, Car> carDictionary) 
        {
            Console.Write("Podaj markę: ");
            string brand = Console.ReadLine();
            Console.Write("Podaj model: ");
            string model = Console.ReadLine();
            Car newCar = new Car(brand, model);
            cars.Add(newCar);
            carDictionary[cars.Count] = newCar;
            Console.WriteLine($"Dodano samochód {brand} {model}.");
        }

        private static void DisplayCars(Dictionary<int, Car> carsDictionary)
        {
            if (carsDictionary.Count == 0)
                Console.WriteLine("Brak samochodów.");
            else
            {
                Console.WriteLine("\nLista samochodów");
                foreach (var carEntry in carsDictionary)
                {
                    int key = carEntry.Key;
                    Car car = carEntry.Value;
                    Console.WriteLine($"Klucz:{key}, marka: {car.Brand}, model: {car.Model}");
                }
            }
        }

        private static void DriveCar(Dictionary<int, Car> carDictionary )
        {
            int carNumber = GetUserInput(carDictionary);
            Car carToDrive = carDictionary[carNumber];
            carToDrive.Drive();
        }

        private static void SimulateRandomDamage(Dictionary<int, Car> carDictionary)
        {
            int carNumber = GetUserInput(carDictionary);
            Car cartoSimulateDamage = carDictionary[carNumber];
            cartoSimulateDamage.SimulateRandomDamage();
        }

        private static void ScrapCar(List<Car> cars, Dictionary<int, Car> carDictionary) 
        {
            int carNumber = GetUserInput();
            Console.WriteLine($"\nSamochód {carDictionary[carNumber].Brand} {carDictionary[carNumber].Model} zastał usunięty.\n");
            cars.RemoveAt(carNumber);
            carDictionary.Remove(carNumber);
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu symulatora jazdy samochodem.");
            Console.WriteLine("1. Dodaj samochód.");
            Console.WriteLine("2. Wyświetl listę samochodów.");
            Console.WriteLine("3. Jedź samochodem..");
            Console.WriteLine("4. Symuluj losowe uszkodzenie");
            Console.WriteLine("5. Zezłomuj samochód");
            Console.WriteLine("6. Wyjście.");
            Console.Write("Wybierz opcję od 1 do 6: ");
            Console.WriteLine();
        }
    }
}
