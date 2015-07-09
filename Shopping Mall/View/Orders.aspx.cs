using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall.View
{
    public partial class Orders : System.Web.UI.Page
    {
        public String orderList = "";
        private DBFunction db = new DBFunction("orderList");
        private String[][] arrOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account"] == null || !Session["account"].Equals("admin"))
            {
                Response.Redirect("/Index.aspx");
            }
            //showList();

            String[][] arrType = db.searchGroupBy("account");
            for (int i = 0; i < arrType.Length; i++)
            {
                orderList += "<div class='center-column'><div class='column-box'>" + arrType[i][0] + "</div></div><ul>";
                String[][] productArr = db.searchByRow("account", arrType[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    orderList += "<li>" + productArr[j][2] + "</li></a>";
                }
                orderList += "</ul>";
            }
        }

        private void showList() 
        {
            arrOrder = db.searchAll();
            for (int i = 0; i < arrOrder.Length; i++)
            {
                orderList +=
                    "<div class='center-column'><div class='column-box'>" + arrOrder[i][1] + "</div>"
                    + "<div class='column-box'>" + arrOrder[i][1] + "</div>"
                    + "<div class='column-name'>" + arrOrder[i][2] + "</div>"
                    + "<div class='column-box'>" + arrOrder[i][3] + "</div>"
                    + "<div class='column-box'>" + arrOrder[i][4] + "</div>"
                    + "<div class='column-box'>" + "折扣" + "</div>"
                    + "<div class='column-delete'><a href='PurchaseCar.aspx?d=" + arrOrder[i][0] + "' class='button-style'>刪除</a></div></div>";
            }
        }
    }
}