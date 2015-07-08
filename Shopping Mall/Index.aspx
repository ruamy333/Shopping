<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping_Mall.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Index.css" rel="stylesheet" />
    <link href="Css/Common.css" rel="stylesheet" />
    <script src="/js/jquery-2.1.4.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="banner" class="container"> 
        <img src="Picture/header-photo.jpg" width="1200" height="400" /> </div>
		<div id="three-column" class="container">
			<header>
				<h2>Products</h2>
			</header>
			<div class="columnbox">
				<a href="#" class="image image-full"><img src="Picture/img01.jpg" alt=""/></a>
				<h2>光纖量測產品</h2>
				<p>● 光時域反射儀 (OTDR)<br/>● 穩定雷射光源及光功率計<br/>● 可視故障定位器</p>
				<a href="View/Product.aspx?t=光纖量測產品" class="button-style">More</a>
			</div>
			<div class="columnbox">
                <a href="#" class="image image-full"><img src="Picture/img02.jpg" alt=""/></a>
				<h2>光纜監測管理系統</h2>
				<p>本系統由多個不同的遙控測試單元、中央監測伺服器、與相關的軟體介面等組成，可用以進行整合性的光纖無人監測、遙控監測與管理、自動光纖資訊蒐集、光纖特性分析與預測等工作。FOMA 可藉由Web網路進行光纖週期性測試、及時光纖狀態回報、光纖失效告警、及自動化的光纖維護管理等功能，為一經濟、有效、並可客製化的光纖監測與告警系統。</p>
				<a href="View/Product.aspx?t=光纜監測管理系統" class="button-style">More</a> 
			</div>
			<div class="columnbox">
                <a href="#" class="image image-full"><img src="Picture/img03.jpg" alt=""/></a>
				<h2>光電轉換產品</h2>
				<p>● 光電收發器<br/>● 乙太網媒體轉換器<br/>● 乙太網媒體交換機<br/>● POF交換機</p>
				<a href="View/Product.aspx?t=光電轉換產品" class="button-style">More</a>
			</div>
		</div>
</asp:Content>
