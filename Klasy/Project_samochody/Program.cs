using Project_samochody.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_samochody
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // domyślny
            Samochod s1 = new Samochod();

            // marka, model, rok produkcji
            Samochod s2 = new Samochod("BMW", "29", 1999);

            // marka, model, rok produkcji, pojemność silnika
            Samochod s3 = new Samochod("Citroen", "c4", 2006, 3.5);

            // marka, model, rok produkcji, pojemność silnika, czy diesel
            Samochod s4 = new Samochod("Citroen", "c5", 2009, 5.9, false);

            // marka, model, rok produkcji, pojemność silnika, czy diesel, data zakupu, status samochodu
            Samochod s5 = new Samochod("Citroen", "c5", 2009, 5.9, true, "03.01.2017", statusSamochodu.Nowy);

            s5.WyswietlInformacje();
            Console.WriteLine();

            s4.ObliczWiekSamochodu();
        }
    }
}
