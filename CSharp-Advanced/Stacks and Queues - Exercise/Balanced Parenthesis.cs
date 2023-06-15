using System.Text;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            // {[()]} - This is a balanced parenthesis.
            // {[]()}
            // {{[[(())]]}}
            
            // {[(])} - This is not a balanced parenthesis.
            // }{()[]
            // {[()]

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Boolean isBalanced = true;

            Stack<string> parenthesesStack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    parenthesesStack.Push(input[i].ToString());
                }
                else
                {
                    if (parenthesesStack.Count > 0)
                    {
                        if ((parenthesesStack.Peek() == "{" && input[i].ToString() == "}") ||
                                (parenthesesStack.Peek() == "[" && input[i].ToString() == "]") ||
                                (parenthesesStack.Peek() == "(" && input[i].ToString() == ")"))
                        {
                            parenthesesStack.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}