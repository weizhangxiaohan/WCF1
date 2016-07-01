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
                p.Id = product.Id;
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
                          where p.Id == id
                          select p).First();

            ProductModel model = new ProductModel();
            model.Id = product.Id;
            model.ProductName = product.ProductName;
            model.Inventory = product.Inventory;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            var product = new ProductService.Product();
            product.Id = productModel.Id;
            product.ProductName = productModel.ProductName;
            product.Inventory = productModel.Inventory;

            productService.UpdateProduct(product);

            return View("Details",productModel);
        }

        public ActionResult Edit(string id)
        {
            var products = productService.GetProducts();
            var product = (from p in products
                           where p.Id == id
                           select p).First();

            ProductModel model = new ProductModel();
            model.Id = product.Id;
            model.ProductName = product.ProductName;
            model.Inventory = product.Inventory;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            var productCreate = new ProductService.Product();
            productCreate.Id = productModel.Id;
            productCreate.ProductName = productModel.ProductName;
            productCreate.Inventory = productModel.Inventory;

            productService.CreateProduct(productCreate);

            var products = productService.GetProducts();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                ProductModel p = new ProductModel();
                p.Id = product.Id;
                p.ProductName = product.ProductName;
                p.Inventory = product.Inventory;
                productModels.Add(p);
            }

            return View("List", productModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            var products = productService.GetProducts();
            var product = (from p in products
                           where p.Id == id
                           select p).First();

            ProductModel model = new ProductModel();
            model.Id = product.Id;
            model.ProductName = product.ProductName;
            model.Inventory = product.Inventory;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ProductModel productModel)
        {
            productService.DeleteProduct(productModel.Id);

            var products = productService.GetProducts();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                ProductModel p = new ProductModel();
                p.Id = product.Id;
                p.ProductName = product.ProductName;
                p.Inventory = product.Inventory;
                productModels.Add(p);
            }

            return View("List", productModels);
        }

    }
}