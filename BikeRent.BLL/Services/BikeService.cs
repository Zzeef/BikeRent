using System;
using AutoMapper;
using BikeRent.BLL.DTO;
using BikeRent.DAL.Entity;
using System.Threading.Tasks;
using BikeRent.DAL.Interfaces;
using BikeRent.BLL.Interfaces;
using System.Collections.Generic;
using BikeRent.BLL.Infrastructure;
using System.Linq;

namespace BikeRent.BLL.Services
{
    public class BikeService : IBikeService
    {
        private IUnitOfWork Database;

        public BikeService(IUnitOfWork uow) 
        {
            Database = uow;
        }

        public OperationDetails AddBike(BikeDTO item)
        {
            if (ExistBike(item).Succedeed)
                return new OperationDetails(false, "");
            Bike bike = new Bike() {
                Id = item.Id,
                Name = item.Name,
                BikeTypeId = item.BikeTypeId,
                RentPrice = item.RentPrice,
                IsRent = item.IsRent
            };
            Database.Bikes.Create(bike);
            Database.Save();
            return new OperationDetails(true, "");
        }

        public OperationDetails DeleteBike(Guid id)
        {
            var item = Database.Bikes.Get(id);
            if (item == null)
                return new OperationDetails(false, "");
            Database.Bikes.Delete(id);
            Database.Save();
            return new OperationDetails(true, "");
        }

        public async Task<OperationDetails> Rent(Guid id) 
        {
            var result = await FindBikeByIdAsync(id);
            if (result != null)
            {
                Database.Bikes.Delete(result.Id);
                result.IsRent = true;
                Bike bike = new Bike()
                {
                    Id = result.Id,
                    Name = result.Name,
                    BikeTypeId = result.BikeTypeId,
                    RentPrice = result.RentPrice,
                    IsRent = result.IsRent
                };

                Database.Bikes.Create(bike);
                Database.Save();
                return new OperationDetails(true, "");
            }
            return new OperationDetails(false, "");
        }

        public async Task<OperationDetails> Rent(Guid id, bool status) 
        {
            var result = await FindBikeByIdAsync(id);
            if (result != null) 
            {
                Database.Bikes.Delete(result.Id);
                result.IsRent = status;
                Bike bike = new Bike()
                {
                    Id = result.Id,
                    Name = result.Name,
                    BikeTypeId = result.BikeTypeId,
                    RentPrice = result.RentPrice,
                    IsRent = result.IsRent
                };

                Database.Bikes.Create(bike);
                Database.Save();
                return new OperationDetails(true, "");
            }
            return new OperationDetails(false, "");
        }

        public async Task<BikeDTO> FindBikeByIdAsync(Guid id)
        {
            Bike bike = await Task.Run(() => Database.Bikes.Get(id));

            if (bike == null)
                return null;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            BikeDTO bikeDTO = mapper.Map<Bike, BikeDTO>(bike);

            return bikeDTO;
        }

        public OperationDetails ExistBike(BikeDTO item) 
        {
            Bike bike = Database.Bikes.Get(item.Id);
            if (bike != null)
                return new OperationDetails(true, "");
            return new OperationDetails(false, "");
        }

        public IEnumerable<BikeDTO> GetBikes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Bike>, IEnumerable<BikeDTO>>(Database.Bikes.GetAll()).Where(x => x.IsRent == true);
        }

        public IEnumerable<BikeDTO> GetFreeBike() 
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Bike>, IEnumerable<BikeDTO>>(Database.Bikes.GetAll()).Where(x => x.IsRent == false);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
