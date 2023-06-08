namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

            string input = Console.ReadLine();

            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = brackets.Pop();
                    Console.WriteLine(input.Substring(startIndex,i - startIndex + 1 ));
                }


            }
        }
    }
}