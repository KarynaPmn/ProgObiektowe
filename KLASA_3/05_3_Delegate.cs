using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_03
{
    internal class Program
    {
        public delegate void NotificationHandler(string messager);

        public class User
        {
            public string Name { get; set; }
            public int Priority { get; set; } // 1 - wysoki, 2 - średni, 3 - niski
        }

        public interface INotifier
        {
            void Notify(string message);
        }

        public class EmailNotifier : INotifier
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        public class SMSNotifier : INotifier
        {
            public void Notify(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
        }

        public class PushNotifier : INotifier
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Push wysłany: {message}");
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;
            public Dictionary<string, User> users = new Dictionary<string, User>();
            private List<INotifier> notifiers = new List<INotifier>();

            public void AddUser(string name, int priority) 
            {
                if (!users.ContainsKey(name))
                {
                    users[name] = new User() { Name = name, Priority = priority };
                    Console.WriteLine($"Dodano użytkownika: {name} z priorytetem {priority}");
                }
                else
                    Console.WriteLine($"Użytkowik {name} już istnieje");
            }
            public void RemoveUser(string name)
            {
                if (users.Remove(name))
                    Console.WriteLine($"Usunięto użytkownika {name}");
                else
                    Console.WriteLine($"Użytkownik {name} nie istnieje");
            }

            public User GetUserByName(string name)
            {
                if (users.TryGetValue(name, out User user))
                {
                    return user;
                }
                return null;
            }

            public void ListUsers()
            {
                if (users.Count == 0)
                {
                    Console.WriteLine("Brak użytkownika");
                    return;
                }
                Console.WriteLine("Lista użytkowników:");
                int index = 1;
                foreach (var user in users)
                {
                    Console.WriteLine($"{index}. {user.Value.Name} (priorytet: {user.Value.Priority})");
                    index++;
                }
            }

            public void SendNotification(string message, int priority)
            {
                if (notifiers.Count == 0)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomienia");
                }

                var filteredUsers = new List<User>(users.Values).FindAll(u => u.Priority <= priority);

                if (filteredUsers.Count == 0)
                {
                    Console.WriteLine($"Brak użytkowników z priorytetem równym lub wyższym niż {priority}");
                    return;
                }

                Console.WriteLine($"Wiadomość: \"{message}\"");
                foreach (var notifier in notifiers)
                    notifier.Notify(message);

                Console.WriteLine("Powiadomienie zostało wysłane do: ");
                foreach (var user in filteredUsers)
                    Console.WriteLine($" - {user.Name} (priorytet: {user.Priority})");
            }
            
            public void AddNotifier(INotifier notifier)
            {
                if (!notifiers.Contains(notifier))
                {
                    notifiers.Add(notifier);
                    Console.WriteLine("Metoda powiadomienia została dodana");
                }
                else
                    Console.WriteLine("Ta metoda powiadomienia już istnieje");
            }

            public void RemoveNotifier(INotifier notifier) 
            {
                if (notifiers.Remove(notifier))
                    Console.WriteLine("Metode powiadomienia została usunięta");
                else
                    Console.WriteLine("Nie znaleziono tej metody powiadomienia");
            }

            public void ListNotifiers()
            {
                if (notifiers.Count == 0)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomienia");
                    return;
                }

                Console.WriteLine("Dostępne motody powiadomienia: ");
                foreach (var notifier in notifiers)
                    Console.WriteLine(notifier.GetType().Name);
            }
        }

        static void Main(string[] args)
        {
            var notificationManager = new NotificationManager();

            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Dodaj użytkownika");
                Console.WriteLine("2. Usuń użytkownika");
                Console.WriteLine("3. Wyślij powiadomienia do użytkownika");
                Console.WriteLine("4. Wyświetl użytkowników");
                Console.WriteLine("5. Dodaj metodę powiadomień");
                Console.WriteLine("6. Usuń metodę powiadomień");
                Console.WriteLine("7. Wyślij metody powiadomień");
                Console.WriteLine("8. Wyjdź");

                Console.Write("\nWybierz opcję: ");

                int choice = 0;
                bool choiceCorrect = false;
                while (!choiceCorrect)
                {
                    var choiceValue = Console.ReadLine();
                    if (!int.TryParse(choiceValue, out var value) || (value <= 0 || value > 8))
                    {
                        Console.Write("Podana nie prawidłowy wybór. Sprubój ponownie: ");
                    }
                    else
                    {
                        choice = value;
                        choiceCorrect = true;
                    }
                }

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
