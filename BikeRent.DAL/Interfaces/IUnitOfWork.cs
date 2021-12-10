using System;

namespace BikeRent.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBikeRepositories Bikes { get; }
        IBikeTypeRepositories BikeTypes { get; }
        void Save();
    }
}
