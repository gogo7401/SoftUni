namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addVAT = x => (x * 1.2D).ToString("F2");
            double[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, input.Select(x => addVAT(x))));
        }
    }
}