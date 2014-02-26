using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.DataAccess
{
   public interface IDatabaseFactory
    {
       CarRentalDbContext DbContext { get;}
    }
}
