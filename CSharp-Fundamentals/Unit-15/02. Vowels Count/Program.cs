using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int vowelsCount = GetVowels(inputString);
            Console.WriteLine(vowelsCount);
        }

        private static int GetVowels(string inputString)
        {
            int result = 0;
            //string[] vowels = new string[] { "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y" };
            string vowels = "AEIOUYaeiouy"; 
            // vowels are a, e, i, o, and u, although y can sometimes count as a vowel
            for (int i = 0; i < inputString.Length; i++)
            {
                if (vowels.IndexOf(char.Parse(inputString[i].ToString())) >= 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
