using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1.Classes
{
    internal class VacuumCleaner : Device
    {
        private bool status = false;

        public void TurnOn()
        {
            if (!status)
            {
                status = true;
                Message("Odkurzać włączono");
            }
        }

        public override string GetStatus()
        {
            if (status)
                return "Odkurzacz jest włączony.";
            else
                return "Odkurzacz jest wyłączony.";
        }
    }
}
