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

        private DBFunction db = new DBFunction("type");
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
                addType();
            }
        }

        private void addType()
        {
            List<String> list = new List<string>();
            list.Add(txtType.Text);
            String[] attribute = new String[1];
            attribute[0] = "name";
            String str = db.insert(attribute, list.ToArray());
            Response.Write("<script>alert('新增成功!');location.href='../Index.aspx';</script>");
        }
    }
}