namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperation = int.Parse(Console.ReadLine());

            int[] command = new int[] { };

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfOperation; i++)
            {
                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;

                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}