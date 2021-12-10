using BikeRent.BLL.Interfaces;
using BikeRent.BLL.Services;
using BikeRent.DAL.EF;
using BikeRent.DAL.Interfaces;
using BikeRent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BikeRent.BLL.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service) 
        {
            service.AddDbContext<BikeRentContext>(option =>
                option.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BikeRentDB; Trusted_Connection = True; MultipleActiveResultSets = true"));

            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IBikeService, BikeService>();
            service.AddTransient<IBikeTypeService, BikeTypeService>();

            return service;
        }
    }
}
