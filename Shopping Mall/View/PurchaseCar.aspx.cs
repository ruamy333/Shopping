using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;

namespace Shopping_Mall.View
{
    public partial class PurchaseCar : System.Web.UI.Page
    {
        public String shoppingList = "";
        private DBFunction db = new DBFunction("purchaseList");
        private String[][] arrOrder;
        private Discount disc = new Discount();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account"] == null || Session["account"].Equals("admin"))
            {
                Response.Redirect("/Index.aspx");
            }
            showList();
            String ID = Request.QueryString["d"];
         
            if (ID !=null)
            {
                db.delete("ID", ID);
                Response.Redirect("PurchaseCar.aspx");
            }
            
        }
        //送出btn
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DBFunction dbOrder = new DBFunction("orderList");
            DBFunction dbProduct = new DBFunction("product");
            String[][] attributes = dbOrder.searchSchema("name");
            String[] schemaArr = new String[attributes.Length];
            for (int i = 0; i < attributes.Length; i++)
            {
                schemaArr[i] = attributes[i][0];
            }
            for (int i = 0; i < arrOrder.Length; i++ )
            {
                int subtotal = 0;
                if (arrOrder[i][7] == null)
                {
                    subtotal = Convert.ToInt32(arrOrder[i][3]) * Convert.ToInt32(arrOrder[i][5]);
                }
                else
                {
                    String[] discountArr = disc.findingType(int.Parse(arrOrder[i][7]), int.Parse(arrOrder[i][5]), int.Parse(arrOrder[i][3]));
                    subtotal = int.Parse(discountArr[1]);
                }
                String[] values = new String[] { "", Session["account"].ToString(), arrOrder[i][2], arrOrder[i][4], subtotal.ToString() };
                dbOrder.insert(schemaArr, values);

                dbProduct.modify("num", int.Parse(arrOrder[i][4]) - int.Parse(arrOrder[i][5]), "name", arrOrder[i][2]);
            }

            Response.Write("<Script language='JavaScript'>alert('購買成功!');location.href='/Index.aspx';</Script>");
        }
        //列出購買清單      
        private void showList()
        {
            
            arrOrder = db.innerJoin("product.ID, purchaseList.ID, product.name, product.price, product.num, purchaseList.num, product.picture, product.discountID", "product", "product.name", "purchaseList.product_name", "purchaseList.account", Session["account"].ToString());
            int subtotal = 0;
            int total = 0;
            for (int i = 0; i < arrOrder.Length; i++)
            {
                String dicountStr = "";
                if (arrOrder[i][7].Equals("0") || arrOrder[i][7].Equals(""))
                {
                    subtotal = Convert.ToInt32(arrOrder[i][3]) * Convert.ToInt32(arrOrder[i][5]);
                    total += subtotal;
                }
                else 
                {
                    String[] discountArr = disc.findingType(int.Parse(arrOrder[i][7]), int.Parse(arrOrder[i][5]), int.Parse(arrOrder[i][3]));
                    subtotal = int.Parse(discountArr[1]);
                    total += subtotal;
                    dicountStr = discountArr[0];
                }

                shoppingList +=
                    "<div class='center-column'><div class='column-img'>"
                    + "<a href='ProductInformation.aspx?p=" + arrOrder[i][0] + "'><img src=../UploadPic/" + arrOrder[i][6] + "></a></div>"
                    + "<div class='column-name'><a href='ProductInformation.aspx?p=" + arrOrder[i][0] + "'>" + arrOrder[i][2] + "</a></div>"
                    + "<div class='column-box'><int>" + arrOrder[i][3] + "</int></div>"
                    + "<div class='column-box'><int>" + arrOrder[i][5] + "</int></div>"
                    + "<div class='column-box'><int>" + subtotal + "</int></div>"
                    + "<div class='column-box'><discount>" + dicountStr + "</discount></div>"
                    + "<div class='column-delete'><a href='PurchaseCar.aspx?d=" + arrOrder[i][1] + "' class='button-style'>刪除</a></div></div>";              
            }
            //計算總金額
            totalPrice.Text += total + "元";         
        }
    }
}