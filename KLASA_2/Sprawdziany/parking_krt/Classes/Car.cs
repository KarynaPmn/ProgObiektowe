using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace parking_krt.Classes
{
    public enum Colors
    {
        Red,
        Green,
        Blue,
        White,
        Black
    }

    internal class Car
    {
        // Utwórz klasę Car, która reprezentuje samochód.
        // Klasa ta powinna mieć następujące właściwości tylko do odczytu:
        // Brand(marka), Model(model), Year(rok produkcji), Color(kolor). 

        public string Brand {  get; set; }
        public string Model {  get; set; }
        public DateTime Year { get; set; }
        public Colors Color {  get; set; }

        // Klasa ta powinna mieć również metodę ShowInformation,
        // która wyświetla informacje o samochodzie na konsoli w formacie:
        // This is {Brand} {Model} from {Year}, color {Color}.

        public void ShowInformation()
        {
            Console.WriteLine($"\nThis is {Brand} {Model} from {Year}, color {Color}");
        }
    }
}
