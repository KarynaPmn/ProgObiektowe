using Destructory_1.Classes;
using System;

namespace Destructory_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Ferrary", 300);
            Car car2 = new Car("Porsche", 280);
            Car car3 = new Car("Lamborghini", 320);

            car1.StartRace();
            car2.StartRace();
            car3.StartRace();

            car2 = null;
            GC.Collect();

            Console.ReadKey();
        }
    }
}

