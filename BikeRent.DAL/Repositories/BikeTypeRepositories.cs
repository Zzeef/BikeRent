using BikeRent.DAL.EF;
using BikeRent.DAL.Entity;
using BikeRent.DAL.Interfaces;

namespace BikeRent.DAL.Repositories
{
    public class BikeTypeRepositories : Repositories<BikeType>, IBikeTypeRepositories
    {
        readonly BikeRentContext context;

        public BikeTypeRepositories(BikeRentContext context)
            : base(context) 
        {
            this.context = context;
        }
    }
}
