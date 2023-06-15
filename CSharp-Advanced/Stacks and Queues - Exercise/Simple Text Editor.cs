using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder(string.Empty);   
            Stack<string> stackUndoes = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "1":
                        stackUndoes.Push(text.ToString());
                        text.Append(command[1]);
                        
                        break;

                    case "2":
                        int count = int.Parse(command[1]);
                        stackUndoes.Push(text.ToString());
                        text.Remove( text.Length - count, count);
                        
                        break;

                    case "3":
                        int position = int.Parse(command[1]);
                        position--;
                        Console.WriteLine(text[position]);
                        break;

                    case "4":
                        text.Clear();
                        text.Append(stackUndoes.Pop());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}