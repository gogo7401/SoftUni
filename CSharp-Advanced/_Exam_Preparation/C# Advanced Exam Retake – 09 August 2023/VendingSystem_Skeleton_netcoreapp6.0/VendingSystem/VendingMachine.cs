using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }

        public int GetCount { get { return Drinks.Count; } }

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > Drinks.Count)
            {

                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return Drinks.Remove(Drinks.FirstOrDefault(d => d.Name == name));
        }

        public Drink GetLongest()
        {
            int max = Drinks.Max(x => x.Volume);
            return Drinks.Where(x => x.Volume == max).First();
        }
        public Drink GetCheapest()
        {
            decimal min = Drinks.Min(x => x.Price);
            return Drinks.Where(x => x.Price == min).First();
        }

        public string BuyDrink(string name)
        {
            return Drinks.FirstOrDefault(x => x.Name == name).ToString();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Drinks available:");
            foreach (var currDrink in Drinks)
            {
                sb.AppendLine(currDrink.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
