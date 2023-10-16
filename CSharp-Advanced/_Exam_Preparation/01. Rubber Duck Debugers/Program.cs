using System.Threading.Tasks;

namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> timeQueue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> taskStack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> ducks = new Dictionary<string, int>();
            ducks.Add("Darth Vader Ducky", 0);
            ducks.Add("Thor Ducky", 0);
            ducks.Add("Big Blue Rubber Ducky", 0);
            ducks.Add("Small Yellow Rubber Ducky", 0);

            while (true)
            {
                if (timeQueue.Count == 0 || taskStack.Count == 0)
                {
                    break;
                }

                int programmersTime = timeQueue.Peek();
                int valueTask = taskStack.Peek();

                int multiply = programmersTime * valueTask;

                if (multiply > 240)
                {
                    valueTask -= 2;
                    timeQueue.Dequeue();
                    timeQueue.Enqueue(programmersTime);
                    taskStack.Pop();
                    taskStack.Push(valueTask);
                    continue;

                }
                else if (multiply >=  181)
                {
                    ducks["Small Yellow Rubber Ducky"]++;
                }
                else if (multiply >= 121)
                {
                    ducks["Big Blue Rubber Ducky"]++;
                }
                else if (multiply >= 61)
                {
                    ducks["Thor Ducky"]++;
                }
                else if (multiply >= 0)
                {
                    ducks["Darth Vader Ducky"]++;
                }

                timeQueue.Dequeue();
                taskStack.Pop();



            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Key}: {duck.Value}");
            }


        }
    }
}