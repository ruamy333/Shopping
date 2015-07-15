using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall
{
    public partial class index : System.Web.UI.Page
    {
        public String columnStr = "";
        private DBFunction db = new DBFunction("product");
        private DBFunction dbType = new DBFunction("type");
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunction db = new DBFunction("indexInfo");

            String[][] infoArr = db.searchAll();
            indexImage.ImageUrl = infoArr[0][1];

            if (Request.QueryString["l"] != null)
            {
                Session.Clear();
                Response.Redirect("Index.aspx");
            }
            setColumn();
        }

        private void setColumn()
        {
            String[][] productTypeArr = dbType.searchAll();
            
            for (int i = 0; i < 3; i++)
            {
                String typeID = productTypeArr[i][0];
                String type = productTypeArr[i][1];
                String[][] productArr = db.searchByRow("type", typeID);
                columnStr += "<div class='columnbox'><a href='View/Product.aspx?type=" + typeID + "' class='image image-full'>"
                           + "<img src='UploadPic/" + productArr[0][5] + "'/></a>"
                           + "<h2>" + type + "</h2><p>";

                for (int j = 0; j < productArr.Length; j++)
                {
                    columnStr += "● " + productArr[j][1] + "<br/>";
                }
                columnStr += "</p><a href='View/Product.aspx?type=" + typeID + "' class='button-style'>More</a></div>";
            }
        }
    }
}