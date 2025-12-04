using Library.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Reader
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private DateTime registeredDate;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredDate { get; set; }

        public Reader(string name, string surname, string email)
        {
            this.id = new Random().Next(1000, 9999);
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.registeredDate = DateTime.Now;
        }

        public void ShowInfo()
        {
            Console.Write($"{this.name} {this.surname} - {this.email}");
        }

        public string GetInfo()
        {
            return $"{this.name} {this.surname} - {this.email}";
        }

        public static Reader RegisterNewReader()
        {
            Console.WriteLine("=== REGISTRATION ===\n");

            string name;
            do
            {
                WriteLineInput("Name");
                name = Console.ReadLine()?.Trim();

                if (!Validator.IsValidName(name))
                {
                    Logger.Instance.LogError("Invalid name.");
                    RedText("Invalid name. Must start with a capital letter and contain at least 2 characters.");
                }
            } while (!Validator.IsValidName(name));

            string surname;
            do
            {
                WriteLineInput("Surname");
                surname = Console.ReadLine()?.Trim();

                if (!Validator.IsValidName(surname))
                {
                    Logger.Instance.LogError("Invalid surname.");
                    RedText("Invalid surname. Must start with a capital letter and contain at least 2 characters.");
                }
            } while (!Validator.IsValidName(surname));

            string email;
            do
            {
                WriteLineInput("Email");
                email = Console.ReadLine()?.Trim();

                if (!Validator.IsValidEmail(email))
                {
                    Logger.Instance.LogError("Invalid email format.");
                    RedText("Invalid email format. Example: example@mail.com");
                }
            } while (!Validator.IsValidEmail(email));

            return new Reader(name, surname, email);
        }

        static void RedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
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

