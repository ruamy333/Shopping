<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping_Mall.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Index.css" rel="stylesheet" />
    <link href="Css/Common.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="banner" class="container"> 
        <asp:Image ID="indexImage" runat="server" width="1200" height="400"/>
        <div class="editBox">
            <div class="edit">
                <asp:FileUpload ID="indexPicUpload" runat="server" />
                <asp:Button ID="btnImgSave" runat="server" CssClass="button-style-headerNfooter" Text="Save" OnClick="btnImgSave_Click"/>
                <%=editImgStr %>
            </div>
        </div>
    </div>
		<div id="three-column" class="container">
			<header>
				<h2>Products</h2>
			</header>
            <%=columnStr %>
		</div>
</asp:Content>
