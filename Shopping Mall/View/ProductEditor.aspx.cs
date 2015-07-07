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
        public String[] discountStr = {"",""};
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtNum.Text.Equals("") || txtPrice.Text.Equals(""))
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入資料');</Script>");
            }
            else
            {
                DBFunction db = new DBFunction("product");
                String[][] arr2 = db.searchSchema("name");
                String[] schemaArr = new String[arr2.Length];
                for(int i=0; i<arr2.Length; i++)
                {
                    schemaArr[i] = arr2[i][0];
                }
                List<String> list = new List<string>();
                list.Add("");
                list.Add(txtName.Text);
                list.Add(dropdownType.SelectedValue);
                list.Add(txtPrice.Text);
                list.Add(txtNum.Text);
                if (FileUpload1.HasFile)
                {
                    String fileName = FileUpload1.FileName;
                    String savePath = Server.MapPath("../UploadPic/");
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
                if (radiobtnDiscount.SelectedIndex == 0)
                {
                    list.Add("");
                }
                else
                {
                    DBFunction dbDiscount = new DBFunction("discount");
                    list.Add(dbDiscount.insertAndSearchID(radiobtnDiscount.SelectedValue, txtDiscountType.Text + "," + txtDiscountContent.Text));
                }
                String str = db.insert(schemaArr, list.ToArray());
                Response.Write("<script>alert('新增成功!');location.href='/Index.aspx';</script>");
            }
        }
        protected void radiobtnDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiscountType.Visible = false;
            txtDiscountContent.Visible = false;
            discountStr[0] = "";
            discountStr[1] = "";
            switch (radiobtnDiscount.SelectedIndex)
            {
                case 1:
                    txtDiscountType.Visible = true;
                    discountStr[1] = "% off";
                break;
                case 2:
                    txtDiscountType.Visible = true;
                    txtDiscountContent.Visible = true;
                    discountStr[0] = "買";
                    discountStr[1] = "送";
                break;
                case 3:
                    txtDiscountType.Visible = true;
                    txtDiscountContent.Visible = true;
                    discountStr[0] = "滿";
                    discountStr[1] = "送";
                break;
            }
        }
    }
}