using System;

namespace BikeRent.DAL.Entity
{
    public class Bike
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BikeTypeId { get; set; }
        public decimal RentPrice { get; set; }
        public bool IsRent { get; set; }

        public virtual BikeType BikeType { get; set; }
    }
}
