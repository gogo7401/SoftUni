using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            PrintLettersBetween(firstLetter, secondLetter);
        }

        private static void PrintLettersBetween(char firstLetter, char secondLetter)
        {
            string result = "";
            char tempLetter = firstLetter;
            if ((int)firstLetter > (int)secondLetter)
            {
                firstLetter = secondLetter;
                secondLetter = tempLetter;
            }
            for (int i = (int)firstLetter +1; i < (int)secondLetter; i++)
            {
                result += (char)i + " ";
            }

            Console.Write(result);
        }
    }
}
