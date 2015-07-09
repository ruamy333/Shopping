using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String leftbarStr = "";
        public String rightStr = "";
        public DBFunction db = new DBFunction("product");
        protected void Page_Load(object sender, EventArgs e)
        {         
            //0708每次load都先判斷是否有回傳值，第一次開網頁並沒有回傳
            //delete();
            PutIntoCart();
            setLeftBar();
            pageShow();
            
        }

        private void setLeftBar()
        {
            String[][] arrType = db.searchGroupBy("type");
            for (int i = 0; i < arrType.Length; i++)
            {
                leftbarStr += "<div class='leftbar-type'>" + arrType[i][0] + "</div><ul>";
                String[][] productArr = db.searchByRow("type", arrType[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    leftbarStr += "<a href='ProductInformation.aspx?p=" + productArr[j][0] + "'><li>" + productArr[j][1] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
        }

        private void delete()
        {
            String del = Request.QueryString["d"];
            if (del != null)
            {
                db.delete("ID", del);
            }
        }

        private void PutIntoCart()
        {
            String num = Request.QueryString["num"];
            String ID = Request.QueryString["ID"];
            if (num != null && num!="")
            {
                if ((String)Session["account"] != "root" || (String)Session["account"] != "abc")
                {
                    Response.Write("<Script language='JavaScript'>alert('請登入');</Script>");
                }
                else
                {
                    String[][] str = db.searchRowByColumn("ID,name,price", "ID", ID);
                    DBFunction db2 = new DBFunction("purchaseList");
                    String[] value = new String[] { str[0][0], (String)Session["account"], str[0][1], str[0][2], num };
                    //String[] value = { str[0][0], str[0][1], str[0][2], str[0][3], num };
                    String[] attribute = { "ID", "account", "product_name", "price", "num" };
                    db2.insert(attribute, value);
                }
            }          
        }

        private void pageShow()
        {
            String[][] array;
            if (Request.QueryString["t"] == null)
            {
                array = db.searchByColumn("id,name,type,price,num,picture");
            }
            else
            {
                array = db.searchByRow("type", Request.QueryString["t"]);
            }
            //0707 新增
            //0708 修改可以回傳ID、購買數量給自己這頁
            for (int a = 0; a <= (array.Length / 2); a++)
            {
                if (2 * a == array.Length)
                    break;
                else
                    rightStr += "<div class ='product'>";
                for (int b = 0; b < 2; b++)
                {
                    if (2 * a + b < array.Length)
                    {
                        rightStr += "<div class ='product-inside'>"
                            + "<div class='ImgDel'>"
                            + "<div class='image'><a href='ProductInformation.aspx?p=" + array[2 * a + b][0] + "'><img src=../UploadPic/" + array[2 * a + b][5] + "></a></div>"
                            + "<div class='delete'>";
                        //刪除按鈕visible的判斷
                        if ((String)Session["account"] == "admin")
                        {
                            rightStr += "<a href='Product.aspx?d=" + array[2 * a + b][0] + "'><img src=../Picture/delete.png style='width:50px;'></a></div>";
                        }
                        else
                        {
                            rightStr += "</div>";
                        }

                        rightStr += "</div>"
                        + "<div class='name'><a href='ProductInformation.aspx?p=" + array[2 * a + b][0] + "'>" + array[2 * a + b][1] + "</a></div>"
                        + "<div class='information'><b style='font-size=0.5cm'>價格：</b>" + array[2 * a + b][3] + "元<b style='font-size=0.5cm;padding-left:35px;'>數量：</b>" + array[2 * a + b][4] + "</div>"
                        + "<div class='information'><form action='Product.aspx' method='get' onsubmit='return validate_form(this)'>購買數量：<input type='number' name='num' style=width:50px runat'server'><input type='hidden' name='ID' value='" + array[2 * a + b][0] + "' runat'server'><br><input class='button-style' type='submit' value='加入購物車'></form></div>"
                        + "</div>";
                    }
                }

                rightStr += "</div>";
            }
        }
    }
}