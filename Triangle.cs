using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace krk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sprawdza dane
            //double a;
            //if (double.TryParse(Console.ReadLine(), out a))
            //    Console.WriteLine(a);
            //else
            //    Console.WriteLine("Błędne dane.");

            bool isCorrect = false;
            do
            {
                Console.WriteLine("Podaj a: ");
                double a;
                while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
                    Console.WriteLine("Wpisz trawidłowe dane!");

                Console.WriteLine("Podaj b: ");
                double b;
                while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
                    Console.WriteLine("Wpisz trawidłowe dane!");

                Console.WriteLine("Podaj c: ");
                double c;
                while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
                    Console.WriteLine("Wpisz trawidłowe dane!");


                if (IsTriang(a, b, c))
                {
                    isCorrect = true;
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.WriteLine("Pole trójkąta o bokach {0}, {1}, {2} wynosi: {3:F2}cm\u00B2", a, b, c, Heron(a, b, c));
                }
                else
                {
                    Console.WriteLine("Podane boki nie tworzą trójkąta.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            } while (!isCorrect);


            Console.ReadKey();
        }
        static bool IsTriang(double a, double b, double c)
        {
            return (a + b > c && b + c > a && c + a > b);
        }

        static double Heron(double a, double b, double c)
        {
            double p = (a + b + c) / 2; // połowa obwodu trójkąta
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }
    }
}
