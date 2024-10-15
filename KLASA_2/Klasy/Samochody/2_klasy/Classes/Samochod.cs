using Newtonsoft.Json;
using System;

namespace _2_klasy.Classes
{
    enum TypPaliwa
    {
        benzyna,
        diesel,
        elektyczny,
        hybrydowy, 
        nieznany
    }

    internal class Samochod
    {
        public static int IloscKol = 4;
        private string Marka { get; set; }
        private string Model {  get; set; }
        private int RokProdukcji { get; set; }
        public DateTime PierwszaRejestracja {  get; set; }
        public TypPaliwa TypPaliwa { get; set; }
        public float PojemnoscSilnika { get; set; }


        public Samochod()
        {
            Model = "Nieznany";
            Marka = "Nieznany";
            RokProdukcji = 0;
            PierwszaRejestracja = DateTime.MinValue;
            TypPaliwa = TypPaliwa.nieznany;
            PojemnoscSilnika = 0;
        }

        public Samochod(string marka, string model, int rokProdukcji, DateTime pierwszaRejestracja, TypPaliwa typPaliwa, float pojemnoscSilnika)
        {
            Marka = marka;
            Model = model;
            RokProdukcji = rokProdukcji;
            PierwszaRejestracja = pierwszaRejestracja;
            TypPaliwa = typPaliwa;
            PojemnoscSilnika = pojemnoscSilnika;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Marka: {Marka}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Rok produkcji: {RokProdukcji}");
            Console.WriteLine($"Data pierwszej rejestracji: {PierwszaRejestracja.ToShortDateString()}");
            Console.WriteLine($"Typ paliwa: {TypPaliwa}");
            Console.WriteLine($"Pojemność silnika: {PojemnoscSilnika}");
            Console.WriteLine("\n\n");
        }

        public int ObliczWiekSamochodu()
        {
            int age = DateTime.Now.Year - PierwszaRejestracja.Year;
            return age;
        }

        public void ZmienMarkeModel(string marka, string model)
        {
            Marka = marka;
            Model = model;
        }

        // Czy klasyk?
        public bool CzyKlasyk()
        {
            if (ObliczWiekSamochodu() >= 25 && ObliczWiekSamochodu() <= 30)
                return true;
            else return false;
        }

        public string WyswietlInformacjeJSON() 
        {
            var samochodJson = new
            {
                marka = Marka,
                model = Model,
                rokProdukcji = RokProdukcji,
                pierwszaRejestracja = PierwszaRejestracja,
                typPaliwa = TypPaliwa,
                pojemnoscSilnika = PojemnoscSilnika,
            };

            return JsonConvert.SerializeObject(samochodJson);
        }

        public double ObliczSpalanie(double zuzytePaliwo, double przejechaneKilometry)
        {
            return (zuzytePaliwo / przejechaneKilometry) * 100; // litry na 100 km
        }

    }
}
