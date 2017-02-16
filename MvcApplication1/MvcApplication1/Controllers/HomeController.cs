using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Pechkin;
using Pechkin.Synchronized;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "欢迎使用 ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test()
        {
            var kuan = int.Parse(Request["kuan"]);
            var gao = int.Parse(Request["gao"]);
            SynchronizedPechkin sc = new SynchronizedPechkin(new GlobalConfig().SetMargins(new Margins(0,0,0,0))
                .SetDocumentTitle("Ololo").SetCopyCount(1).SetImageQuality(1000)
                .SetLosslessCompression(true).SetMaxImageDpi(350).SetOutlineGeneration(true).SetOutputDpi(1200).SetPaperOrientation(true)
                .SetPaperSize(PaperKind.Letter));
            
#region boy反面有三行

            var boyfanhtmlallthree = @"<html>
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
				<div class='divtxt3'>
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
</html>";
#endregion
            
#region boy反面有两行

            var boyfanhtml1 = @"<html>
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
            }
			span{
				position:relative;
				font-family:微软雅黑;
				font-size:13px;
				width:67.23px;
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
				top: 100px;
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
				<div class='divhr4'></div>
			</div>
        </p>
    </body>
</html>";
            #endregion

#region 正面

            var zhengmianhtml = @"<html>
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
            }
			span{
				position:relative;
				font-family:微软雅黑;
				font-size:13px;
				width:67.23px;
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
				top: 100px;
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
				<div class='divhr4'></div>
			</div>
        </p>
    </body>
</html>";
            #endregion
            byte[] buf = sc.Convert(new ObjectConfig().SetPrintBackground(true),zhengmianhtml);
            try
            {
                string fn = Path.GetTempFileName()+".pdf";

                FileStream fs = new FileStream(fn, FileMode.Create);
                fs.Write(buf, 0, buf.Length);
                fs.Close();

                SynchronizedPechkin sc1 = new SynchronizedPechkin(new GlobalConfig().SetMargins(new Margins(0, 0, 0, 0))
                .SetDocumentTitle("Ololo").SetCopyCount(1).SetImageQuality(1000)
                .SetLosslessCompression(true).SetMaxImageDpi(350).SetOutlineGeneration(true).SetOutputDpi(1200).SetPaperOrientation(true)
                .SetPaperSize(PaperKind.Letter));
                byte[] buf1 = sc1.Convert(new ObjectConfig().SetPrintBackground(true), boyfanhtml1);
                FileStream fs1 = new FileStream(fn, FileMode.Append);
                fs1.Write(buf1, 0, buf1.Length);
                fs1.Close();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=123.pdf");//强制下载 
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(buf);
                Response.End();
            }
            catch { }

            return View();
        }
    }
    public class TimedAction
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public TimedAction(string name, TimeSpan duration)
        {
            Name = name;
            Duration = duration;
        }
    }

    public class PerformanceCollector
    {
        private string _name = "Perfomance statistics";
        private DateTime _lastMilestone = DateTime.Now;
        private List<TimedAction> _actions = new List<TimedAction>();

        public PerformanceCollector() { }
        public PerformanceCollector(string name)
        {
            _name = name;
        }

        public void FinishAction(string actionName)
        {
            DateTime cur = DateTime.Now;

            _actions.Add(new TimedAction(actionName, cur - _lastMilestone));

            _lastMilestone = cur;
        }

        public TimedAction[] GetListOfDurations()
        {
            return _actions.ToArray();
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            TimeSpan whole = TimeSpan.Zero;

            ret.Append(_name).Append(":\n\n");

            foreach (TimedAction action in _actions)
            {
                ret.Append(action.Name).Append(": ").Append(action.Duration.TotalMilliseconds).Append("ms (")
                    .Append(action.Duration.Ticks).Append("t)\n");

                whole += action.Duration;
            }

            ret.Append("\nTotal: ").Append(whole.TotalMilliseconds).Append("ms (")
                    .Append(whole.Ticks).Append("t)");

            return ret.ToString();
        }

    }
}
