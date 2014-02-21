using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRentals.Model
{
  public class CarRentalUser
    {
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }       
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Repeat Password")]
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }

  
}
