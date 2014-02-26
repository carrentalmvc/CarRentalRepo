using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.DataAccess
{
    /// <summary>
    /// This class returns an instance of the CarRentalDbContext an also calles Dispose() on that
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
       private CarRentalDbContext _carrentalDataContext = null;
       public DatabaseFactory()
       {
           //this.GetDatabaseContext();

           this._carrentalDataContext = DbContext;
       }

        //public CarRentalDbContext GetDatabaseContext()
        //{
        //    return (_carrentalDataContext ?? new CarRentalDbContext());
        //}

        public CarRentalDbContext DbContext
        {
            get {

                return (_carrentalDataContext ?? new CarRentalDbContext());
            }
        }

        protected override void DisposeCore()
        {
            if (_carrentalDataContext != null)
            {
                _carrentalDataContext.Dispose();
            }
        }
    }
}
