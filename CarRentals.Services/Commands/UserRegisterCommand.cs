using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Services.Command;

namespace CarRentals.Services.Commands
{
    /// <summary>
    /// This class represent the UserCommand to register a new User
    /// </summary>
   public  class UserRegisterCommand : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}
