using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentals.Model.DomainObjects;
using CarRentals.Repository;
using CarRentals.Services;

namespace Mvc.CarRentalApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRentalUserRepository _repo;

        public HomeController(ICarRentalUserRepository repo)
        {
            this._repo = repo;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Controller = RouteData.Values["controller"];
            ViewBag.View = RouteData.Values["view"];

            return View();
        }

        [HttpPost]
        public PartialViewResult Login(LoginViewModel login)
        {
            var viewResult = new ActionResultViewModel();

            if (ModelState.IsValid)
            {
                if (new CarRentalMembershipProvider(_repo,null).ValidateUser(login.EmailAddress, login.PasswordText))
                {
                    RedirectToAction("MyView", "MyAccount");
                }
                
            }

             viewResult.Message = "Login Failed";

            return PartialView("_ActionResult",viewResult);

          
        }

    }
}
