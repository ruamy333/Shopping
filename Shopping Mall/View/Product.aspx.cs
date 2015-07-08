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
                    if(2*a+b<array.Length)
                        rightStr += "<div class ='product-inside'>"
                            +"<div class='image'><img src=../UploadPic/" + array[2 * a + b][0] + "></div>"
                            +"<div class='name'><a href='#'>" + array[2 * a + b][1] + "</a></div>"
                            +"<div class='information'><b style='font-size=0.5cm'>價格：</b>" + array[2 * a + b][2] + "元<b style='font-size=0.5cm;padding-left:35px;'>數量：</b>" + array[2 * a + b][3] + "</div>"
                            +"</div>";
                }

                rightStr += "</div>";
            }
            
        }
    }
}