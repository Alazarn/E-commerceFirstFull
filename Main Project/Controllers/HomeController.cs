using E_commerceFirstFull.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository<Product> productRepository;
        public HomeController(IProductRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(productRepository.Products);
        }

        /*public IActionResult SearchInitializer(string query)
        {
            return RedirectToActionPermanent("Index", "Search", query);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
