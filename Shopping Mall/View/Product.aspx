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
                revert: true
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
                <%=leftbarStr %>
        </div>
        <div class="rightbar">
            <div id="buycar">
			    <img src="/Picture/buycar.png" />
	        </div>
            <%=rightStr %>
        </div>
        
        <div class="page">
            <%=pageStr %>
        </div>
    </div>
    <!--防止空值-->
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
    </script>
</asp:Content>
