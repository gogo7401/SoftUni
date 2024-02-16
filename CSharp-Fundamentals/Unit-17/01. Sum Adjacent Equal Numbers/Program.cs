using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> input = new List<string>();
            List <double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            for (int i = 0; i < input.Count-1; i++)
            {
                if (input[i] == input[i+1])
                {
                    input[i] = input [i] + input[i+1];
                    input.Remove(input[i + 1]);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", input));

        }
    }
}
