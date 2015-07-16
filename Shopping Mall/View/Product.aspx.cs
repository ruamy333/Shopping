using Shopping_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping_Mall.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String leftbarStr = "";
        public String rightStr = "";
        public String pageStr = "";
        public String buycarStr = "";
        public String editType = "";
        private DBFunction db = new DBFunction("product");
        private DBFunction dbType = new DBFunction("type");
        private Discount dis = new Discount();
        protected void Page_Load(object sender, EventArgs e)
        {
            setLeftBar();
            //0708每次load都先判斷是否有回傳值，第一次開網頁並沒有回傳
            if (Session["account"] == null || !Session["account"].Equals("admin"))
            {
                buycarStr += "<div id='buycar'><a href='PurchaseCar.aspx'><img src='../Picture/buycar.png' /></a></div>";
            }
            else
            {
                txtType.Visible = true;
                ImageButton1.Visible = true;
            }
            String del = Request.QueryString["del"];
            if (del != null)
            {
                delete(del);          
            }

            String num = Request.QueryString["num"];
            String ID = Request.QueryString["ID"];
            if (num != null && num != "")
            {
                if ((String)Session["account"] != null)
                {
                    PutIntoCart(num,ID);
                }
                else
                {
                    Response.Write("<Script language='JavaScript'>alert('請登入');</Script>");
                }
            }
            else if(ID != null && (num == null || num=="")){
                Response.Write("<Script language='JavaScript'>alert('請輸入數量');</Script>");
            }

                    
            pageShow(6);
        }

        private void setLeftBar()
        {
            leftbarStr = "";
            String[][] productTypeArr = dbType.searchAll();

            for (int i = 0; i < productTypeArr.Length; i++)
            {
                if (Session["account"] == null || !Session["account"].Equals("admin"))
                {
                    leftbarStr += "<div class='leftbar-type'>" + productTypeArr[i][1] + "</div><ul>";
                }
                else
                {
                    leftbarStr += "<div class='leftbar-type'>" + productTypeArr[i][1] + "<div class='left-update'><a href='ProductType.aspx?update=" + productTypeArr[i][0] + "'><img src=../Picture/edit.png style='width:10px;'></a></div>"+"</div>"
                       + ""
                       + "<ul>";
                }
                String[][] productArr = db.searchByRow("type", productTypeArr[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    leftbarStr += "<a href='ProductInformation.aspx?product=" + productArr[j][0] + "'><li>" + productArr[j][1] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
        
        }
        //刪除
        private void delete(String del)
        {
             db.delete("ID", del);
             Response.Redirect("Product.aspx");
        }

        //click商品數量加入購物車
        private void PutIntoCart(String num,String ID)
        {   
            DBFunction dbPurchase = new DBFunction("purchaseList");
            String[][] info = db.searchRowByColumn("name, price", "ID", ID);
            //舊有資料更新
            String[][] checkArr = dbPurchase.searchRowByColumn("product_name , num", "account", Session["account"].ToString());
            if (checkArr.Length > 0)
            {
                bool check = false;
                int i;
                for (i = 0; i < checkArr.Length; i++)
                {
                    if (checkArr[i][0].Equals(info[0][0]))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                    dbPurchase.modify("num", int.Parse(checkArr[i][1]) + int.Parse(num), "account", Session["account"].ToString() + "' AND product_name='" + info[0][0]);
                else newData(dbPurchase, info[0][0], num, (int.Parse(num) * int.Parse(info[0][1])).ToString());
            }
            else
            {
                newData(dbPurchase, info[0][0], num, (int.Parse(num) * int.Parse(info[0][1])).ToString());
            }
            Response.Redirect("Product.aspx");
        }
        //新增購物車資料
        private void newData(DBFunction dbPurchase, String name, String num, String price)
        {
            String[][] attributes = dbPurchase.searchSchema("name");
            String[] schemaArr = new String[attributes.Length];
            for (int i = 0; i < attributes.Length; i++)
            {
                schemaArr[i] = attributes[i][0];
            }
            String[] values = new String[] { "", Session["account"].ToString(), name, price, num };
            dbPurchase.insert(schemaArr, values);
        }
        
        //num is the amount of items at each page
        //p為分頁碼
        private void pageShow(int num)
        {
            String p = Request.QueryString["page"];
            int page = Convert.ToInt32(p);
            //第一次進入沒有回傳值，強制為第一頁
            if (p == null)
            {
                page = 1;
            }
            //首頁click more進來的畫面
            String[][] array;
            if (Request.QueryString["type"] == null || Request.QueryString["type"] == "")
            {
                array = db.searchByColumnOrder("ID,name,type,price,num,picture,introduction,discountID");
            }
            else
            {
                array = db.searchByRowOrder("type", Request.QueryString["type"]);
            }
            int count=-1;
            //index為每頁第一筆資料在array中的位置
            int index = (page - 1) * num;
            for (int a = index; a < index+num; a++)
            {
                
                count++;
#region 欄位product
                if(count%2==0){
                    rightStr += "<div class ='product'>";
                }
                String[] discountArr = null;

#region 欄位product-inside
                rightStr += "<div class ='product-inside'>";
#region 欄位ImgDel
                rightStr += "<div class='ImgDel'>";

                String imageUrl;
                if (array[a][5] == null || array[a][5].Equals(""))
                {
                    imageUrl = "../Picture/nonePic.png";
                }
                else imageUrl = "../UploadPic/" + array[a][5];

                //判斷有無優惠方案
                if (array[a][7] != null && array[a][7] != "0")
                {
                    discountArr = dis.findingType(Convert.ToInt32(array[a][7]), 1, Convert.ToInt32(array[a][3]));
                    rightStr += "<a href='ProductInformation.aspx?product=" + array[a][0] + "'>"
                        + "<div id='" + array[a][0] + "' class='image' style='background:url(" + imageUrl + ") no-repeat; background-size:300px 200px;'>"
                        + "<div class='dis-box'><div class='dis-title'>Sale</div><div class='dis-text'>" + discountArr[0] + "</div>"
                        + "</div>"
                        + "</div></a>";
                }
                else rightStr += "<a href='ProductInformation.aspx?product=" + array[a][0] + "'><div class='image' id='" + array[a][0] + "' style='background:url(" + imageUrl + ") no-repeat; background-size:300px 200px;'></div></a>";

                //刪除按鈕visible的判斷
                if ((String)Session["account"] == "admin")
                {
                    rightStr += "<div class='delete'>";
                    rightStr += "<a href='Product.aspx?del=" + array[a][0] + "'><img src=../Picture/delete.png style='width:30px;'></a>";
                    rightStr += "</div><div class='delete'>";
                    rightStr += "<a href='ProductEditor.aspx?u=" + array[a][0] + "'><img src=../Picture/edit.png style='width:30px;'></a></div>";
                }

                rightStr += "</div>"
                    + "<div class='name'><a href='ProductInformation.aspx?product=" + array[a][0] + "'>" + array[a][1] + "</a></div>";
#endregion
#region 欄位information
                if (array[a][7] != null && array[a][7] != "0")
                {
                    //策略顯示
                    rightStr += "<div class='information'>價格："
                        + "<del>" + array[a][3] + "元</del>　"
                        + "<span class = 'discount'>" + discountArr[1] + "元</span>　　"
                        + "數量：" + array[a][4] + "</div>";
                }
                else
                {
                    rightStr += "<div class='information'>價格：" + array[a][3] + "元　　　"
                        + "數量：" + array[a][4] + "</div>";
                }
#endregion information
#region 欄位information
                //欄位ID,name,type,price,num,picture,discountID
                //1個ASP.NET擁有多個form
                if ((String)Session["account"] != "admin")
                {
                    rightStr += "</form><form runat'server' action='Product.aspx' method='get' onsubmit='return validate_form(this)'>"
                            + "<div class='information'>購買數量："
                            + "<input type='number' id='txt" + array[a][0] + "' class='form-control' name='num' min='0' max='" + array[a][4] + "' style=width:50px runat'server'>"
                            + "<input type='hidden' name='ID' value='" + array[a][0] + "' runat'server'></div>";
#endregion
                    rightStr += "<input class='button-style' type='submit' value='加入購物車'>"
                            + "</form>";
                            
                }
                rightStr += "</div>";
#endregion

                //是否最後一筆資料、是否每頁顯示上限
                if (a == array.Length - 1 || a == ((page - 1) * num+ num-1))
                {
                    rightStr += "</div>";
                    break;
                }
                //每兩筆一個product的div
                else if (count % 2 == 1)
                {
                    rightStr += "</div>";
                }
#endregion 
            }
            #region 欄位page       
            for (int i = 0; i <= (array.Length / num); i++)
            {
                //若資料少於num筆數的頁碼呈現
                //以及資料筆數等於總資料長度停止
                if (num * i != array.Length)
                {
                    if (page != i + 1)
                    {
                        pageStr += "<a href='Product.aspx?page=" + (i + 1) + "&type=" + Request.QueryString["type"] + "'>" + (i + 1) + "</a>　";
                    }

                    else
                    {
                        pageStr += "<span class='here'>" + page + "</span>　";
                    }
                }
            }
            #endregion
        }


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

    }
}