using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class SharedSignInSignUpViewModel
    {
        public UserRegistrationViewModel RegModel { get; set; } = new();
        public LoginViewModel LoginModel { get; set; } = new();
    }
}
