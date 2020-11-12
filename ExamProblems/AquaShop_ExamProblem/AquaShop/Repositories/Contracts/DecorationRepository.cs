using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration targetDecoration = decorations.FirstOrDefault(x => x.GetType().Name == type);
            return targetDecoration;
        }

        public bool Remove(IDecoration model)
        {
            return decorations.Remove(model);
        }
    }
}
