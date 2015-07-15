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
        }
    }
}