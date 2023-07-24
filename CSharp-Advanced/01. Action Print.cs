using System.Threading.Channels;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> Print = (i) => Console.WriteLine(string.Join(Environment.NewLine, i));
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Print(input);
        }
    }
}