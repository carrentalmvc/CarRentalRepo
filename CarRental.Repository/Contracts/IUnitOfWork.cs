using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Repository.Contracts;

namespace CarRental.Repository
{
    /// <summary>
    /// Disposable should be in the UnitofWork and not in Repository
    /// </summary>
   public interface IUnitOfWork : IDisposable
    {
       IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

       void Save();
    }
}
