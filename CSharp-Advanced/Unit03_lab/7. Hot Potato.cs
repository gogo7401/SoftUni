namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int burnCount = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);

            int currentCount = 1;

            string currendKid = null;

            while (kids.Count > 1)
            {
                if (currentCount == burnCount)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    currentCount = 1;
                }
                else
                {
                    currendKid = kids.Dequeue();
                    kids.Enqueue(currendKid);
                    currentCount++;
                }



            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}