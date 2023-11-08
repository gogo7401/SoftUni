namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeeDrinks = new Dictionary<int, string>()
            {
                { 50, "Cortado" },
                { 75, "Espresso"},
                { 100, "Capuccino"},
                { 150, "Americano"},
                { 200, "Latte"},
            };


            var createdDrinks = new Dictionary<string, int>();

            var coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int sum = 0;

            while (true)
            {
                if (coffee.Count == 0 || milk.Count == 0) 
                {
                    break;
                }
                int currMilk = milk.Peek(); 
                sum = coffee.Dequeue() + milk.Pop();

                if (coffeeDrinks.ContainsKey(sum))
                {
                    if (createdDrinks.ContainsKey(coffeeDrinks[sum]) == false)
                    {
                        createdDrinks.Add(coffeeDrinks[sum],0);
                    }
                    createdDrinks[coffeeDrinks[sum]]++;
                }
                else
                {
                    milk.Push(currMilk-5);
                }

            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }

            foreach (var drink in createdDrinks.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }

        }
    }
}