using System.Data.SqlClient;
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
            int retVal = 0;
            if (!UserExists(user))
            {
                using (var cxt = this.DataContext)
                {
                    var userId = new SqlParameter { ParameterName = "@UserId", Value = 0, Direction = System.Data.ParameterDirection.Output };
                    var roleId = new SqlParameter("@RoleId", user.RoleId);
                    var firstName = new SqlParameter("@FirstName", user.FirstName);
                    var lastName = new SqlParameter("@LastName", user.LastName);
                    var email = new SqlParameter("@EmailAddress", user.EmailAddress);
                    var passsword = new SqlParameter("@Password", user.Password);
                    var active = new SqlParameter("@IsActive", user.IsActive);
                    cxt.Database.Connection.Open();
                    var result = cxt.Database.SqlQuery<int>("CarRental_InsertUser @UserId,@RoleId,@FirstName,@LastName,@EmailAddress,@Password,@IsActive",
                                                                         userId, roleId, firstName, lastName, email, passsword, active);
                    if (result != null)
                    {
                        retVal = result.Single();
                    }
                }
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