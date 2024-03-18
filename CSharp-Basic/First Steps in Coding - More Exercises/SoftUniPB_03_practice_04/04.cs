//  04
using System;

namespace CelsiustoFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegetable = double.Parse(Console.ReadLine());
            double priceFruite = double.Parse(Console.ReadLine());
            double kiloVegetable = double.Parse(Console.ReadLine());
            double kiloFruit = double.Parse(Console.ReadLine());

            double prihodi = ((kiloVegetable* priceVegetable) +(kiloFruit* priceFruite)) / 1.94;
            

            Console.WriteLine($"{prihodi:F2}");
        }
    }
}