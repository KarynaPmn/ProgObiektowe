using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptoject_try_catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine("Podaj dwie liczby:\n");
                Console.Write("Podaj a: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Podaj b: ");
                int y = int.Parse(Console.ReadLine());
                //if (y == 0)
                //    throw new Exception("Nie można dzielić prze zero!");
                double result = x / y;

                Console.Write($"Wynik dzielenia {x} / {y} = ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{result:F2}");
                Console.ResetColor();
            }
            catch (DivideByZeroException ex)
            {
                ErrorColorChange("Nie wolno dzielić przez 0.");
                //Console.WriteLine("Nie wolno dzielić przez 0.");
            }
            catch (FormatException)
            {
                ErrorColorChange("Błędny format danych, podaj podal liczbę zmiennoprzecinkową lub całkowitą.");
                //Console.WriteLine("Błędny format danych, podaj podal liczbę zmiennoprzecinkową lub całkowitą.");
            }
            catch (OverflowException)
            {
                ErrorColorChange($"Podana liczba jest błędna, podaj dane z zakresu <{int.MinValue}; {int.MaxValue}>");
                //Console.WriteLine($"Podana liczba jest błędna, podaj dane z zakresu <{int.MinValue}; {int.MaxValue}>");
            }
            catch (Exception ex)
            {
                ErrorColorChange($"Błąd: {ex.Message}");
                //Console.WriteLine($"Błąd: {ex.Message}");
            }
            // Ważna jest kolejność!

            Console.ReadKey();
        }

        static void ErrorColorChange(string comment)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Błąd: {comment}");
            Console.ResetColor();
        }
    }
}
