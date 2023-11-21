using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        protected Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PlayerNameNull));
                }
                name = value;
            }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            protected set
            {
                if (value < 1) { value = 1; }
                if (value > 10) {  value = 10; }
                rating = value;
            }
        }

        private string team;

        public string Team
        {
            get { return team; }
            private set 
            { 
                team = value; 
            }
        }


        public void JoinTeam(string teamName)
        {
            this.Team = teamName;
        }


        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");

            return sb.ToString().Trim();
        }
    }
}
