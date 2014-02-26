using System;
using System.Collections.Generic;

namespace CarRentals.Model.DomainObjects
{
    public class CarRentalRole
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDtTm { get; set; }

        public DateTime UpdateDtTm { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<CarRentalUser> Users { get; set; }
    }
}