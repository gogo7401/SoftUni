using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string weekDay = Console.ReadLine();
            double singlePersonPrice = 0.00;
            double totalPrice = 0.00;

            switch (weekDay)
            {
                case "Friday":
                    if (groupType == "Students")
                    {
                        singlePersonPrice = 8.45;
                    }
                    else if (groupType == "Business")
                    {
                        singlePersonPrice = 10.90;
                    }
                    else if (groupType == "Regular")
                    {
                        singlePersonPrice = 15.00;
                    }
                    break;
                case "Saturday":
                    if (groupType == "Students")
                    {
                        singlePersonPrice = 9.80;
                    }
                    else if (groupType == "Business")
                    {
                        singlePersonPrice = 15.60;
                    }
                    else if (groupType == "Regular")
                    {
                        singlePersonPrice = 20.00;
                    }
                    break;
                case "Sunday":
                    if (groupType == "Students")
                    {
                        singlePersonPrice = 10.46;
                    }
                    else if (groupType == "Business")
                    {
                        singlePersonPrice = 16.00;
                    }
                    else if (groupType == "Regular")
                    {
                        singlePersonPrice = 22.50;
                    }
                    break; 
 
            }
            if (groupType == "Students" && peopleCount >= 30)
            {
                totalPrice = singlePersonPrice * peopleCount - (singlePersonPrice * peopleCount * 0.15);
            }
            else if (groupType == "Business" && peopleCount >= 100)
            {
                totalPrice = singlePersonPrice * (peopleCount - 10);
            }
            else if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20) 
            {
                totalPrice = singlePersonPrice * peopleCount - (singlePersonPrice * peopleCount * 0.05);
            }
            else { totalPrice = singlePersonPrice * peopleCount; }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
