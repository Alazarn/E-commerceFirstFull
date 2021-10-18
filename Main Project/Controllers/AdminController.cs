using E_commerceFirstFull.Models;
using E_commerceFirstFull.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILoggerService logger;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment environment;
        private readonly IProductRepository<Product> repository;
        public AdminController(ILoggerService logger, UserManager<User> userManager, IWebHostEnvironment environment,
            IProductRepository<Product> repository, RoleManager<IdentityRole> roleManager)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.environment = environment;
            this.repository = repository;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            UsersViewModel model = new();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.UserForm.Email, UserName = model.UserForm.UserName,
                    FirstName = model.UserForm.FirstName, LastName = model.UserForm.LastName };

                var result = await userManager.CreateAsync(user, model.UserForm.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("EditUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult EditUsers()
        {
            return View(userManager.Users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> EditTheUser(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                logger.LogInfo($"This User with Id: {user.Id} is doesn't exist");
                return NotFound();
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var allRoles = roleManager.Roles.ToList();

            CreateAndEditUserViewModel model = new CreateAndEditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AllRoles = allRoles,
                UserRoles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheUser(CreateAndEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    
                    //var allRoles = roleManager.Roles.ToList();
                    
                    var addedRoles = model.UserRoles.Except(userRoles);
                    
                    var removedRoles = userRoles.Except(model.UserRoles);

                    await userManager.AddToRolesAsync(user, addedRoles);

                    await userManager.RemoveFromRolesAsync(user, removedRoles);

                    return RedirectToAction("EditUsers");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
            }
            return RedirectToAction("EditUsers");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CardPath = "/img/Cards/" + model.Card.FileName;
                model.ImgPath = "/img/" + model.Img.FileName;

                using (var fileStream = new FileStream(environment.WebRootPath + model.CardPath, FileMode.Create))
                {
                    await model.Card.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(environment.WebRootPath + model.ImgPath, FileMode.Create))
                {
                    await model.Img.CopyToAsync(fileStream);
                }

                Product product = new Product
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    Price = model.Price,
                    Features = model.Features,
                    CardPath = model.Card.FileName,
                    ImgPath = model.Img.FileName
                };
                repository.Create(product);

                return RedirectToAction("EditProducts");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditProducts(IEnumerable<Product> products)
        {
            if (products == null || products.Count() == 0)
            {
                return View(repository.Products);
            }
            return View(products);
        }

        public IActionResult DeleteProduct(Guid? id)
        {
            if(id != null)
            {
                Product product = repository.Products.FirstOrDefault(x => x.Id == id);
                IEnumerable<Product> products = repository.Delete(product);
                return RedirectToAction("EditProducts", products);
            }
            return View();
        }
    }
}
