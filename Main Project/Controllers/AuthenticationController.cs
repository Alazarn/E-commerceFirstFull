using E_commerceFirstFull.Models;
using E_commerceFirstFull.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoggerService logger;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AuthenticationController(ILoggerService logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //[HttpGet]
        //public IActionResult Index(string returnUrl = null)
        //{
        //    return View(new LoginViewModel { ReturnUrl = returnUrl });
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel loginModel)
        {

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                        return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password are incorrect");                    
                }                
            }
            else
            {
                logger.LogInfo("Incorrect login data.");
            }


            return View(loginModel);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(UserRegistrationViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = userModel.Email, UserName = userModel.UserName };
                var userRole = new List<string>() { "User" };

                var result = await userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(user, userRole);
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userModel);
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
