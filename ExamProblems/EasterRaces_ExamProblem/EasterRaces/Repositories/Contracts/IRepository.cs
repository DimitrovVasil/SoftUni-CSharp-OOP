namespace EasterRaces.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        public ICollection<T> Models { get; }

        public void Add(T model);
        public bool Remove(T model);
        public T GetByName(string name);
        public ICollection<T> GetAll();
    }
}
