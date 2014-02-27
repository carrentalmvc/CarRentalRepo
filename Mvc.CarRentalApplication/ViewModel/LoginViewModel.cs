using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.CarRentalApplication
{
    public class LoginViewModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PasswordText { get; set; }
    }
}