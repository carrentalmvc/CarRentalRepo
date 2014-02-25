using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarRentals.DataAccess;

namespace CarRentals.Repository
{
   public class RepositoryBase<T> where T : class
    {

       private CarRentalDbContext _dbcontext = null;

       private readonly IDbSet<T> dbset;

       public RepositoryBase(IDatabaseFactory databseFactory)
       {
           DatabaseFactory = databseFactory;
           dbset = DataContext.Set<T>();
       }

       protected IDatabaseFactory DatabaseFactory { get;private set; }

       protected CarRentalDbContext DataContext
       {
           get 
           {
               return (_dbcontext ?? DatabaseFactory.GetDatabaseContext());
             
           }
       }

       public virtual void Add(T entity)
       {
           dbset.Add(entity);
       }

       public virtual void Update(T entity)
       {
           dbset.Attach(entity);
           _dbcontext.Entry(entity).State = EntityState.Modified;

       }

       public virtual void Delete(T entity)
       {
           dbset.Remove(entity);
       }

       public virtual void Delete(Expression<Func<T, bool>> predicate)
       {
           IEnumerable<T> objects = dbset.Where<T>(predicate).AsEnumerable();
           if (objects != null && objects.Any())
           {
               foreach (T obj in objects)
               {
                   dbset.Remove(obj);
               }
           }
       }

       public virtual T GetById(long Id)
       {
           return dbset.Find(Id);
       }

       public virtual T GetById(string Id)
       {
           return dbset.Find(Id);
       }

       public virtual T Get(Expression<Func<T,bool>> predicate)
       {
           return dbset.Where(predicate).FirstOrDefault<T>();
       }

       public virtual IEnumerable<T> GetAll()
       {
           return dbset.ToList();
       }

       public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
       {
           return dbset.Where(predicate).AsEnumerable<T>();
       }
        
    }
}
