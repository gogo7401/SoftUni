using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double totalPrice = 0.00;
            for (int i = 0; i < N; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());  
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double price = ((days * capsulesCount) * pricePerCapsule)*1.0;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
