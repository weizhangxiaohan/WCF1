using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AService.Interfaces;
using AService.DAL;
using AService.DAL.Model;
using AService.DAL.Products;

namespace AService.Services
{
    public class ProductService : IProductService
    {
        private ProductGateway _productGateway;
        private Logs.ILogger _logger;

        private ProductGateway ProductGateway
        {
            get
            {
                if (_productGateway == null)
                {
                    _productGateway = new ProductGateway();
                }
                return _productGateway;
            }
        }

        private Logs.ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logs.Log4NetLogger();
                }
                return _logger;
            }
        }

        public void CreateProduct(Product product)
        {
            ProductGateway.CreateProduct(product);
        }

        public int GetProductInventory(string productCode)
        {
            Product product = ProductGateway.FindByProductCode(productCode);
            return product.Inventory;
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductGateway.GetAllProducts();
        }

        public void UpdateProduct(Product product)
        {
            ProductGateway.UpdateProduct(product);
        }

        public void DeleteProduct(string productId)
        {
            ProductGateway.DeleteProduct(productId);
            Logger.Log("Delete a product.ProductId is " + productId);
        }
    }
}
