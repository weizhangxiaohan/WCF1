using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductCategoryViewModel
    {
        public IList<ProductCategory> Categorys { get; set; }
    }

    public class ProductCategory
    {
        public string Name { get; set; }
    }
}