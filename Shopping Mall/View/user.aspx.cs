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
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunction db = new DBFunction();
            String[] arr = db.searchByColumn("name");
            Label1.Text = arr[0];
            Label2.Text = arr[1];
            Label3.Text = arr[2];
            //for (int i = 1; i < 4; i++)
            //{
            //        ((Label)FindControl("Label" + i.ToString())).Text = arr[i] + "<br/>";
            //}
       
        }
    }
}