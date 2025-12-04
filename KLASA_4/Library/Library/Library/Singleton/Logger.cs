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

        private readonly string _logFile = "D:\\Library\\Library\\Library\\libraryLogs.txt";

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }
        public void Log(string message) 
        {
            string logMessage = $"[LOG {DateTime.Now}] {message}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(logMessage);
            Console.ResetColor();

            SaveLog(logMessage);
        }

        public void LogError(string message) 
        {
            string logMessage = $"[LOG ERROR {DateTime.Now}] {message}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(logMessage);
            Console.ResetColor();

            SaveLog(logMessage);
        }

        private void SaveLog(string message)
        {
            File.AppendAllText(_logFile, message + "\n");
        }
    }
}
