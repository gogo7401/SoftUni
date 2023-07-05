using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace _07_._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string>[,] info = new SortedSet<string>[1, 2];
            var vloggers = new Dictionary<string, SortedSet<string>[,]>();

            string line;
            while ((line = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vLoggerOne = tokens[0];
                string command = tokens[1];
                string vLoggerTwo = tokens[2];

                if (command == "joined")
                {
                    if (vloggers.ContainsKey(vLoggerOne) == false)
                    {
                        vloggers.Add(vLoggerOne, new SortedSet<string>[1, 2]);
                        //info[0, 0] = new SortedSet<string>();
                        //info[0, 1] = new SortedSet<string>();
                        //vloggers[vLoggerOne] = info;
                        vloggers[vLoggerOne][0, 0] = new SortedSet<string>();
                        vloggers[vLoggerOne][0, 1] = new SortedSet<string>();
                    }
                }
                else if (command == "followed")
                {
                    // Ако някое от дадените имена на Vlogger не съществува във вашата колекция, игнорирайте тази команда.
                    // Vlogger не може да следва себе си.

                    if (vloggers.ContainsKey(vLoggerOne) == false || vloggers.ContainsKey(vLoggerTwo) == false || vLoggerOne == vLoggerTwo)
                    {
                        continue;
                    }

                    //// Влогърите не могат да следват някого, на когото вече са последователи.

                    //if (followers[vLoggerFollowed].Contains(vLogger))
                    //{
                    //    continue;
                    //}

                    // „{vloggername} последва {vloggername}“ – Първият влогър последва втория влогър.

                    //info = vloggers[vLoggerTwo];

                    //info[0, 0].Add(vLoggerOne);

                    vloggers[vLoggerTwo][0, 0].Add(vLoggerOne);

                    //info[0, 0].Clear();
                    //info[0,1].Clear();

                    //info = vloggers[vLoggerOne];

                    //info[0, 1].Add(vLoggerTwo);

                    vloggers[vLoggerOne][0, 1].Add(vLoggerTwo);

                    //info[0, 0].Clear();
                    //info[0, 1].Clear();

                }

            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var output = vloggers.OrderByDescending(x => x.Value[0, 0].Count)
                .ThenBy(x => x.Value[0, 1].Count)
                .ToDictionary(x => x);

            int number = 0;
            foreach (var item in output.Keys)
            {
                number++;
                if (number == 1)
                {
                    // 1. VenomTheDoctor : 2 followers, 0 following
                    Console.WriteLine($"{number}. {item.Key} : {item.Value[0, 0].Count} followers, {item.Value[0, 1].Count} following");
                    if (item.Value[0, 0].Count > 0)
                    {
                        // * EmilConrad
                        foreach (var followers in item.Value[0, 0])
                        {
                            Console.WriteLine($"*  {followers}");
                        }
                    }
                }
                else
                {
                    // 2. EmilConrad : 1 followers, 1 following
                    Console.WriteLine($"{number}. {item.Key} : {item.Value[0, 0].Count} followers, {item.Value[0, 1].Count} following");
                }
            }


        }
    }

    public class VideoLogger
    {
        public SortedSet<string> followers { get; set; }

        public HashSet<string> following { get; set; }

        // Create a class constructor with a parameter
        public VideoLogger(string followers, string following)
        {
            this.followers.Add(followers);
            this.following.Add(following);
        }

    }
}