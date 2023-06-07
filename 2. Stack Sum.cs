namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
               
            
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            string command = Console.ReadLine();

            while (command.ToUpper() != "END")
            {
                string[] commandSplits = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandSplits[0].ToUpper() == "ADD")
                {
                    stack.Push(int.Parse(commandSplits[1]));
                    stack.Push(int.Parse(commandSplits[2]));
                }
                else if (commandSplits[0].ToUpper() == "REMOVE")
                {
                    int countToRemove = int.Parse(commandSplits[1]);    

                    if (stack.Count >= countToRemove)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}