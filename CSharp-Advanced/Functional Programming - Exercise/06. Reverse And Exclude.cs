namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, IEnumerable<int>> reverseList = (x) => x = x.Reverse();

            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            list = reverseList(list).ToList();

            Predicate<int> isDivide = (x) => x % divider != 0;

            foreach (int item in list)
            {
                if (isDivide(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}