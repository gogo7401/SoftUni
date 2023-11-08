using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Basketball
{
    public class Team
    {
        private readonly List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            bool removed = false;

            removed = players.Remove(players.FirstOrDefault(n => n.Name == name));

            if (removed) { OpenPositions++; }

            return removed;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedCount = 0;

            var list = players.FindAll(n => n.Position == position);

            removedCount = list.Count;

            OpenPositions += removedCount;

            foreach (var player in list)
            {
                players.Remove(player);
            }

            return removedCount;
        }

        public Player RetirePlayer(string name)
        {
            Player retiredPlayer = players.FirstOrDefault(n => n.Name == name);

            if (retiredPlayer != null)
            {
                retiredPlayer.Retired = true;
            }

            return retiredPlayer;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.FindAll(n => n.Games >= games);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            var list = players.FindAll(p => p.Retired == false);

            foreach ( var player in list)
            {
                sb.AppendLine(player.ToString());
            }


            return sb.ToString().TrimEnd();
        }

    }
}
