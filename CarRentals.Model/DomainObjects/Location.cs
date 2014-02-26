using System;

namespace CarRentals.Model.DomainObjects
{
    public class Location
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }

        public DateTime CreatedDtm { get; set; }

        public DateTime UpdatedDtm { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}