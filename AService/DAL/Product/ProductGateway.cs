using AService.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AService.DAL.Products
{
    public class ProductGateway
    {        
        private static readonly string XML_FILE_PATH = @"C:\Users\marvin.wei\Source\Repos\WCF1\AService\App_Data\SimpleDataBase.xml";
        //private static readonly string XML_FILE_PATH = @"C:\Users\Administrator\Source\Repos\WCF1\AService\App_Data\SimpleDataBase.xml";

        private IEnumerable<Product> products;
        private XElement rootElement;

        public XElement RootElement
        {
            get
            {
                if (rootElement == null)
                {
                    rootElement = XElement.Load(XML_FILE_PATH);
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
                new XElement("Inventory", product.Inventory),
                new XElement("UnitPrice",product.UnitPrice)));

            RootElement.Save(XML_FILE_PATH);
        }

        public void UpdateProduct(Product product)
        {
            var productElements = RootElement.Element("Products").Elements("Product");

            var productElement = (from p in productElements
                                 where p.Element("Id").Value == product.Id
                                 select p).Single();

            productElement.SetElementValue("ProductName", product.ProductName);
            productElement.SetElementValue("Inventory", product.Inventory);
            productElement.SetElementValue("UnitPrice", product.UnitPrice);

            RootElement.Save(XML_FILE_PATH);
        }

        public void DeleteProduct(string productId)
        {
            var productElements = RootElement.Element("Products").Elements("Product");

            var productElement = (from p in productElements
                                  where p.Element("Id").Value == productId
                                  select p).Single();
            productElement.Remove();

            RootElement.Save(XML_FILE_PATH);
        }
    }

    public static class ProductMapping
    {
        public static IEnumerable<Product> Convert(IEnumerable<XElement> productXElements)
        {
            IList<Product> products = new List<Product>();
            foreach (var xelement in productXElements)
            {
                Product product = new Product();
                product.Id = xelement.Element("Id").Value;
                product.ProductName = xelement.Element("ProductName").Value;
                product.Inventory = int.Parse(xelement.Element("Inventory").Value);
                if (xelement.Element("UnitPrice") != null) { 
                    product.UnitPrice = decimal.Parse(xelement.Element("UnitPrice").Value);
                }
                products.Add(product);
            }
            return products;
        }      
    }
}
