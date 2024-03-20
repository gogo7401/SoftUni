//  07
using System;

namespace HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double stenaX = x * x * 2 - 1.2 * 2;
            double stenaY = x * y * 2 - 1.5 * 1.5 * 2;
            double pokrivPrav = x * y * 2;
            double pokrivTriagal = x * h;  // x * h / 2 * 2

            double litreZelena = (stenaX+stenaY) / 3.4;
            double litreChervena = (pokrivPrav + pokrivTriagal) / 4.3;

            Console.WriteLine($"{litreZelena:F2}");
            Console.WriteLine($"{litreChervena:F2}");
        }
    }
}
