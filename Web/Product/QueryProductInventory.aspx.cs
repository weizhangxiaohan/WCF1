using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Product
{
    public partial class QueryProductInventory : System.Web.UI.Page
    {
        ProductService.ProductServiceClient productService = new ProductService.ProductServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void queryButton_Click(object sender, EventArgs e)
        {

            int result = productService.GetProductInventory(productCodeInput.Text);
            queryResult.Text = string.Format("该产品的库存为{0}",result);
            queryResult.ForeColor = Color.Red;
        }
    }
}