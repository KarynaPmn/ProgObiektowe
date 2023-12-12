using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace kkk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> slownik = new Dictionary<int, string>();
            slownik.Add(1, "Franek");
            slownik.Add(2, "Anna");
            slownik.Add(3, "Tomasz");

            foreach (var item in slownik)
                Console.WriteLine($"{item.Value}");

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////
            /// Tworzymy słownik, który przechowuje łańcuchy jako klucze i liczby jako wartości
            Dictionary<string, int> slownik1 = new Dictionary<string, int>();

            // Dodajemy kilka par kluczy-wartość do słownika
            slownik1.Add("jeden", 1);
            slownik1.Add("dwa", 2);
            slownik1.Add("trzy", 3);

            // Wyświetlenie zawartości słownika za pomocą pętli foreach
            // SP. 1
            foreach (var item in slownik1)
                Console.WriteLine("Klucz: {0}, wartość: {1}", item.Key, item.Value);
            // SP. 2
            foreach (KeyValuePair<string, int> item in slownik1)
                Console.WriteLine("Klucz: {0}, wartość: {1}", item.Key, item.Value);
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////
            // Utwórz słownik, który może przechwywać łańcuchy jako klucze i wartości 
            Dictionary<string, string> capital = new Dictionary<string, string>();

            // Dodaj kilka par klucz-wartoćś do słownika za pomocą składni inicjalizatora kolekcji
            capital = new Dictionary<string, string>
            {
                { "Polska", "Warszawa"},
                { "Niemcy", "Berlin"},
                { "Francja", "Paryż"},
                { "Włochy", "Rzym"},
            };

            foreach (var item in capital)
            {
                Console.WriteLine("Kraj: {0}, stolica: {1}", item.Key, item.Value);
            }

            ////////////////////////////////////////////////////
            Dictionary<string, string> phones = new Dictionary<string, string>();
            phones.Add("+48 123 444 234", "Katarzyna");
            phones.Add("+48 234 456 764", "Tomasz");
            phones.Add("+48 987 765 543", "Anna");
            //phones.Add("+48 987 765 543", "Krystyna");// ERROR: Klucze nie mogą się powtarzać

            foreach (KeyValuePair<string, string> item in phones)
                Console.WriteLine("Numer telefonu: {0}, osoba: {1}", item.Key, item.Value);
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////////////////////

            Dictionary<string, string> animals = new Dictionary<string, string>();
            animals = new Dictionary<string, string>()
            {
                { "pies", "hauhau"},
                { "kot", "miaumiau"},
                { "krowa", "muu"},
                { "koń", "iha"},
            };

            foreach (var item in animals)
                Console.WriteLine("Zwierzę: {0}, dżwięk: {1}", item.Key, item.Value);
            Console.WriteLine();
            ////////////////////////////////////////////////////////////////////////////
            
            Dictionary<string, string> colors = new Dictionary<string, string>();

            colors.Add("biały", "#FFFFFF");
            colors.Add("czarny", "#000000");
            colors.Add("czerwony", "#FF0000");
            colors.Add("zielony", "#00FF00");
            colors.Add("niebieski", "#0000FF");

            foreach (var color in colors)
                Console.WriteLine("Kolor: {0}, Hex: {1}", color.Key, color.Value);
            Console.WriteLine();
            
            ///////////////////////////////////////////////////////////////////////////
            
            Dictionary<string, string> data = new Dictionary<string, string>();

            // Poproś użytkownika o podanie liczby par klucz-wartość
            Console.Write("Podaj ile par klucz-wartośc chcesz wprowadzić: ");
            int n = int.Parse(Console.ReadLine());

            // W pętli pobieraby od użytkownika klucz i wartość następnie dodamy do słownika
            for (int i = 0; i < n; i++)
            {
                Console.Write("Podaj klucz: ");
                string key = Console.ReadLine();
                Console.Write("Podaj wartość: ");
                string value = Console.ReadLine();
                data.Add(key, value);
            }

            foreach (var item in data)
                Console.WriteLine("Klucz: {0}, wartość: {1}", item.Key, item.Value);
            Console.WriteLine();

            ///// ZADANIE /////
            //  Napisz funkcję, która przyjmuje jako argument listę liczb całkowitych i zwraca słownik, w którym kluczem jest liczba, a wartością jest jej częstotliwość występowania na liście.
            //  Jeśli lista jest pusta lub null, funkcja powinna zwrócić pusty słownik.
            //  Przykład: dla listy[1, 2, 3, 2, 4, 1, 5, 2] funkcja powinna zwrócić słownik { 1: 2, 2: 3, 3: 1, 4: 1, 5: 1}.
            //  Napisz program, który wczytuje od użytkownika ciąg znaków, próbuje przekonwertować go na liczbę całkowitą za pomocą metody TryParse, a następnie wyświetla wynik na konsoli.
            //  Jeśli konwersja się powiedzie, program powinien wyświetlić liczbę i informację, że jest to poprawna liczba całkowita.
            //  Jeśli konwersja się nie powiedzie, program powinien wyświetlić informację, że podany ciąg znaków nie jest poprawną liczbą całkowitą.
            //  Przykład: dla ciągu znaków “123” program powinien wyświetlić “123 jest poprawną liczbą całkowitą”.
            //  Dla ciągu znaków “abc” program powinien wyświetlić “abc nie jest poprawną liczbą całkowitą”.
            ///
          // NEDOKONCZONE!
            Console.WriteLine("\nZadanie");
            string cZnaki = Console.ReadLine();
            if (int.TryParse(cZnaki, out int znaki))
            {
                Console.WriteLine("Ciąg znaków jest poprawny!");
            }
            else
            {
                Console.WriteLine("Ciąg znaków jest niepoprawny!");
            }

            string[] L =  cZnaki.Split();
            List<string> l = L;

            Dictionary<int, int> D = Slownik(L);
            foreach (var d in D)
                Console.WriteLine("{0} wystepuje {1} razy", d.Key, d.Value);
            Console.ReadKey();                   
        }

        static Dictionary<int, int> Slownik(string[] T)
        {
            Dictionary<int, int> D = new Dictionary<int, int>();
            foreach (var i in T)
                if (D.ContainsKey(i))
                    D[i]++;
                else
                    D[i] = 1;

            return D;
        }
    }
}
