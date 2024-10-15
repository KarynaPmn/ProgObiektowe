using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zwirzątka_spr.classes
{
    internal class Person
    {
        // 3. Utwórz klasę Person z właściwościami imię, nazwisko, data urodzenia, imiona_zwierząt (lista)

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public List<string> PetNames { get; set; }


    }
}
