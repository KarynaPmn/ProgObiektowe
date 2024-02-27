using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_10_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            // 1.) Napisz program w C#, który wczytuje liczbę całkowitą od użytkownika i oblicza jej pierwiastek kwadratowy.
            // 2.) Jeśli liczba jest ujemna, program powinien zgłosić wyjątek ArgumentOutOfRangeException i wyświetlić odpowiedni komunikat. 
            // 3.) Jeśli użytkownik wprowadzi nieprawidłowe dane, program powinien zgłosić wyjątek FormatException i poprosić o ponowne wprowadzenie liczby.
            // 4.) Program powinien działać w pętli, dopóki użytkownik nie wpisze q.Użyj instrukcji try-catch-finally do obsługi wyjątków.

            /////////////// MY CODE ///
            
            bool isCorrect = false;

            do
            {
                try 
                {
                    Console.Write("Podaj a: ");
                    string u = Console.ReadLine();
                    if (u == "q")
                    {
                        Console.WriteLine("Koniec programu");
                        break;
                    }

                    int a = Convert.ToInt32(u);
                    if (a < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new Exception("Podano ujemną liczbę."); 
                        Console.ResetColor();
                    }
                    double pierwiastek = Math.Sqrt(a);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Pierwiastek: {pierwiastek}");
                    Console.ResetColor();
                    //isCorrect = true;
                }
                catch (ArgumentOutOfRangeException )
                {
                    ErrorColor("Liczba nie jest całkowita.\n");
                }
                catch (FormatException)
                {
                    ErrorColor("Dane są nie poprawne. Podaj liczbę całkowitą.\n");
                }
                catch (Exception ex)
                {
                    ErrorColor("Błąd: " + ex.Message + "\n");
                }
 
            } while (!isCorrect);

            Console.ReadKey();
//////////////////////////////////////////////////////////////////////////////////////////////////           


//////////// ZADANIE 1///

            
            string input;
            do
            {
                Console.WriteLine("Podaj liczbę całkowitą lub 0, aby wyjść z programu.");
                input = Console.ReadLine();
                if (input == "q") { break; }


                try
                {
                    int number = int.Parse(input);
                    if (number < 0)
                        throw new ArgumentOutOfRangeException("Liczba nie może byc ujemna.");
                    if (number > 0)
                    {
                        double sqrt = Math.Sqrt(number);
                        Console.WriteLine($"Pierwiastek z { number } wynosi: {sqrt}");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Błąd: {ex.ParamName}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nNieprawidłowe dane wyjściowe. Podaj prawidłową liczbę całkowitą.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nNieprawidłowe dane wyjściowe. Przekroczony zakres liczby <{int.MinValue} , {int.MaxValue}>. Podaj prawidłową liczbę całkowitą.");
                }
                finally
                {
                    Console.WriteLine("\nDziękujemy za skorzystnie z programu! :)");
                    Console.WriteLine();
                }
            } while (input != "q");

//////////////////////////////////////////////////////////////////////////////////////////
          
            // Zadanie 2.
            // Napisz program w C#, który wczytuje od użytkownika 5 liczb całkowitych i zapisuje je w tablicy. 
            // Następnie program prosi użytkownika o podanie indeksu tablicy i wyświetla liczbę znajdującą się pod tym indeksem. 
            // Jeśli użytkownik wprowadzi indeks spoza zakresu tablicy, program powinien zgłosić wyjątek ArgumentOutOfRangeException
            // i wyświetlić odpowiedni komunikat.Jeśli użytkownik wprowadzi nieprawidłowe dane, program powinien zgłosić wyjątek FormatException
            // i poprosić o ponowne wprowadzenie danych.Program powinien działać w pętli, dopóki użytkownik nie wpisze q.
            // Użyj instrukcji try-catch do obsługi wyjątkówJeśli liczba jest ujemna, program powinien zgłosić wyjątek ArgumentOutOfRangeException
            // i wyświetlić odpowiedni komunikat. 
            // Jeśli użytkownik wprowadzi nieprawidłowe dane, program powinien zgłosić wyjątek FormatException i poprosić o ponowne wprowadzenie liczby.

            /////////////// MY CODE /// --> nie dokończone!
            
            string number_user;
            bool isCorrect = false;
            do
            {
                try
                {
                    int[] T = new int[5];
                    for (int i = 0; i < T.Length; i++)
                    {
                        Console.Write($"Podaj {i++} liczbę: ");
                        number_user = Console.ReadLine();
                        if (number_user == "q")
                        {
                            isCorrect = true;
                            break;
                        }
                        T[i] = Convert.ToInt32(number_user);
                    }

                    Console.Write("\nPodaj indeks tablicy: ");
                    int indeks = int.Parse(Console.ReadLine());
                    if (indeks < 0 || indeks > T.Length)
                        throw new ArgumentOutOfRangeException($"\nPodano index spoza zakresu tablicy. Podaj prawidłowy index od 0 do {T.Length - 1}");

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPodano nie przwidłowe dane. Wpisz poprawną liczbę całkowitą.");
                }
                catch (ArgumentOutOfRangeException ae)
                {
                    Console.WriteLine($"\nBłąd: {ae.ParamName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nBłąd: {ex.Message}");
                }
            } while (!isCorrect);
            
            ////////////// ZADANIE 2. ///
            int[] array = new int[5];
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Wprowadź 5 liczb całkowitych");
                try
                {
                    for (int i = 0; i < array.Length; i++) 
                    {
                        Console.Write($"\nPodaj liczbę {i + 1}: ");
                        array[i] = int.Parse( Console.ReadLine() );
                    }
                    isCorrect = true;   
                }
                catch (FormatException)
                { Console.WriteLine("\nNieprawidłowe dane. Wprowadź poprawną liczbe całkowitą."); }
                catch (OverflowException)
                { Console.WriteLine("\nNieprawidłowe dane. Liczba spoza zakresu <--, -->"); }
            } while (!isCorrect);

            int index = 0;
            string input;

            do
            {
                Console.Write("\nWprowadź index tablicy: ");
                input = Console.ReadLine();

                if (input == "q")
                    break;

                try
                {
                    index = int.Parse(input);

                    if (index > array.Length - 1 || index < 0)
                        throw new OverflowException("\nBłąd: !!!");
                    Console.WriteLine($"Liczba pod indeksem {index} to {array[index]}\n");
                }
                catch (FormatException)
                { Console.WriteLine("\nNieprawidłowe dane. Wprowadź liczbę całkowitą."); }
                catch (IndexOutOfRangeException)
                { Console.WriteLine("\nPoza zakresem."); }
                catch(OverflowException)
                { Console.WriteLine(""); }
            } while (true);

            Console.ReadKey();
        }

        static void ErrorColor(string error)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor ();
        }

        
    }
}
