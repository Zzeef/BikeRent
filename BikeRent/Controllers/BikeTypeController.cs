using BikeRent.BLL.DTO;
using BikeRent.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BikeRent.Controllers
{
    [ApiController]
    [Route("/api/biketype")]
    public class BikeTypeController : ControllerBase
    {
        IBikeTypeService bikeTypeService;

        public BikeTypeController(IBikeTypeService bikeTypeService) 
        {
            this.bikeTypeService = bikeTypeService;
        }

        [HttpGet]
        public IEnumerable<BikeTypeDTO> Get()
        {
            return bikeTypeService.GetBikeTypes();
        }


    }
}
