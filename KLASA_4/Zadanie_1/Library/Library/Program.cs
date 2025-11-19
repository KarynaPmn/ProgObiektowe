using Library.Builders;
using Library.Factories;
using Library.Models;
using Library.Singleton;
using System.Collections.Generic;

List<Reader> readers = new List<Reader>()
{
    new Reader("Malt", "Bond", "malbonte@gmail.com"),
    new Reader("Caleb", "Smith", "caleb.smith@gmail.com"),
    new Reader("Farley", "King", "farley234@gmail.com"),
};

List<Book> books = new List<Book>()
{
    new Book("Nemesis", new Author("Jo", "Nesbø"), "criminal", "A detective Harry Hole investigates a deadly secret in Oslo.", "2002-04-01"),
    new Book("The Snowman", new Author("Jo", "Nesbø"), "criminal", "A chilling snowman appears when the first snow falls…", "2007-10-24"),
    new Book("Macbeth", new Author("Jo", "Nesbø"), "thriller", "A gritty retelling of Shakespeare’s Macbeth in a dystopian Scotland.", "2018-04-02"),
    new Book("Fourth Wing", new Author("Rebecca", "Yarros"), "fantasy", "War‑college, dragons, romance entwined with danger.", "2023-05-02"),
    new Book("The Cruel King", new Author("Rina", "Kent"), "romanse", "A romance of power, terror and forbidden love in a royal court.", "2022-12-01"),
    new Book("Iron Flame", new Author("Rebecca", "Yarros"), "romanse", "Continuation of Fourth Wing – hearts, dragons, stakes grow higher.", "2024-02-20"),
};


List<Reservation> reservations = new List<Reservation>();

bool exit = true;
while (exit)
{
    Console.WriteLine("\n=== LIBRARY ===\n");

    Console.WriteLine("--- MENU ---");
    Console.WriteLine("1. Registration new reader");
    Console.WriteLine("2. Catalog of readers");
    Console.WriteLine("3. Add book to catolog");
    Console.WriteLine("4. Catalog");
    Console.WriteLine("5. Reservation");
    Console.WriteLine("6. List of reservations");
    Console.WriteLine("7. Close app");

    try
    {
        WriteLineInput("Choose an option");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > 7) {
            RedText("Incorrect choice. Try again: ");
            WriteLineInput("Choose an option");
        }

        Console.Clear();
        switch (choice)
        {
            case 1:
                Reader newReader = Reader.RegisterNewReader();
                readers.Add(newReader);
                Logger.Instance.Log("Registered new reader");
                break;
            case 2:
                Console.WriteLine("=== READERS ===");
                if (readers.Count == 0)
                    Console.WriteLine("Sorry.. there are no readers.");
                else
                {
                    for (int i = 0; i < readers.Count; i++)
                    {
                        Console.Write($"\n{i + 1}]");
                        readers[i].ShowInfo();
                        Console.WriteLine();
                    }

                    bool ifRemoveUser = false;

                    while (true)
                    {
                        WriteLineInput("Do you want to remove user? (Y/N)");
                        string input = Console.ReadLine()?.Trim().ToUpper();

                        if (input == "Y" || input == "N")
                        {
                            ifRemoveUser = input == "Y";
                            break;
                        }

                        RedText("Incorrect choice. Try again.");
                    }

                    if (ifRemoveUser)
                    {
                        Console.WriteLine("\n=== Remove reader ===\n");
                        WriteLineInput("Give any index from list");

                        int choiceIndex;
                        while (!int.TryParse(Console.ReadLine(), out choiceIndex) || choiceIndex <= 0 || choiceIndex > readers.Count)
                        {
                            RedText("Incorrect choice. Try again: ");
                        }

                        Logger.Instance.Log($"Remove a reader - {readers[choiceIndex - 1].Email}");
                        readers.Remove(readers[choiceIndex - 1]);
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            case 3:
                Book newBook = new Book();
                books.Add(newBook);
                break;
            case 4:
                Console.WriteLine("\n=== CATALOG ===\n");
                if (books.Count == 0)
                    OrangeText("Sorry.. but catalog is empty.");
                else
                {
                    foreach (Book book in books)
                    {
                        if (book.IsAvailable)
                        {
                            Console.WriteLine($"[\"{book.getTitle()}\" - {book.getAuthor()} ({book.Genre})]");
                            Console.WriteLine($"Description: {book.Description}\n");
                        }
                        else
                            OrangeText($"|BOROWED| \"{book.getTitle()}\" - {book.getAuthor()}");
                    }
                }
                break;
            case 5:
                Console.Write("=== RESERVATION ===\n");

                if (readers.Count == 0)
                    OrangeText("Sorry.. but readers catalog is empty.");
                else
                {
                    Reception reception = new Reception();
                    IReservationBuilder builder = new ReservationBuilder();

                    Console.WriteLine("\n=== Select reader ===\n");
                    for (int i = 0; i < readers.Count; i++)
                    {
                        Console.Write($"{i + 1}] ");
                        readers[i].ShowInfo();
                        Console.WriteLine();
                    }

                    WriteLineInput("Give any index from list");
                    int choiceIndexReader;
                    while (
                            !int.TryParse(Console.ReadLine(), out choiceIndexReader)
                            || choiceIndexReader <= 0
                            || choiceIndexReader > readers.Count
                          )
                    {
                        RedText("Incorrect choice. Try again:");
                        WriteLineInput("Give any index from list");
                    }

                    Console.WriteLine("\n=== Select book ===\n");
                    List<Book> avaiableBooks = books.FindAll(book => book.IsAvailable);
                    for (int i = 0; i < avaiableBooks.Count(); i++)
                    {
                        Console.WriteLine($"\n{i + 1}] ");
                        avaiableBooks[i].ShowInfo();
                    }

                    WriteLineInput("Give any index from list");
                    int choiceIndexBook;
                    while (
                            !int.TryParse(Console.ReadLine(), out choiceIndexBook)
                            || choiceIndexBook <= 0
                            || choiceIndexBook > avaiableBooks.Count
                          )
                    {
                        RedText("Incorrect choice. Try again:");
                        Console.Write("\n--- Give any index from list ---\n>>> ");
                    }

                    Reservation reservation = reception.NewReservation(builder, readers[choiceIndexReader - 1], avaiableBooks[choiceIndexBook - 1]);
                    reservations.Add(reservation);
                }

                break;
            case 6:
                Console.Write("=== RESERVATIONS ===\n");

                if (reservations.Count == 0)
                    OrangeText("Sorry.. there are no reservations.");
                else
                {
                    for (int i = 0; i < reservations.Count; i++)
                    {
                        Console.WriteLine($"\n{i + 1}]");
                        reservations[i].ShowInfo();
                    }

                    WriteLineInput("Do you want to remove reservation? (Y/N)");
                    string input = Console.ReadLine().Trim().ToUpper();
                    bool ifRemoveUser = input == "Y";

                    if (ifRemoveUser)
                    {
                        Console.WriteLine("\n=== Remove reservation ===\n");
                        WriteLineInput("Give any index from list");

                        int choiceIndex;
                        if (!int.TryParse(Console.ReadLine(), out choiceIndex))
                        {
                            RedText("Incorrect choice. Try again: ");
                            continue;
                        }

                        Logger.Instance.Log($"Remove a reservation - {reservations[choiceIndex - 1].Id}");
                        reservations[choiceIndex - 1].Book.MarkAsReturned();
                        reservations.Remove(reservations[choiceIndex - 1]);
                    }
                }
                break;
            case 7:
                Console.WriteLine("\nThank you for using this app!");
                exit = false;
                break;
        }

        Console.ReadKey();
        Console.Clear();

    }
    catch (Exception ex)
    {
        Logger.Instance.LogError($"Error: {ex.Message}");
    }
}

void RedText(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ResetColor();
}

void OrangeText(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(text);
    Console.ResetColor();
}

void WriteLineInput(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine($"\n--- {text} ---");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(">>> ");
    Console.ResetColor();
}