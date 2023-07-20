namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> Print = (n) => Console.WriteLine($"Sir {n}");
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in names)
            {
                Print(name);
            }


        }
    }
}