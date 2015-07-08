using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall.View
{
    public partial class PurchaseCar : System.Web.UI.Page
    {
        public String shoppingList = "";
        private DBFunction db = new DBFunction("purchaseList");
        private String[][] arrOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            showList();

            String ID = Request.QueryString["d"];
            db.delete("ID", ID);
        }
        //送出btn
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("<Script language='JavaScript'>alert('購買成功!');location.href='/Index.aspx';</Script>");
        }
        //列出購買清單      
        private void showList()
        {
            arrOrder = db.searchRowByColumn("ID, product_name, price, num", "account", "root");
            int total = 0;
            for (int i = 0; i < arrOrder.Length; i++)
            {
                int price = Convert.ToInt32(arrOrder[i][2]) * Convert.ToInt32(arrOrder[i][3]);
                total += price;
                shoppingList += "<div class='center-column'><div class='column-name'><a href='ProductInformation.aspx?d='>" + arrOrder[i][0] + "</a></div>"
                    + "<div class='column-priceAndnum'>" + arrOrder[i][2] + "</div>"
                    + "<div class='column-priceAndnum'>" + arrOrder[i][3] + "</div>"
                    + "<div class='column-priceAndnum'>" + price + "</div>"
                    + "<div class='column-delete'><a href='PurchaseCar.aspx?d=" + arrOrder[i][0] + "' class='button-style'>刪除</a></div></div>";              
            }
            //計算總金額
            totalPrice.Text += total + "元";         
        }
    }
}