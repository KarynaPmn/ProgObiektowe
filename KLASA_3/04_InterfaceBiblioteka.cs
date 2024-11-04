// Interfejsy
// - Zdefiniuj klasę Book, która ma reprezentować informacje o książce, takie jak tytuł,
//   autor, rok wydania i cena.
// - Zaimplementuj interfejs IComparable<Book> w klasie Book, który pozwala na
//   porównywanie obiektów typu Book według ich ceny. Aby to zrobić, zdefiniuj metodę
//   CompareTo(Book other), która zwraca liczbę całkowitą oznaczającą relację pomiędzy
//   bieżącym obiektem a innym obiektem typu Book.
// - Zdefiniuj konstruktor klasy Book, który przyjmuje jako parametry tytuł, autora, rok
//   wydania i cenę książki i inicjalizuje odpowiednie pola klasy.
// - Zdefiniuj metodę ToString() klasy Book, która zwraca reprezentację tekstową obiektu
//   typu Book, składającą się z tytułu, autora, roku wydania i ceny książki, oddzielonych
//   przecinkami.
// - Zdefiniuj klasę Program, która zawiera metodę Main, w której utwórz listę książek
//   typu Book i dodaj do niej kilka przykładowych obiektów.
// - Posortuj listę książek według ceny, używając metody Sort klasy List<T>. Wyświetl
//   posortowaną listę na konsoli, używając metody ToString() klasy Book.
// - Posortuj listę książek według innych kryteriów, np. daty publikacji, autora, tytułu,
//   używając metod OrderBy, OrderByDescending i ThenBy z przestrzeni nazw
//   System.Linq. Wyświetl posortowane listy na konsoli, używając metody ToString() klasy
//   Book.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Interface
{
    class Book : IComparable<Book>
    {
        string title;
        public string author;
        public int yearOfPublication;
        public double price;

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return price.CompareTo(other.price);
        }

        //public int CompareTo(Book other)
        //{
        //    if (other == null) return 1;
        //    return author.CompareTo(other.author);
        //}

        public Book(string title, string author, int yearOfPublication, double price)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{title}, {author}, {yearOfPublication}, {price} zł";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Hobbit", "Nowak", 1954, 45.99));
            books.Add(new Book("Hobbit1", "Pawlak", 2000, 155.99));
            books.Add(new Book("Hobbit2", "Arbuz", 1943, 788.99));
            books.Add(new Book("Hobbit3", "Karbuz", 1937, 95.99));

            books.Sort(); // CompareTo()
            Console.WriteLine("\nLista książek sortowana według ceny: ");
            foreach (Book book in books)
                Console.WriteLine(book.ToString());

            // OrderBy
            Console.WriteLine("\nLista książek sortowana według daty publikacji: ");
            var sortedByYear = books.OrderBy(book => book.yearOfPublication);
            foreach (Book book in sortedByYear)
                Console.WriteLine(book.ToString());

            // OrderByDescending
            Console.WriteLine("\nLista książek sortowana według awtorów nierosnąco: ");
            var sortedByAuthor = books.OrderByDescending(book => book.author);
            foreach (Book book in sortedByAuthor)
                Console.WriteLine(book.ToString());

            Console.ReadKey();
        }
    }
}
