namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //// скапано решение без LINQ
            //List<int> numbers = new List<int>(Console.ReadLine()
            //   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //   .Select(int.Parse)
            //   .ToList()); 

            //numbers.Sort(); 

            //int count  = numbers.Count > 3 ? numbers.Count-3 : 0;

            //for (int i = numbers.Count -1; i >= count; i--)
            //{
            //    Console.Write($"{numbers[i]} ");
            //}
            //
            

            // готино решение с използване само на LINQ
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}