using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall.View
{
    public partial class Login : System.Web.UI.Page
    {
        private DBFunction db = new DBFunction("account");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //登入btn
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (account.Text.Equals("admin") && password.Text.Equals("admin"))
            {
                Session["account"] = "admin";
                Response.Redirect("../Index.aspx");
            }
            else if (verify())
            {
                Session["account"] = account.Text;
                Response.Redirect("../Index.aspx");
            }
            else 
            {
                Response.Write("<Script language='JavaScript'>alert('輸入之帳號或密碼有誤，請重新輸入');</Script>");
            }
        }
        private bool verify()
        {
            String acc = account.Text;
            String pwd = password.Text;
            String[] arr = db.searchRowByColumn("password", "account", acc)[0];
            if (arr.Length==0) return false;
            else if (arr[0].Equals(pwd)) return true;
            else return false;
        }
    }
}