using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall.View.ProductInfo
{
    public partial class ProductInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunction db = new DBFunction();
            productName.Text = "蛋";
            String[] arr = db.searchByRow("name", productName.Text);
            priceLabel.Text = arr[3];
            for (int i = 1; i <= int.Parse(arr[4]); i++)
            {
                numberDropList.Items.Add(i+"");
            }
            //productImage.ImageUrl = arr[5];
        }
    }
}