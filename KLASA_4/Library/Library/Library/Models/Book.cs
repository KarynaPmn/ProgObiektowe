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

            Console.WriteLine("=== ADD NEW BOOK ===\n");

            string title;
            while (true)
            {
                WriteLineInput("Title");
                title = Console.ReadLine().Trim();
                if (Validator.IsValidTitle(title)) break;
                RedText("Invalid title. Must start with a capital letter and be at least 2 characters.");
                Logger.Instance.LogError("Invalid title.");
            }

            Author author;
            while (true)
            {
                WriteLineInput("Author (First Last)");
                string[] authorData = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (authorData.Length == 2 && Validator.IsValidName(authorData[0]) && Validator.IsValidName(authorData[1]))
                {
                    author = new Author(authorData[0], authorData[1]);
                    break;
                }
                RedText("Invalid author name. Use format: 'First Last'. Both start with capital letters.");
                Logger.Instance.LogError("Invalid author name.");
            }

            string genre;
            while (true)
            {
                WriteLineInput("Genre (criminal / thriller / fantasy / romance )");
                genre = Console.ReadLine().Trim().ToLower();
                if (Validator.IsValidGenre(genre)) break;
                RedText("Invalid genre. Allowed: 'criminal', 'fantasy', 'thriller', 'romanse'.");
                Logger.Instance.LogError("Invalid genre.");
            }

            string description;
            while (true)
            {
                WriteLineInput("Description");
                description = Console.ReadLine().Trim();
                if (Validator.IsValidDescription(description)) break;
                RedText("Description too short. Must be at least 5 characters.");
                Logger.Instance.LogError("Invalid description.");
            }

            string publicationDate;
            while (true)
            {
                WriteLineInput("Publication date (yyyy-MM-dd)");
                publicationDate = Console.ReadLine().Trim();
                if (Validator.IsValidDate(publicationDate)) break;
                RedText("Invalid date format. Use: yyyy-MM-dd");
                Logger.Instance.LogError("Invalid date format.");
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

        private static void WriteLineInput(string text)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\n--- {text} ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(">>> ");
                Console.ResetColor();
        }
       }
   }
