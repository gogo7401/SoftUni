//  10
using System;

namespace WeatherForecastPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double t = double.Parse(Console.ReadLine());

            if ((t<5) || (t>35)) { Console.WriteLine("unknown"); }
            if ((t >= 5) && (t <= 11.9)) { Console.WriteLine("Cold"); }
            if ((t >= 12) && (t <= 14.9)) { Console.WriteLine("Cool"); }
            if ((t >= 15) && (t <= 20)) { Console.WriteLine("Mild"); }
            if ((t >= 20.1) && (t <= 25.9)) { Console.WriteLine("Warm"); }
            if ((t >= 26) && (t <= 35)) { Console.WriteLine("Hot"); }
        }
    }
}