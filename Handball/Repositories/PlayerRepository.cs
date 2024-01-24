using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => players as IReadOnlyCollection<IPlayer>;

        public void AddModel(IPlayer model)
        {

            players.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return players.Any(p => p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return players.FirstOrDefault(model => model.Name == name);
        }

        public bool RemoveModel(string name)
        {
            IPlayer modelToRemoveName = players.FirstOrDefault(p => p.Name == name);

            if (modelToRemoveName != null)
            {
                players.Remove(modelToRemoveName);
                return true;
            }
            else
            {
                return false; // Model with the specified name was not found
            }
            
        }
    }
}
