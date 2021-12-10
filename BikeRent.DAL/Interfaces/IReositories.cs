using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BikeRent.DAL.Interfaces
{
    public interface IRepositories<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
        Task<int> SaveChangeAsync();
    }
}
