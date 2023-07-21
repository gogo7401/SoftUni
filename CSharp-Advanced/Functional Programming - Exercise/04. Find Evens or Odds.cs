namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = (c) => c % 2 == 0;
            Predicate<int> isOdd = (d) => d % 2 != 0;

            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse) 
                .ToArray();

            string command = Console.ReadLine();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (command == "even" && isEven(i))
                {
                    Console.Write($"{i} ");
                }
                else if (command == "odd" && isOdd(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}