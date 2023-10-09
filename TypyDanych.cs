using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2_project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // komentarz w jednej linii

            /*
             * komentarz w
             * wielu liniach
             */

            Console.Write("Pierwszy program");
            Console.WriteLine("w języku C#");
            Console.WriteLine("test");
            Console.Clear();


            //typy dannych
            /*
             * int 16, 32, 64
             * byte 0-255 (8 bitów => 1 bajt)
             * sbyte -128 - 127 (8 bitów => 1 bajt)
             * short -32768 - 32767 (16 bitów => 2 bajt)
             * ushort 0 - 65535 (16 bitów => 2 bajt)
             * int -2 147 483 648 - 2 147 483 647 (32 bitów => 4 bajt)
             * uint 0 - 4 294 967 295  (32 bitów => 4 bajt)
             * long - -9223372036854775808 - 9223372036854775807 (64 bitów => 8 bajtów)
             * ulong - 0 - 18 446 744 073 709 551 615 (64 bitów => 8 bajtów, ponad 18 trylionów)
             * 
             * bool (true/false) ile ma bitów/bajtów
             * char U + 0000 do U + FFFF (16 bitowy znak z tablicy Unicode)
             * string ?
             * 
             * float -3,4 x 10 ^ 38 (do potęgi) do 3,4 x 10 ^ 38 (32 bity)
             * double (64 bitów)
             * decimal (128 bitów)
             */

            int i; //deilaracja zmiennej i
            int i1 = 10; //deilaracja z jednoczesną inicjalizacją zmiennej i 

            Console.WriteLine("Zmienna i1 wynosi:" + i1);

            System.Int32 i2 = 100;

            Console.WriteLine("Zmienna i1 wynosi: {0}, znienna i2 wynosi: {1}", i1, i2);
            Console.WriteLine($"Zmienna i1 wynosi: {i1}, znienna i2 wynosi: {i2}");

            byte b = 100;
            sbyte sb = -10;
            short s = -20000;

            int i3 = 10;
            Int32 i4 = 10;
            System.Int32 i5 = 10;

            long l = -10L; //sufiks L
            ulong l1 = 10UL; // sufiks UL

            Console.WriteLine("Zmienna l: {0}, zmienna ul: {1}", l, l1);

            float f = 10.5F; // sufiks F

            //Zapis systemów liczbowych
            //binarny
            Console.WriteLine(0b1011); //11(10)

            //oktalny
            Console.WriteLine(011); //11
            int io = Convert.ToInt32("12", 8);
            Console.WriteLine(io); //10 => 2*8^0 + 1*8^1 = 2 + 8 = 10(10)

            //heksadecymalny
            Console.WriteLine(0xA1); // 161(10) => A*16^1 + 1*16^0 = 10*16 + 1 = 161

            //Zakres typu dannych
            Console.WriteLine(byte.MinValue); //0
            Console.WriteLine(byte.MaxValue); //255

            Console.WriteLine(sbyte.MinValue); //-128
            Console.WriteLine(sbyte.MaxValue); //127

            Console.WriteLine(int.MinValue); //-2147483648
            Console.WriteLine(Int32.MinValue); //-2147483648
            Console.WriteLine(System.Int32.MinValue); //-2147483648

            Console.WriteLine(long.MinValue); //-9223372036854775808
            Console.WriteLine(long.MaxValue); //9223372036854775807

            Console.WriteLine(float.MinValue); //-3,402823E+38
            Console.WriteLine(float.MaxValue); //3,402823E+38

            Console.WriteLine(double.MinValue); //-1,79769313486232E+308
            Console.WriteLine(double.MaxValue); //1,79769313486232E+308

            Console.WriteLine(decimal.MinValue); //-79228162514264337593543950335
            Console.WriteLine(decimal.MaxValue); //79228162514264337593543950335

            //Unicode
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Аль-Хайтам");
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("♥");
            Console.WriteLine("\x2665");

            char letter = 'a';
            Console.WriteLine(letter);

            char letter2 = (char)97;
            Console.WriteLine(letter2);

            Console.WriteLine("πr²");

            Console.ReadKey();
        }
    }
}
