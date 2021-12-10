using System;
using BikeRent.DAL.EF;
using BikeRent.DAL.Interfaces;

namespace BikeRent.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BikeRentContext db;
        private BikeRepositories bikeRepositories;
        private BikeTypeRepositories bikeTypeRepositories;

        public UnitOfWork(BikeRentContext context) 
        {
            db = context;
        }

        public IBikeRepositories Bikes 
        {
            get 
            {
                if (bikeRepositories == null)
                    bikeRepositories = new BikeRepositories(db);
                return bikeRepositories;
            }
        }
        public IBikeTypeRepositories BikeTypes 
        {
            get
            {
                if (bikeTypeRepositories == null)
                    bikeTypeRepositories = new BikeTypeRepositories(db);
                return bikeTypeRepositories;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disosed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disosed)
            {
                db.Dispose();
            }
            this.disosed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
