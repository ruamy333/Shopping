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
        public DBFunction db = new DBFunction("product");
        public Discount dis = new Discount();
        protected void Page_Load(object sender, EventArgs e)
        {         
            //0708每次load都先判斷是否有回傳值，第一次開網頁並沒有回傳
            delete();
            PutIntoCart();
            setLeftBar();
            pageShow(6);
        }

        private void setLeftBar()
        {
            String[][] arrType = db.searchGroupBy("type");
            for (int i = 0; i < arrType.Length; i++)
            {
                leftbarStr += "<div class='leftbar-type'>" + arrType[i][0] + "</div><ul>";
                String[][] productArr = db.searchByRow("type", arrType[i][0]);
                for (int j = 0; j < productArr.Length; j++)
                {
                    leftbarStr += "<a href='ProductInformation.aspx?p=" + productArr[j][0] + "'><li>" + productArr[j][1] + "</li></a>";
                }
                leftbarStr += "</ul>";
            }
        }
        //刪除
        private void delete()
        {
            String del = Request.QueryString["d"];
            if (del != null)
            {
                db.delete("ID", del);
            }
        }

        //click商品數量加入購物車
        private void PutIntoCart()
        {
            String num = Request.QueryString["num"];
            String ID = Request.QueryString["ID"];
            if (num != null && num != "")
            {
                if ((String)Session["account"] != null)
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
                else
                {
                    Response.Write("<Script language='JavaScript'>alert('請登入');</Script>");
                }
            }
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
        //pp為分頁碼
        private void pageShow(int num)
        {
            String pp = Request.QueryString["pp"];
            Boolean finish = false;
            int index = Convert.ToInt32(pp);
            //第一次進入沒有回傳值，強制為第一頁
            if (pp == null)
            {
                index = 1;
            }
                //首頁click more進來的畫面
                String[][] array;
                if (Request.QueryString["t"] == null || Request.QueryString["t"] == "")
                {
                    array = db.searchByColumnOrder("ID,name,type,price,num,picture,introduction,discountID");
                }
                else
                {
                    array = db.searchByRowOrder("type", Request.QueryString["t"]);
                }
                //0707 新增
                //0708 修改可以回傳ID、購買數量給自己這頁
                for (int a = 0; a <= (num / 2); a++)
                {
                    if (finish == true)
                        break;
                    if (2 * a == num)
                        break;
                    else
                        rightStr += "<div class ='product'>";
                    for (int b = 0; b < 2; b++)
                    {
                        if (finish == true)
                            break;
                        if (2 * a + b < num)
                        {
                            String[] discountArr = null;

                        int i = 2 * a + b + (index - 1) * num;
                        if (i == array.Length - 1)
                        {
                            finish = true;
                            }
                            rightStr += "<div class ='product-inside'>"
                                + "<div class='ImgDel'>";
                        if (array[i][7] != null && array[i][7] != "0")
                            {
                            discountArr = dis.findingType(Convert.ToInt32(array[i][7]), 1, Convert.ToInt32(array[i][3]));
                            rightStr += "<a href='ProductInformation.aspx?p=" + array[i][0] + "'><div class='image' style='background:url(../UploadPic/" + array[i][5] + ") no-repeat; background-size:300px 200px;'><div class='dis-box'><div class='dis-text'>" + discountArr[0] + "</div></div></div></a>";
                            }
                            else rightStr += "<div class='image'><a href='ProductInformation.aspx?p=" + array[i][0] + "'><img src=../UploadPic/" + array[i][5] + "></a></div>";
                        rightStr += "<div class='delete'>";

                            //刪除按鈕visible的判斷
                            if ((String)Session["account"] == "admin")
                            {
                            rightStr += "<a href='Product.aspx?d=" + array[i][0] + "'><img src=../Picture/delete.png style='width:48px;'></a>";
                                rightStr += "</div><div class='delete'>";
                            rightStr += "<a href='ProductEditor.aspx?u=" + array[i][0] + "'><img src=../Picture/edit.png style='width:45px;'></a></div>";
                            }
                            else
                            {
                                rightStr += "</div>";
                            }
                            rightStr += "</div>"
                            + "<div class='name'><a href='ProductInformation.aspx?p=" + array[i][0] + "'>" + array[i][1] + "</a></div>";
                            if (array[i][7] != null && array[i][7] != "0")
                            {
                                //策略顯示
                            rightStr += "<div class='information'>價格："
                                    + "<del>" + array[i][3] + "元</del>　"
                                    + "<span class = 'discount'>" + discountArr[1] + "元</span>　　"
                                    + "數量：" + array[i][4] + "</div>";
                            }
                            else
                            {
                            rightStr += "<div class='information'>價格：" + array[i][3] + "元　　　"
                                    + "數量：" + array[i][4] + "</div>";

                            //欄位ID,name,type,price,num,picture,discountID
                        rightStr += "<form action='Product.aspx' method='get' onsubmit='return validate_form(this)'>"
                                + "<div class='information'>購買數量："
                                    + "<input type='number' class='form-control' name='num' min='1' max='" + array[i][4] + "' style=width:50px runat'server'>"
                                    + "<input type='hidden' name='ID' value='" + array[i][0] + "' runat'server'></div>"
                                    + "<input class='button-style' type='submit' value='加入購物車'>"
                                    + "</form>"
                                    + "</div>";
                        }
                    }
                    rightStr += "</div>";
                }

                for (int page = 0; page <= (array.Length / num); page++)
                {
                    //若資料少於num筆數的頁碼呈現
                    //以及資料筆數等於總資料長度停止
                    if (num * page != array.Length)
                    {
                        if (index != page + 1)
                        {
                            pageStr += "<a href='Product.aspx?pp=" + (page + 1) + "&t=" + Request.QueryString["t"] + "'>" + (page + 1) + "</a>　";
                        }

                        else
                        {
                            pageStr += "<span class='here'>" + index + "</span>　";
                        }

                    }
                    }

                }
        }
    }
}