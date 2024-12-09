using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Delegaty
{
    internal class Program
    {
        public delegate void NotithicationHandler(string message); 

        public interface INotifier
        {
            void Notify(string message);
        }

        public class EmailNotifier : INotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Email wysłany: {message}");
                }
                catch (Exception ex) {
                    Console.WriteLine($"Błąd podczas wysłania email: {ex.Message}");
                }
            }

            public void SendEmail(string message)
            {
                Console.WriteLine($"\nEmail wysłany: {message}");
            }
        }

        public class SMSNotifier : INotifier 
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"SMS wysłany: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysłania SMS: {ex.Message}");
                }
            }

            public void SendSMS(string message)
            {
                Console.WriteLine($"\nSMS wysłany: {message}");

            }
        }

        public class PushNotifier : INotifier 
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Push wysłany: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysłania Push: {ex.Message}");
                }
            }

            public void SendPushNotifier(string message)
            {
                Console.WriteLine($"\nPowiadomienie push wysłany: {message}");
            }
        }

        public class NotifiacationManager
        {
            public NotithicationHandler Notify;

            public void AddNotificationMethod(NotithicationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Console.WriteLine("Ta metoda powiadomienia jest już dodana");
                    return;
                }

                Notify += handler;
                Console.WriteLine("Dodano metodę powiadomienia");
            }

            public void RemoveNotificationMethod(NotithicationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Console.WriteLine("Usunięto motodę powiadomienia");
                    Notify -= handler;
                    return;
                }
            }

            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("\nBrak dostępnych metodę powiadomienia. Dodaj co najmniej jedną metodę.");
                    return;
                }

                foreach (var handler in Notify.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(message);
                        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Wysłano: {handler.Method.Name}, wiadomość: {message}{Environment.NewLine}";
                        File.AppendAllText("log.txt", logEntry);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine($"Błąd podczas wysyłania powiadomienia: {ex.Message}");
                    }
                }

                //Notify?.Invoke(message);
            }
            public void ListNotification()
            {
                if (Notify == null)
                {
                    Console.WriteLine("\nBrak dostępnych metodę powiadomienia.");
                    return;
                }

                Console.WriteLine("Zarejestrowane metody powiadomień: ");

                var displayHandlers = new HashSet<string>();

                foreach (var handler in Notify.GetInvocationList())
                {
                    var target = handler.Target;
                    var methodName = handler.Method.Name;
                    var className = target?.GetType().Name ?? "Nieznany";

                    var uniqueKey = $"{className}.{methodName}";

                    if (!displayHandlers.Contains(uniqueKey))
                    {
                        displayHandlers.Add(uniqueKey);
                        Console.WriteLine($"- Klasa {className}, metoda {methodName}");
                    }
                }
            }
        }


        public static void ShowMenu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Dodaj powiadomienie Email.");
            Console.WriteLine("2. Dodaj powiadomienie SMS.");
            Console.WriteLine("3. Dodaj powiadomienie Push.");
            Console.WriteLine("4. Usuń powiadomienie Email.");
            Console.WriteLine("5. Usuń powiadomienie SMS.");
            Console.WriteLine("6. Usuń powiadomienie Push.");
            Console.WriteLine("7. Wyślij powiadomienie.");
            Console.WriteLine("8. Wyjście z programu.");
            Console.Write("Wybierz opcję:");
        }

        static void Main(string[] args)
        {
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            var notificationManager = new NotifiacationManager();

            //notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
            //notificationManager.SendNotification("Test");

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            //Console.WriteLine("\nDodano powiadomienie email.");
                            break;
                        case 2:
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            //Console.WriteLine("\nDodano powiadomienie SMS.");
                            break;
                        case 3:
                            notificationManager.AddNotificationMethod(pushNotifier.SendPushNotifier);
                            //Console.WriteLine("\nDodano powiadomienia Push.");
                            break;
                        case 4:
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            //Console.WriteLine("\nUsunięto powiadomienie email.");
                            break;
                        case 5:
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            //Console.WriteLine("\nUsunięto powiadomienie SMS.");
                            break;
                        case 6:
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPushNotifier);
                            //Console.WriteLine("\nUsunięto powiadomienia Push.");
                            break;
                        case 7:
                            Console.Write("Podaj wiadomość: ");
                            string message = Console.ReadLine();

                            notificationManager.SendNotification(message);
                            break;
                        case 8:
                            return;
                        default:
                            Console.WriteLine("\nWystąpił bład. Sprobój ponownie.");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
