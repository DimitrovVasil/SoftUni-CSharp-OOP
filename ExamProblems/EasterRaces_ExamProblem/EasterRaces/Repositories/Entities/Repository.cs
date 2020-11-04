using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Repositories.Contracts;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            Models = new List<T>();
        }

        public List<T> Models;

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            IReadOnlyCollection<T> collection = Models.AsReadOnly();

            return collection;
        }

        public T GetByName(string name)
        {
            dynamic dynamic = 5;
            T element = dynamic;
            return element;

            throw new Exception("NE SAM GO IMPLEMENTIRAL");
        }

        public bool Remove(T model)
        {
            if (Models.Contains(model))
            {
                Models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
