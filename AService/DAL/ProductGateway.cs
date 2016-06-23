using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AService.DAL
{
    public class ProductGateway
    {
        IEnumerable<Product> products;

        public ProductGateway()
        {
            //string path = @"C:\Users\marvin.wei\Source\Repos\WCF1\AService\AppData\SimpleDataBase.xml";
            string path = @"C:\Users\Administrator\Source\Repos\WCF1\AService\AppData\SimpleDataBase.xml";
            IEnumerable<XElement> productXElements = XElement.Load(path).Element("Products").Elements("Product");
            products = ProductMapping.Convert(productXElements);
        }

        public Product FindByProductCode(string productCode)
        {
            var result = from p in products
                         where p.ProductCode == productCode
                         select p;
            return result.First();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
    }

    public static class ProductMapping
    {
        public static IEnumerable<Product> Convert(IEnumerable<XElement> productXElements)
        {
            List<Product> products = new List<Product>();
            foreach (var xelement in productXElements)
            {
                Product product = new Product();
                product.ProductCode = xelement.Element("ProductCode").Value;
                product.ProductName = xelement.Element("ProductName").Value;
                product.Inventory = int.Parse(xelement.Element("Inventory").Value);
                products.Add(product);
            }
            return products;
        }
    }
}
