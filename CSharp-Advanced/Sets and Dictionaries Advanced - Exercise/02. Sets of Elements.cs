namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLenght = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray(); 

            int setOne = setsLenght[0];
            int setTwo = setsLenght[1];

            HashSet<int> setsOne = new HashSet<int>();
            HashSet<int> setsTwo = new HashSet<int>();

            for (int i = 0; i < setOne;  i++)
            {
                setsOne.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setTwo; i++)
            {
                setsTwo.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in setsOne)
            {
                if (setsTwo.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}