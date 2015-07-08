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
            String name = Request.QueryString["d"];
            if (name == null)
            {
                name = "Mini OTDR: FiberPal OT-8800";
            }
            productShow(name);
            
            sidebar();
        }
        //讀取產品介紹
        private void productShow(String name) 
        {         

            String[][] proArr = db.searchByRow("name", name);
            productName.Text = proArr[0][1];
            priceLabel.Text = proArr[0][3];
            for (int i = 1; i <= int.Parse(proArr[0][4]); i++)
            {
                numberDropList.Items.Add(i + "");
            }
            productImage.ImageUrl = "../UploadPic/" + proArr[0][5];
            introLabel.Text = proArr[0][6];
        }
        //購買btn
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            DBFunction dbPurchase = new DBFunction("purchaseList");
            String[][] attributes = db.searchSchema("name");
            String[] schemaArr = new String[attributes.Length];
            for (int i = 1; i < attributes.Length; i++)
            {
                schemaArr[i] = attributes[i][0];
            }
            String[] values = new String[]{"root", productName.Text, priceLabel.Text, numberDropList.SelectedValue};
            dbPurchase.insert(schemaArr, values);

            Response.Redirect("Product.aspx");
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