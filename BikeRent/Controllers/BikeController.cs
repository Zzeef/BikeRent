using BikeRent.BLL.DTO;
using BikeRent.BLL.Interfaces;
using BikeRent.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRent.Controllers
{
    [ApiController]
    [Route("/api/bike")]
    public class BikeController : ControllerBase
    {
        IBikeService bikeService;

        public BikeController(IBikeService bikeService) 
        {
            this.bikeService = bikeService;
        }

        [HttpGet]
        public IEnumerable<BikeDTO> Get()
        {
            return bikeService.GetBikes();
        }

        [HttpGet]
        [Route("/api/bike/freebike")]
        public IEnumerable<BikeDTO> GetFreeBikes() 
        {
            return bikeService.GetFreeBike();
        }

        [HttpPost]
        [Route("/api/bike/create")]
        public IActionResult CreateBike(string name, string bikeTypeId, int rentPrice)
        {
            BikeDTO item = new BikeDTO() {
                Id = new Guid(),
                Name = name,
                BikeTypeId = new Guid(bikeTypeId),
                RentPrice = rentPrice,
                IsRent = false
            };
            var result = bikeService.AddBike(item);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id) 
        {
            var result = bikeService.DeleteBike(new Guid(id));
            return Ok(result.Message);
        }

        [HttpPut("{id}")]
        [Route("/api/bike")]
        public async Task<IActionResult> Put(string id, bool status)
        {
            var result = await bikeService.Rent(new Guid(id), status);
            return Ok(result.Message);
        }
    }
}
