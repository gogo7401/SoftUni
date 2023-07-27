namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> filtersSet = new HashSet<string>();

            List<string> peoples = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] token = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = token[0];
                string filter = token[1] + ";" + token[2];

                if (action == "Add filter")
                {
                    filtersSet.Add(filter);
                }
                else
                {
                    filtersSet.Remove(filter);
                }
            }

            foreach (string filter in filtersSet)
            {
                string[] token = filter.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string condition = token[0];
                string value = token[1];

                peoples.RemoveAll(GetPredicate(condition, value));
            }

            Console.WriteLine(string.Join(" ", peoples));

        }

        static Predicate<string> GetPredicate(string condition, string value)
        {
            switch (condition)
            {
                case "Starts with":
                    return p => p.StartsWith(value);
                        case "Ends with":
                    return p => p.EndsWith(value);
                        case "Length":
                    return p => p.Length == int.Parse(value);
                        case "Contains":
                    return p => p.Contains(value);  
                default:
                    return default(Predicate<string>);

            }
        }
    }
}