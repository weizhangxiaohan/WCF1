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
            model.Categorys.Add(new ProductCategory { Name = "111"});
            model.Categorys.Add(new ProductCategory { Name = "222" });
            model.Categorys.Add(new ProductCategory { Name = "333" });
            model.Categorys.Add(new ProductCategory { Name = "444" });
            return PartialView(model);
        }
    }

    public class Album
    {
        public string Title { get; set; }
    }
}