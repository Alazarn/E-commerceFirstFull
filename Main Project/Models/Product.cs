using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace E_commerceFirstFull.Models
{
    public class Product : IComparable<Product>
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }        
        [Required]
        public string Features { get; set; }        
        [Required]
        public string CardPath { get; set; }
        [Required]
        public string ImgPath { get; set; }

        public int CompareTo(Product o)
        {
            return this.Title.CompareTo(o.Title);
        }
    }
}
