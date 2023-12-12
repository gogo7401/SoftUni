using System;

namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            if ((int)input > 90)
            {
                Console.WriteLine("lower-case");
            }
            else { Console.WriteLine("upper-case"); }
        }
    }
}
