using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class ProductModel
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalItems { get; set; }
        public string SortMethod { get; set; } = "Relevance";
        public List<Product> Products { get; set; }
    }
}
