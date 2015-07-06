<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shopping_Mall.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="Css/LoginStyle.css" media="screen" />
        <link rel="stylesheet" type="text/css" href="Css/Common.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contentBox">       
        <h2><asp:Label ID="productName" runat="server" >Login</asp:Label></h2>
        <br/>
        <div class="formBox">
            <div class="title">Account：</div>
            <br/>
            <asp:TextBox ID="account" class="form-control textBox" runat="server"></asp:TextBox>
        </div>
        <div class="formBox">
            <div class="title">Password：</div>
            <br/>
            <asp:TextBox ID="pwd" class="form-control textBox" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" class="button-style" runat="server" Text="Submit" OnClick="btnLogin_Click"/>
    </div>

</asp:Content>
