using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    internal class TeamRepository : IRepository<ITeam>
    {
        private readonly ICollection<ITeam> teams;
        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => teams as IReadOnlyCollection<ITeam>;

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return teams.Any(t => t.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }

        public bool RemoveModel(string name)
        {
            ITeam removeModelName = teams.FirstOrDefault(t => t.Name == name);
            if (removeModelName != null)
            {
                teams.Remove(removeModelName);
                return true;
            }
            return false;
        }
    }
}
