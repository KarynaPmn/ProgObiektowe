using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SPR_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Grupa 2

            //Napisz program, który:

            //Definiuje funkcję UtworzTabliceLiczb(int n), która przyjmuje jako parametr liczbę całkowitą n i zwraca tablicę jednowymiarową o długości n, wypełnioną liczbami z zakresu od 1 do 10, które podaje użytkownik z klawiatury
            //Definiuje funkcję ObliczPole(int a), która przyjmuje jako parametr liczbę całkowitą a i zwraca wartość pola kwadratu o boku a.Wzór na pole kwadratu to:
            //            P = a2

            //Definiuje funkcję ObliczObwod(int a), która przyjmuje jako parametr liczbę całkowitą a i zwraca wartość obwodu kwadratu o boku a.Wzór na obwód kwadratu to:
            //            O = 4a

            //            W funkcji Main:
            //Deklaruje zmienną n i przypisuje jej wartość 5.
            //Wywołuje funkcję UtworzTabliceLiczb(n) i przypisuje jej wynik do zmiennej tablica.
            //Wyświetla na ekranie zawartość tablicy tablica.

            //Dla każdego elementu tablicy tablica:
            //Wywołuje funkcję ObliczPole i przypisuje jej wynik do zmiennej pole.
            //Wywołuje funkcję ObliczObwod i przypisuje jej wynik do zmiennej obwod.

            //Wyświetla na ekranie informację o polu i obwodzie kwadratu o boku równym danemu elementowi tablicy.
            //Napisz funkcję, która umożliwia podanie w parametrze indeksu tablicy a następnie zwróci ona wynik pola i obwodu kwadratu
            try
            {

                int n = 5; // dl. tablicy
            
                int[] Tablica = UtworzTabliceLiczb(n);

                Console.Write("\nElementy tablicy: ");
                foreach (var i in Tablica)
                    Console.Write(i + " ");
                Console.WriteLine("\n");

                int indeks = 0;
                foreach (var i in Tablica)
                {
                    int pole = ObliczPole(i);
                    int obwod = ObliczObwod(i);
                    Console.WriteLine($"Dla elementu {indeks}: Pole = {pole} a Obwód = {obwod}");
                    indeks++;
                }
                Console.WriteLine("\n");

                WypiszWartoscElementuIndeks(n);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }

        static int[] UtworzTabliceLiczb(int n)
        {
            int[] T = new int[n];

            for (int i = 0; i < n; i++) 
            {
                Console.Write($"Podaj {i} element tablicy: ");
                string a = Console.ReadLine();
                if (int.TryParse(a, out int liczba) && liczba > 0 && liczba < 10)
                    T[i] = liczba;
                else
                {
                    Console.WriteLine("Podano nie prawidłe dane. Wpisz liczbę całkowitą od 1 do 10.");
                    i--;
                }
            }
            return T;
        }

        static int ObliczPole(int a)
        {
            return a * 2;
        }

        static int ObliczObwod(int a)
        {
            return a * 4;
        }

        static void WypiszWartoscElementuIndeks(int dlugosc)
        {
            int pole;
            int obwod;
            bool isCorrect = false;

            do
            {
                Console.Write($"Podaj indeks tablicy od 0 do {dlugosc - 1}: ");
                string a = Console.ReadLine();
                if (int.TryParse(a, out int liczba) && liczba > 0 && liczba < 10)
                {
                    liczba++;
                    pole = ObliczPole(liczba);
                    obwod = ObliczObwod(liczba);
                    Console.WriteLine($"Dla {a}: Pole = {pole} a Obwód = {obwod}");
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Podano nie prawidłe dane. Wpisz liczbę od 1 do 10.");
                }

            }while (isCorrect == false);

        }
    }
}
