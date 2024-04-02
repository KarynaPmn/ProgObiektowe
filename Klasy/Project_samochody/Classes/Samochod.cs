using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_samochody.Classes
{
    enum statusSamochodu
    {
        Nowy,
        Używany,
        Zabytkowy,
        brak
    }

    internal class Samochod
    {
        private string Marka {  get; set; }
        private string Model { get; set; }
        private int RokProdukcji { get; set; }
        private double PojemnoscSilnika { get; set; }
        private bool CzyDiesel {  get; set; }
        private DateTime DataZakupu { get; set; }
        private statusSamochodu StatusSamochodu { get; set; }

        public Samochod()
        {
            Marka = "nieznane";
            Model = "nieznane";
            RokProdukcji = 0000;
            PojemnoscSilnika = 0.0;
            CzyDiesel = false;
            DataZakupu = new DateTime(00,00,00);
            StatusSamochodu = statusSamochodu.brak;
        }

        public Samochod(string marka, string model, int rokProdukcji)
        {
            Marka = marka;
            Model = model;
            RokProdukcji = rokProdukcji;
        }

        public Samochod(string marka, string model, int rokProdukcji, double pojemnoscSilnika) : this(marka, model, rokProdukcji)
        {
            PojemnoscSilnika = pojemnoscSilnika;
        }

        public Samochod(string marka, string model, int rokProdukcji, double pojemnoscSilnika, bool czyDiesel) : this(marka, model, rokProdukcji, pojemnoscSilnika)
        {
            CzyDiesel = czyDiesel;
        }

        public Samochod(string marka, string model, int rokProdukcji, double pojemnoscSilnika, bool czyDiesel, string dataZakupu, statusSamochodu statusSamochodu) : this(marka, model, rokProdukcji, pojemnoscSilnika, czyDiesel)
        {
            DataZakupu = DateTime.Parse(dataZakupu);
            StatusSamochodu = (statusSamochodu)Enum.Parse(typeof(statusSamochodu), Console.ReadLine());
        }


        public void WyswietlInformacje()
        {
            Console.WriteLine("INFORMACJE O SAMOCHODZIE:");
            Console.WriteLine("1) Marka: {0}", Marka);
            Console.WriteLine("2) Model: {0}", Model);
            Console.WriteLine("3) Rok produkcji: {0}", RokProdukcji);
            Console.WriteLine("4) Pojemność silnika: {0}", PojemnoscSilnika);
            Console.WriteLine("5) Czy diesel: {0}", CzyDiesel ? "tak" : "nie");
            Console.WriteLine("6) Data zakupu: {0}", DataZakupu);
            Console.WriteLine("7) Status: {0}", StatusSamochodu);
        }

        public string ObliczWiekSamochodu()
        {
            DateTime today = DateTime.Now;
            int wiekSamochodu = today.Year - DataZakupu.Year;
            return Convert.ToString(wiekSamochodu);
        }
    }
}
