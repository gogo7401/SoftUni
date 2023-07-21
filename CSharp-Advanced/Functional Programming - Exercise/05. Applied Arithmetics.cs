using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>,List<int>> add = x => x.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(x => x * 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(x => x - 1).ToList();

            Action<List<int>> print = p => Console.WriteLine(string.Join(" ", p));

            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        list = add(list);
                        break;
                    case "multiply":
                        list = multiply(list);
                        break;
                    case "subtract":
                        list = subtract(list);
                        break;
                    case "print":
                        print(list);
                        break;
                    default:
                        break;
                }


            }

        }
    }
}