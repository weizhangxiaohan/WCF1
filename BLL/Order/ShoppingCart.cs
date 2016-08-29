using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Order
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> _items;

        public  IList<ShoppingCartItem> ShoppingCartItems
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Convert.ToDecimal(1234.56);
            }
        }

        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }



        //private static decimal CalculateTotalPrice(Dictionary<string, int> goods)
        //{
        //    return Convert.ToDecimal(1234.56);
        //}

        public  void AddGoods(ShoppingCartItem shoppingCarItem)
        {
            var query = (from o in ShoppingCartItems
                         where o.GoodId == shoppingCarItem.GoodId
                         select o).FirstOrDefault();

            if (query == null)
            {
                ShoppingCartItems.Add(shoppingCarItem);
            }
            else
            {
                query.Amount += shoppingCarItem.Amount;
            }
            
            HttpContext.Current.Session["ShoppingCart"] = this;
        }


        public static ShoppingCart Current
        {
            get
            { 
                if (HttpContext.Current.Session["ShoppingCart"] == null)
                {
                    HttpContext.Current.Session["ShoppingCart"] = new ShoppingCart();
                }

                return HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
            }
        }
    }

    public class ShoppingCartItem
    {
        public string GoodId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
