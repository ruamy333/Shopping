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
            DBFunction db = new DBFunction("product");
            String[] arrType = db.searchGroupBy("type");
            for (int i = 0; i < arrType.Length; i++)
            {
                leftbarStr += "<a href='#'><div class='leftbar-type'>" + arrType[i] + "</div><div class='leftbar-baseline'></div></a><ul>";
                String[] arr1 = db.searchRowByColumn("name", "type", arrType[i]);
                for (int j = 0; j < arr1.Length; j++)
                {
                    leftbarStr += "<a href='#'><li>" + arr1[j] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
            

            //0707 新增
            String[] arrName = db.searchByColumn("name");
            String[] arrImg = db.searchByColumn("picture");
            String[] arrPrice = db.searchByColumn("price");
            String[] arrNum = db.searchByColumn("num");
            for (int a = 0; a <= (arrName.Length / 2); a++)
            {
                rightStr += "<div class ='product'>";
                for (int b = 0; b < 2; b++)
                {
                    if(2*a+b<arrName.Length)
                        rightStr += "<div class ='product-inside'><div class='image'><img src=../UploadPic/" + arrImg[2 * a + b] + "></div>"+ "名稱：" + "<div class='name'>" + arrName[2 * a + b] + "</div>" +"價格：" + "<div class='information'>" + arrPrice[2 * a + b] + "</div>"+ "數量：" +" <div class='information'>" + arrNum[2 * a + b] + "</div></div>";
                }
                rightStr += "</div>";
            }

        }
    }
}