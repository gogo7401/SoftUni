namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            string command = Console.ReadLine();

            Boolean isSafe = true;
            int totalCarsPassed = 0;
            string car = string.Empty;
            string characterHit = string.Empty;

            while (command != "END")
            {
                if (command == "green")
                {
                    int remainingSeconds = greenLight;
                    int bonusseconds = freeWindow;
                    
                    while (queue.Count > 0)
                    {
                        if ((remainingSeconds - queue.Peek().Length) > 0)
                        {
                            remainingSeconds -= queue.Peek().Length;
                            queue.Dequeue();
                            totalCarsPassed++;
                        }
                        else
                        {
                            break;
                        }
                        
                        
                    }

                    if (queue.Count > 0 && remainingSeconds > 0)
                    {
                        car = queue.Peek();
                        remainingSeconds += bonusseconds;
                        if (remainingSeconds >= car.Length)
                        {
                            queue.Dequeue();
                            totalCarsPassed++;
                        }
                        else
                        {
                            characterHit = car.Substring(remainingSeconds,1);
                            isSafe= false;
                            break;
                        }
                    }



                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            if (isSafe)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{car} was hit at {characterHit}.");
            }
        }
    }
}