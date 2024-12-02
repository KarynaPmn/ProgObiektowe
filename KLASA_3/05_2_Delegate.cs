using System;

namespace Delegate
{
    internal class Program
    {
        public delegate void NotithicationHandler(string message); 

        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"\nEmail wysłany: {message}");
            }
        }

        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine($"\nSMS wysłany: {message}");

            }
        }

        public class PushNotifier
        {
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
                Notify += handler;
            }

            public void RemoveNotificationMethod(NotithicationHandler handler)
            {
                Notify -= handler;
            }

            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("\nBrak dostępnych metod powiadomienia.");
                }
                Notify?.Invoke(message);
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
                            Console.WriteLine("\nDodano powiadomienie email.");
                            break;
                        case 2:
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("\nDodano powiadomienie SMS.");
                            break;
                        case 3:
                            notificationManager.AddNotificationMethod(pushNotifier.SendPushNotifier);
                            Console.WriteLine("\nDodano powiadomienia Push.");
                            break;
                        case 4:
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("\nUsunięto powiadomienie email.");
                            break;
                        case 5:
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("\nUsunięto powiadomienie SMS.");
                            break;
                        case 6:
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPushNotifier);
                            Console.WriteLine("\nUsunięto powiadomienia Push.");
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
