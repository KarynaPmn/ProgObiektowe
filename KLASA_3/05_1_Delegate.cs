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
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");

            }
        }

        public class PushNotifier
        {
            public void SendPushNotifier(string message)
            {
                Console.WriteLine($"Powiadomienie push wysłany: {message}");
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
                Notify?.Invoke(message);
            }

            static void Main(string[] args)
            {
                var emailNotifier = new EmailNotifier();
                var smsNotifier = new SMSNotifier();
                var pushNotifier = new PushNotifier();

                var notificationManager = new NotifiacationManager();

                notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                notificationManager.AddNotificationMethod(pushNotifier.SendPushNotifier);

                notificationManager.SendNotification("Pierwsza wiadomość.");
                Console.WriteLine();

                notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                notificationManager.SendNotification("Druga wiadomość.");
            }
        }
    }
}
