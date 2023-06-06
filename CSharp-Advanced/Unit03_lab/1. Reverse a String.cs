namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> chars = new Stack<char>();
            string input = Console.ReadLine();
            foreach (char ch in input)
            {
                chars.Push(ch);
            }
            Console.WriteLine(string.Join("", chars.ToArray()));
        }
    }
}