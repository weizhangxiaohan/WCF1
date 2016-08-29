using BLL.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
//using Webdiyer.WebControls.Mvc;
using PagedList;
using System.Threading;
using StackExchange.Profiling;

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

        public ActionResult List(int pageIndex = 1)
        {
            var products = productService.GetProducts();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                ProductModel p = new ProductModel();
                p.Id = product.Id;
                p.ProductName = product.ProductName;
                p.Inventory = product.Inventory;
                p.UnitPrice = product.UnitPrice;
                productModels.Add(p);
            }

            //var profiler = MiniProfiler.Current; // it's ok if this is null
            //using (profiler.Step("Set page title"))
            //{
            //    ViewBag.Title = "Home Page";
            //}
            //using (profiler.Step("Doing complex stuff"))
            //{
            //    using (profiler.Step("Step A"))
            //    { // something more interesting here
            //        Thread.Sleep(100);
            //    }
            //    using (profiler.Step("Step B"))
            //    { // and here
            //        Thread.Sleep(250);
            //    }
            //}

            var model = productModels.ToPagedList<ProductModel>(pageIndex,10);
            return PartialView(model);
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
            productCreate.UnitPrice = productModel.UnitPrice;

            productService.CreateProduct(productCreate);

            return RedirectToAction("List");
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
            return RedirectToAction("List");
        }

        public ActionResult AddToShoppingCart(string id)
        {
            var orderItem = new BLL.Order.ShoppingCartItem();
            orderItem.GoodId = id;
            orderItem.Amount = 1;
            orderItem.UnitPrice = 5;

            ShoppingCart.Current.AddGoods(orderItem);

            return RedirectToAction("Detail","ShoppingCart");
        }

    }
}