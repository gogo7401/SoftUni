using System.Diagnostics.Contracts;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            int passedCarsCount = 0;

            while (input.ToLower() != "end")
            {
                if (input.ToLower() == "green")
                {
                    int carToPass = cars.Count;
                    if (carToPass > n)
                    {
                        carToPass = n;
                    }
                    for (int i = 0; i < carToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCarsCount++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}