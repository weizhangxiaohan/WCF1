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
        [Required(ErrorMessage = "必须填写产品名称")]
        [DisplayName("产品名称")]
        public string ProductName { get; set; }
        public int Inventory { get; set; }
    }
}