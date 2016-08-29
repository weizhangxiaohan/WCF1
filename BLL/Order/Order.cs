using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Order
{
    public class Order
    {
        public IList<OrderItem> Items;
    }

    public class OrderItem
    {
        public string ProductID { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
