using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, ErrorMessage = "Field {0} should contain min {2} and max {1} symbols.", MinimumLength = 4)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        public string PasswordConfirm { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Incorrect Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        //public ICollection<string> Roles { get; set; }
    }
}
