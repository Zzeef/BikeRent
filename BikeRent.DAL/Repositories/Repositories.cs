using BikeRent.DAL.EF;
using BikeRent.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRent.DAL.Repositories
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        readonly BikeRentContext context;
        readonly DbSet<T> db;

        public Repositories(BikeRentContext context)
        {
            this.context = context;
            db = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return db;
        }

        public T Get(Guid id)
        {
            return db.Find(id);
        }

        public void Create(T item)
        {
            db.Add(item);
        }

        public void Update(T item)
        {
            context.Entry<T>(item).Reload();
        }

        public void Delete(Guid id)
        {
            T item = db.Find(id);
            if (item != null)
            {
                db.Remove(item);
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
