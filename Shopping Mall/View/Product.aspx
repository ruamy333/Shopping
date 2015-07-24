<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Shopping_Mall.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link href="../Css/Common.css" rel="stylesheet" />
    <link href="Css/Product.css" rel="stylesheet" />
    <script src="../js/lefrbar-effect.js"></script>
    <script src="../js/buycar-scroll.js"></script>
    <script>
        $(document).ready(function () {
            var productID = "";
            $(".image").draggable({
                drag: function (event, ui) {
                    productID = $(this).attr("id");
                },
                revert: true,
                containment: "#containment-wrapper",
                scroll: false
            });
            
            $("#buycar").droppable({
                drop: function (event, ui) {
                    var txtID = "txt" + productID;
                    var number = document.getElementById(txtID).value;
                    document.location.href = "Product.aspx?ID=" + productID + "&num=" + number;
                }
            });
        });
  </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-middle">
        <div class="leftbar">
            <%=editType %>
            <div class="formBox" style="margin-top:10px;">
                <div class="textbox-position"><asp:TextBox ID="txtSearch"  CssClass="form-control textBox" placeholder="搜尋關鍵字" runat="server"></asp:TextBox></div>
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="../Picture/search.png" style="width:30px;" OnClick="btnSearch_Click" />
            </div>

            <div class="formBox" style="margin-top:10px;">
                <div class="textbox-position"><asp:TextBox ID="txtType"  CssClass="form-control textBox" placeholder="新增類別" runat="server" Visible="False"></asp:TextBox></div>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Picture/add.png" style="width:30px;" OnClick="btnSubmit_Click" Visible="False" />
            </div>
            <%=leftbarStr %>
        </div>
        <div class="rightbar">
            <div class="viewbox">
                <asp:Label ID="labView" runat="server" CssClass="position" Text="View:"></asp:Label>
                <asp:ImageButton ID="view2" runat="server" CssClass="position" ImageUrl="../Picture/view2.png" OnClick="btnView2_Click"/>
                <asp:ImageButton ID="view3" runat="server" CssClass="position" ImageUrl="../Picture/view3.png" OnClick="btnView3_Click"/>
                <asp:ImageButton ID="view4" runat="server" CssClass="position" ImageUrl="../Picture/view4.png" OnClick="btnView4_Click"/>
            </div>
            <%--<%=buycarStr %>--%>
            <%=rightStr %>            
        </div>        
        <div class="page">
            <%=pageStr %>
        </div>
    </div>
    <%--<!--防止空值-->
    <script type="text/javascript">
        function validate_required(field, alerttxt) {
            with (field) {
                if (value == null || value == "")
                { alert(alerttxt); return false }
                else { return true }
            }
        }

        function validate_form(thisform) {
            with (thisform) {
                if (validate_required(num, "請選擇數量") == false)
                { email.focus(); return false }
            }
        }
    </script>--%>
</asp:Content>
