using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        private List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Models
        {
            get { return players.AsReadOnly(); }
        }




        public void AddModel(IPlayer player)
        {
            players.Add(player);
        }
        public bool RemoveModel(string name)
        {
            return players.Remove(players.FirstOrDefault(p => p.Name == name));
        }

        public bool ExistsModel(string name)
        {
            bool result = false;

            if (players.FirstOrDefault(p => p.Name == name) != null) 
            { 
                result = true;
            }

            return result;
        }

        public IPlayer GetModel(string name)
        {
            return players.FirstOrDefault(p => p.Name == name);  
        }

    }
}
