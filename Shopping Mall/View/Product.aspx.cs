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
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunction db = new DBFunction();
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
            
        }
    }
}