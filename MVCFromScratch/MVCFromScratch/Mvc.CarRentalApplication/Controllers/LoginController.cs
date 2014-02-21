using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentals.Model;

namespace Mvc.CarRentalApplication.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
           if(TryValidateModel(model))
           {
               if (model.Email.Equals("anil@gmail.com") && model.Password.Equals("1234"))
               {
                   return View("Login Successfull");
               }
           }

           return View("Index");
        }
    }

}
