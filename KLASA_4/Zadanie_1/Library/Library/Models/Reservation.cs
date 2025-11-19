using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Reservation
    {
        public string Id { get; set; }
        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Reader: {Reader.Name} {Reader.Surname}");
            Console.WriteLine($"Book: \"{Book.Title}\" - {Book.Author.ToString()}");
            Console.WriteLine($"Reservation date: {ReservationDate}");
            Console.WriteLine($"Return date: {ReturnDate} ");
        }
    }
}
