using Library.Models;
using Library.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Factories
{
    public interface IBook
    {
        void Create(Book book);
    }

    public class CriminalBook : IBook
    {
        void IBook.Create(Book book)
        {
            Logger.Instance.Log($"Add new book: \"{book.Title}\" - {book.Author}");
        }
    }

    public class FantasyBook : IBook
    {
        void IBook.Create(Book book)
        {
            Logger.Instance.Log($"Add new book: \"{book.Title}\" - {book.Author.ToString()} ({book.Genre})");
        }
    }

    public class TrillersBook : IBook
    {
        void IBook.Create(Book book)
        {
            Logger.Instance.Log($"Add new book: \"{book.Title}\" - {book.Author.ToString()} ({book.Genre})");
        }
    }

    public class RomanseBook : IBook
    {
        void IBook.Create(Book book)
        {
            Logger.Instance.Log($"Add new book: \"{book.Title}\" - {book.Author.ToString()} ({book.Genre})");
        }
    }

    public static class BookFactory
    {
        public static IBook CreateBook(string type)
        {
            return type.ToLower() switch
            {
                "criminal" => new CriminalBook(),
                "fantasy" => new FantasyBook(),
                "trillers" => new TrillersBook(),
                "romanse" => new RomanseBook(),
                _ => throw new ArgumentException("Unknow genre.")
            };
        }
    }
}
