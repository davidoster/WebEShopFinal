using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebEShopFinal.Models
{
    public class Product
    {
        public int Id { get; set; } // Id (Primary key)
        [Required]
        [MinLength(8, ErrorMessage = "Title should be at least 8 characters"),MaxLength(25, ErrorMessage = "Title can not be more than 25 characters")]
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        [Required]
        //[Range(0, double.MaxValue, ErrorMessage = "It must be a decimal/number between {0} and {1}.")]
        [PriceValidation(5,50000)]
        public double Price { get; set; } // Price
                                          //public int Product_CategoryId { get; set; } // Category_Id
        public virtual Category Category { get; set; }
        
        public Product()
        {

        }

        public Product(string title, string description, double price)
        {
            Title = title;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Title = {Title}, Price = {Price}";
        } 
    }
}