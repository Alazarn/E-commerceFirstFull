using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using E_commerceFirstFull.Models;


namespace E_commerceFirstFull.Services
{
    public class ProductService
    {
        public List<string> SelectedCategoriesCached { get; set; } = new List<string>();
        public string SearchQueryCached { get; set; }
        public string SortObjectCached { get; set; } = "Relevance";

        public void GetListOfCategories(string genre, string features, string platform)
        {
            if (genre == "All Categories")
            {
                SelectedCategoriesCached.Clear();
            }
            else
            {
                if (genre != null)
                    if (SelectedCategoriesCached.Contains(genre))
                        SelectedCategoriesCached.Remove(genre);
                    else
                        SelectedCategoriesCached.Add(genre);
                else if (features != null)
                    if (SelectedCategoriesCached.Contains(features))
                        SelectedCategoriesCached.Remove(features);
                    else
                        SelectedCategoriesCached.Add(features);
                else if (platform != null)
                    if (SelectedCategoriesCached.Contains(platform))
                        SelectedCategoriesCached.Remove(platform);
                    else
                        SelectedCategoriesCached.Add(platform);
            }
        }

        public IEnumerable<Product> SortProduct(ref IEnumerable<Product> selectedProducts, SortState sortOrder)
        {
            if (sortOrder != SortState.None)
            {
                SortObjectCached = sortOrder switch
                {
                    SortState.Alphabetically => "Alphabetically",
                    SortState.PriceDesc => "Price: High to Low",
                    SortState.PriceAsc => "Price: Low to High",
                    //SortState.DateDesc => ,
                    //SortState.DateAsc => ,
                    _ => "Relevance",
                };
            }
            else
            {
                sortOrder = SortObjectCached switch
                {
                    "Alphabetically"=> SortState.Alphabetically, 
                    "Price: High to Low" => SortState.PriceDesc,
                    "Price: Low to High" => SortState.PriceAsc,
                    //SortState.DateDesc => ,
                    //SortState.DateAsc => ,
                    _ => SortState.Relevance,
                };
            }            

            selectedProducts = sortOrder switch
            {
                SortState.Alphabetically => selectedProducts.OrderBy(s => s.Title),
                SortState.PriceDesc => selectedProducts.OrderByDescending(s => s.Price),
                SortState.PriceAsc => selectedProducts.OrderBy(s => s.Price),
                //SortState.DateDesc => selectedProducts.OrderByDescending(s => s.Date),
                //SortState.DateAsc => selectedProducts.OrderBy(s => s.Date),
                _ => selectedProducts,
            };            

            return selectedProducts;
        }

    }
}
