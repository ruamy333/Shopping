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
        private String[][] productArr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account"] == null || !Session["account"].Equals("admin"))
            {
                Response.Redirect("/Index.aspx");
            }
            showList();
            if (Request.QueryString["pay"] != null)
            {
                String[] payDate = Request.QueryString["pay"].Split(':');
                if (payDate != null) db.modify("pay_date", payDate[0], "ID", payDate[1]);
                Response.Redirect("Orders.aspx");
            }
            if (Request.QueryString["ship"] != null)
            {
                String[] shipDate = Request.QueryString["ship"].Split(':');
                if (shipDate != null) db.modify("shipping_date", shipDate[0], "ID", shipDate[1]);
                Response.Redirect("Orders.aspx");
            }
        }

        private void showList() 
        {
            String[][] arrType = db.searchGroupBy("ID");
            for (int i = 0; i < arrType.Length; i++)
            {
                productArr = db.searchByRow("ID", arrType[i][0]);
                String[][] accJoinOrder = db.innerJoin("account.name", "account", "account.account", "orderList.account", "orderList.ID", arrType[i][0]);
                orderList += "<div class='center-column'>" 
                    + "<div class='column-boxS'>" + productArr[i][0] + "</div>"
                    + "<div class='column-boxS'>" + accJoinOrder[0][0] + "</div>"
                    + "<div class='column-boxL'>點擊<ul>";
                int total = 0;
                for (int j = 0; j < productArr.Length; j++)
                {
                    total += int.Parse(productArr[j][4]);
                    //orderList += "<li>" + productArr[j][2] + "  " + productArr[j][3] + "</li>";
                }
                DateTime dt = DateTime.Now;
                orderList += "</ul></div>"
                    + "<div class='column-boxS'>" + total.ToString() + "</div>";
                if (productArr[i][5] == null || productArr[i][5].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style'><a href='Orders.aspx?pay=" + dt.ToShortDateString().ToString() + ":" + productArr[i][0] + "'>未繳費</a></div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已繳費</div>" + productArr[i][5] + "</div>";
                if (productArr[i][6] == null || productArr[i][6].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style'><a href='Orders.aspx?ship=" + dt.ToShortDateString().ToString() + ":" + productArr[i][0] + "'>未出貨</a></div></div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已出貨</div>" + productArr[i][6] + "</div></div>";
            }
        }
    }
}