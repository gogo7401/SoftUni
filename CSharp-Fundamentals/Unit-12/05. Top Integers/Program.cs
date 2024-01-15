using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isMaxNumber = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                int beginFrom = i + 1;
                for (int j = beginFrom; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isMaxNumber = false; 
                        break;
                    }
                }
                if (isMaxNumber) { Console.Write($"{numbers[i]} "); }
                isMaxNumber = true;
            }
        }
    }
}
