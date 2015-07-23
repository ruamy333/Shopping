<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInformation.aspx.cs" Inherits="Shopping_Mall.View.ProductInfo.ProductInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/ProdInfoStyle.css" rel="stylesheet" />
    <link href="../Css/Common.css" rel="stylesheet" />
    <script src="../js/jquery.hoverpulse.js"></script>
    <script src="../js/lefrbar-effect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">
        <div class="leftbar">
            <%=editType %>
            <div class="formBox" style="margin-top:10px;">
                <div class="textbox-position"><asp:TextBox ID="txtSearch"  CssClass="form-control textBox" placeholder="搜尋關鍵字" runat="server"></asp:TextBox></div>
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="../Picture/search.png" style="width:30px;" OnClick="btnSearch_Click" />
            </div>

            <div class="formBox" style="margin-top:10px;">
                <div class="textbox-position"><asp:TextBox ID="txtType"  CssClass="form-control textBox" placeholder="新增類別" runat="server" Visible="False"></asp:TextBox></div>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Picture/add.png" style="width:30px;float:left;" OnClick="btnSubmit_Click" Visible="False" />
            </div>
            <%=leftbarStr %>
        </div>
        <div class="contentRight">
                <div class="sectionBoxTop">
                    <%=deleteNeditStr %>
                    <div class="sectionBoxMiddle">
                        <asp:Image ID="productImage" CssClass="image" runat="server"/>                      
                    </div>
                    <div class="sectionBoxRight">
                        <%=imageStr %>
				        <asp:Label ID="productName" CssClass="content-header" runat="server" ></asp:Label>
                        <br/><br/>
                        <asp:Button ID="btnInvisible" runat="server" CssClass="button-style-headerNfooter" Text="顯示" OnClick="btnInvisible_Click"/>
                        <%=priceStr %>
                        <div class="content-text">
                            <asp:DropDownList ID="numberDropList" runat="server" CssClass="form-control" Width="60"></asp:DropDownList>
                            <asp:Label ID="laseNum" runat="server" Text="　剩餘數量： "></asp:Label>
                        </div>
                        <div class="content-text">
                            <asp:Button ID="btnPurchase" CssClass="button-style" runat="server" Text="放入購物車" OnClick="btnPurchase_Click"/>
                            <asp:Label ID="alertLogin" runat="server" Text="欲購買請洽服務人員"></asp:Label>
                        </div>
                    </div>     
                </div>
                <div class="sectionBoxBottom">
                    <br/> 
                    <asp:Label ID="introLabel" CssClass="content-text" runat="server" ></asp:Label>
                </div>
        </div>
    </div>
</asp:Content>
