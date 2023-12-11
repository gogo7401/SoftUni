using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            int lightsabresCount = int.Parse(Math.Ceiling(countOfStudents * 1.1).ToString());
            int beltCount = countOfStudents - (countOfStudents / 6);

            double equipmentPrice = lightsabresCount * priceOfLightsabers + countOfStudents * priceOfRobes + beltCount * priceOfBelts;

            if (equipmentPrice <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentPrice:F2}lv.");
            }
            else { Console.WriteLine($"John will need {equipmentPrice-amountOfMoney:F2}lv more."); }
        }
    }
}
