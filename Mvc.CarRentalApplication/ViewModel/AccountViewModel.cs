using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.CarRentalApplication
{
    public class AccountViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordText { get; set; }

        public string ConfirmPassword { get; set; }

        public string EmailAddress { get; set; }
    }
}