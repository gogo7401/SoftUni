﻿using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
