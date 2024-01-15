using System;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberWagons = new int[int.Parse(Console.ReadLine())];
            int sum = 0;
            for (int i = 0; i < numberWagons.Length; i++)
            {
                numberWagons[i] = int.Parse(Console.ReadLine());    
                sum += numberWagons[i];
            }
            Console.WriteLine(String.Join(' ',numberWagons));
            Console.WriteLine(sum);
        }
    }
}
