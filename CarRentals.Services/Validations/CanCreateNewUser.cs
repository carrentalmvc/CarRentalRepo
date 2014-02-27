using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model.DomainObjects;
using CarRentals.Core.Common;
using CarRentals.Repository;

namespace CarRentals.Services.Validations
{
   public  class CanCreateNewUser : IValidationHandler<CarRentalUser>
    {
       private readonly ICarRentalUserRepository _repo;

       public CanCreateNewUser(ICarRentalUserRepository repo)
       {
           this._repo = repo;
       }
        public IEnumerable<ValidationResult> Validate(CarRentalUser entity)
        {
            var user = _repo.Get(u => u.EmailAddress == entity.EmailAddress);
            if (user != null)
            {
                return new List<ValidationResult>{
               
                 new ValidationResult{MemberName = entity.EmailAddress ,Message= "User already exists in the database"}
               };
            }

            return null;
        }
    }
}
