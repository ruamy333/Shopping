using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall
{
    public partial class ProductType : System.Web.UI.Page
    {

        private DBFunction dbType = new DBFunction("type");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtType.Text.Equals(""))
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入類別名稱');location.href='ProductType.aspx';</Script>");
            }
            else
            {
                UpdateType();
            }
        }

        private void UpdateType()
        {
            dbType.modify("name", txtType.Text, "ID", Request.QueryString["update"]);
            Response.Write("<Script language='JavaScript'>alert('修改成功');location.href='Product.aspx';</Script>");
        }
    }
}