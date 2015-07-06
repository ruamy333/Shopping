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
        <asp:Panel ID="Panel1" runat="server" Height="222px" Width="644px">
            <div class="product-inside">
                <div class="sale">
                    <div class="image">

                    </div>
                    <div class="SaleColumn">

                    </div>
                    <div class="SaleColumn">

                    </div>

               </div>
            </div>
           
        </asp:Panel>
        
    </div>
</div>
</asp:Content>
