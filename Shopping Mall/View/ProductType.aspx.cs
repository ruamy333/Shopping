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
            //判斷帳號
            if (Session["account"] == null || !Session["account"].Equals("admin"))
            {
                Response.Redirect("../Index.aspx");
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean complicate = false;
            String[][] type = dbType.searchAll();
            for(int i=0;i<type.Length;i++)
            {
                if(txtType.Text==type[i][1])
                {
                    complicate=true;             
                    break;
                }
            }
            if (txtType.Text=="" || txtType.Text==null)
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入類別名稱');location.href='Product.aspx';</Script>");
            }
                //不等於類別名稱
            else if(complicate)
            {
                Response.Write("<Script language='JavaScript'>alert('類別名稱重複');location.href='Product.aspx';</Script>");
            }
            else
            {
                UpdateType();
            }
        }

        private void UpdateType()
        {
            dbType.modify("name", txtType.Text, "ID", Request.QueryString["update"]);
            //Response.Write("<Script language='JavaScript'>alert('修改成功');location.href='Product.aspx';</Script>");
            
            Response.Write(""
                      + "<script type='text/javascript' language='javascript'>"
                  + "if(confirm('確認更改?'))"
                  + "{alert('更改成功');location.href='Product.aspx';}"
                  + "else{alert('取消');location.href='Product.aspx';}</script>");
            
        }
    }
}