using System;

namespace BikeRent.BLL.DTO
{
    public class BikeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BikeTypeId { get; set; }
        public decimal RentPrice { get; set; }
        public bool IsRent { get; set; }
    }
}
