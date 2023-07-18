using System.Diagnostics;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int count = int.Parse(Console.ReadLine());
            string condition = string.Empty;
            int age = 0;
            string filter = string.Empty;

            Func<int, string, int, bool> createFilter = (p, c, a) => c == "older" ? p >= a : p < a;
            Action<string, string, int> createPriner = (c, n, a) =>
            {
                if (c == "name")
                {
                    Console.WriteLine(n);
                }
                else if (c == "age")
                {
                    Console.WriteLine(a);
                }
                else if (c == "name age")
                {
                    Console.WriteLine($"{n} - {a}");
                }
            };

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(input[0], int.Parse(input[1]));
            }

            condition = Console.ReadLine();

            age = int.Parse(Console.ReadLine());   
            
            filter = Console.ReadLine();    

            foreach (var (namePerson, agePerson) in people)
            {
                if (createFilter(agePerson, condition, age))
                {
                    createPriner(filter, namePerson, agePerson);
                }
            }

            // CreateFilter
            // CreatePrinter
        }
    }
}