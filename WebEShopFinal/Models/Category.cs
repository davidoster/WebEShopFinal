using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEShopFinal.Models
{
    public class Category: IDisposable
    {
        [DisplayName("Category Id")]
        public int Id { get; set; } // Id (Primary key)
        
        [DisplayName("Product Title")]
        [Required]
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public virtual ICollection<Product> Products { get; set; }

        public void Dispose()
        {

        }
    }
}