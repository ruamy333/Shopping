using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping_Mall.Database;
using System.Text.RegularExpressions; 

namespace Shopping_Mall
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public String linkStr;
        public String editHeaderStr;
        public String editAboutStr;
        public String editContactStr;
        public String editMissionStr;
        public String Path;
        
        private DBFunction db = new DBFunction("indexInfo");
        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Request.ApplicationPath;
            if (Path != "/")
                Path += "/";

            setIndexInfo();

            //未登入
            if (Session["account"] == null)
            {
                linkStr = "<li id='login'><a href='" + Path + "View/Login.aspx'>Login</a></li>";
            }
            //管理員登入
            else if (Session["account"].ToString().Equals("admin"))
            {
                //修改連結                
                editHeaderStr = "<a href='" + Path + "Index.aspx?edit=header'><img src=" + Path + "Picture/edit.png style='width:30px;'></a>";
                editMissionStr = "<a href='" + Path + "Index.aspx?edit=mission'><img src=" + Path + "Picture/edit.png style='width:30px;'></a>";
                editAboutStr = "<a href='" + Path + "Index.aspx?edit=about'><img src=" + Path + "Picture/edit.png style='width:30px;'></a>";
                editContactStr = "<a href='" + Path + "Index.aspx?edit=contact'><img src=" + Path + "Picture/edit.png style='width:30px;'></a>";

                linkStr = "<li id='producteditor'><a href='" + Path + "View/ProductEditor.aspx'>Add Product</a></li>"
                        + "<li id='order'><a href='" + Path + "View/Orders.aspx'>Order</a></li>"
                        + "<li id='logout'><a href='" + Path + "Index.aspx?l=0'>Logout</a></li>";
            }
            //使用者登入
            else
            {
                linkStr = "<li id='purchasecar'><a href='" + Path + "View/PurchaseCar.aspx'>Shopping car</a></li>"
                    + "<li id='order'><a href='" + Path + "View/Orders.aspx'>Order</a></li>"    
                    + "<li id='logout'><a href='" + Path + "Index.aspx?l=0'>Logout</a></li>";
            }
            setMenuLink();

            //修改
            if (Request.QueryString["edit"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["edit"].ToString().Equals("header"))
                    {
                        headerLab.Visible = false;
                        headerTxt.Visible = true;
                        btnHeaderSave.Visible = true;
                        headerTxt.Text = headerLab.Text;
                        editHeaderStr = "";
                    }
                    else if (Request.QueryString["edit"].ToString().Equals("mission")) 
                    {
                        missionLab.Visible = false;
                        txtMission.Visible = true;
                        btnMissionSave.Visible = true;
                        txtMission.Text = missionLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;
                        editMissionStr = "";
                    }
                    else if (Request.QueryString["edit"].ToString().Equals("about")) 
                    {
                        aboutLab.Visible = false;
                        txtAbout.Visible = true;
                        btnAboutSave.Visible = true;
                        txtAbout.Text = aboutLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;
                        editAboutStr = "";
                    }
                    else if (Request.QueryString["edit"].ToString().Equals("contact"))
                    {
                        addLab.Visible = false;
                        mailLab.Visible = false;
                        phoneLab.Visible = false;
                        faxLab.Visible = false;

                        txtAddress.Visible = true;
                        txtMail.Visible = true;
                        txtPhone.Visible = true;
                        txtFax.Visible = true;

                        btnContactSave.Visible = true;

                        txtAddress.Text = addLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;
                        txtMail.Text = mailLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;
                        txtPhone.Text = phoneLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;
                        txtFax.Text = faxLab.Text.Replace("<br/>", System.Environment.NewLine).Replace("&nbsp;", " "); ;

                        editContactStr = "";
                    }
                }
            }
        }

        //Header修改儲存按鈕
        protected void btnHeaderSave_Click(object sender, EventArgs e)
        {
            String newHeader = headerTxt.Text;
            if (newHeader.Equals("")) Response.Write("<Script language='JavaScript'>alert('請輸入內容');</Script>");
            else
            {
                db.modify("header", newHeader, "header", headerLab.Text);
                Response.Redirect("Index.aspx");
            }
        }
        //Mission修改儲存按鈕
        protected void btnMissionSave_Click(object sender, EventArgs e)
        {
            String newMission = txtMission.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            db.modify("leftfooter", newMission, "header", headerLab.Text);
            Response.Redirect("Index.aspx");
        }
        //About修改儲存按鈕
        protected void btnAboutSave_Click(object sender, EventArgs e)
        {
            String newAbout = txtAbout.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            db.modify("introduction", newAbout, "header", headerLab.Text);
            Response.Redirect("Index.aspx");
        }
        //Contact修改儲存按鈕
        protected void btnContactSave_Click(object sender, EventArgs e)
        {
            String newAddress = txtAddress.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            String newMail = txtMail.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            String newPhone = txtPhone.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            String newFax = txtFax.Text.Replace(System.Environment.NewLine, "<br/>").Replace(" ", "&nbsp;");
            db.modify("address", newAddress, "header", headerLab.Text);
            db.modify("mail", newMail, "header", headerLab.Text);
            db.modify("phone", newPhone, "header", headerLab.Text);
            db.modify("fax", newFax, "header", headerLab.Text);
            Response.Redirect("Index.aspx");
        }

        private void setIndexInfo()
        {
            String[][] infoArr = db.searchAll();

            headerLab.Text = infoArr[0][0];
            aboutLab.Text = infoArr[0][2];
            addLab.Text = infoArr[0][3];
            mailLab.Text = infoArr[0][4];
            phoneLab.Text = infoArr[0][5];
            faxLab.Text = infoArr[0][6];
            missionLab.Text = infoArr[0][7];

            //修改隱藏
            headerTxt.Visible = false;
            btnHeaderSave.Visible = false;
            txtMission.Visible = false;
            btnMissionSave.Visible = false;
            txtAbout.Visible = false;
            btnAboutSave.Visible = false;
            txtAddress.Visible = false;
            txtMail.Visible = false;
            txtPhone.Visible = false;
            txtFax.Visible = false;
            btnContactSave.Visible = false;
        }

        //Menu按鈕被點擊的狀態
        private void setMenuLink()
        {
            String[] arr = ContentPlaceHolder1.Page.ToString().Split('_', '.');
            String id = arr[arr.Length - 2];
            if (id.Equals("productinformation"))
                id = "product";
            linkStr += "<script type='text/javascript'>$(document).ready(function () { $('#" + id + "').addClass('active'); });</script>";
        }
    }
}