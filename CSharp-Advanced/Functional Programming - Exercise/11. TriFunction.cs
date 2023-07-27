using System;
using System.Diagnostics.CodeAnalysis;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // 1 variant s vlozeni func
            
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> sumNames = new Dictionary<string, int>();

            Func<int, Func<List<string>, Dictionary<string, int>>, string> print = (n, c) =>
            {
                string result = string.Empty;

                foreach (var item in c(names))
                {
                    if (item.Value >= number)
                    {
                        return item.Key;
                        break;
                    }
                }

                return result;
            };

            Func<List<string>, Dictionary<string, int>> calculate = (n) =>
            {
                Dictionary<string, int> sum = new Dictionary<string, int>();

                foreach (string name in n)
                {
                    int sumary = 0;
                    for (int i = 0; i < name.Length; i++)
                    {
                        sumary += (int)name[i];
                    }
                    sum.Add(name, sumary);
                }

                return sum.OrderBy(x => x.Value).ToDictionary(s => s.Key, z => z.Value);
            };

            Console.WriteLine(print(number, calculate));



            // 2 variant bez Func

            //int number = int.Parse(Console.ReadLine());

            //List<string> names = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .ToList();

            //Dictionary<string, int> sumNames = new Dictionary<string, int>();

            //foreach (string name in names)
            //{
            //    int sum = 0;
            //    for (int i = 0; i < name.Length; i++)
            //    {
            //        sum += (int)name[i];
            //    }
            //    sumNames.Add(name, sum);
            //}

            //foreach (var item in sumNames.OrderBy(x => x.Value))
            //{
            //    if (item.Value >= number)
            //    {
            //        Console.WriteLine(item.Key);
            //        return;
            //    }
            //}
        }
    }
}