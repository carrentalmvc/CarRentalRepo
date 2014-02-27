using System;
using System.Collections.Generic;

namespace CarRentals.Model.DomainObjects
{
    public class CarRentalRole
    {
        private List<CarRentalUser> _users;

        public CarRentalRole()
        {
            _users = new List<CarRentalUser>();
        }
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDtTm { get; set; }

        public DateTime UpdateDtTm { get; set; }

        public bool IsDeleted { get; set; }
        //These are navigational propeties
        public virtual ICollection<CarRentalUser> Users { get; set; }
    }
}