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

        public static Reader RegisterNewReader()
        {
            Console.WriteLine("=== REGISTRATION ===");

            string name;
            do
            {
                Console.Write("--- Name --- \n>>> ");
                name = Console.ReadLine()?.Trim();
            } while (!Validator.IsValidName(name));

            string surname;
            do
            {
                Console.Write("--- Surname --- \n>>> ");
                surname = Console.ReadLine()?.Trim();
            } while (!Validator.IsValidName(surname));

            string email;
            do
            {
                Console.Write("--- Email --- \n>>> ");
                email = Console.ReadLine()?.Trim();
            } while (!Validator.IsValidEmail(email));

            return new Reader(name, surname, email);
        }

    }
}

