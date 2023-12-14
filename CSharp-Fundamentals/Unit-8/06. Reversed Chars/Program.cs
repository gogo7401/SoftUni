using System;

namespace _06._Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            char firstChar = char.Parse(firstString);
            string secondString = Console.ReadLine();
            char secondChar = char.Parse(secondString);
            string thirdString = Console.ReadLine();
            char thirdChar = char.Parse(thirdString);
            Console.WriteLine($"{thirdChar} {secondChar} {firstChar}");
        }
    }
}
