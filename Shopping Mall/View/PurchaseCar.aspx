<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseCar.aspx.cs" Inherits="Shopping_Mall.View.PurchaseCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Css/PurchaseCarStyle.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../Css/Common.css" media="screen" />
    <script src="../js/jquery.hoverpulse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-top">
            <h2><asp:Label ID="titleLabel" CssClass="content-header" runat="server" Text="購物車"></asp:Label></h2>
        </div>
        <div class="content-center">
            <div class="center-column">
                <div class="column-box">
                    <asp:Label ID="img" CssClass="content-text" runat="server" Text="商品圖示"></asp:Label>
                </div>
                <div class="column-name">
                    <asp:Label ID="name" CssClass="content-text" runat="server" Text="商品名稱"></asp:Label>
                </div>
                <div class="column-box">
                    <asp:Label ID="price" CssClass="content-text" runat="server" Text="商品價格"></asp:Label>
                </div>
                <div class="column-box">
                    <asp:Label ID="num" CssClass="content-text" runat="server" Text="數量"></asp:Label>
                </div>
                <div class="column-box">
                    <asp:Label ID="total" CssClass="content-text" runat="server" Text="小計"></asp:Label>
                </div>
                <div class="column-box">
                    <asp:Label ID="discount" CssClass="content-text" runat="server" Text="優惠"></asp:Label>
                </div>
            </div>
            <%=shoppingList %>
        </div>
        <div class="content-bottom">
            <div class="bottom-right">
                <asp:Button ID="btnPurchase" CssClass="button-style" runat="server" Text="確定購買" OnClick="btnSubmit_Click"/>
            </div>
            <div class="bottom-left">
                <asp:Label ID="totalPrice" CssClass="content-text" runat="server" Text="總金額："></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
