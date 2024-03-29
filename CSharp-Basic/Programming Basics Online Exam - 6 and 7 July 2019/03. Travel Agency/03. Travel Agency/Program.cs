using System;

namespace _03._Travel_Agency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();   
            string typePacket = Console.ReadLine(); 
            string vipDiscount = Console.ReadLine();
            int day = int.Parse(Console.ReadLine());

            double priceDay = 0.00;
            bool isRigth = true;
            if (day > 7) { day --; }
            if (day > 0)
            {
                switch (townName)
                {
                    case "Bansko":
                    case "Borovets":
                        {
                            if (typePacket == "noEquipment" || typePacket == "withEquipment")
                            {
                                if (vipDiscount == "yes" || vipDiscount == "no")
                                {
                                    if (vipDiscount == "yes")
                                    {
                                        if (typePacket == "withEquipment") { priceDay = 90.00; }
                                        else { priceDay = 76.00; }
                                    }
                                    else
                                    {
                                        if (typePacket == "withEquipment") { priceDay = 100.00; }
                                        else { priceDay = 80.00; }
                                    }
                                }
                                else { isRigth = false; }
                            }
                            else { isRigth = false; }
                        }
                        break;
                    case "Varna":
                    case "Burgas":
                        {
                            if (typePacket == "noBreakfast" || typePacket == "withBreakfast")
                            {
                                if (vipDiscount == "yes" || vipDiscount == "no")
                                {
                                    if (vipDiscount == "yes")
                                    {
                                        if (typePacket == "withBreakfast") { priceDay = 114.40; }
                                        else { priceDay = 93.00; }
                                    }
                                    else
                                    {
                                        if (typePacket == "withBreakfast") { priceDay = 130.00; }
                                        else { priceDay = 100.00; }
                                    }
                                }
                                else { isRigth = false; }
                            }
                            else { isRigth = false; }
                        }
                        break;
                    default:
                        { isRigth = false; }
                        break;
                }
                if (!isRigth) { Console.WriteLine("Invalid input!"); }
                else
                {
                    Console.WriteLine($"The price is {day*priceDay:f2}lv! Have a nice time!");
                }
            }
            else { Console.WriteLine("Days must be positive number!"); }
        }
    }
}
