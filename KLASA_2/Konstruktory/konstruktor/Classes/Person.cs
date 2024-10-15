using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konstruktor.Classes
{
    internal class Person
    {
        // Statyczne pole, które przechowuje liczbę obiektów klasy Person
        public static int Counter = 0;

        // Właściwości
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }

        // Konstruktor statyczny jest wywoływany automatycznie aby zainicjować klasę przed utworzeniem 1-szej instancji.
        // Konstruktor statyczny jest wywoływany tylko raz przed pierwszym użyciem typy.
        // Nie może mieć parametrów ani idyntyfikatorów dostępu.
        // Służy do inicjonowania pół statycznych lub wykonywania innych operacji statycznych.
        // (Wykonywania dowolnego kodu, który jest związany z klasą a nie z jej obiektami np. )

        static Person()
        {
            Console.WriteLine("Konstruktor domyslny klasy Person");
            Console.WriteLine("Statyczny konstruktor klasy Person");
            // Counter++;

        }

        // Konstruktor domyślny jest bezparametrowy.
        // Jeśli klasa nie ma rzadnego Konstruktora to Konstruktor domyślny jest wywoływany przy tworzeniu obiektu.
        // Inicjiuje on wszystkie pola do ich wartości domyślnych.
        // Jeśli dyfiniujemy jakiś konstruktor parametryczny to nie otrzymamy automatycznie konstruktora domyślnego.
        // Możemy go samodzielnie zadeklarować.

        // Dodać konstruktor domyślny
        public Person() 
        {
            Name = "Nieznane";
            Surname = "Nieznane";
            Counter++;
        }

        // Konstrktor parametryczny ma coajmniej jeden parametr.
        // Służy do inicjowania pól obiektu zgodnie z wartościami podanymi przy tworzeniu obiektów.
        // Możemy mieć wiele onstruktorów parametrycznych, o ile różnią się liczbą lub typem paraetrów.

        // Konstruktor parametryczny z jednym parametrem
        public Person(string name)
        {
            Console.WriteLine("Konstruktor parametryczny z jednym parametrem \n");
            Name = name;
            Counter++;
        }

        // Konstruktor parametryczny z dwoma parametrami
        public Person(string name, string surname)
        {
            Console.WriteLine("Konstruktor parametryczny z dwoma parametrami \n");
            Name = name;
            Surname = surname;
            Counter++;
        }

        // Konstruktor parametryczny z trzema parametrami
        public Person(string name, string surname, int age)
        {
            Console.WriteLine("Konstruktor parametryczny z dwoma parametrami \n");
            Name = name;
            Surname = surname;
            Age = age;
            Counter++;
        }

        // Konstruktor parametryczny z czterma parametrami
        // THI służy do wywołania innego konstruktora tej samej klasy,
        // czyli konstruktora parametrycznego z trzema parametrami.
        // Dziaki temu konstruktor z czterema parametrami nie musi
        // inicjować pól Name, Surname, Age, a może skupić się na dodaniu pola Height.
        // Jest to sposób na uniknięcie powtarzania kodu i zapełnienia spójności pracy.
        public Person(string name, string surname, int age, float height) :this(name, surname, age) 
        {
            Console.WriteLine("Konstruktor parametryczny z czterma parametrami \n");
            Height = height;    
            Counter++;
        }
                
        public string GetData()
        {
            return $"Imię i nazwisko: {Name} {Surname}, wiek: {Age}, wysokość: {Height}";
        }
    }

}
