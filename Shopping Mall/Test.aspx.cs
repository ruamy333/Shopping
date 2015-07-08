using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunction db = new DBFunction("product");
            String[][] arr = db.searchByColumn("product_name");
            for (int i = 0; i < arr.Length; i++)
            {
                Response.Write(arr[i][0] + "<br/>");
            }

            String[][] arr2 = db.searchSchema("name");
            for (int i = 0; i < arr2.Length; i++)
            {
                Response.Write(arr2[i][0] + "<br/>");
            }

            String[] arr3 = db.searchByRow("product_color","黑")[0];
            for (int i = 0; i < arr3.Length; i++)
            {
                Response.Write(arr3[i]);
            }

            String[] arr4 = db.searchByRow("product_price", 20, 30)[0];
            for (int i = 0; i < arr4.Length; i++)
            {
                Response.Write(arr4[i] + "<br/>");
            }
            /*
            String[] value = {"", "青茶", "25", "green", "L"};
            String str = db.insert(arr2, value);
            Response.Write(str + "<br/>");
            
            String str = db.delete("product_name", "青茶");
            Response.Write(str + "<br/>");
            */
        }
    }
}