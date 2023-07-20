namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> minValue = (n) => n.OrderBy(x => x).ToList();
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int result = minValue(numbers)[0];
            Console.WriteLine(result);
        }
    }
}