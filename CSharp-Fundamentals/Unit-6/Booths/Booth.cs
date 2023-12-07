using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
			// ----------------------------------------------------
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
			// ----------------------------------------------------

            this.currentBill = 0;
            this.turnover = 0;
        }

        private int boothId;

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }


        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                capacity = value; 
            }
        }
//
// •	DelicacyMenu – DelicacyRepository all available to order delicacies
// •	CocktailMenu – CocktailRepository all available to order cocktails
		
// ----------------------------------------------------
        private readonly IRepository<IDelicacy> delicacyMenu;

        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return delicacyMenu; }
        }

        private readonly IRepository<ICocktail> cocktailMenu;

        public IRepository<ICocktail> CocktailMenu
        {
            get { return cocktailMenu; }
        }
// ----------------------------------------------------

        private double currentBill;

        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }


        private double turnover;

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }


        private bool isReserved;

        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }


        public void ChangeStatus()
        {
            if (this.IsReserved)
            {
                this.IsReserved = false;

            }
            else
            {
                this.IsReserved = true;
            }
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
// ----------------------------------------------------
            foreach ( var cocktail in this.CocktailMenu.Models )
            {
                sb.AppendLine(cocktail.ToString());
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine(delicacy.ToString());
            }
// ----------------------------------------------------
            return sb.ToString().Trim();
        }
    }
}
