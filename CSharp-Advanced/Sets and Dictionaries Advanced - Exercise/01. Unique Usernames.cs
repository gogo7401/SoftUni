namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}