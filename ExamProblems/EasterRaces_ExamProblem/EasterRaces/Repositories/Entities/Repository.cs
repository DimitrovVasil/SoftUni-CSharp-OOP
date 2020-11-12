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
        private List<T> models;

        public Repository()
        {
            models = new List<T>();
        }

        public ICollection<T> Models
        { 
            get => models;
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public ICollection<T> GetAll()
        {
            return models.AsReadOnly();
        }

        public T GetByName(string name)
        {
            var result = models.FirstOrDefault(x => x.GetType().Name == name);
            return result;
        }

        public bool Remove(T model)
        {

            return models.Remove(model);
            //var modelForRemove = models.FirstOrDefault(x => x.GetType() == model.GetType());

            //if (modelForRemove != null)
            //{
            //    models.Remove(modelForRemove);
            //    return true;
            //}

            //return false;
        }
    }
}
