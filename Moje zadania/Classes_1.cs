using System;

namespace o
{

    // W klasach są używane modyfikatiry dostępu: private, public, protected, internal (domyślnie ustawione jest private)

    public class Person
    {
        private string _name;

        public string SecondName { get; set; }


        // Właściłość Name w krótszej wersji to Name {get; set}
        public string Name // property -- właściwsści
        {
            get // metod
            {
                return _name;
            }
            set // metod
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Pole imię nie może być puste.");
                 
                _name = value;
                // _name = "Najwyższy Król Elthame " + value;
            }
        }

        public string FullName
        {
            get{
                return "\nIsota: " + SecondName + " " + Name;
            }
        }

        public string ShortName
        {
            get
            {
                return $"{SecondName} {Name.Substring(0, 1)}.";
            }
        }

        // Opisanie get i set:
       
        //public string GetName()
        //{
        //    return _name;
        //}

        //public void SetName(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //        throw new ArgumentNullException("Pole imię nie może być puste.");

        //    _name = name;
        //}


        /////   KONSTRUKTOR     /////
        ///

        public Person(string secondName, string name, int age)     // nazwa konstruktora musi mieć taką sama nazwę jak i sam class
        {
            // Sprawdzenie wprowadzonych danych
            if (age < 0)
                throw new ArgumentOutOfRangeException("Nie mozna podać liczbę lat ujemną.");

            SecondName = secondName;
            Name = name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // W konstruktorach
            Person P = new Person("Najwyższy król Elthame", "Cardan", 000);

            // W klasach
            //Person P = new Person();
            //P.Name = "Cardan";
            //P.SecondName = "Najwyższy Król Elthame";

            Console.WriteLine(P.FullName);
            Console.WriteLine("Skrót: {0}", P.ShortName);

            //P.SetName("Cardan");
            //Console.WriteLine(P.GetName());

            Console.ReadKey();
        }
    }
}
