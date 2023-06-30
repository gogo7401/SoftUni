namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lineCount = int.Parse(Console.ReadLine());

            SortedSet<string>   periodicTable = new SortedSet<string>();

            for (int i = 0; i < lineCount; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in elements)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));

        }
    }
}