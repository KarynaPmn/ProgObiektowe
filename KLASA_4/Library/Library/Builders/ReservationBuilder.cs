using Library.Factories;
using Library.Models;
using Library.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Builders
{
    public interface IReservationBuilder
    {
        void SetId();
        void SetReader(Reader reader);
        void SetBook(Book book);
        void SetDates(DateTime start);
        Reservation Build();
    }

    internal class ReservationBuilder : IReservationBuilder
    {
        private Reservation reservation = new Reservation();

        public void SetId() => reservation.Id = Guid.NewGuid().ToString();

        public void SetReader(Reader reader) => reservation.Reader = reader;

        public void SetBook(Book book) => reservation.Book = book;

        public void SetDates(DateTime start)
        {
            reservation.ReservationDate = start;
            reservation.ReturnDate = start.AddDays(14);
        }


        public Reservation Build() => reservation;
    }

    public class Reception
    {
        public Reservation NewReservation(IReservationBuilder builder, Reader reader, Book book)
        {
            Console.WriteLine("=== NEW RESERVATION ===");

            builder.SetId();
            builder.SetReader(reader);
            builder.SetBook(book);
            builder.SetDates(DateTime.Now);
            book.MarkAsBorrowed();

            Logger.Instance.Log($"Add new reservation: |{reader.Name} {reader.Surname}| \"{book.getTitle()}\" - {book.getAuthor()}");
            return builder.Build();
    
        }
    }
}
