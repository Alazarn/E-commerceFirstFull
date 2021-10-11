using System.ComponentModel.DataAnnotations;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }        

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        //public string ReturnUrl { get; set; }
    }
}
