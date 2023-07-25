using System.Diagnostics.Metrics;

namespace _09._Predicate_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = token[0];
                string condition = token[1];
                string filter = token[2];

                if (token[0] == "Double")
                {

                    List<string> peopleToDouble = guests.FindAll(GetPredicate(condition, filter));

                    int index = guests.FindIndex(GetPredicate(condition, filter));

                    if (index >= 0)
                    {
                        guests.InsertRange(index, peopleToDouble);
                    }
                }
                else if (token[0] == "Remove")
                {
                    guests.RemoveAll(GetPredicate(condition, filter));
                }

            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string condition, string filter)
        {
            switch (condition)
            {
                case "StartsWith":
                    return r => r.StartsWith(filter);

                case "EndsWith":
                    return r => r.EndsWith(filter);

                case "Length":
                    return r => r.Length == int.Parse(filter);

                default:
                    return default(Predicate<string>);
            }
        }
    }
}