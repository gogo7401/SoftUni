using System;

namespace _02._Passed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            if (n >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
