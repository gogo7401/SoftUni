namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sides = new SortedDictionary<string, SortedSet<string>>();
            var users = new HashSet<string>();  

            string line;

            while ((line = Console.ReadLine()) != "Lumpawaroo")
            {
                string forceSide = string.Empty;
                string forceUser = string.Empty;
                string[] tokens = line.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 2)
                {
                    forceSide = tokens[0];
                    forceUser = tokens[1];

                    if (sides.ContainsKey(forceSide) == false)
                    {
                        sides.Add(forceSide, new SortedSet<string>());
                    }

                    if (users.Contains(forceUser) == false)
                    {
                        sides[forceSide].Add(forceUser);
                    }

                }
                else
                {
                    string[] input = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    forceUser = input[0];   
                    forceSide = input[1];   

                    if (sides.ContainsKey(forceSide) == false)
                    {
                        sides.Add(forceSide, new SortedSet<string>());  
                    }

                    if (users.Contains(forceUser))
                    {
                        foreach (var sideUsers in sides.Values)
                        {
                            if (sideUsers.Contains(forceUser))
                            {
                                sideUsers.Remove(forceUser);
                            }
                        }
                        sides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                    }
                    else
                    {
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        sides[forceSide].Add(forceUser);
                        
                    }
                }
                users.Add(forceUser);

            }

            foreach (var (side, sideMembers) in sides.OrderByDescending(m => m.Value.Count))
            {
                if (sideMembers.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {sideMembers.Count}");
                    foreach (var sideMember in sideMembers)
                    {
                        Console.WriteLine($"! {sideMember}");
                    }
                }
            }




        }
    }
}