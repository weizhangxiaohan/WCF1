using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AService.DAL;

namespace AService.Interfaces
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        int GetProductInventory(string productCode);

        [OperationContract]
        IEnumerable<Product> GetProducts();

        [OperationContract]
        void CreateProduct(Product product);

        [OperationContract]
        void UpdateProduct(Product product);
    }
}
