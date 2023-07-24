namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int letterCount = int.Parse(Console.ReadLine());    
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> Print = (list) =>
            {
                foreach (var item in list)
                {
                    if (item.Length <= letterCount)
                    {
                        Console.WriteLine(item);
                    }
                }
            };

            Print(names);
        }
    }
}