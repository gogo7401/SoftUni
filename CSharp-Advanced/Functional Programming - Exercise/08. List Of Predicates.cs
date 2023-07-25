namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> isPrint = (n, d) =>
            {
                bool isTrue = true;

                foreach (var item in d)
                {
                    if (n % item != 0)
                    {
                        isTrue = false; 
                        break;
                    }
                }

                return isTrue;
            };

            for (int i = 1; i <= lastNumber; i++)
            {
                if (isPrint(i, divisors))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}