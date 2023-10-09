namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> toolsQueue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> substancesStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            List<int> challengesList = new List<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            while (true)
            {
                if (toolsQueue.Count == 0 || substancesStack.Count == 0)
                {
                    if (challengesList.Count > 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                        Print(toolsQueue, substancesStack, challengesList);
                    }
                    else
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        Print(toolsQueue, substancesStack, challengesList);
                    }
                    return;
                }

                if (challengesList.Count == 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    Print(toolsQueue,substancesStack,challengesList);
                    return;
                }
                
                
                int tool = toolsQueue.Dequeue();
                int substance = substancesStack.Pop();  
                int multiply = tool * substance;

                if (challengesList.Contains(multiply))
                {
                    challengesList.Remove(multiply);
                }
                else
                {
                    toolsQueue.Enqueue(tool+1);
                    if (substance-1 > 0)
                    {
                        substancesStack.Push(substance-1);
                    }
                }


            }




        }

        //o	"Tools: element1, element2, element3 … elementn"
        //o	"Substances: element1, element2, element3 … elementn"
        //o	"Challenges: element1, element2, element3 … elementn"


        static void Print(Queue<int> toolsQueue, Stack<int> substancesStack, List<int> challengesList)
        {
            if (toolsQueue.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", toolsQueue)}");
            }
            if (substancesStack.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substancesStack)}");
            }
            if (challengesList.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challengesList)}");
            }
        }
    }
}