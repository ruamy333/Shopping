using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall
{
    public partial class ProductManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtNum.Text.Equals("") || txtPrice.Text.Equals(""))
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入資料');</Script>");
            }
            else
            {
                DBFunction db = new DBFunction();
                String[] arr2 = db.searchSchema("name");
                List<String> list = new List<string>();
                list.Add("");
                list.Add(txtName.Text);
                list.Add(dropdownType.SelectedValue);
                list.Add(txtPrice.Text);
                list.Add(txtNum.Text);
                if (FileUpload1.HasFile)
                {
                    String fileName = FileUpload1.FileName;
                    String savePath = Server.MapPath("../../UploadPic/");
                    String saveResult = savePath + fileName;
                    String fileExtension = System.IO.Path.GetExtension(saveResult).ToLower();  //取得上傳的檔案類型
                    if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                    {
                        FileUpload1.SaveAs(saveResult);
                        list.Add(fileName);
                    }
                    else
                    {
                        list.Add("");
                    }
                }
                else
                {
                    list.Add("");
                }
                list.Add(txtSummary.Text);
                String str = db.insert(arr2, list.ToArray());
                Response.Write("<script>alert('新增成功!');location.href='../../Index.aspx';</script>");
            }
        }
    }
}