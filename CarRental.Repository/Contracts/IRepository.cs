using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        T GetById(long Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
    }
}
