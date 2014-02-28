using System;
using System.Web.Mvc;
using CarRentals.Core.Common;
using CarRentals.Model.DomainObjects;
using CarRentals.Repository;
using CarRentals.Services;

namespace Mvc.CarRentalApplication.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ICarRentalUserRepository _userRepo;
        private readonly IUnitOfWork _uow;

        public RegisterController(ICarRentalUserRepository repo, IUnitOfWork uow)
        {
            this._userRepo = repo;
            this._uow = uow;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult Register(AccountViewModel user)
        {
            var actionResult = new ActionResultViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    //To Do: Use Auto mappers
                    var internalModal = new CarRentalUser
                    {
                        RoleId = user.RoleId,
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailAddress = user.EmailAddress,
                        PasswordText = user.PasswordText
                    };

                    if (new CarRentalMembershipProvider(_userRepo, _uow).CreateUser(internalModal))
                    {
                        actionResult.Message = "User created successfully";
                    }

                    else
                    {
                        actionResult.Message = "User creation Failed";
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return PartialView("_ActionResult", actionResult);
        }
    }
}