using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;
using System.IO;

namespace Shopping_Mall.View.ProductInfo
{
    public partial class ProductInformation : System.Web.UI.Page
    {
        private DBFunction db = new DBFunction("product");
        private DBFunction dbType = new DBFunction("type");
        private DBFunction dbIndexInfo = new DBFunction("indexInfo");
        private String visible;
        public String editType = "";
        public String imageStr;
        public String priceStr;
        public String deleteNeditStr;
        private Discount dis = new Discount();
        private String finalPrice;
        private String proID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            visible = dbIndexInfo.searchAll()[0][8];
            alertLogin.Visible = false;
            btnInvisible.Visible = false;

            if (Request.QueryString["product"] != null) proID = Request.QueryString["product"];
            if (Session["account"] == null || Session["account"].Equals("admin"))
            {                
                btnPurchase.Visible = false;
                alertLogin.Visible = true;
            }
            if (Session["account"] != null && Session["account"].Equals("admin"))
            {
                editBtns(proID);
                btnInvisible.Visible = true;
                txtType.Visible = true;
                ImageButton1.Visible = true;
            }
            else deleteNeditStr = "";
            productShow(proID);
            setLeftBar();
        }
        //修改刪除商品
        private void editBtns(String ID)
        {
            deleteNeditStr += "<div class='sectionBoxLeft'><div class='deleteNedit'>";
            deleteNeditStr += "<a href='Product.aspx?del=" + ID + "'><img src=../Picture/delete.png style='width:30px;'></a>";
            deleteNeditStr += "</div><div class='deleteNedit'>";
            deleteNeditStr += "<a href='ProductEditor.aspx?product=" + ID + "'><img src=../Picture/edit.png style='width:30px;'></a></div></div>";
        }
        //讀取產品介紹
        private void productShow(String ID) 
        {
            String[][] proArr;
            if(ID == null || ID.Equals("")){
                proArr = db.searchTop(1);
            }
            else proArr = db.searchByRow("ID", ID);

            productName.Text = proArr[0][1];

            if (visible.Equals("true"))
            {
                btnInvisible.Text = "隱藏";
                //判斷有無優惠方案
                if (proArr[0][7] != null && proArr[0][7] != "0")
                {
                    String[] discountArr = null;
                    discountArr = dis.findingType(Convert.ToInt32(proArr[0][7]), 1, Convert.ToInt32(proArr[0][3]));
                    imageStr = "<div class='dis-box'><div class='dis-title'>Sale</div><div class='dis-text'>" + discountArr[0] + "</div></div>";
                    priceStr = "<div class='content-text'>價格：<del>" + proArr[0][3] + "元</del><span class = 'discount'>" + discountArr[1] + "元</span><br/></div><div class='content-text'>數量：</div>";
                    finalPrice = discountArr[1];
                }
                else
                {
                    priceStr = "<div class='content-text'>價格：" + proArr[0][3] + "元<br/></div><div class='content-text'>數量：</div>";
                    finalPrice = proArr[0][3];
                }

                for (int i = 0; i < int.Parse(proArr[0][4]); i++)
                {
                    numberDropList.Items.Add((i + 1) + "");
                }
                if (int.Parse(proArr[0][4]) == 0) laseNum.Text = "　　目前無庫存";
                else laseNum.Text += proArr[0][4] + " 個";
            }
            else
            {
                btnInvisible.Text = "顯示";
                priceStr = "";
                numberDropList.Visible = false;
                laseNum.Visible = false;
            }

            String imageUrl = HttpRuntime.AppDomainAppPath;
            imageUrl += "UploadPic\\" + proArr[0][0] + ".png";
            if (!File.Exists(imageUrl))
            {
                productImage.ImageUrl = "../Picture/nonePic.png";
            }
            else
            {
                productImage.ImageUrl = "../UploadPic/" + proArr[0][0] + ".png";
            }
            introLabel.Text = proArr[0][6];
        }
        //購買btn
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            DBFunction dbPurchase = new DBFunction("purchaseList");
            //舊有資料更新
            String[][] checkArr = dbPurchase.searchRowByColumn("product_name , num", "account", Session["account"].ToString());
            if (checkArr.Length > 0)
            {
                bool check = false;
                int i;
                for (i = 0; i < checkArr.Length; i++)
                {
                    if (checkArr[i][0].Equals(productName.Text))
                    {
                        check = true;
                        break;
                    }
                }
                if(check)
                    dbPurchase.modify("num", int.Parse(checkArr[i][1]) + int.Parse(numberDropList.SelectedValue), "account", Session["account"].ToString() + "' AND product_name='" + productName.Text);
                else newData(dbPurchase);
            }
            else
            {
                newData(dbPurchase);
            }
            Response.Redirect("Product.aspx");
        }
        //隱藏價格和數量
        protected void btnInvisible_Click(object sender, EventArgs e)
        {
            if (visible.Equals("false"))
                dbIndexInfo.modify("priceVisible", "true", "priceVisible", visible); 
            else
                dbIndexInfo.modify("priceVisible", "false", "priceVisible", visible);
            Response.Redirect("ProductInformation.aspx?product=" + proID);
        }
        //新增購物車資料
        private void newData(DBFunction dbPurchase) 
        {
            String[][] attributes = dbPurchase.searchSchema("name");
            String[] schemaArr = new String[attributes.Length];
            for (int i = 0; i < attributes.Length; i++)
            {
                schemaArr[i] = attributes[i][0];
            }
            String[] values = new String[] { "", Session["account"].ToString(), productName.Text, finalPrice, numberDropList.SelectedValue };
            dbPurchase.insert(schemaArr, values);
        }
        //左方menu
        public String leftbarStr = "";
        private void setLeftBar()
        {
            leftbarStr = "";
            if (Request.QueryString["type"] != null)
            {
                leftbarStr += "<script type='text/javascript'>$(document).ready(function () {$('#ul" + Request.QueryString["type"] + "').show();});</script>";
            }
            String[][] productTypeArr = dbType.searchAll();

            for (int i = 0; i < productTypeArr.Length; i++)
            {
                if (Session["account"] == null || !Session["account"].Equals("admin"))
                {
                    leftbarStr += "<div class='leftbar-type'>"
                        + "<a href='Product.aspx?type="
                        + productTypeArr[i][0] + "'>" 
                        + productTypeArr[i][1] + "</a></div><ul id='ul" + productTypeArr[i][0] + "'>";
                }
                else
                {
                    leftbarStr +=

                    "<div class='leftbar-type'>"
                        + "<a href='Product.aspx?type="
                        + productTypeArr[i][0] + "'>" 
                        + productTypeArr[i][1] + "</a>"
                    //更新大類別鈕
                        + "<div class='left-update'><a href='ProductType.aspx?update=" + productTypeArr[i][0] + "'><img src=../Picture/edit.png style='width:20px;'></a>"
                        + "</div>"
                    //刪除大類別鈕
                    //+"<script>if(confirm('視窗內文字')){alert('你按下確定');}else{alert('你按下取消');}"
                        + "<div class='left-update'><a href='Product.aspx?deleteType=" + productTypeArr[i][0] + "'><img src=../Picture/delete.png style='width:20px;'></a>"
                        + "</div>"
                    //大類別分類進入
                        //+ "<div class='left-update'><a href='Product.aspx?type=" + productTypeArr[i][0] + "'><img src=../Picture/more.png style='width:20px;'></a>"
                        //+ "</div>"
                    + "</div>"
                    // + "</script>"
                    + "<ul id='ul" + productTypeArr[i][0] + "'>";                    
                }
                String[][] productArr = db.searchByRow("type", productTypeArr[i][0]);
                /*if (db.searchByRow("type", productTypeArr[i][0]).Length >= 1)
                {
                    leftbarStr += "<a href='Product.aspx?type=" + productTypeArr[i][0] + "'><li>全部商品</li></a>";
                }*/
                for (int j = 0; j < productArr.Length; j++)
                {
                    leftbarStr += "<a href='ProductInformation.aspx?product=" + productArr[j][0] + "&type=" + productTypeArr[i][0] + "'><li>" + productArr[j][1] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
        }
        //新增類別名稱
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            List<String> list = new List<string>();
            if (txtType.Text == null)
            {
                Response.Write("<Script language='JavaScript'>alert('請輸入類別名稱');</Script>");
            }
            String[][] array = dbType.searchAll();
            for (int type = 0; type < array.Length; type++)
            {
                if (txtType.Text == array[type][1])
                {
                    Response.Write("<Script language='JavaScript'>alert('類別名稱已存在');</Script>");
                    break;
                }
                else if (txtType.Text == null || txtType.Text == "")
                {
                    Response.Write("<Script language='JavaScript'>alert('請輸入資料');</Script>");
                    break;
                }
                else if (type == array.Length - 1)
                {
                    list.Add(txtType.Text);
                    String[] attribute = new String[1];
                    attribute[0] = "name";
                    String str = dbType.insert(attribute, list.ToArray());
                    Response.Write("<Script language='JavaScript'>alert('新增成功!');</script>");
                    setLeftBar();
                }
            }
        }
        //Search
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            String searchLab = txtSearch.Text;
            Response.Redirect("Product.aspx?search=" + searchLab);
        }
    }
}