using System;
using System.Collections.Generic;
using System.Linq;
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
            // Utwórz listę liczb całkowitych i wypełnij ją losowymi wartościami z zakresu od 1 do 100.
            // Napisz metodę, która przyjmuje jako parametr listę liczb i zwraca listę liczb, które są podzielne przez 3 lub 5.
            // Wyświetl na konsoli listę liczb losowych i listę liczb podzielnych przez 3 lub 5.

            List<int> L = new List<int>();
            Random rand = new Random();
            for(int i = 0; i < 10; i++) 
                L.Add(rand.Next(1, 100));
            List<int> L_new = PodzielnePrzez_3_5(L);

            Console.WriteLine("\nLista liczb losowych:");
            foreach (var i in L)
                Console.Write(i + " ");
            Console.WriteLine("\nLista liczb z listy podzielnych przez 3 lub 5:");
            foreach (var i_new in L_new)
                Console.Write(i_new + " ");

            List<int> PodzielnePrzez_3_5(List<int> T)
            {
                for(int i = 0; i < T.Count ; i++)
                    if (T[i] % 3 != 0 || T[i] % 5 != 0)
                        T.Remove(T[i]);

                return T;
            }
            Console.ReadKey();







        }
    }
}
