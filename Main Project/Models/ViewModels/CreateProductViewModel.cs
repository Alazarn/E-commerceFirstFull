using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class CreateProductViewModel
    {        
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string Features { get; set; }        
        public string CardPath { get; set; }
        public string ImgPath { get; set; }
        public IFormFile Card { get; set; }
        public IFormFile Img { get; set; }
    }
}
