using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Contracts
{
   public interface IRepository<T> where T : class
    {
       void Add(T entity);

       void Delete(T entity);

       void Update(T entity);

       T GetById(long Id);

       IEnumerable<T> GetAll();

       IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
    }
}
