using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarynaPomin_g2.cs.Klasy
{
    internal class Person
    {
        //3. Utwórz klasę Person z właściwościami imię, nazwisko, data urodzenia, imiona_zwierząt (lista)

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string[] NamesIfAnimals { get; set; }

        //4. Napisz metodę wyświetlającą imiona zwierząt należących do właściciela

        public string SetAnimalsOwner(string nameOwner, string[] Animals)
        {
            string s = $"Właściciel {nameOwner}: ";
            foreach (var Animal in Animals)
            {
                s += Animal + ", ";
            }
            return s;
        }
    }
}
