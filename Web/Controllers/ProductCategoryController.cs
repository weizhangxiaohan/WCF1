using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            ProductCategoryViewModel model = new ProductCategoryViewModel();
            model.Categorys = new List<ProductCategory>();
            model.Categorys.Add(new ProductCategory { Name = "All" });
            model.Categorys.Add(new ProductCategory { Name = "Foods"});
            model.Categorys.Add(new ProductCategory { Name = "Shoes" });
            model.Categorys.Add(new ProductCategory { Name = "Phones" });
            model.Categorys.Add(new ProductCategory { Name = "Virtrul" });
            return PartialView(model);
        }
    }

    public class Album
    {
        public string Title { get; set; }
    }
}