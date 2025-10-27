using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1.Classes
{
    internal class WashingMachine : Device
    {
        private int programNumber = 0;
        
        public int setNumber(int number)
        {
            this.programNumber = number;

            if (programNumber >= 0 && programNumber < 12)
                return programNumber;
            return 0;
        }
        

        public override string GetStatus()
        {
            return $"Pralka ma ustawiony program numer: {programNumber} .";
        }
    }
}
