using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1.Classes
{
    internal class Device
    {
        public void Message(string text)
        {
            Console.WriteLine(text);
        }

        public virtual string GetStatus()
        {
            return "Urządzenie jest w stanie nieznanym";
        }
    }
}
