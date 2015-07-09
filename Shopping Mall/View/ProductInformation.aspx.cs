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
            alertLogin.Visible = false;
            if (Session["account"] == null || Session["account"].Equals("admin"))
            {
                btnPurchase.Visible = false;
                alertLogin.Visible = true;
            }
            productShow(Request.QueryString["p"]);
            setLeftBar();
        }
        //讀取產品介紹
        private void productShow(String ID) 
        {
            if(ID == null){
                ID = "21";
            }
            String[][] proArr = db.searchByRow("ID", ID);

            productName.Text = proArr[0][1];
            priceLabel.Text = proArr[0][3];
            for (int i = 0; i < int.Parse(proArr[0][4]); i++)
            {
                numberDropList.Items.Add((i+1) + "");
            }
            if (int.Parse(proArr[0][4]) == 0) laseNum.Text = "　　目前無庫存";
            else laseNum.Text += proArr[0][4] + " 個";
            productImage.ImageUrl = "../UploadPic/" + proArr[0][5];
            introLabel.Text = proArr[0][6];
        }
        //購買btn
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            DBFunction dbPurchase = new DBFunction("purchaseList");
            //舊有資料更新
            String[][] checkArr = dbPurchase.searchRowByColumn("product_name , num", "account", Session["account"].ToString());
            if (checkArr.Length > 0)
            {
                bool check = false;
                int i;
                for (i = 0; i < checkArr.Length; i++)
                {
                    if (checkArr[i][0].Equals(productName.Text))
                    {
                        check = true;
                        break;
                    }
                }
                if(check)
                    dbPurchase.modify("num", int.Parse(checkArr[i][1]) + int.Parse(numberDropList.SelectedValue), "account", Session["account"].ToString() + "' AND product_name='" + productName.Text);
                else newData(dbPurchase);
            }
            else
            {
                newData(dbPurchase);
            }
            //String[][] checkArr = dbPurchase.searchRowByColumn("account, num", "product_name", productName.Text);
            //if (checkArr.Length > 0)
            //{
            //    for (int i = 0; i < checkArr.Length; i++)
            //    {
            //        if (checkArr[i][0].Equals(Session["account"]))
            //            dbPurchase.modify("num", int.Parse(checkArr[i][1]) + int.Parse(numberDropList.SelectedValue), "account", checkArr[i][0]);
            //    }
            //}
            //else 
            //{
            //    newData(dbPurchase);
            //}

            Response.Redirect("Product.aspx");
        }
        //新增購物車資料
        private void newData(DBFunction dbPurchase) 
        {
            String[][] attributes = dbPurchase.searchSchema("name");
            String[] schemaArr = new String[attributes.Length];
            for (int i = 0; i < attributes.Length; i++)
            {
                schemaArr[i] = attributes[i][0];
            }
            String[] values = new String[] { "", Session["account"].ToString(), productName.Text, priceLabel.Text, numberDropList.SelectedValue };
            dbPurchase.insert(schemaArr, values);
        }
        //左方menu
        public String leftbarStr = "";
        private void setLeftBar()
        {
            String[][] arrType = db.searchGroupBy("type");
            for (int i = 0; i < arrType.Length; i++)
            {
                //leftbarStr += "<a href='Product.aspx?t=" + arrType[i][0] + "'><div class='leftbar-type'>" + arrType[i][0] + "</div><div class='leftbar-baseline'></div></a><ul>";
                leftbarStr += "<div class='leftbar-type'>" + arrType[i][0] + "</div><ul>";
                String[][] productArr = db.searchByRow("type", arrType[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    leftbarStr += "<a href='ProductInformation.aspx?p=" + productArr[j][0] + "'><li>" + productArr[j][1] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
        }
    }
}