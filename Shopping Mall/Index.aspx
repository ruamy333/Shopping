<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping_Mall.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Index.css" rel="stylesheet" />
    <link href="Css/Common.css" rel="stylesheet" />
    <script src="js/jquery.movingboxes.js"></script>
    <link href="Css/movingboxes.css" rel="stylesheet" />
    <style>
		/* Dimensions set via css in MovingBoxes version 2.2.2+ */
		#slider { width: 1200px; }
		#slider li { width: 300px; }
	</style>

    <script>
        $(function () {
            $('#slider').movingBoxes({
                /* width and panelWidth options deprecated, but still work to keep the plugin backwards compatible
                width: 500,
                panelWidth: 0.5,
                */
                startPanel: 1,      // start with this panel
                wrap: false,  // if true, the panel will infinitely loop
                buildNav: true,   // if true, navigation links will be added
                navFormatter: function () { return "&#9679;"; } // function which returns the navigation text for each panel
            });

        });
	</script>
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
        

        <%--<%=columnStr %>--%>
	</div>

    <ul id="slider">
            <%=columnStr %>
	    </ul>
</asp:Content>
