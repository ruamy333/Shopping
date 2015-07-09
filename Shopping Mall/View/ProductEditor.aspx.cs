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
        private DBFunction db = new DBFunction("product");
        private String[] schemaArr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //判斷帳號
            if (Session["account"] == null || !Session["account"].Equals("admin"))
            {
                Response.Redirect("/Index.aspx");
            }
            else
            {
                String[][] arr = db.searchSchema("name");
                schemaArr = new String[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    schemaArr[i] = arr[i][0];
                }
                if (!IsPostBack)
                {
                    //修改商品資訊，載入商品詳細資料
                    if (Request.QueryString["u"] != null)
                    {
                        setProductInfo(Request.QueryString["u"]);
                    }
                }
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //避免資料空值或負值
            if (txtName.Text.Equals("") || txtNum.Text.Equals("") || txtPrice.Text.Equals(""))
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入資料');</Script>");
            }
            else if (Int16.Parse(txtPrice.Text) < 0 || Int16.Parse(txtNum.Text) < 0)
            {
                Response.Write("<Script language='JavaScript'>alert('數字不可為負值');</Script>");
            }
            else
            {
                if (Request.QueryString["u"] != null)
                {
                    //修改詳細資料
                    modifyProduct(Request.QueryString["u"]);
                }
                else
                {
                    //新增商品資料
                    addProduct();
                }

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
            }
        }

        //由資料庫取得商品資訊並呈現在網頁上
        private void setProductInfo(String productID)
        {
            String[][] productInfo = db.searchByRow("ID", productID);
            txtName.Text = productInfo[0][1];
            dropdownType.SelectedValue = productInfo[0][2];
            txtPrice.Text = productInfo[0][3];
            txtNum.Text = productInfo[0][4];
            txtSummary.Text = productInfo[0][6].Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " ");
            
            if (productInfo[0][7].Equals("0"))
            {
                radiobtnDiscount.SelectedIndex = 0;
            }
            else
            {
                String[][] discountArr = db.innerJoin("discount.type", "discount", "discount.discountID", "product.discountID", "discount.discountID", productInfo[0][7]);
                radiobtnDiscount.SelectedValue = discountArr[0][0];
            }
        }

        //新增商品
        private void addProduct()
        {
            List<String> list = new List<string>();
            list.Add("");
            list.Add(txtName.Text);
            list.Add(dropdownType.SelectedValue);
            list.Add(txtPrice.Text);
            list.Add(txtNum.Text);
            list.Add(fileUpload());
            list.Add(txtSummary.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;"));
            list.Add(getDiscountID());
            String str = db.insert(schemaArr, list.ToArray());
            Response.Write("<script>alert('新增成功!');location.href='/Index.aspx';</script>");
        }

        //修改商品詳細資料
        private void modifyProduct(String productID)
        {
            String[][] productInfo = db.searchByRow("ID", productID);
            String fileName = productInfo[0][5];
            if (!fileUpload().Equals(""))
            {
                fileName = fileUpload();
            }
            String data = schemaArr[1] + "='" + txtName.Text + "', " +
                          schemaArr[2] + "='" + dropdownType.SelectedValue + "', " +
                          schemaArr[3] + "='" + txtPrice.Text + "', " +
                          schemaArr[4] + "='" + txtNum.Text + "', " +
                          schemaArr[5] + "='" + fileName + "', " +
                          schemaArr[6] + "='" + txtSummary.Text + "', " +
                          schemaArr[7] + "='" + getDiscountID();
            db.modifyAll(data,"ID",productID);
            Response.Redirect("Product.aspx");
        }

        //取得檔案路徑
        private String fileUpload()
        {
            if (FileUpload1.HasFile)
            {
                String fileName = FileUpload1.FileName;
                String savePath = Server.MapPath("../UploadPic/");
                String saveResult = savePath + fileName;
                String fileExtension = System.IO.Path.GetExtension(saveResult).ToLower();  //取得上傳的檔案類型
                if (fileExtension == ".gif" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg")
                {
                    FileUpload1.SaveAs(saveResult);
                    return fileName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        //新增優惠至資料庫並取得該筆資料ID
        private String getDiscountID()
        {
            if (radiobtnDiscount.SelectedIndex == 0)
            {
                return "0";
            }
            else
            {
                DBFunction dbDiscount = new DBFunction("discount");
                return dbDiscount.insertAndSearchID(radiobtnDiscount.SelectedValue, txtDiscountType.Text + "," + txtDiscountContent.Text);
            }
        }
    }
}