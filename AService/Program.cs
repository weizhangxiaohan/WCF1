using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AService.Services;

namespace AService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost productService = new ServiceHost(typeof(ProductService));
                productService.Open();

                ServiceHost userService = new ServiceHost(typeof(UserService));
                userService.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Started");
            Console.ReadKey();
        }
    }
}
