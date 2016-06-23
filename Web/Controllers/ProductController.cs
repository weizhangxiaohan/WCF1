using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProductController : Controller
    {

        ProductService.ProductServiceClient productService = new ProductService.ProductServiceClient();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var products = productService.GetProducts();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                ProductModel p = new ProductModel();
                p.Id = product.ProductCode;
                p.ProductName = product.ProductName;
                p.Inventory = product.Inventory;
                productModels.Add(p);
            }
            return View(productModels);
        }

        public ActionResult Details(string id)
        {
            var products = productService.GetProducts();
            var product = (from p in products
                          where p.ProductCode == id
                          select p).First();

            ProductModel model = new ProductModel();
            model.Id = product.ProductCode;
            model.ProductName = product.ProductName;
            model.Inventory = product.Inventory;

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var products = productService.GetProducts();
            var product = (from p in products
                           where p.ProductCode == id
                           select p).First();

            ProductModel model = new ProductModel();
            model.Id = product.ProductCode;
            model.ProductName = product.ProductName;
            model.Inventory = product.Inventory;

            return View(model);
        }
    }
}