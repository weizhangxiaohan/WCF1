using BLL.Order;
using Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Detail()
        {
            List<Models.OrderItem> model = new List<Models.OrderItem>();

            foreach (var item in ShoppingCart.Current.ShoppingCartItems)
            {
                Models.OrderItem orderItem = new Models.OrderItem();
                orderItem.GoodId = item.GoodId;
                orderItem.UnitPrice = item.UnitPrice;
                orderItem.Amount = item.Amount;
                model.Add(orderItem);
            }
            return View(model);
        }

        public ActionResult CheckOut()
        {
            ShoppingCartModel model = new ShoppingCartModel();
            model.TotalPrice = ShoppingCart.Current.TotalPrice;
            return View(model);
        }

        public ActionResult PayUseZhiFuBao()
        {
            Response.ContentType = "text/plain";
            string partner = "2";
            string subject = "store__name";//商品名称
            string body = "goods__info";       //商品描述
            string out_trade_no = "order__no";//订单号
            string total_fee = "1234.66"; //总金额
            string seller_email = "abc@abc.com";//卖家邮箱
            string return_url = "http://localhost:59002/ShoppingCart/PayCallBack";//回调地址
            string key = "abc123";
            string sign = MD5Utility.UserMd5(total_fee + partner + out_trade_no + subject + key);
            //重定向到支付的页面
            Response.Redirect("http://paytest.rupeng.cn/AliPay/PayGate.ashx?partner=" + partner + "&return_url=" + return_url + "&subject=" + subject +
                "&body=" + body + "&out_trade_no=" + out_trade_no + "&total_fee=" + total_fee + "&seller_email=" + seller_email
                + "&sign=" + sign);

            return View();
        }

        public ActionResult PayCallBack()
        {
            string orderNo = Request["out_trade_no"];
            ViewBag.orderNo = orderNo;
            return View();
        }
    }
}