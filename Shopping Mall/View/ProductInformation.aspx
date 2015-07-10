<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInformation.aspx.cs" Inherits="Shopping_Mall.View.ProductInfo.ProductInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/ProdInfoStyle.css" rel="stylesheet" />
    <link href="../Css/Common.css" rel="stylesheet" />
    <script src="../js/jquery.hoverpulse.js"></script>
    <script src="../js/lefrbar-effect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">
        <div class="leftbar" id="aa">
                <%=leftbarStr %>
        </div>
        <div class="contentRight">
                <div class="sectionBoxTop">
                    <div class="sectionBoxLeft">
                        <asp:Image ID="productImage" CssClass="image" runat="server" />
                    </div>
                    <div class="sectionBoxRight">
				        <asp:Label ID="productName" CssClass="content-header" runat="server" ></asp:Label>
                        <br/>             
                        <div class="content-text">價格：
                            <asp:Label ID="priceLabel" runat="server" ></asp:Label>元 <br/>
                        </div>
                        <div class="content-text">數量：
                            <asp:DropDownList ID="numberDropList" runat="server" CssClass="form-control" Width="60"></asp:DropDownList>
                            <asp:Label ID="laseNum" runat="server" Text="　剩餘數量： "></asp:Label>
                        </div>
                        <div class="content-text">
                            <asp:Button ID="btnPurchase" CssClass="button-style" runat="server" Text="放入購物車" OnClick="btnPurchase_Click"/>
                            <asp:Label ID="alertLogin" runat="server" Text="欲購買請先登入"></asp:Label>
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
