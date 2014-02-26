using System.Linq;
using CarRentals.DataAccess;
using CarRentals.Model.DomainObjects;

namespace CarRentals.Repository
{
    /// <summary>
    /// Each repository needs to be supplied with a DbContext(This should be done by UnitOfWork)
    /// </summary>
    public class CarRentalUserRepository : RepositoryBase<CarRentalUser>, ICarRentalUserRepository
    {
        public CarRentalUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }

        public override void Add(CarRentalUser user)
        {
            if (!UserExists(user))
            {
                base.Add(user);
            }
        }

        #region Helper Methods

        public bool UserExists(CarRentalUser user)
        {
            bool retVal = false;
            if (user == null)
            {
                return false;
            }

            var users = this.GetAll().Where(u => u.EmailAddress.ToLower().Equals(user.EmailAddress.ToLower())).SingleOrDefault();
            if (users != null)
            {
                retVal = true;
            }

            return retVal;
        }

        #endregion Helper Methods
    }

    public interface ICarRentalUserRepository : IRepository<CarRentalUser>
    {
    }
}