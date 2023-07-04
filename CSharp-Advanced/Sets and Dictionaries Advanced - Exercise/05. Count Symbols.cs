namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();

            var sortedDict = new SortedDictionary<char, int>();

            foreach (char c in chars)
            {
                if (sortedDict.ContainsKey(c) == false)
                {
                    sortedDict.Add(c, 0);
                }
                sortedDict[c]++;
            }

            foreach (var (ch, times) in sortedDict)
            {
                Console.WriteLine($"{ch}: {times} time/s");
            }
        }
    }
}