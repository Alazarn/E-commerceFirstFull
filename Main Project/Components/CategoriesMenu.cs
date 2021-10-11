using Microsoft.AspNetCore.Mvc;
using E_commerceFirstFull.Models.ViewModels;


namespace E_commerceFirstFull.Infrastructure.Components
{
    public class CategoriesMenu : ViewComponent
    { 

        public IViewComponentResult Invoke()
        {
            ProductCategoriesViewModel productCategories = new();

            return View(productCategories);
        }
    }
}
