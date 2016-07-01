using AService.DAL.Model;
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
        private static readonly string path = @"C:\Users\marvin.wei\Source\Repos\WCF1\AService\App_Data\SimpleDataBase.xml";
        //string path = @"C:\Users\Administrator\Source\Repos\WCF1\AService\App_Data\SimpleDataBase.xml";

        private IEnumerable<Product> products;
        private XElement rootElement;

        public XElement RootElement
        {
            get
            {
                if (rootElement == null)
                {
                    rootElement = XElement.Load(path);
                }
                return rootElement;
            }
        }

        private IEnumerable<Product> Products
        {
            get
            {
                //if (products == null)
                //{
                    IEnumerable<XElement> productXElements = RootElement.Element("Products").Elements("Product");
                    products = ProductMapping.Convert(productXElements);
                //}
                return products;

            }
        }

        public ProductGateway()
        {
        }

        public Product FindByProductCode(string productId)
        {
            var result = from p in products
                         where p.Id == productId
                         select p;
            return result.First();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public void CreateProduct(Product product)
        {
            RootElement.Element("Products").Add(new XElement("Product",
                new XElement("Id",DateTime.Now.ToString("yyyyMMddhhmmss")),
                new XElement("ProductName",product.ProductName),
                new XElement("Inventory", product.Inventory)));

            RootElement.Save(path);
        }

        public void UpdateProduct(Product product)
        {
            var productElements = RootElement.Element("Products").Elements("Product");

            var productElement = (from p in productElements
                                 where p.Element("Id").Value == product.Id
                                 select p).Single();

            productElement.SetElementValue("ProductName", product.ProductName);
            productElement.SetElementValue("Inventory", product.Inventory);

            RootElement.Save(path);
        }

        public void DeleteProduct(string productId)
        {
            var productElements = RootElement.Element("Products").Elements("Product");

            var productElement = (from p in productElements
                                  where p.Element("Id").Value == productId
                                  select p).Single();
            productElement.Remove();

            RootElement.Save(path);
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
                product.Id = xelement.Element("Id").Value;
                product.ProductName = xelement.Element("ProductName").Value;
                product.Inventory = int.Parse(xelement.Element("Inventory").Value);
                products.Add(product);
            }
            return products;
        }
    }
}
