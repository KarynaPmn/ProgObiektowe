using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAnimal
    {
        void MakeSound();
    }

    public class Dog : IAnimal
    {
        public void MakeSound() 
        {
            Console.WriteLine("Gau!");
        }
    }

    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Miau!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            dog.MakeSound();
            cat.MakeSound();

            Console.ReadKey();
        }
    }
}
