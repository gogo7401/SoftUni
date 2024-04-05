using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] reversedNumbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                reversedNumbers[i] = int.Parse(Console.ReadLine());
            }
            reversedNumbers = reversedNumbers.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", reversedNumbers));

        }
    }
}
