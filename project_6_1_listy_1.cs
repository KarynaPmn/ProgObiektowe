using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace project_6_1_listy_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzele listy liczb całkowitych
            List<int> ints = new List<int>();

            // Tworzenie listy liczb całkowitych z początkowymi elementami, używając inicjalizatora kolekcji
            List<int> ints1 = new List<int>() { 2, 1, 10, -2};

            // Dodanie elementów do listy za pomocą Add()
            ints1.Add(10);
            ints1.Add(15);

            // Usuwanie elementów z listy za pomocą metody Remove()
            ints1.Remove(1);

            // Wyświetlenie długości listy za pomocą właściwości Count
            Console.WriteLine($"Długość listy: {ints1.Count}"); 

            // Wyświetlenie elementów listy 
            foreach(int i in ints) { Console.Write($"{i} "); } // 2, 1, 10, -2, 10, 15

            ints1.Remove(1);
            foreach (int i in ints) { Console.Write($"{i} "); } // 2, 10, -2, 10, 15

            ///// ZADANIA /////
            /// ZAD_1
            // Napisz program, który tworzy listę liczb całkowitych i wypełnia ją losowymi wartościami z zakresu od 1 do 100.
            // Napisz program, który wyświetla menu z pięcioma opcjami, co chcesz zrobić z listą:
            // Wyświetlić listę liczb podzielnych przez 3 lub 5
            // Wyświetlić listę liczb nieparzystych
            // Wyświetlić listę liczb posortowanych rosnąco
            // Wyświetlić listę liczb posortowanych malejąco
            // Wyjść z programu
            // Napisz metodę dla każdej opcji, która przyjmuje jako parametr listę liczb i zwraca listę liczb spełniających warunek danej opcji.
            // Napisz kod, który obsługuje wybór użytkownika i wywołuje odpowiednią metodę, a następnie wyświetla wynikową listę na konsoli.
            // Napisz kod, który powtarza wyświetlanie menu i obsługę wyboru, dopóki użytkownik nie wybierze opcji wyjścia z programu.

            /// ZADANIE 1
            List<int> L = new List<int>();

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
                L.Add(rand.Next(1, 100));

            //List<int> L_new = PodzielnePrzez_3_5(L);

            //Console.WriteLine("\nLista liczb losowych:");
            //foreach (var i in L)
            //    Console.Write(i + " ");
            //Console.WriteLine("\nLista liczb z listy podzielnych przez 3 lub 5:");
            //foreach (var i_new in L_new)
            //    Console.Write(i_new + " ");
            ////

            /// ZADANIE 2
            // Deklaracja zmiennej podanej prze użytkownika
            int choice;

            // Tworzenie pętli do wyświetlenie menu i obsługi wyboru
            do
            {
                Console.WriteLine("1. Wyświetlić listę liczb podzielnych przez 3 lub 5");
                Console.WriteLine("2. Wyświetlić listę liczb nieparzystych");
                Console.WriteLine("3. Wyświetlić listę liczb posortowanych rosnąco");
                Console.WriteLine("4. Wyświetlić listę liczb posortowanych malejąco");
                Console.WriteLine("5. Wyjść z programu");

                Console.Write("Podaj swój wybór: ");
                choice = int.Parse(Console.ReadLine());

                switch(choice) 
                {
                    case 1:
                        List<int> divisible = PodzielnePrzez_3_5(L);
                        Console.WriteLine("Lista liczb podzielonych przez 3 lub 5");
                        foreach (var i in divisible)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        // DOKOŃCZYĆ
                }
            } while (choice != 5);

            Console.ReadKey();

        }

    /// ZAD_1
        static List<int> PodzielnePrzez_3_5(List<int> T)
        {
            List<int> Result = new List<int>();

            foreach (var i in T)                
                if (i % 3 == 0 || i % 5 == 0)
                    Result.Add(i);
            
            return Result;
        }
    /// ZAD_2

    }
}
