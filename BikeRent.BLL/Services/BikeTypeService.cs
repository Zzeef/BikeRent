using System;
using AutoMapper;
using BikeRent.BLL.DTO;
using BikeRent.DAL.Entity;
using System.Threading.Tasks;
using BikeRent.BLL.Interfaces;
using BikeRent.DAL.Interfaces;
using BikeRent.BLL.Infrastructure;
using System.Collections.Generic;

namespace BikeRent.BLL.Services
{
    public class BikeTypeService : IBikeTypeService
    {
        private IUnitOfWork Database;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<BikeType, BikeTypeDTO>()).CreateMapper();

        public BikeTypeService(IUnitOfWork uow) 
        {
            Database = uow;
        }

        public OperationDetails AddBikeType(BikeTypeDTO item)
        {
            if (ExistBikeType(item).Succedeed)
                return new OperationDetails(false, "");
            BikeType bikeType = new BikeType() 
            {
                Id = item.Id,
                Name = item.Name
            };
            Database.BikeTypes.Create(bikeType);
            Database.Save();
            return new OperationDetails(true, "");
        }

        public OperationDetails DeleteBikeType(Guid id)
        {
            var item = Database.BikeTypes.Get(id);
            if (item == null)
                return new OperationDetails(false, "");
            Database.BikeTypes.Delete(id);
            return new OperationDetails(true, "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async  Task<BikeTypeDTO> FindBikeTypeByIdAsync(Guid id)
        {
            BikeType bikeType = await Task.Run(() => Database.BikeTypes.Get(id));

            if (bikeType == null)
                return null;
            BikeTypeDTO bikeTypeDTO = mapper.Map<BikeType, BikeTypeDTO>(bikeType);
            return bikeTypeDTO;
        }

        public OperationDetails ExistBikeType(BikeTypeDTO item)
        {
            BikeType bikeType = Database.BikeTypes.Get(item.Id);
            if (bikeType != null)
                return new OperationDetails(true, "");
            return new OperationDetails(false, "");
        }

        public IEnumerable<BikeTypeDTO> GetBikeTypes()
        {
            return mapper.Map<IEnumerable<BikeType>, IEnumerable<BikeTypeDTO>>(Database.BikeTypes.GetAll());
        }
    }
}
