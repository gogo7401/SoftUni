using System;

namespace _02._Family_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countNight = int.Parse(Console.ReadLine()); 
            double priceNight = double.Parse(Console.ReadLine());
            int procentAddBudget = int.Parse(Console.ReadLine());

            double totalPrice = 0.00;

            if (countNight > 7) { priceNight = priceNight - priceNight * 0.05; }

            totalPrice = countNight * priceNight + budget * procentAddBudget / 100;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-totalPrice:f2} leva after vacation.");
            }
            else Console.WriteLine($"{totalPrice-budget:f2} leva needed.");
        }
    }
}
