using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentals.Model.DomainObjects;

namespace Mvc.CarRentalApplication.Controllers
{
    public class RegisterController : Controller
    {
        //Register/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Register(CarRentalUser model)
        {

            if (ModelState.IsValid)
            { 
               return Json(new {Message="Post was successful"});
            }

            else
            {
                return Json(new { Message = "Post was failure" });
            }

        }
    }
}