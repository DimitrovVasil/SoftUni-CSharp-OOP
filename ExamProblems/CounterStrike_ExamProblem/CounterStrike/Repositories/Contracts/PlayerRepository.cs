using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            IPlayer player = players.FirstOrDefault(p => p.Username == name);
            return player;
        }

        public bool Remove(IPlayer model) => players.Remove(model);
    }
}
