using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.classes
{
    enum Color{
        Red, 
        Blue, 
        Green, 
        Black, 
        White
    }

    internal class Car
    {
  
        public string Brand { private get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Color Color { get; set; }

        public string GetBrend()
        {
            return Brand;
        }
        public void ShowInformation()
        {
            Console.WriteLine($"This is {Brand} {Model} from {Year}, color {Color}.");
        }
    }
}
