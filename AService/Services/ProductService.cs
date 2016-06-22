using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AService.Interfaces;

namespace AService.Services
{
    public class ProductService : IProductService
    {
        public int GetProductInventory(string productCode)
        {
            return 3;
        }
    }
}
