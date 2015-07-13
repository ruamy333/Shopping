<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Shopping_Mall.View.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Css/OrderStyle.css" media="screen" />
    <script src="../js/lefrbar-effect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-top">
            <h2><asp:Label ID="titleLabel" CssClass="content-header" runat="server" Text="訂單"></asp:Label></h2>
        </div>
        <div class="content-center">
            <div class="center-column">
                <div class="column-boxS">
                    <asp:Label ID="account" CssClass="content-text" runat="server" Text="訂單編號"></asp:Label>
                </div>
                <div class="column-boxS">
                    <asp:Label ID="name" CssClass="content-text" runat="server" Text="姓名"></asp:Label>
                </div>
                <div class="column-boxL">
                    <asp:Label ID="productNnum" CssClass="content-text" runat="server" Text="商品及數量"></asp:Label>
                </div>
                <div class="column-boxS">
                    <asp:Label ID="total" CssClass="content-text" runat="server" Text="總金額"></asp:Label>
                </div>
                <div class="column-boxM">
                    <asp:Label ID="payment" CssClass="content-text" runat="server" Text="繳費"></asp:Label>
                </div>
                <div class="column-boxM">
                    <asp:Label ID="shipment" CssClass="content-text" runat="server" Text="出貨"></asp:Label>
                </div>
            </div>
            <%=orderList %>
        </div>
    </div>
</asp:Content>
