using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Repository;

namespace CarRentals.Repository
{
    /// <summary>
    /// Disposable should be in the UnitofWork and not in Repository
    /// </summary>
   public interface IUnitOfWork
    {
       

       void Commit();
    }
}
