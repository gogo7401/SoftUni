namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<PetrolPump> pumps = new Queue<PetrolPump>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(new PetrolPump(input[0], input[1]));

            }

            int count = 0;

            while (count <= n - 1)
            {
                Boolean isValid = true;
                int totalLiters = 0;
                int currentLiters = 0;
                int currentDistance = 0;

                Queue<PetrolPump> pumpsTemp = new Queue<PetrolPump>(pumps);

                for (int i = 0; i < n; i++)
                {
                    PetrolPump currentPump = pumpsTemp.Dequeue();
                    currentLiters = currentPump.Liters;
                    totalLiters += currentLiters;
                    currentDistance = currentPump.Distance;
                    totalLiters -= currentDistance;

                    if (totalLiters < 0)
                    {
                        isValid = false;
                        break;
                    }
                    
                }

                if (isValid)
                {
                    Console.WriteLine(count);
                    break;
                }
                else
                {
                    count++;
                    pumps.Enqueue(pumps.Dequeue());
                }

            }


        }

        class PetrolPump
        {
            public PetrolPump(int liters, int distance)
            {
                this.Liters = liters;
                this.Distance = distance;
            }

            public int Liters { get; set; }
            public int Distance { get; set; }

        }
    }
}