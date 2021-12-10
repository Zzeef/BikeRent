using System;
using BikeRent.BLL.DTO;
using System.Threading.Tasks;
using BikeRent.BLL.Infrastructure;
using System.Collections.Generic;

namespace BikeRent.BLL.Interfaces
{
    public interface IBikeTypeService
    {
        IEnumerable<BikeTypeDTO> GetBikeTypes();
        OperationDetails AddBikeType(BikeTypeDTO item);
        OperationDetails DeleteBikeType(Guid id);
        Task<BikeTypeDTO> FindBikeTypeByIdAsync(Guid id);
        void Dispose();
    }
}
