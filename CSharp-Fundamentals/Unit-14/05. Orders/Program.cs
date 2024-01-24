using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double result = orderPrice(product, quantity);
            Console.WriteLine($"{result:f2}");
        }

        static double orderPrice(string product, int quantity)
        {
            double result = 0.00;
            switch (product)
            {
                case "coffee":
                    result = quantity * 1.50;
                    break;
                case "water":
                    result = quantity * 1.00;
                    break;
                case "coke":
                    result = quantity * 1.40;
                    break;
                case "snacks":
                    result = quantity * 2.00;
                    break;
            }
            return result;
        }
    }
}
