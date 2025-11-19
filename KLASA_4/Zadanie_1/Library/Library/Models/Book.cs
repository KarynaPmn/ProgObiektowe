using Library.Factories;
using Library.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsAvailable { get; set; }

        public Book()
        {
            Book newBook = AddNewBook();

            if (newBook != null)
            {
                Id = newBook.Id;
                Title = newBook.Title;
                Author = newBook.Author;
                Genre = newBook.Genre;
                Description = newBook.Description;
                PublicationDate = newBook.PublicationDate;
                IsAvailable = newBook.IsAvailable;
            }
        }

        public Book(string title, Author author, string genre, string description, string publicationDate)
        {
            Random rand = new Random();
            Id = rand.Next(999);
            Title = title;
            Author = author;
            Genre = genre;
            Description = description;
            PublicationDate = DateTime.Parse(publicationDate);
            IsAvailable = true;

            Logger.Instance.Log($"Add new book: \"{this.Title}\" - {this.Author.ToString()} ({this.Genre})");
        }

        public void MarkAsBorrowed() => IsAvailable = false;
        public void MarkAsReturned() => IsAvailable = true;

        public static Book AddNewBook()
        {
            void RedText(string text)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                Console.ResetColor();
            }

            Console.WriteLine("=== ADD NEW BOOK ===");

            string title;
            while (true)
            {
                Console.Write("--- Title --- \n>>> ");
                title = Console.ReadLine().Trim();
                if (Validator.IsCleanText(title)) break;
                RedText("Invalid title. Must start with a capital letter and be at least 2 characters.");
            }

            Author author;
            while (true)
            {
                Console.Write("--- Author (First Last) --- \n>>> ");
                string[] authorData = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (authorData.Length == 2 && Validator.IsValidName(authorData[0]) && Validator.IsValidName(authorData[1]))
                {
                    author = new Author(authorData[0], authorData[1]);
                    break;
                }
                RedText("Invalid author name. Use format: 'First Last'. Both start with capital letters.");
            }

            string genre;
            while (true)
            {
                Console.Write("--- Genre (criminal / fantasy) --- \n>>> ");
                genre = Console.ReadLine().Trim().ToLower();
                if (Validator.IsValidGenre(genre)) break;
                RedText("Invalid genre. Allowed: 'criminal' or 'fantasy'.");
            }

            string description;
            while (true)
            {
                Console.Write("--- Description --- \n>>> ");
                description = Console.ReadLine().Trim();
                if (Validator.IsValidDescription(description)) break;
                Console.WriteLine("Description too short. Must be at least 5 characters.");
            }

            string publicationDate;
            while (true)
            {
                Console.Write("--- Publication date (yyyy-MM-dd) --- \n>>> ");
                publicationDate = Console.ReadLine().Trim();
                if (Validator.IsValidDate(publicationDate)) break;
                RedText("Invalid date format. Use: yyyy-MM-dd");
            }

            try
            {
                Book newBook = new Book(title, author, genre, description, publicationDate);
                IBook bookFactory = BookFactory.CreateBook(genre);
                bookFactory.Create(newBook);
                return newBook;
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError($"Error during adding new book: {ex.Message}");
                return null;
            }
        }

        public string getTitle()
        {
            return this.Title;
        }

        public string getAuthor()
        {
            return this.Author.ToString();
        }

        public void ShowInfo()
        { 
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Publication date: {PublicationDate}");
            Console.WriteLine($"Available: {(IsAvailable ? "Available" : "Borrowed")}");
            Console.WriteLine();
        }
    }
}
