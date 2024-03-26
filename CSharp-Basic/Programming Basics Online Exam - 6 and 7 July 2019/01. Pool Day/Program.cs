using System;

namespace _01._Pool_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            double entryTax = double.Parse(Console.ReadLine());
            double priceSunLounge = double.Parse(Console.ReadLine());
            double priceSunUmbrella = double.Parse(Console.ReadLine());

            double sum_entryTax = countPeople * entryTax;
            double sum_priceSunLounge = Math.Ceiling(countPeople * 0.75)*priceSunLounge;
            double sum_priceSunUmbrella = Math.Ceiling(countPeople * 0.5) * priceSunUmbrella;
            double totalSum = sum_entryTax + sum_priceSunLounge + sum_priceSunUmbrella;

            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
