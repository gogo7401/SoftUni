namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();  

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(number) == false)
                {
                    dict.Add(number, 0);
                }

                dict[number]++;
            }

            foreach (var (numberKey, numberValue) in dict)
            {
                if (numberValue % 2 == 0)
                {
                    Console.WriteLine(numberKey);
                    break;
                }
            }
        }
    }
}