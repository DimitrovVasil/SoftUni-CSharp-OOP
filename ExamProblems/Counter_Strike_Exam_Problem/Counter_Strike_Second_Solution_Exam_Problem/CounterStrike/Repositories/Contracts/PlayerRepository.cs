using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");
            }

            models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            if (models.Any(n => n.Username == name))
            {
                return models.FirstOrDefault(n => n.Username == name);
            }

            return null;
        }

        public bool Remove(IPlayer model)
        {
            return models.Remove(model);
        }
    }
}
