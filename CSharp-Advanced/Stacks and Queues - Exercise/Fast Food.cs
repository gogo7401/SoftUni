namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalQuantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(input);

            Boolean isComplete = true;

            if (orders.Count > 0)
            {
                Console.WriteLine(orders.Max());
            }

            int currentOrderQuantity = 0;

            while (orders.Count > 0)
            {
                currentOrderQuantity = orders.Peek();

                if (totalQuantity >= currentOrderQuantity)
                {
                    totalQuantity -= currentOrderQuantity;
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    isComplete= false;
                    break;
                }

            }

            if (isComplete)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}