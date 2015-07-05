using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static String s;
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] arr = ContentPlaceHolder1.Page.ToString().Split('_','.');
            s = arr[arr.Length-2];
        }
    }
}