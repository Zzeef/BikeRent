using BikeRent.DAL.Entity;
using System.Linq;

namespace BikeRent.DAL.Interfaces
{
    public interface IBikeRepositories : IRepositories<Bike>
    {
        public IQueryable<Bike> GetFreeBike();
    }
}
