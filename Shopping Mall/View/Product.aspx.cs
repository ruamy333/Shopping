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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*String num = Request.QueryString["num"];
            DBFunction db = new DBFunction("purchaselist");
            db.insert("num",num);*/

            DBFunction db = new DBFunction("product");
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
            

            //0707 新增
            String[][] array = db.searchByColumn("picture,name,price,num");
            for (int a = 0; a <= (array.Length / 2); a++)
            {
                if (2 * a == array.Length)
                    break;
                else
                    rightStr += "<div class ='product'>";
                for (int b = 0; b < 2; b++)
                {
                    if(2*a+b<array.Length)
                        rightStr += "<div class ='product-inside'>"
                            +"<div class='image'><img src=../UploadPic/" + array[2 * a + b][0] + "></div>"
                            +"<div class='name'><a href='#'>" + array[2 * a + b][1] + "</a></div>"
                            +"<div class='information'><b style='font-size=0.5cm'>價格：</b>" + array[2 * a + b][2] + "元<b style='font-size=0.5cm;padding-left:35px;'>數量：</b>" + array[2 * a + b][3] + "</div>"
                            +"<div class='information'><a href='PurchaseCar.aspx?d=>"+"購買數量: <input type='number' name='num' value=''><br><input type='submit' value='Submit'></a></div>"
                            //+"<div class='information'>刪除: <asp:Button ID='Button1' runat='server' Text='Button' /></div>"
                            +"</div>";
                }

                rightStr += "</div>";
            }
        }
    }
}