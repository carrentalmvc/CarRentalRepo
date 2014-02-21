using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model;
using CarRentals.DataAccess;
using System.Data.Entity;

namespace CarRentals.Repository
{
    /// <summary>
    /// Each repository needs to be supplied with a DbContext(This should be done by UnitOfWork)
    /// </summary>
    public class CarRentalUserRepository
    {
        public CarRentalUserRepository(CarRentalDbContext cxt)
        {
            
        }
        
    }
}
