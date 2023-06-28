namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();    
            bool isParty = false;
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                if (line == "PARTY")
                {
                    isParty = true;
                    continue;
                }

                if (isParty == false)
                {
                    guests.Add(line);
                }
                else
                {
                    guests.Remove(line);
                }
            }

            Console.WriteLine(guests.Count);
            foreach (var vipGuest in guests)
            {
                char ch = char.Parse(vipGuest.Substring(0,1));
                if (Char.IsDigit(ch))
                {
                    Console.WriteLine(vipGuest);
                }
            }

            foreach (var regularGuest in guests)
            {
                char ch = char.Parse(regularGuest.Substring(0, 1));
                if (Char.IsLetter(ch))
                {
                    Console.WriteLine(regularGuest);
                }
            }
        }
    }
}