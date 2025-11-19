using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Singleton
{
    internal class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null) 
                        _instance = new Logger();
                    return _instance;
                }
            }
        }
        public void Log(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
            Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
            Console.ResetColor();
        }
    }
}
