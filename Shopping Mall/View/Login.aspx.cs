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
        private DBFunction db = new DBFunction();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //登入btn
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                Response.Write("<Script language='JavaScript'>alert('登入成功');</Script>");
                //Response.Redirect("/Index.aspx");
            }
            else 
            {
                Response.Write("<Script language='JavaScript'>alert('輸入之帳號或密碼有誤，請重新輸入');</Script>");
            }
            
        }
        private bool verify()
        {
            db.changeTableName("user_account");
            String acc = account.Text;
            String pwd = password.Text;
            String correspondPwd = db.searchRowByColumn("password","account",acc)[0];
            if (correspondPwd.Equals(pwd))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}