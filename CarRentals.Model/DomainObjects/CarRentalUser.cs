using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CarRentals.Model.DomainObjects
{
  public class CarRentalUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }
        public CarRentalRole UserRole { get; set; }
        
    }
  
}
