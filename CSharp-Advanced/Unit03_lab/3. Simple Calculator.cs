namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int firstoperand = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int SecondOperand = int.Parse(stack.Pop());

                int result = 0;

                if (sign == "-")
                {
                    result = firstoperand - SecondOperand;
                    stack.Push(result.ToString());
                }
                else if (sign == "+")
                {
                    result = firstoperand + SecondOperand;
                    stack.Push(result.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}