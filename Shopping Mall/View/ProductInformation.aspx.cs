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
        private DBFunction db = new DBFunction("product");

        protected void Page_Load(object sender, EventArgs e)
        {
            productShow();
            sidebar();
        }
        //讀取產品介紹
        private void productShow() 
        {
            productName.Text = "Mini OTDR: FiberPal OT-8800";
            String[] arr = db.searchByRow("name", productName.Text)[0];
            priceLabel.Text = arr[3];
            for (int i = 1; i <= int.Parse(arr[4]); i++)
            {
                numberDropList.Items.Add(i + "");
            }
            productImage.ImageUrl = "../UploadPic/" + arr[5];
            introLabel.Text = arr[6];
        }
        //購買btn
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }
        //左方menu
        public String leftbarStr = "";
        private void sidebar()
        {
            String[][] arrType = db.searchGroupBy("type");
            for (int i = 0; i < arrType.Length; i++)
            {
                leftbarStr += "<a href='#'><div class='leftbar-type'>" + arrType[i][0] + "</div><div class='leftbar-baseline'></div></a><ul>";
                String[][] productArr = db.searchRowByColumn("name", "type", arrType[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    for (int k = 0; k < productArr[j].Length; k++)
                    {
                        leftbarStr += "<a href='#'><li>" + productArr[j][k] + "</li></a>";
                    }                
                }
                leftbarStr += "</ul>";
            }
        }
    }
}