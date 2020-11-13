using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            IGun targetGun = guns.FirstOrDefault(gun => gun.Name == name);
            return targetGun;
        }

        public bool Remove(IGun model) => guns.Remove(model);

    }
}
