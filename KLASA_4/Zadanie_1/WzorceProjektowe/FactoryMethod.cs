using System;

namespace WzorceProjektowe
{
    internal class Program
    {
      //  Fabryka Abstrakcyjna - dostarcza interfejs do tworzenia rodzin powiązanych lub zależnych od siebie obiektów bez określania ich konkretnych klas.
      
       public interface INotification
       {
            void Send(string message);
       }

        public class EmailNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[EMAIL] Wysłano: {message}");
            }
        }

        public class SMSNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[SMS] Wysłano: {message}");
            }
        }

        public class PushNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[PUSH] Wysłano: {message}");
            }
        }

        // KLASA FABRYCZNA
        public static class NotificationFactory
        {
            public static INotification CreateNotification(string type) {
                return type.ToLower() switch
                {
                    "email" => new EmailNotification(),
                    "sms" => new SMSNotification(),
                    "push" => new PushNotification(),
                    _ => throw new ArgumentException("Nieznany typ powiadomienia.")
                };
            }
        }

        static void Main(string[] args)
        {
            INotification emai = NotificationFactory.CreateNotification("email");
            emai.Send("Hello World!");

            INotification sms = NotificationFactory.CreateNotification("sms");
            sms.Send("Masz nową wiadomość.");

            Console.ReadKey();
        }
    }
}
