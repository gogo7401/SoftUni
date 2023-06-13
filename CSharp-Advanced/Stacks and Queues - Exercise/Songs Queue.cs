namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueSongs = new Queue<string>(input);

            string command = string.Empty;

            while (queueSongs.Count > 0)
            {
                command = Console.ReadLine();

                if (command == "Play" && queueSongs.Count > 0)
                {
                    queueSongs.Dequeue();
                }

                if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }

                if (command.Substring(0,3) == "Add")
                {
                    string newSong = command.Substring(4);
                    if (queueSongs.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        queueSongs.Enqueue(newSong);
                    }
                }

            }

            Console.WriteLine("No more songs!");

        }
    }
}