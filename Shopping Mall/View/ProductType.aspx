<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="Shopping_Mall.ProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Common.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/ProductEditor.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">
			<div class="content-header"></div>
        <div class="formBox">
            <div class="title">新增類別：</div>
            <asp:TextBox ID="txtType"  class="form-control textBox " runat="server"></asp:TextBox>
        </div>
        <div class="buttonBox">
            <asp:Button ID="btnSubmit" class="button-style" runat="server" Text="送出" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnCancle" class="button-style" runat="server" Text="取消" OnClick="btnCancle_Click"/>
        </div>
    </div>
</asp:Content>
