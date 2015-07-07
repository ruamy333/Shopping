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
        private String[] arrOrder;
        int arrOrderLen;

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
            arrOrderLen = db.searchRowByColumn("account", "account", "root").Length;
            int tmp = 0;
            int total = 0;
            for (int i = 0; i < arrOrderLen; i++)
            {
                int price = Convert.ToInt32(arrOrder[tmp + 2]) * Convert.ToInt32(arrOrder[tmp + 3]);
                total += price;
                shoppingList += "<div class='center-column'><div class='column-name'><span class='content-text'>" + arrOrder[tmp + 1] + "</span></div>"
                    + "<div class='column-priceAndnum'>" + arrOrder[tmp + 2] + "</div>"
                    + "<div class='column-priceAndnum'>" + arrOrder[tmp + 3] + "</div>"
                    + "<div class='column-priceAndnum'>" + price + "</div>"
                    + "<div class='column-delete'><a href='PurchaseCar.aspx?d=" + arrOrder[tmp] + "' class='button-style'>刪除</a></div></div>";
                tmp += 4;                
            }
            //計算總金額
            totalPrice.Text += total + "元";         
        }
    }
}