namespace _09_._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // {username}-{language}-{points}
            var students = new SortedDictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            string line;
            while ((line = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string language = tokens[1];
                int points = 0;
                if (language == "banned")
                {
                    if (students.ContainsKey(username))
                    {

                        students.Remove(username);
                        continue;
                    }
                }
                else
                {

                    points = int.Parse(tokens[2]);
                }

                if (students.ContainsKey(username) == false)
                {
                    students.Add(username, points);

                }
                else
                {
                    if (students[username] < points)
                    {
                        students[username] = points;
                    }
                }

                if (submissions.ContainsKey(language) == false)
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;


            }

            Console.WriteLine("Results:");
            foreach (var (username, points) in students.OrderByDescending(p => p.Value))
            {

                Console.WriteLine($"{username} | {points}");
            }
            Console.WriteLine("Submissions:");
            foreach (var (language, count) in submissions.OrderByDescending(p => p.Value).ThenBy(l => l.Key))
            {

                Console.WriteLine($"{language} - {count}");
            }
        }
    }
}