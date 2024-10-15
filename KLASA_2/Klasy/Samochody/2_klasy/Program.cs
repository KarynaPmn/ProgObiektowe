using _2_klasy.Classes;
using System;
using System.Collections.Generic;


namespace _2_klasy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Tworzenie listy samochodów
            List<Samochod> Cars = new List<Samochod>();

            ShowMenu(Cars);
  
        }

        // MENU 
        static void ShowMenu(List<Samochod> cars)
        {

            // Opcje
            Console.WriteLine(
                "1. Dodaj samochód\r\n" +
                "2. Wyświetl informacje\r\n" +
                "3. Oblicz wiek samochodu\r\n" +
                "4. Sprawdź, czy klasyk\r\n" +
                "5. Wyświetl informacje JSON\r\n" +
                "6. Oblicz spalanie\r\n" +
                "7. Wyjście\r\n");

            Console.Write("\nWybież jedną z opcji: ");
            string TryparseWyborUser = Console.ReadLine();
            int wyborUser;
            if (!int.TryParse(TryparseWyborUser, out wyborUser)){
                Console.Clear();
                Console.WriteLine("Błąd: podano niepoprawne dane! Napisz cyfrę od 1 do 7.");
                Console.ReadKey();
                Console.Clear();
                ShowMenu(cars);
            }


            switch (wyborUser)
            {
                case 1:
                    AddNewCar(cars);
                    break;
                case 2:
                    ShowInformationsAboutCar(cars);
                    break;
                case 3:
                    CoutYearsCar(cars);
                    break;
                case 4:
                    IfKlassic(cars);
                    break;
                case 5:
                    ShowInformationJSON(cars);
                    break;
                case 6:
                    CountBurningCar(cars);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Dziękujemy za skorzystanie z programu!");
                    Console.ReadKey();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Błąd: podano niepoprawne dane! Napisz cyfrę od 1 do 7.");
                    Console.ReadKey();
                    Console.Clear();
                    ShowMenu(cars);
                    break;

            }
  
        }

        static void IfDataIsNull(List<Samochod> cars)
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Brak samochodów :(");
                Console.WriteLine("Przed rozpoczęciem programu dodaj samochód.");
                Console.ReadKey();
                Console.Clear();
                ShowMenu(cars);
            }
        }

        // 1. Dodaj samochód
        static void AddNewCar(List<Samochod> cars) 
        {
            Console.Clear();

            bool IsCorrect = false;

            do
            {
                try
                {
                    Console.WriteLine("Aby dodać nowy samochód wpisz poniżej dane samochodu.");
                    Console.Write("Marka: ");
                    string marka = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Rok produkcji: ");
                    int rokProdukcji = int.Parse(Console.ReadLine());
                    Console.Write("Data pierwszej rejestracji (podaj w formacie RRRR-MM-DD): ");
                    DateTime pierwszaRejestracja = DateTime.Parse(Console.ReadLine());
                    Console.Write("Typ paliwa: ");
                    TypPaliwa typPaliwa = (TypPaliwa)Enum.Parse(typeof(TypPaliwa), Console.ReadLine().ToLower());
                    Console.Write("Pojemność silnika: ");
                    float pojemnoscSilnika = float.Parse(Console.ReadLine());
                    Samochod carUser = new Samochod(marka, model, rokProdukcji, pierwszaRejestracja, typPaliwa, pojemnoscSilnika);
                    cars.Add(carUser);

                    IsCorrect = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podano nie prawidłowe dane! Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsCorrect);

            Console.WriteLine("\nDodano nowy samochód!");

            Console.ReadKey();
            Console.Clear();
            ShowMenu(cars);
        }

        // 2. Wyświetl informacje
        static void ShowInformationsAboutCar(List<Samochod> cars)
        {
            Console.Clear();


            if(cars.Count == 0)
            {
                Samochod samochod = new Samochod();
                samochod.WyswietlInformacje();
            }
            else
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    Console.WriteLine($"Informacja samochodzie numer {i + 1}");
                    cars[i].WyswietlInformacje();
                }
            }

            Console.ReadKey();
            Console.Clear();
            ShowMenu(cars);
        }

        // 3. Oblicz wiek samochodu
        static void CoutYearsCar(List<Samochod> cars) 
        {
            Console.Clear();
            IfDataIsNull(cars);

            bool IsCorrect = false;

            do
            {
                try
                {
                    Console.Write($"Podaj numer samochodu (do {cars.Count}), aby sprawdzić jego wiek: ");
                    int numberCar = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Wiek: " + cars[numberCar].ObliczWiekSamochodu());
                    IsCorrect = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podano nie prawidłowe dane! Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsCorrect);

            Console.ReadLine();
            Console.Clear();
            ShowMenu(cars);
        }

        // 4. Sprawdź, czy klasyk
        static void IfKlassic(List<Samochod> cars) 
        {
            Console.Clear();
            IfDataIsNull(cars);

            bool IsCorrect = false;

            do
            {
                try
                {
                    Console.Write($"Podaj numer samochodu (do {cars.Count}), aby sprawdzić czy jest klasyczny: ");
                    int numberCar = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine(cars[numberCar].CzyKlasyk() ? "Tak" : "Nie");

                    IsCorrect = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podano nie prawidłowe dane! Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsCorrect);

            Console.ReadLine();
            Console.Clear();
            ShowMenu(cars);
        }

        // 5. Wyświetl informacje JSON
        static void ShowInformationJSON(List<Samochod> cars) 
        {
            Console.Clear();
            IfDataIsNull(cars);

            bool IsCorrect = false;

            do
            {
                try
                {
                    Console.Write($"Podaj numer samochodu (do {cars.Count}), aby wyświetlić jego dane w formacie JSON: ");
                    int numberCar = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine(cars[numberCar].WyswietlInformacjeJSON());

                    IsCorrect = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podano nie prawidłowe dane! Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsCorrect);

            Console.ReadLine();
            Console.Clear();
            ShowMenu(cars);
        }

        // 6. Oblicz spalanie
        static void CountBurningCar(List<Samochod> cars) 
        {
            Console.Clear();
            IfDataIsNull(cars);

            bool IsCorrect = false;

            do
            {
                try
                {
                    Console.Write($"Podaj numer samochodu (do {cars.Count}): ");
                    int numberCar = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Podaj kilometry przejechane: ");
                    double km = double.Parse(Console.ReadLine());
                    Console.Write("Podaj ile zużyto paliwa:");
                    double paliwo = double.Parse(Console.ReadLine());

                    Console.WriteLine($"Spalanie: {cars[numberCar].ObliczSpalanie(km, paliwo)} litrów na 100 km");

                    IsCorrect = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podano nie prawidłowe dane! Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsCorrect);

            Console.ReadLine();
            Console.Clear();
            ShowMenu(cars);
        }
    }
}
