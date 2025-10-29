using System;

namespace ConsoleApp1
{
    internal class Program
    {
        public class PokojHotelowy
        {
            public string Typ { get; set; }
            public string Balkon { get; set; }
            public string Klimatyzacja { get; set; }
            public string Telewizor { get; set; }
            public string Lodowka { get; set; }

            public void WyswietlInfo()
            {
                Console.WriteLine($"Pokój: {Typ}");
                Console.WriteLine($"Balkon: {Balkon}");
                Console.WriteLine($"Klimatyzacja: {Klimatyzacja}");
                Console.WriteLine($"Telewizor: {Telewizor}");
                Console.WriteLine($"Lodówka: {Lodowka}");
                Console.WriteLine();
            }
        }

        public interface IPokojBuilder
        {
            void UstawTyp();
            void DodajBalkon();
            void DodajKlimatyzacje();
            void DodajWyposazenie();
            PokojHotelowy PobierzPokoj();
        }

        public class StandardowyPokojBuilder : IPokojBuilder
        {
            private PokojHotelowy pokojHotelowy = new PokojHotelowy();

            public void UstawTyp() => pokojHotelowy.Typ = "Standardowy";
            public void DodajBalkon() => pokojHotelowy.Balkon = "Nie";
            public void DodajKlimatyzacje() => pokojHotelowy.Klimatyzacja = "Tak";
            public void DodajWyposazenie()
            {
                pokojHotelowy.Telewizor = "Tak";
                pokojHotelowy.Lodowka = "Nie";
            }

            public PokojHotelowy PobierzPokoj() => pokojHotelowy;
        }

        public class LuksusowyPokojBuilder : IPokojBuilder
        {
            private PokojHotelowy pokojHotelowy = new PokojHotelowy();

            public void UstawTyp() => pokojHotelowy.Typ = "Luksusowy";
            public void DodajBalkon() => pokojHotelowy.Balkon = "Tak";
            public void DodajKlimatyzacje() => pokojHotelowy.Klimatyzacja = "Tak";
            public void DodajWyposazenie()
            {
                pokojHotelowy.Telewizor = "Tak";
                pokojHotelowy.Lodowka = "Tak";
            }

            public PokojHotelowy PobierzPokoj() => pokojHotelowy;
        }

        public class Recepcja
        {
            public PokojHotelowy PrzygotujPokoj(IPokojBuilder builder)
            {
                builder.UstawTyp();
                builder.DodajBalkon();
                builder.DodajKlimatyzacje();
                builder.DodajWyposazenie();
                return builder.PobierzPokoj();
            }
        }

        static void Main(string[] args)
        {
            Recepcja recepcja = new Recepcja();

            var standardowyBuilder = new StandardowyPokojBuilder();
            PokojHotelowy pokojStandardowy = recepcja.PrzygotujPokoj(standardowyBuilder);
            pokojStandardowy.WyswietlInfo();

            var luksusowyBuilder = new LuksusowyPokojBuilder();
            PokojHotelowy pokojLuksusowy = recepcja.PrzygotujPokoj(luksusowyBuilder);
            pokojLuksusowy.WyswietlInfo();

            Console.ReadKey();
        }
    }
}
