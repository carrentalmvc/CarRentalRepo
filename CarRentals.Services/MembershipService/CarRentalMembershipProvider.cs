﻿using System;
using System.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Web.Security;
using CarRentals.Core.Common;
using CarRentals.Model.DomainObjects;
using CarRentals.Repository;
using CarRentals.Services.Validations;
using log4net;

namespace CarRentals.Services
{
    public class CarRentalMembershipProvider : MembershipProvider
    {
        //http://stackoverflow.com/questions/1551503/dependency-injection-and-asp-net-membership-providers
        //This is done here cuz ,memebrship classes are generated by .NET runtime and we cant do any constructor injection into these role and memebrship provider classes
        //public ICarRentalUserRepository UserRepo
        //{
        //    get
        //    {
        //        return DependencyResolver.Current.GetService<ICarRentalUserRepository>();
        //    }
        //}
        //public IUnitOfWork UOW
        //{
        //    get
        //    {
        //        return DependencyResolver.Current.GetService<IUnitOfWork>();
        //    }
        //}
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ICarRentalUserRepository _repo;

        private IUnitOfWork _uow;

        public CarRentalMembershipProvider(ICarRentalUserRepository repo, IUnitOfWork uow)
        {
            this._repo = repo;
            this._uow = uow;
        }

        #region Useful Methods

        public bool CreateUser(CarRentals.Model.DomainObjects.CarRentalUser user)
        {
            try
            {
                var valErrors = new CanCreateNewUser(_repo).Validate(user);
                if (valErrors == null)
                {
                    if (user.UserRole == null)
                    {
                        user.RoleId = (Int32)CarRentals.Model.Enums.CarRentalRole.NormalUser;
                        user.UserRole = new CarRentalRole { RoleId = user.RoleId, RoleName = "NormalUser", IsActive = true, CreateDtTm = DateTime.Now };
                    }
                    var bytes = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["EncKeyBase64"]), null, DataProtectionScope.LocalMachine);
                    var password = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["EncPasswordBase64"]), null, DataProtectionScope.LocalMachine).ToString();
                    user.Password = new Encryption(bytes, password).Encrypt(user.PasswordText);
                    _repo.Add(user);
                    //_uow.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error occurred while creating the user : {0}", ex.Message));
                throw;
            }
        }

        public override bool ValidateUser(string emailAddress, string txtpassword)
        {
            bool retVal = false;
           CarRentals.Services.CarRentalUserServiceProxy.CarRentalUserServiceClient client = null;
            try
            {
                //Actually, this service call is unnecessary.Leaving this here to play around with WCF services
                client = new CarRentals.Services.CarRentalUserServiceProxy.CarRentalUserServiceClient("NetTcpBinding_ICarRentalUserService");
                var result =  client.ValidateUser(new CarRentalUserServiceProxy.CarRentalUser { EmailAddress = emailAddress });                
                if (result)
                {
                    var user = _repo.Get(u => u.EmailAddress == emailAddress);
                    if (user != null)
                    {
                        var bytes = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["EncKeyBase64"]), null, DataProtectionScope.LocalMachine);
                        var password = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["EncPasswordBase64"]), null, DataProtectionScope.LocalMachine).ToString();
                        var decryptedPassword = new Encryption(bytes, password).Decrypt(user.Password);
                        if (string.Compare(txtpassword, decryptedPassword, true) == 0)
                        {
                            retVal = true;
                        }
                    }
                }
                client.Close();
            }

            catch (FaultException fe)
            {
                logger.Error(string.Format("Error from the service operation: {0}", fe.Message));
                client.Abort();
                return retVal;
            }

            catch (CommunicationException ce)
            {
                logger.Error(string.Format("Error communicating with the service : {0}", ce.Message));
                client.Abort();
                return retVal;
            }

            catch (TimeoutException te)
            {
                logger.Error(string.Format("Timeout EXception while connecting with the  service : {0}", te.Message));
                client.Abort();
                return retVal;
            }            

            return retVal;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Useful Methods

        #region Unused Methods

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

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion Unused Methods
    }
}