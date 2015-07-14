<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEditor.aspx.cs" Inherits="Shopping_Mall.ProductManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Common.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/ProductEditor.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentBlock">
			<div class="content-header"></div>
        <div class="formBox">
            <div class="title">商品名稱：</div>
            <asp:TextBox ID="txtName"  class="form-control textBox " runat="server"></asp:TextBox>
        </div>
        
        <div class="formBox">
            <div class="title">商品類別：</div>
            <asp:DropDownList ID="dropdownType" CssClass="textBox form-control" runat="server">
                <asp:ListItem>光纖量測產品</asp:ListItem>
                <asp:ListItem>光纜監測管理系統</asp:ListItem>
                <asp:ListItem>光電轉換產品</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="formBox">
            <div class="title">商品價格：</div>
            <asp:TextBox ID="txtPrice"  class="textBox form-control " runat="server" TextMode="Number" min="1"></asp:TextBox>
        </div>
        <div class="formBox">
            <div class="title">商品數量：</div>
            <asp:TextBox ID="txtNum"  class="textBox form-control " runat="server" TextMode="Number" min="1"></asp:TextBox>
        </div>
        <div class="summaryBox">
            <div class="title">折扣方式：</div>
            <asp:RadioButtonList ID="radiobtnDiscount" runat="server" OnSelectedIndexChanged="radiobtnDiscount_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True">無</asp:ListItem>
                <asp:ListItem>折扣</asp:ListItem>
                <asp:ListItem>其他</asp:ListItem>
            </asp:RadioButtonList>
            <div class="discountDetail">
             <%=discountStr[0] %><asp:TextBox ID="txtDiscountType" runat="server" Visible="false" class="discountTextBox form-control" TextMode="Number" min="0"></asp:TextBox>
             <%=discountStr[1] %><asp:TextBox ID="txtDiscountContent" runat="server" Visible="false" class="discountTextBox form-control" TextMode="Number" min="0"></asp:TextBox>
            </div>
        </div>
        <div class="formBox">
            <div class="title">上傳圖片：</div>
             <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>

        <div class="formBox">
            <div class="title">商品簡介：</div>
        </div>
        <div class="summaryBox">
            <asp:TextBox ID="txtSummary" CssClass="form-control summary" Rows="6" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <div class="buttonBox">
            <asp:Button ID="btnSubmit" class="button-style" runat="server" Text="送出" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnCancle" class="button-style" runat="server" Text="取消" OnClick="btnCancle_Click"/>
        </div>
    </div>
</asp:Content>
