using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        public TeamRepository()
        {
            this.teams = new List<ITeam>();
        }

        private List<ITeam> teams;

        public IReadOnlyCollection<ITeam> Models
        {
            get { return teams.AsReadOnly(); }
        }


        public void AddModel(ITeam team)
        {
            teams.Add(team);
        }
        public bool RemoveModel(string name)
        {
            return teams.Remove(teams.FirstOrDefault(t => t.Name == name));
        }

        public bool ExistsModel(string name)
        {
            return (teams.FirstOrDefault(t => t.Name == name) == null) ? false : true;
        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }

    }
}
