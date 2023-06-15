namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(inputBottles);
            Queue<int> cups = new Queue<int>(inputCups);

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {

                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek();

                if (currentBottle >= currentCup)
                {

                    wastedWater += (currentBottle - currentCup);
                    cups.Dequeue();
                }
                else
                {
                    currentCup -= currentBottle;
                    while (currentCup > 0 && bottles.Count > 0)
                    {
                        currentBottle = bottles.Pop();
                        currentCup -= currentBottle;
                        if (currentCup <= 0)
                        {
                            //currentCup *= -1;
                            wastedWater += -1*currentCup;
                            cups.Dequeue();
                        }
                    }
                    
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}