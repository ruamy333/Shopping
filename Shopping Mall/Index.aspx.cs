using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall
{
    public partial class index : System.Web.UI.Page
    {
        public String Path;
        public String columnStr;
        public String editImgStr;
        private DBFunction db = new DBFunction("product");
        private DBFunction dbType = new DBFunction("type");
        private String[][] infoArr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Request.ApplicationPath;
            if (Path != "/")
                Path += "/";

            //找圖
            DBFunction db = new DBFunction("indexInfo");
            infoArr = db.searchAll();
            indexImage.ImageUrl = infoArr[0][1];
            txtImg.Visible = false;
            btnImgSave.Visible = false;

            //判斷管理者
            if (Session["account"] != null && Session["account"].ToString().Equals("admin"))
                editImgStr = "<a href='" + Path + "Index.aspx?edit=image'><img src=../Picture/edit.png style='width:30px;'></a>";
            
            //修改圖
            if (Request.QueryString["edit"] != null && Request.QueryString["edit"].ToString().Equals("image"))
            {
                if (!IsPostBack)
                {
                    txtImg.Visible = true;
                    btnImgSave.Visible = true;
                    txtImg.Text = infoArr[0][1];
                    editImgStr = "";
                }
            }

            //判斷是否登出
            if (Request.QueryString["l"] != null)
            {
                Session.Clear();
                Response.Redirect("Index.aspx");
            }
            setColumn();
        }

        //Img修改儲存按鈕
        protected void btnImgSave_Click(object sender, EventArgs e)
        {
            String newImg = txtImg.Text;
            db.modify("index_pic", newImg, "index_pic", infoArr[0][1]);
            Response.Redirect("Index.aspx");
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