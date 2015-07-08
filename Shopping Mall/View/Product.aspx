<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Shopping_Mall.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Common.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/Product.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="content-middle">
    <div class="leftbar">
            <%=leftbarStr %>
    </div>
    <div class="rightbar">

        <%=rightStr %>
    </div>

</div>
</asp:Content>
