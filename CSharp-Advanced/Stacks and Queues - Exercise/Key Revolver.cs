namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());    
            int gunBarrelSize = int.Parse(Console.ReadLine());
            
            int[] inputBullet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputLocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfTheIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(inputBullet);
            Queue<int> queueLocks = new Queue<int>(inputLocks);

            //Console.WriteLine(string.Join(" ",stackBullets));
            //Console.WriteLine(string.Join(" ", queueLocks));

            int countOfShoots = 0;
            int moneyEarned = 0;
            int moneySpend = 0;

            while (stackBullets.Count > 0 && queueLocks.Count > 0)
            {
                // bullet <= lock   - remove bullet && remove lock, print "Bang!"
                // bullet > lock    - only remove bullet, print "Ping!"
                // countOfShoots > gunBarrelSize   - print "Reloading!" 
                

                int currentBulet = stackBullets.Pop();
                int currentLock = queueLocks.Peek();

                countOfShoots++;
                moneySpend += bulletPrice;

                if (currentBulet <= currentLock)
                {
                    queueLocks.Dequeue();
                    Console.WriteLine("Bang!");

                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countOfShoots == gunBarrelSize && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    countOfShoots = 0;
                }
            }

            moneyEarned = valueOfTheIntelligence - moneySpend;

            if (queueLocks.Count == 0)
            {
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }

        }
    }
}