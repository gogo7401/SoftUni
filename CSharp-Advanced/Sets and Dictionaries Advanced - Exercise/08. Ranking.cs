using System.ComponentModel;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, int>>();


            string line;
            bool endPartOne = false;
            while ((line = Console.ReadLine()) != "end of submissions")
            {
                if (line == "end of contests")
                {
                    endPartOne = true;
                    continue;
                }



                if (!endPartOne)
                {
                    string[] tokens = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string contest = tokens[0];
                    string password = tokens[1];
                    if (contests.ContainsKey(contest) == false)
                    {
                        contests.Add(contest, password);
                    }
                    contests[contest] = password;
                }
                else
                {
                    // {contest}=>{password}=>{username}=>{points}
                    string[] tokens = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                    string contest = tokens[0];
                    string password = tokens[1];
                    string username = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (contests.ContainsKey(contest) && contests[contest] == password)
                    {
                        if (students.ContainsKey(username) == false)
                        {
                            students.Add(username, new Dictionary<string, int>());
                            students[username].Add(contest, points);
                        }
                        else
                        {
                            if (students[username].ContainsKey(contest) == false)
                            {
                                students[username].Add(contest, points);
                            }
                            else if (students[username][contest] < points)
                            {
                                students[username][contest] = points;
                            }
                        }
                    }

                }
            }

            string bestUser = string.Empty;
            int totalPoints = int.MinValue;

            foreach (var username in students.Keys)
            {
                int currentUserPoints = 0;
                foreach (int points in students[username].Values)
                {
                    currentUserPoints += points;
                }

                if (currentUserPoints > totalPoints)
                {
                    bestUser = username;
                    totalPoints = currentUserPoints;
                }


            }

            Console.WriteLine($"Best candidate is {bestUser} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var username in students.Keys)
            {
                Console.WriteLine(username);
                foreach (var (contest, points) in students[username].OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }




        }
    }
}