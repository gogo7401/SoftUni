using System;

namespace _03._Coffee_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int countDrink = int.Parse(Console.ReadLine());
            double priceDrink = 0.00;
            double totalPrice = 0.00;

            switch (drink)
            {
                case "Espresso":
                    if (sugar== "Without") { priceDrink = 0.90 - 0.90 * 0.35; }
                    else if (sugar== "Normal") { priceDrink = 1.00; }
                    else if (sugar== "Extra") { priceDrink = 1.20; }
                    if (countDrink >= 5) { priceDrink = priceDrink - priceDrink * 0.25; }
                    break;
                case "Cappuccino":
                    if (sugar == "Without") { priceDrink = 1.00 - 1.00 * 0.35; }
                    else if (sugar == "Normal") { priceDrink = 1.20; }
                    else if (sugar == "Extra") { priceDrink = 1.60; }
                    break;
                case "Tea":
                    if (sugar == "Without") { priceDrink = 0.50 - 0.50 * 0.35; }
                    else if (sugar == "Normal") { priceDrink = 0.60; }
                    else if (sugar == "Extra") { priceDrink = 0.70; }
                    break;

            }
            totalPrice = countDrink * priceDrink;
            if (totalPrice > 15.00) { totalPrice = totalPrice - totalPrice * 0.20; }
            Console.WriteLine($"You bought {countDrink} cups of {drink} for {totalPrice:f2} lv.");
        }
    }
}
