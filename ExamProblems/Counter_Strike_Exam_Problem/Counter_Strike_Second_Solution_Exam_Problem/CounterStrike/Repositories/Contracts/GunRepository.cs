using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    //TODO: Abstract?
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }

            models.Add(model);
        }

        public IGun FindByName(string name)
        {
            if (models.Any(n => n.Name == name))
            {
                return models.FirstOrDefault(n => n.Name == name);
            }

            return null;
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
