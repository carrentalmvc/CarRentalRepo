using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.DataAccess;

namespace CarRental.Repository
{
    /// <summary>
    /// Uow is used to have a single DbContext for a set of Repository operations
    /// This class needs to have all the repositories this needs
    /// and a databse context.
    /// Please refer : http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// and http://codereview.stackexchange.com/questions/11785/ef-code-first-with-repository-unitofwork-and-dbcontextfactory
    /// </summary>
   public  class CarRentalUserUnitOfWork : IUnitOfWork
    {
       public CarRentalUserUnitOfWork()
       {
           this.Context = new CarRentalDbContext();
       }

       public CarRentalDbContext Context { get; set; }
        public void Save()  
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Contracts.IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
