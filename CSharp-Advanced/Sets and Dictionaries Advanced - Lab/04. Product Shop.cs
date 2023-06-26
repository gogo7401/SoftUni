using static System.Formats.Asn1.AsnWriter;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodShops = new SortedDictionary<string, Dictionary<string, double>>();

            string command;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string foodShop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (foodShops.ContainsKey(foodShop) == false)
                {
                    foodShops.Add(foodShop, new Dictionary<string, double>());
                }

                if (foodShops[foodShop].ContainsKey(product) == false)
                {
                    foodShops[foodShop].Add(product, price);
                }
                else
                {
                    foodShops[foodShop][product] = price;
                }
            }

            foreach (var (foodShop, productAndPrice) in foodShops)
            {
                Console.WriteLine($"{foodShop}->");

                foreach (var (productName, productPrice) in productAndPrice)
                {
                    Console.WriteLine($"Product: {productName}, Price: {productPrice}");
                }
            }
        }
    }
}