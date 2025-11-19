using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public interface IPlatnosc
        {
            string Autoryzuj();
            string PobierzOpis();
        }

        public class KartaPlatnicza : IPlatnosc
        {
            public string Autoryzuj() => "KartaPłatnicza: Rozpoczynam autoryzację...";
            public string PobierzOpis() => "KartaPłatnicza: Łączę się z systemem VISA/Mastercard.";
        }

        public class PayPal : IPlatnosc
        {
            public string Autoryzuj() => "PayPal: Rozpoczynam autoryzację...";
            public string PobierzOpis() => "PayPal: Nawiązuję połączenie z kontem użytkownika.";
        }

        public abstract class FabrykaPlatnosci
        {
            public abstract IPlatnosc UtworzPlatnosc();

            public void ZrealizujTransakcje(decimal kwota)
            {
                IPlatnosc platnosc = UtworzPlatnosc();
                Console.WriteLine($"[Transakcja] Kwota: {kwota} PLN");
                Console.WriteLine(platnosc.Autoryzuj());
                Console.WriteLine(platnosc.PobierzOpis());
                Console.WriteLine("[Transakcja] Płatność zakończona pomyślnie.\n");
            }

        }

        public class FabrykaKart : FabrykaPlatnosci
        {
            
            public override IPlatnosc UtworzPlatnosc()
            {   
                return new KartaPlatnicza();
            }
        }

        public class FabrykaPayPal : FabrykaPlatnosci
        {
            public override IPlatnosc UtworzPlatnosc()
            {
                return new PayPal();
            }
        }

        static void Main(string[] args)
        {
            FabrykaPlatnosci fabrykaPlatnosci;

            fabrykaPlatnosci = new FabrykaKart();
            fabrykaPlatnosci.ZrealizujTransakcje(150.00m);

            fabrykaPlatnosci = new FabrykaPayPal();
            fabrykaPlatnosci.ZrealizujTransakcje(50.00m);

            Console.ReadKey();
        }
    }
}
