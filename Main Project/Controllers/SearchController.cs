using Microsoft.AspNetCore.Mvc;
using E_commerceFirstFull.Models;
using E_commerceFirstFull.Services;
using System.Linq;
using E_commerceFirstFull.Models.ViewModels;
using System.Collections.Generic;

namespace E_commerceFirstFull.Controllers
{
    public class SearchController : Controller
    {
        private IProductRepository<Product> repository;
        private ProductService productService;
        private int totalItems = 0;        

        public SearchController(IProductRepository<Product> productRepository, ProductService productService)
        {
            this.productService = productService;
            this.repository = productRepository;
        }        

        public IActionResult Index(RequestParameters request)
        {
            if (request.SearchForm == true)
                productService.SearchQueryCached = request.SearchQuery;            

            var selectedProducts = repository.GetByTitle(productService.SearchQueryCached);
            productService.GetListOfCategories(request.Genre, request.Features, request.Platform);

            if (productService.SelectedCategoriesCached.Count == 0)
                totalItems = selectedProducts.Count();

            selectedProducts = selectedProducts.Where(x => productService.SelectedCategoriesCached
                                               .All(x.Features.Contains));

            if (productService.SelectedCategoriesCached.Count != 0)
                totalItems = selectedProducts.Count();

            selectedProducts = selectedProducts.Skip((request.PageNumber - 1) * request.PageSize)
                                               .Take(request.PageSize);

            productService.SortProduct(ref selectedProducts, request.SortOrder);            

            
            return View(Map(request.PageNumber, totalItems, productService.SortObjectCached, selectedProducts));            
        }        

        private ProductModel Map(int pageNumber, int totalItems, string sortObjectCached, 
            IEnumerable<Product> selectedProducts)
        {
            ProductModel productModel = new()
            {
                CurrentPage = pageNumber,
                TotalItems = totalItems,
                SortMethod = sortObjectCached,
                Products = selectedProducts.ToList()
            };

            return productModel;
        }

        public IActionResult ProductPage()
        {
            return View();
        }
    }
}
