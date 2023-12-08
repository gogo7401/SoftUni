using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            double money = 0.00;

            while (coins != "Start")
            {
                switch (coins)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        money += double.Parse(coins.ToString());
                        coins = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        coins = Console.ReadLine();
                        break;
                }
            }
            string product = Console.ReadLine();
            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        if (money >= 2.0)
                        {
                            money -= 2.0;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else { Console.WriteLine("Sorry, not enough money"); }
                        break;
                    case "Water":
                        if (money >= 0.7)
                        {
                            money -= 0.7;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else { Console.WriteLine("Sorry, not enough money"); }
                        break;
                    case "Crisps":
                        if (money >= 1.5)
                        {
                            money -= 1.5;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else { Console.WriteLine("Sorry, not enough money"); }
                        break;
                    case "Soda":
                        if (money >= 0.8)
                        {
                            money -= 0.8;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else { Console.WriteLine("Sorry, not enough money"); }
                        break;
                    case "Coke":
                        if (money >= 1.0)
                        {
                            money -= 1.0;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else { Console.WriteLine("Sorry, not enough money"); }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:F2}");
        }
    }
}
