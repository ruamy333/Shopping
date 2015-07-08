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
            
            String ID = Request.QueryString["d"];
            db.delete("ID", ID);

            
            String num = Request.QueryString["num"];
            DBFunction db2 = new DBFunction("purchaseList");
            String [] input={"ID","account","product_name","price","num"};
            String[] value = { "19", "root", "PALM OTDR: FIBERPAL OT-8600", "25600", num };
            db2.insert(input,value);
            setLeftBar();
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
            for (int a = 0; a <= (array.Length / 2); a++)
            {
                if (2 * a == array.Length)
                    break;
                else
                    rightStr += "<div class ='product'>";
                for (int b = 0; b < 2; b++)
                {
                    if (2 * a + b < array.Length)
                        rightStr += "<div class ='product-inside'>"
                            + "<div class='image'><a href='ProductInformation.aspx?p=" + array[2 * a + b][0] + "'><img src=../UploadPic/" + array[2 * a + b][5] + "></a></div>"
                            + "<div class='delete'><a href='Product.aspx?d=" + array[2 * a + b][0] + "'><img src=../Picture/delete.png style='width:50px;'></a></div>"
                            + "<div class='name'><a href='ProductInformation.aspx?p=" + array[2 * a + b][0] + "'>" + array[2 * a + b][1] + "</a></div>"
                            + "<div class='information'><b style='font-size=0.5cm'>價格：</b>" + array[2 * a + b][3] + "元<b style='font-size=0.5cm;padding-left:35px;'>數量：</b>" + array[2 * a + b][4] + "</div>"
                            + "<div class='information'><form action='Product.aspx' method='get' >購買數量：<input type='number' name='num' runat'server'><br><input type='submit' value='Submit'></form></div>"
                            + "</div>";
                }

                rightStr += "</div>";
            }
            
        }

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