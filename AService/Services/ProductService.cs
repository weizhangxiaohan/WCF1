﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AService.Interfaces;
using AService.DAL;

namespace AService.Services
{
    public class ProductService : IProductService
    {
        ProductGateway productGateway = new ProductGateway();

        public int GetProductInventory(string productCode)
        {
            Product product = productGateway.FindByProductCode(productCode);
            return product.Inventory;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productGateway.GetAllProducts();
        }
    }
}