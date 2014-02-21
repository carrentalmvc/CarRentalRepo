using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentals.DataAccess
{
    /// <summary>
    /// All the methods in this interface are already implemented in the DbContext class.This is added only for testing purposes
    /// </summary>
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
       
    }
}
