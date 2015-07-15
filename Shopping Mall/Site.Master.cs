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
        public String linkStr;
        public String Path;
        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Request.ApplicationPath;
            if (Path != "/")
                Path += "/";
            if (Session["account"] == null)
            {
                linkStr = "<li id='login'><a href='" + Path + "View/Login.aspx'>Login</a></li>";
            }
            else if (Session["account"].ToString().Equals("admin"))
            {
                linkStr = "<li id='producteditor'><a href='" + Path + "View/ProductEditor.aspx'>Add Product</a></li>"
                        + "<li id='producttype'><a href='" + Path + "View/ProductType.aspx'>Add Type</a></li>"
                        + "<li id='order'><a href='" + Path + "View/Orders.aspx'>Order</a></li>"
                        + "<li id='logout'><a href='" + Path + "Index.aspx?l=0'>Logout</a></li>";
            }
            else
            {
                linkStr = "<li id='purchasecar'><a href='" + Path + "View/PurchaseCar.aspx'>Shopping car</a></li>"
                    + "<li id='order'><a href='" + Path + "View/Orders.aspx'>Order</a></li>"    
                    + "<li id='logout'><a href='" + Path + "Index.aspx?l=0'>Logout</a></li>";
            }
            setMenuLink();
        }
        private void setMenuLink()
        {
            String[] arr = ContentPlaceHolder1.Page.ToString().Split('_', '.');
            String id = arr[arr.Length - 2];
            if (id.Equals("productinformation"))
                id = "product";
            linkStr += "<script type='text/javascript'>$(document).ready(function () { $('#" + id + "').addClass('active'); });</script>";
        }
    }
}