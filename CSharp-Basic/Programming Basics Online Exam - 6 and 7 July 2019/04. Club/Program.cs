using System;

namespace _04._Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double profit = double.Parse(Console.ReadLine());
            string nameCocktail = "";
            int priceCocktail = 0;
            double orderValue = 0.00;
            double currentBill = 0.00;

            while (true)
            {
                nameCocktail = Console.ReadLine();
                if (nameCocktail == "Party!")
                {
                    Console.WriteLine($"We need {profit-currentBill:f2} leva more.");
                    break;
                }
                int countCocktail = int.Parse(Console.ReadLine());
                priceCocktail = nameCocktail.Length;
                orderValue = priceCocktail* 1.0 * countCocktail;
                if (orderValue % 2 != 0)
                {
                    orderValue = orderValue - orderValue * 25.0 / 100;
                }
                currentBill += orderValue;

                if (currentBill >= profit)
                {
                    Console.WriteLine($"Target acquired.");
                    break;
                }


            }
            Console.WriteLine($"Club income - {currentBill:f2} leva.");
        }
    }
}
