using BikeRent.BLL.DTO;
using BikeRent.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRent.BLL.Interfaces
{
    public interface IBikeService
    {
        IEnumerable<BikeDTO> GetBikes();
        IEnumerable<BikeDTO> GetFreeBike();
        OperationDetails AddBike(BikeDTO item);
        OperationDetails DeleteBike(Guid id);
        Task<BikeDTO> FindBikeByIdAsync(Guid id);
        OperationDetails ExistBike(BikeDTO item);
        Task<OperationDetails> Rent(Guid id, bool status);
        void Dispose();
    }
}
