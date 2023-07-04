namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string item = input[j];
                    if (wardrobe[color].ContainsKey(item) == false)
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] wanted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string wantedColor = wanted[0];
            string wantedClothing = wanted[1];

            foreach (var (color, items) in wardrobe) 
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (clothing, count) in items)
                {
                    if (color == wantedColor && clothing == wantedClothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");
                    }
                }
            }
        }
    }
}