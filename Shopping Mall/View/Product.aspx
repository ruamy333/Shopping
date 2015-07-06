<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Shopping_Mall.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Common.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/Product.css"><link/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="content-middle">
    <div class="leftbar">
            <%=leftbarStr %>
    </div>
    <div class="product">
    <h1>商品區</h1>
        <div class="sale" style="border-left:solid 1px">
            <div class="SaleColumn" style="border-top:solid 1px">
                <img class="image" src="../picture/pic1.jpg"/>
            </div>
            <div class="SaleColumn" style="border-top:solid 1px">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="SaleColumn" style="border-top:solid 1px">
                <a href="">詳細資訊</a>
            </div>
        </div>
        <div class="sale" style="border-left:solid 1px">
                <div class="SaleColumn">
                    <img class="image" src="../picture/pic2.jpg"/>
                </div>
                <div class="SaleColumn">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="SaleColumn">
                    <a href="">詳細資訊</a>
                </div>
            </div>      
        <div class="sale" style="border-left:solid 1px">
            <div class="SaleColumn">
                    <img class="image" src="../picture/pic3.jpg"/>
                </div>
            <div class="SaleColumn">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
            <div class="SaleColumn">
                    <a href="">詳細資訊</a>
                </div>
        </div>
        
    </div>
</div>
</asp:Content>
