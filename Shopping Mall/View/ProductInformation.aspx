<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInformation.aspx.cs" Inherits="Shopping_Mall.View.ProductInfo.ProductInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css"
        href="Css/prodInfoStyle.css" media="screen" />
    <link rel="stylesheet" type="text/css"
        href="../Css/Common.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">

        <div class="contentLeft">
            <div class="sidebarContent">
                <asp:HyperLink ID="linkProduct" class="content-text" runat="server" OnClick="linkProduct_Click">linkProduct</asp:HyperLink>
                Product1<br/>
                商品2<br/>
                商品3<br/>
            </div>
        </div>
        <div class="contentRight">
            <div class="sectionContent">
                <div class="sectionBoxTop">
                    <div class="sectionBoxLeft">
                        <div class="image"><asp:Image ID="productImage" runat="server" /></div>
                    </div>
                    <div class="sectionBoxRight">
				        <h2><asp:Label ID="productName" class="content-header" runat="server" ></asp:Label></h2>
                        <br/>             
                        <div class="content-text">價格：
                            <asp:Label ID="priceLabel" runat="server" ></asp:Label>元 <br/>
                        </div>
                        <div class="content-text">數量：
                            <asp:DropDownList ID="numberDropList" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnPurchase" class="button-style" runat="server" Text="購買" OnClick="btnPurchase_Click"/>
                        </div>
                    </div>     
                </div>
                <div class="sectionBoxBottom">
                    <asp:Label ID="introLabel" class="content-text" runat="server" ></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
