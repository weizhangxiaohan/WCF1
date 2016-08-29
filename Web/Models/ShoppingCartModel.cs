using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ShoppingCartModel
    {
        public IEnumerable<OrderItem> items;

        public decimal TotalPrice;
    }

    public class OrderItem
    {
        [DisplayName("Good ID")]
        public string GoodId { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
    }
}