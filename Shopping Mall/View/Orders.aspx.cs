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
            if (Session["account"] == null)              
                Response.Redirect("../Index.aspx");
            else if (!Session["account"].Equals("admin")) customerShowList();
            else showList();
            
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
                    + "<div class='column-boxS'>" + productArr[0][0] + "</div>"
                    + "<div class='column-boxS'>" + accJoinOrder[0][0] + "</div>"
                    + "<div class='column-boxL'><div class='column-retractable'>點擊</div><ul>";
                int total = 0;
                for (int j = 0; j < productArr.Length; j++)
                {
                    total += int.Parse(productArr[j][4]);
                    orderList += "<li>" + productArr[j][2] + "  數量：" + productArr[j][3] + "</li>";
                }
                DateTime dt = DateTime.Now;
                orderList += "</ul></div>"
                    + "<div class='column-boxS'>" + total.ToString() + "</div>";
                if (productArr[0][5] == null || productArr[0][5].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style' style='background-color:#ff4500'><a href='Orders.aspx?pay=" + dt.ToShortDateString().ToString() + ":" + productArr[0][0] + "'>未繳費</a></div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已繳費</div>" + productArr[0][5] + "</div>";
                if (productArr[0][6] == null || productArr[0][6].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style' style='background-color:#ff4500'><a href='Orders.aspx?ship=" + dt.ToShortDateString().ToString() + ":" + productArr[0][0] + "'>未出貨</a></div></div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已出貨</div>" + productArr[0][6] + "</div></div>";
            }
        }

        private void customerShowList() 
        {
            String[][] arrType = db.searchGroupBy("ID", "account", Session["account"].ToString());
            for (int i = 0; i < arrType.Length; i++)
            {
                productArr = db.searchByRow("ID", arrType[i][0]);
                String[][] accJoinOrder = db.innerJoin("account.name", "account", "account.account", "orderList.account", "orderList.ID", arrType[i][0]);
                orderList += "<div class='center-column'>"
                    + "<div class='column-boxS'>" + productArr[0][0] + "</div>"
                    + "<div class='column-boxS'>" + accJoinOrder[0][0] + "</div>"
                    + "<div class='column-boxL'><div class='column-retractable'>點擊</div><ul>";
                int total = 0;
                for (int j = 0; j < productArr.Length; j++)
                {
                    total += int.Parse(productArr[j][4]);
                    orderList += "<li>" + productArr[j][2] + "  數量：" + productArr[j][3] + "</li>";
                }
                orderList += "</ul></div>"
                    + "<div class='column-boxS'>" + total.ToString() + "</div>";
                if (productArr[0][5] == null || productArr[0][5].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style' style='background-color:#ff4500'>未繳費</div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已繳費</div>" + productArr[0][5] + "</div>";
                if (productArr[0][6] == null || productArr[0][6].Equals(""))
                    orderList += "<div class='column-boxM'><div class='button-style' style='background-color:#ff4500'>未出貨</div></div></div>";
                else orderList += "<div class='column-boxM'><div class='button-style'>已出貨</div>" + productArr[0][6] + "</div></div>";
            }
        }
    }
}