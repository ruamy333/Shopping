<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Shopping_Mall.View.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Css/PurchaseCarStyle.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../Css/Common.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="content-top">
            <h2><asp:Label ID="titleLabel" CssClass="content-header" runat="server" Text="訂單"></asp:Label></h2>
        </div>
        <div class="content-center">
            <div class="center-column">
                <div class="column-box">
                    <asp:Label ID="img" CssClass="content-text" runat="server" Text="帳號"></asp:Label>
                </div>
                <div class="column-box">
                    <asp:Label ID="name" CssClass="content-text" runat="server" Text="姓名"></asp:Label>
                </div>
                <div class="column-name">
                    <asp:Label ID="productName" CssClass="content-text" runat="server" Text="商品名稱"></asp:Label>
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
            <%=orderList %>
        </div>
    </div>
</asp:Content>
