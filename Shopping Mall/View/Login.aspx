<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shopping_Mall.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Common.css" rel="stylesheet" />
    <link href="Css/LoginStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contentBox">       
        <h2><asp:Label ID="Labtitle" runat="server" >Login</asp:Label></h2>
        <br/>
        <div class="formBox">
            <div class="title">Account：</div>
            <asp:TextBox ID="account" CssClass="form-control textBox" runat="server"></asp:TextBox>
        </div>
        <div class="formBox">
            <div class="title">Password：</div>
            <asp:TextBox ID="password" CssClass="form-control textBox" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" CssClass="button-style" runat="server" Text="Submit" OnClick="btnLogin_Click"/>
    </div>

</asp:Content>
