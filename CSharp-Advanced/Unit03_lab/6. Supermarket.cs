namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    int queueCount = queue.Count;
                    for (int i = 0; i < queueCount; i++)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}