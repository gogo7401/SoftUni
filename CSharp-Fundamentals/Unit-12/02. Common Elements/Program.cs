using System;
using System.Linq;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split().ToArray();
            string[] arrayTwo = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < arrayTwo.Length; i++)
            {
                for (int j = 0; j < arrayOne.Length; j++)
                {
                    if (arrayTwo[i] == arrayOne[j]) { Console.Write($"{arrayTwo[i]} "); }
                }
            }
        }
    }
}
