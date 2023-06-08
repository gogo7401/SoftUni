namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            int queueCount = queue.Count;

            for (int i = 0; i < queueCount; i++)
            {
                int element = queue.Dequeue();
                if (element % 2 == 0)
                {
                    queue.Enqueue(element);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}