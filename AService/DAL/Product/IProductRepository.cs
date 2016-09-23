using System.Collections.Generic;
using AService.DAL.Model;

namespace AService.DAL.Products
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void DeleteProduct(string productId);
        Product FindByProductCode(string productId);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
    }
}