using System;
using System.Web.Mvc;
using System.Web.Security;
using CarRentals.Repository;

namespace CarRentals.Services
{
    public class CarRentalRoleProvider : RoleProvider
    {
        public ICarRentalUserRepository UserRepo
        {
            get;
            set;
        }

        public CarRentalRoleProvider()
        {
            UserRepo = DependencyResolver.Current.GetService<ICarRentalUserRepository>();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = UserRepo.Get(u => u.EmailAddress == username && u.UserRole != null && u.UserRole.RoleName == roleName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        #region Unused

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion Unused
    }
}