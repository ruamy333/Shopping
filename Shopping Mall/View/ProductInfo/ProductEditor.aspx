<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEditor.aspx.cs" Inherits="Shopping_Mall.ProductManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-2.1.4.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/ProductManage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">
        
        <div class="formBox">
            <div class="title">商品名稱:</div>
            <asp:TextBox ID="txtName"  class="textBox form-control " runat="server"></asp:TextBox>
        </div>
        
        <div class="formBox">
            <div class="title">商品類別:</div>
            <asp:DropDownList ID="dropdownType" CssClass="textBox form-control" runat="server">
                <asp:ListItem>3C產品</asp:ListItem>
                <asp:ListItem>飲料</asp:ListItem>
                <asp:ListItem>服飾</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="formBox">
            <div class="title">商品價格:</div>
            <asp:TextBox ID="txtPrice"  class="textBox form-control " runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="formBox">
            <div class="title">商品數量:</div>
            <asp:TextBox ID="txtNum"  class="textBox form-control " runat="server" TextMode="Number"></asp:TextBox>
            </div>
         <div class="formBox">
            <div class="title">上傳圖片:</div>
             <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>

        <div class="formBox">
            <div class="title">商品簡介:</div>
            
        </div>
        <asp:TextBox ID="txtSummary" CssClass="form-control" rows="3" TextMode="MultiLine" runat="server"></asp:TextBox>
        <div class="buttonBox">
            <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="送出" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnCancle" class="btn btn-default" runat="server" Text="取消" OnClick="btnCancle_Click"/>
        </div>
    </div>
</asp:Content>
