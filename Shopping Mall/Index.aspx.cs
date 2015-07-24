using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.IO;
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
        private DBFunction dbIndex = new DBFunction("indexInfo");
        private String[][] infoArr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Request.ApplicationPath;
            if (Path != "/")
                Path += "/";

            //找圖
            infoArr = dbIndex.searchAll();
            indexImage.ImageUrl = infoArr[0][1];
            indexPicUpload.Visible = false;
            btnImgSave.Visible = false;

            //判斷管理者
            if (Session["account"] != null && Session["account"].ToString().Equals("admin"))
                editImgStr = "<a href='" + Path + "Index.aspx?edit=image'><img src=Picture/edit.png style='width:30px;'></a>";

            //修改圖
            if (Request.QueryString["edit"] != null && Request.QueryString["edit"].ToString().Equals("image"))
            {
                if (!IsPostBack)
                {
                    btnImgSave.Visible = true;
                    indexPicUpload.Visible = true;
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
            String newImg = fileUpload();
            dbIndex.modify("index_pic", newImg, "index_pic", infoArr[0][1]);
            Response.Redirect("Index.aspx");
        }

        private void setColumn()
        {
            String[][] productTypeArr = dbType.searchAll();
            for (int i = 0; i < productTypeArr.Length; i++)
            {
                String typeID = productTypeArr[i][0];
                String type = productTypeArr[i][1];
                String[][] productArr = db.searchByRow("type", typeID);
                if(productArr.Length != 0)
                {
                    columnStr += "<li><div class='columnbox'><a href='View/Product.aspx?type=" + typeID + "' class='image image-full'>";

                    String imgUrl = HttpRuntime.AppDomainAppPath;
                    imgUrl += "UploadPic\\" + productArr[0][0] + ".png";
                    if (!File.Exists(imgUrl))
                    {
                        imgUrl = "Picture/nonePic.png";
                    }
                    else
                    {
                        imgUrl = "UploadPic/" + productArr[0][0] + ".png";
                    }

                    columnStr += "<img src='" + imgUrl + "'/></a>"
                               + "<h2>" + type + "</h2><p>";
                    int productNum = productArr.Length;
                    if (productNum > 3)
                    {
                        productNum = 3;
                    }
                    for (int j = 0; j < productNum; j++)
                    {
                        if (j == productNum - 1)
                        {
                            columnStr += "● " + productArr[j][1] + "...<br/>";
                        }
                        else
                        {
                            columnStr += "● " + productArr[j][1] + "<br/>";
                        }
                    }
                    columnStr += "</p><a href='View/Product.aspx?type=" + typeID + "' class='button-style'>More</a></div></li>";
                }
            }
        }

        //取得檔案路徑
        private String fileUpload()
        {
            if (indexPicUpload.HasFile)
            {
                String fileName = indexPicUpload.FileName;
                String savePath = Server.MapPath("Picture/");
                String saveResult = savePath + fileName;
                String fileExtension = System.IO.Path.GetExtension(saveResult).ToLower();  //取得上傳的檔案類型
                if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                {
                    indexPicUpload.SaveAs(saveResult);
                    return "Picture/" + fileName;
                }
                else return "";
            }
            else return "";
        }
    }
}