using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model;
using CarRentals.DataAccess;

namespace CarRentals.Repository
{
    public interface ICarRentalUserRepository
    {

        bool ValidateUser(CarRentalUser user);
    }
}
