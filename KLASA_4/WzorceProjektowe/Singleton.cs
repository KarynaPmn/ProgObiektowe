using System;

namespace WzorceProjektowe
{
    internal class Program
    {
        // SINGLETON - klasa ma tylko jedną instancję i zapewnia globalny punkt dostępu do niej.

        class ConfigurationManager
        {
            private static ConfigurationManager _instance;

            // dla bezpieczeństwa wątków, tylko jeden wątek naraz
            //private static readonly object _lock = new object(); 

            public string Path { get; private set; }
            public bool DebugMode { get; private set; }

            // Tylko sama klasa może wywołać swój konstruktor to umożliwia kontrolę, by istniała tylko jedna instancja
            private ConfigurationManager() { }

            public static ConfigurationManager Instance => _instance ??= new ConfigurationManager();

            // ??= 
            //public static ConfigurationManager Instance
            //{
            //    get
            //    {
            //        lock (_lock)
            //        {
            //            if (_instance == null)
            //                _instance = new ConfigurationManager();
            //            return _instance;
            //        }
            //    }
            //}

            public void SetConfig(string path, bool debug)
            {
                Path = path;
                DebugMode = debug;
            }

            public void ShowConfig()
            {
                Console.WriteLine($"PATH: {Path}");
                Console.WriteLine($"DEBUG MODE: {DebugMode}");
            }
        }

        static void Main(string[] args)
        {
            var config = ConfigurationManager.Instance;
            config.SetConfig("/path/to/config", true);
            config.ShowConfig();

            Console.ReadKey();
        }
    }
}
