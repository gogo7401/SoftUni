using System;
using System.Linq;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();    
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = i+1; j < line.Length; j++)
                {
                    if ((line[i] + line[j] ) == magicNumber)
                    {
                        Console.WriteLine($"{line[i]} {line[j]}");
                    }
                }
            }
        }
    }
}
