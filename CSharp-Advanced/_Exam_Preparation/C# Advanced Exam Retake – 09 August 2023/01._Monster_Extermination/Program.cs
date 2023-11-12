namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monsterArmor_queue = new Queue<int>();
            Stack<int> soldierStrike_stack = new Stack<int>();
            int killedMonsters = 0;
            int soldier = 0;
            int countAdded = 0;

            int[] input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                monsterArmor_queue.Enqueue(input[i]);
            }

            input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

            for(int i = 0;i < input.Length; i++)
            {
                soldierStrike_stack.Push(input[i]);
            }

            while (monsterArmor_queue.Count > 0 && soldierStrike_stack.Count > 0)
            {

                int monster = monsterArmor_queue.Dequeue();
                soldier += soldierStrike_stack.Pop();

                if (soldier >= monster)
                {
                    killedMonsters++;
                    soldier -= monster;

                    if (soldier > 0 && soldierStrike_stack.Count == 0 && countAdded == 0)
                    {
                        soldierStrike_stack.Push(soldier);
                        soldier = 0;
                        countAdded++;
                    }
                }
                else if (soldier < monster)
                {
                    monster -= soldier;
                    soldier = 0;
                    monsterArmor_queue.Enqueue(monster);
                }


            }

            if (monsterArmor_queue.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (soldierStrike_stack.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");

        }
    }
}