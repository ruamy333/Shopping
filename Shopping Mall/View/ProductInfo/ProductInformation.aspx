<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInformation.aspx.cs" Inherits="Shopping_Mall.View.ProductInfo.ProductInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css"
        href="Css/prodInfoStyle.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">

        <div class="contentLeft">
            <div class="sidebarContent">
                商品1<br>
                商品2<br>
                商品3<br>
            </div>
        </div>
        <div class="contentRight">
            <div class="sectionContent">
                <h2><asp:Label ID="productName" runat="server" ></asp:Label></h2>
                <div class="sectionBoxLeft">
                    <div class="image"><asp:Image ID="productImage" runat="server" /></div>
                </div>
                <div class="sectionBoxRight">
                    <p>
                        價格：<asp:Label ID="priceLabel" runat="server" ></asp:Label>
                        元 <br>
                        數量：<asp:DropDownList ID="numberDropList" runat="server"></asp:DropDownList>
                    </p>
                </div>
                
                <div class="sectionBoxBottom">
                    <p>
                        內容內容內容...
                    </p>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
