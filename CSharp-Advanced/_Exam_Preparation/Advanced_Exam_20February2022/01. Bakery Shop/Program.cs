using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _01._Bakery_Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var waterQueue = new Queue<double>(Console.ReadLine().Split(" ").Select(double.Parse));
            var flourStack = new Stack<double>(Console.ReadLine().Split(" ").Select(double.Parse));

            int countCroissant = 0;
            int countMuffin = 0;
            int countBaguette = 0;
            int countBagel = 0;

            var baked = new Dictionary<string, int>(); 


            while (waterQueue.Count > 0 && flourStack.Count > 0)
            {
                double water = waterQueue.Dequeue();
                double flour = flourStack.Pop();    

                string product = CreateProduct(water, flour);

                if (product == "none")
                {
                    flourStack.Push(flour - water);
                    CounterProducts(baked, "Croissant");
                }
                else
                {
                    CounterProducts(baked, product);
                }

            }

            foreach (var item in baked.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (waterQueue.Any() )
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourStack.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }

        private static void CounterProducts(Dictionary<string, int> baked, string product)
        {
            if (baked.ContainsKey(product) == false)
            {
                baked.Add(product, 0);
            }
            baked[product]++;
        }

        public static string CreateProduct(double water, double flour)
        {
            string readyProduct = "none";

            double summaryProducts = water + flour;

            if (water*100/50 == summaryProducts && flour*100/50 == summaryProducts)
            {
                readyProduct = "Croissant";
            }
            else if (water * 100 / 40 == summaryProducts && flour * 100 / 60 == summaryProducts)
            {
                readyProduct = "Muffin";
            }
            else if (water * 100 / 30 == summaryProducts && flour * 100 / 70 == summaryProducts)
            {
                readyProduct = "Baguette";
            }
            else if (water * 100 / 20 == summaryProducts && flour * 100 / 80 == summaryProducts)
            {
                readyProduct = "Bagel";
            }

                return readyProduct;
        }
    }
}
