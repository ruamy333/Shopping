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
            productName.Text = "Mini OTDR: FiberPal OT-8800";
            String[] arr = db.searchByRow("name", productName.Text);
            priceLabel.Text = arr[3];
            for (int i = 1; i <= int.Parse(arr[4]); i++)
            {
                numberDropList.Items.Add(i+"");
            }
            productImage.ImageUrl = arr[5];
            introLabel.Text = arr[6];
        }
        
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ProductInformation.aspx");
        }

        protected void linkProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        //private void sidebar() 
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Label link = new Label();
        //        link.Text = "link" + i.ToString();

        //    }
        //}

    }
}