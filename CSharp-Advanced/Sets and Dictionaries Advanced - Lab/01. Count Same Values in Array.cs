namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input // -2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3

            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dict = new Dictionary<double, int> ();

            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]) == false)
                {
                    dict.Add(input[i], 0);
                }

                dict[input[i]]++;
            }

            foreach (var (value, count) in dict)
            {
                Console.WriteLine($"{value} - {count} times");
            }


        }
    }
}