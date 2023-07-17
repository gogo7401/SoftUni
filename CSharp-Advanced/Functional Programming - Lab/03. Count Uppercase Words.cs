namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 variant
            //Predicate<string> isCapitalLetter = x => x[0] == x.ToUpper()[0];
            //2 variant
            Predicate<string> isCapitalLetter = x => char.IsUpper(x[0]);
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, input
                .Where(x => isCapitalLetter(x))));
        }
    }
}