<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    主页
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <div>
        <%=Html.ActionLink("测试","Test") %>
        <% using (Html.BeginForm("Test","Home",FormMethod.Post))
           { %>
           
        宽：<%=Html.TextBox("kuan",0) %>
        高：<%=Html.TextBox("gao",0) %>
        <%--html:<%=Html.TextArea("html", @"<html>
    <head>
        <title>Test HTML-PDF file</title>
        
        <style type='text/css'>
            .last-cell {
                text-align: center;
                font-style: italic;
            }
            code {
                color: #484848;
                background-color: rgb(250, 250, 250);
                /*border: 1px solid #dadada;
                padding: 5px;
                margin: 15px; display: block;*/
            }
			span{
				position:relative;
				font-family:微软雅黑;
				font-size:13px;
				width:67.23px;
				/*letter-spacing:1px;*/
			}
			.maximg{
				position:absolute;
				width:1135px;
				height:709px;
			}
			body{
				margin:0 0;
			}
			.divtext{
				margin-left: 80px;
				top: 255px;
				position: relative;
			}
			.divtext1{
				margin-left: 80px;
				top: 480px;
				position: relative;
			}
			.divhr{
				border: 1.5px;
				margin-bottom: 0px;
				color: black;
				border-style: solid;
				width: 990px;
			}
			.divhr1{
				border: 0px;
				margin-bottom: 0px;
				background-color: black;
                color: black;
				border-style: solid;
				width: 990px;
				height: 0.5px;
				padding: 0.5px;
				margin-top: 2px;
				position: absolute;
				top: 17px;
			}
			.divhr2{
				border: 1.5px;
				margin-bottom: 0px;
				color: black;
				border-style: solid;
				width: 990px;
				top: 130px;
				position: absolute;
			}
            .divhr3{
				background-image: url(d:/heng.png);
				background-repeat: repeat-x;
				width: 992px;
				height: 3px;
				margin-top: 18px;
			}
            .divhr4{
				border: 1.5px;
				margin-bottom: 0px;
				color: black;
				border-style: solid;
				width: 990px;
				top: 110px;
				position: absolute;
			}
			.divran1{
				width:68px;
				float:left;
				font-family:微软雅黑;
				font-size:13px;
			}
			.divran2{
				width:72px;
				float:left;
				font-family:微软雅黑;
				font-size:13px;
			}
			.divtxt1{
				position: absolute;
				top: 30px;
				text-align:center;
			}
			.divtxt2{
				position: absolute;
				top: 65px;
				text-align:center;
			}
			.divtxt3{
				position: absolute;
				top: 100px;
				text-align:center;
			}
			.divtxt4{
				position: absolute;
			}
            hr{
				position: absolute;
				background-color: black;
				border: 0px;
				padding: 0.5px;
				width: 990px;
				top: 15px;
			}
        </style>
    </head>
    <body>
        <p>
            <img class='maximg' src='d:/1.jpg'>
			<div class='divtext'>
				<div class='divhr'></div>
				<div>
					<div class='divran1' style='margin-left: 8px;'>1号染色体</div>
					<div class='divran1' style='margin-left: 10px;'>2号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>3号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>4号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>5号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>6号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>7号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>8号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>9号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>10号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>11号染色体</div>
					<div class='divran2' style='margin-left: 10px;'>12号染色体</div>
				</div>
				<div class='divhr3'></div>
				<div class='divtxt1'>
					<div class='divran1' style='margin-left: 8px;'>/</div>
					<div class='divran1' style='margin-left: 10px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 10px;'>/</div>
				</div>
				<div class='divtxt2'>
					<div class='divran1' style='margin-left: 8px;'>/</div>
					<div class='divran1' style='margin-left: 10px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 10px;'>/</div>
				</div>
				<div class='divtxt3'>
					<div class='divran1' style='margin-left: 8px;'>/</div>
					<div class='divran1' style='margin-left: 10px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 14px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran1' style='margin-left: 16px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 13px;'>/</div>
					<div class='divran2' style='margin-left: 10px;'>/</div>
				</div>
				<div class='divhr2'></div>
			</div>
			<div class='divtext1'>
				<div class='divhr'></div>
				<div class='divtxt4'>
					<div class='divran1' style='margin-left: 6px;'>13号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>14号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>15号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>16号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>17号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>18号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>19号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>20号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>21号染色体</div>
					<div class='divran2' style='margin-left: 10px;'>22号染色体</div>
				</div>
				<div class='divhr3'></div>
				<div class='divtxt1'>
					<div class='divran1' style='margin-left: 6px;'>13号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>14号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>15号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>16号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>17号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>18号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>19号染色体</div>
					<div class='divran2' style='margin-left: 11px;'>20号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>21号染色体</div>
					<div class='divran2' style='margin-left: 10px;'>22号染色体</div>
				</div>
				<div class='divtxt2'>
					<div class='divran1' style='margin-left: 6px;'>13号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>14号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>15号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>16号染色体</div>
					<div class='divran1' style='margin-left: 14px;'>17号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>18号染色体</div>
					<div class='divran1' style='margin-left: 16px;'>19号染色体</div>
					<div class='divran2' style='margin-left: 11px;'>20号染色体</div>
					<div class='divran2' style='margin-left: 13px;'>21号染色体</div>
					<div class='divran2' style='margin-left: 10px;'>22号染色体</div>
				</div>
				<div class='divhr2'></div>
			</div>
        </p>
    </body>
</html>",new Dictionary<string, object>()
{
    {"cols","200"},
    {"rows","200"}
})%>--%>
        <input type="submit" value="提交"/>
        <%} %>
    </div>
    <p>
        若要了解有关 ASP.NET MVC 的更多信息，请访问 <a href="http://asp.net/mvc" title="ASP.NET MVC 网站">http://asp.net/mvc</a>。
    </p>
</asp:Content>
