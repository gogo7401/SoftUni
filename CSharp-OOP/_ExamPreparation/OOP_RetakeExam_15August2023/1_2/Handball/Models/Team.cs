using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            this.players = new List<IPlayer>();

        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TeamNameNull));
                }
                name = value;
            }
        }



        private int pointsEarned;

        public int PointsEarned
        {
            get { return pointsEarned; }
            private set { pointsEarned = value; }
        }

        private double overallRating;

        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                decimal ovRating = (decimal)players.Average(p => p.Rating);
                return (double)Math.Round(ovRating, 2);
            }

        }

        private List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return players.AsReadOnly(); }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer goalkeeper = Players.FirstOrDefault(p => p.GetType().Name == "Goalkeeper");
            goalkeeper.IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {this.OverallRating}");
            string listOfPlayers = "none";
            if (Players.Count > 0)
            {
                listOfPlayers = string.Join(", ", Players.Select(p => p.Name));
            }
            sb.AppendLine($"--Players: {listOfPlayers}");
            return sb.ToString().Trim();
        }





    }
}
