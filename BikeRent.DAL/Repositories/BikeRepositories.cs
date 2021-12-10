using System.Linq;
using BikeRent.DAL.EF;
using BikeRent.DAL.Entity;
using BikeRent.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeRent.DAL.Repositories
{
    public class BikeRepositories : Repositories<Bike>, IBikeRepositories 
    {
        readonly BikeRentContext context;

        public BikeRepositories(BikeRentContext context) 
            : base(context)
        {
            this.context = context;
        }

        public IQueryable<Bike> GetFreeBike() 
        {
            return context.Bikes.FromSqlRaw("SELECT * FROM");
        }
    }
}
