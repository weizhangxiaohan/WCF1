using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductModel
    {
        
        public string Id { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Range(1,9999)]
        public int Inventory { get; set; }
    }
}