using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Helper;
using Pechkin;
using Pechkin.Synchronized;

namespace DNACreator
{
    public partial class frmMain : Form
    {
        public OpenFileDialog FileDialog { get; set; }
        public FolderBrowserDialog FolderBrowser { get; set; }
        public string destPath = "d:";
        public frmMain()
        {
            InitializeComponent();
            txtkuan.Text = 570.ToString();
            txtgao.Text = 910.ToString();
            txtDestinationFolder.Text = destPath;
            txtFileSelect.Text = "";
            this.txtHtml.Visible = false;

            FileDialog = new OpenFileDialog();
            FolderBrowser = new FolderBrowserDialog();

            FileDialog.FileOk += new CancelEventHandler(this.FileDialog_FileOk);
            btnCreateNew.Click+=new EventHandler(this.btnCreateNew_Click);
        }

        private void FileDialog_FileOk(object sender, EventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var file = dialog.FileName;
            if (!ExcelHelper.IsExcel(file))
            {
                MessageBox.Show(string.Format("请选择后缀名为{0}的文件!", ".xlsx/.xls"), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var cancelEvents = (CancelEventArgs)e;
                cancelEvents.Cancel = true;
                return;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFileSelect.Text))
            {
                MessageBox.Show("请选择dna数据集表","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            SynchronizedPechkin sc = new SynchronizedPechkin(new GlobalConfig().SetMargins(new Margins(0, 0, 0, 0))
                .SetDocumentTitle("Ololo").SetCopyCount(1).SetImageQuality(1000)
                .SetLosslessCompression(true).SetMaxImageDpi(350).SetOutlineGeneration(true).SetOutputDpi(1200).SetPaperOrientation(true)
                .SetPaperSize(new PaperSize("cus", int.Parse(txtkuan.Text), int.Parse(txtgao.Text))).SetCopyCount(1));

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

            var boyfanhtmltwo = @"<html>
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

            #region girl反面有两行

            var girlfanhtml1 = @"<html>
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
				margin-left: 120px;
				top: 430px;
				position: relative;
width:1000px;
			}
			.divh1{
				border: 0px;
				border-bottom:1.5px;
				margin-left:190px;
				color: white;
				border-style: solid;
				width: 400px;
				height:2px;
				padding:0px;
				position:relative;
			}
			.divh2{
				border: 0px;
				border-bottom:1.5px;
				margin-bottom: 0px;
				margin-left:190px;
				color: white;
				border-style: solid;
				width: 400px;
				height:2px;
				padding:0px;
				position:absolute;
			}
			.divh3{
				border: 0px;
				border-bottom:1.5px;
				margin-bottom: 0px;
				margin-left:190px;
				color: white;
				border-style: solid;
				width: 400px;
				height:2px;
				padding:0px;
				position:absolute;
				letter-spacing:0px;
			}
			.divran1{
				font-family:微软雅黑;
				font-size:30px;
				color:white;
				margin-bottom:24px;
			}
        </style>
    </head>
    <body>

            <img class='maximg' src='d:/f.jpg'>
			<div class='divtext'>
				<div style='width:1000px'>
					<div class='divran1'>姓　　&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名&nbsp;<div class='divh1'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;涨价卷之女</div></div></div>
					<div class='divran1'>样&nbsp;&nbsp;品&nbsp;&nbsp;编&nbsp;&nbsp;号&nbsp;<div class='divh2'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;16SDFSDSFFDSFDS</div></div></div>
					<div class='divran1'>DNA档&nbsp;案&nbsp;号&nbsp;<div class='divh3'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;BGIF3252846110740</div></div></div>
				</div>
			</div>
    </body>
</html>";
            #endregion

            byte[] buf = sc.Convert(new ObjectConfig().SetPrintBackground(true), txtHtml.Text);
            try
            {
                FileStream fs = File.Create("d:/12.pdf",buf.Length);
                fs.Write(buf, 0, buf.Length);
                fs.Close();

                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "d:/12.pdf";
                myProcess.Start();
            }
            catch { }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            var dnaSerialStr =
                "[{\"Key\":\"TPOX\",\"Value\":\"2\"},{\"Key\":\"CSF1PO\",\"Value\":\"5\"},{\"Key\":\"PENTAD\",\"Value\":\"21\"},{\"Key\":\"VWA\",\"Value\":\"12\"},{\"Key\":\"TH01\",\"Value\":\"11\"},{\"Key\":\"FGA\",\"Value\":\"4\"},{\"Key\":\"PENTAE\",\"Value\":\"15\"},{\"Key\":\"AMEL\",\"Value\":\"sex\"},{\"Key\":\"Yindel\",\"Value\":\"Y\"},{\"Key\":\"DYS391\",\"Value\":\"Y\"},{\"Key\":\"SE33\",\"Value\":\"6\"},{\"Key\":\"YGATAH4\",\"Value\":\"Y\"}]";
            if (!File.Exists(txtFileSelect.Text))
            {
                MessageBox.Show("请选择dna数据集表", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Directory.Exists(txtDestinationFolder.Text))
            {
                MessageBox.Show("请选择pdf文件的保存地址", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnCreateNew.Enabled = false;
            var jsonHelper = new JsonHelper();
            var excelHelper = new ExcelHelper(txtFileSelect.Text);
            var dnaDatas = new List<DNADataEntity>();

            try
            {
                var dnaSerial = new Dictionary<string, string>();
                dnaSerial = jsonHelper.JsonDeserialize<Dictionary<string, string>>(dnaSerialStr);

                var datas = excelHelper.GetFirstSheetData();
                excelHelper.Dispose();
                datas.RemoveAt(0);

                #region 将数据转化为对象

                foreach (var data in datas)
                {
                    //从数据表中把数据加载入对象
                    var dnaData = new DNADataEntity();
                    dnaData.Name = data[0];
                    dnaData.DataNum = data[1];
                    dnaData.DnaNum = data[2];
                    dnaData.DnaData = data[3];
                    //初始化该人的dna数据
                    dnaData.DnaDataDetail = new Dictionary<string, List<string>>();
                    //获取该人的dna数据信息详情
                    foreach (var ranseti in dnaData.DnaData.Split(';'))
                    {
                        if (string.IsNullOrEmpty(ranseti))
                        {
                            continue;
                            ;
                        }
                        //获取到该序列的序列号信息
                        var dnaShuju = ranseti.Split(':');
                        string dnaXuHao = dnaShuju[0];
                        //初始化该序列所在的染色体编号
                        string ranSeTiXuHao = "";

                        //处理性别或y染色体
                        switch (dnaXuHao.ToUpper())
                        {
                            case "AMEL":
                                dnaXuHao =
                                    Regex.Replace(dnaShuju[1], "[^A-Za-z]*", "", RegexOptions.IgnoreCase).ToUpper();
                                if (dnaXuHao == "XX")
                                {
                                    dnaData.Sex = "女";
                                }
                                else
                                {
                                    dnaData.Sex = "子";
                                }
                                continue;
                                break;
                        }
                        if (dnaSerial.ContainsKey(dnaXuHao.ToUpper()))
                        {
                            //处理其他特殊染色体
                            ranSeTiXuHao = dnaSerial[dnaXuHao.ToUpper()];
                        }
                        else
                        {
                            //处理一般染色体
                            dnaXuHao = Regex.Match(dnaXuHao, "D[0-9]*S").Value;
                            dnaXuHao = Regex.Replace(dnaXuHao, "[a-zA-Z]", "");
                            ranSeTiXuHao = dnaXuHao;
                        }
                        //获取该染色体序号下的染色体
                        var ransenti = dnaData.DnaDataDetail.FirstOrDefault(x => x.Key == ranSeTiXuHao);
                        var ransetishuju = "";
                        Regex.Matches(dnaShuju[1], "[0-9,.]*").Cast<Match>().ToList().ForEach(x =>
                        {
                            ransetishuju += x.Value;
                        });
                        ransetishuju = string.IsNullOrEmpty(ransetishuju) ? "/" : ransetishuju;
                        if (ransenti.Value == null)
                        {
                            var dnaShujus = new List<string>();
                            dnaShujus.Add(ransetishuju);
                            dnaData.DnaDataDetail.Add(ranSeTiXuHao, dnaShujus);
                        }
                        else
                        {
                            ransenti.Value.Add(ransetishuju);
                        }
                    }
                    dnaDatas.Add(dnaData);
                }

                #endregion

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

                var boyfanhtmltwo = @"<html>
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
				    background-image: url([1]);
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
                <img class='maximg' src='[2]'>
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
					    <div class='divran1' style='margin-left: 8px;'>(1-1)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-1)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-1)</div>
				    </div>
				    <div class='divtxt2'>
					    <div class='divran1' style='margin-left: 8px;'>(1-2)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-2)</div>
				    </div>
				    <div class='divtxt3'>
					    <div class='divran1' style='margin-left: 8px;'>(1-2)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-2)</div>
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
                        <div class='divran2' style='margin-left: 20px;'>X染色体</div>
                        <div class='divran2' style='margin-left: 2px;'>Y染色体</div>
				    </div>
				    <div class='divhr3'></div>
				    <div class='divtxt1'>
					    <div class='divran1' style='margin-left: 6px;'>(13-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(14-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(15-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(16-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(17-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(18-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(19-1)</div>
					    <div class='divran2' style='margin-left: 11px;'>(20-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(21-1)</div>
					    <div class='divran2' style='margin-left: 10px;'>(22-1)</div>
                        <div class='divran2' style='margin-left: 10px;'>/</div>
                        <div class='divran2' style='margin-left: 2px;'>(Y-1)</div>
				    </div>
				    <div class='divtxt2'>
					    <div class='divran1' style='margin-left: 6px;'>(13-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(14-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(15-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(16-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(17-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(18-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(19-2)</div>
					    <div class='divran2' style='margin-left: 11px;'>(20-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(21-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(22-2)</div>
                        <div class='divran2' style='margin-left: 10px;'>/</div>
                        <div class='divran2' style='margin-left: 2px;'>(Y-2)</div>
				    </div>
				    <div class='divhr4'></div>
			    </div>
            </p>
        </body>
    </html>";

                #endregion

#region girl反面有两行

                var girlfanhtml1 = @"<html>
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
				    background-image: url([1]);
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
                <img class='maximg' src='[2]'>
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
					    <div class='divran1' style='margin-left: 8px;'>(1-1)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-1)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-1)</div>
				    </div>
				    <div class='divtxt2'>
					    <div class='divran1' style='margin-left: 8px;'>(1-2)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-2)</div>
				    </div>
				    <div class='divtxt3'>
					    <div class='divran1' style='margin-left: 8px;'>(1-2)</div>
					    <div class='divran1' style='margin-left: 10px;'>(2-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(3-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(4-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(5-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(6-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(7-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(8-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(9-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(10-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(11-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(12-2)</div>
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
                        <div class='divran2' style='margin-left: 20px;'>X染色体</div>
                        <div class='divran2' style='margin-left: 2px;'>X染色体</div>
				    </div>
				    <div class='divhr3'></div>
				    <div class='divtxt1'>
					    <div class='divran1' style='margin-left: 6px;'>(13-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(14-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(15-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(16-1)</div>
					    <div class='divran1' style='margin-left: 14px;'>(17-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(18-1)</div>
					    <div class='divran1' style='margin-left: 16px;'>(19-1)</div>
					    <div class='divran2' style='margin-left: 11px;'>(20-1)</div>
					    <div class='divran2' style='margin-left: 13px;'>(21-1)</div>
					    <div class='divran2' style='margin-left: 10px;'>(22-1)</div>
                        <div class='divran2' style='margin-left: 10px;'>/</div>
                        <div class='divran2' style='margin-left: 2px;'>/</div>
				    </div>
				    <div class='divtxt2'>
					    <div class='divran1' style='margin-left: 6px;'>(13-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(14-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(15-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(16-2)</div>
					    <div class='divran1' style='margin-left: 14px;'>(17-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(18-2)</div>
					    <div class='divran1' style='margin-left: 16px;'>(19-2)</div>
					    <div class='divran2' style='margin-left: 11px;'>(20-2)</div>
					    <div class='divran2' style='margin-left: 13px;'>(21-2)</div>
					    <div class='divran2' style='margin-left: 10px;'>(22-2)</div>
                        <div class='divran2' style='margin-left: 10px;'>/</div>
                        <div class='divran2' style='margin-left: 2px;'>/</div>
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
				    margin-left: 120px;
				    top: 430px;
				    position: relative;
    width:1000px;
			    }
			    .divh1{
				    border: 0px;
				    border-bottom:1.5px;
				    margin-left:190px;
				    color: white;
				    border-style: solid;
				    width: 400px;
				    height:1.5px;
				    padding:0px;
				    position:relative;
			    }
			    .divh2{
				    border: 0px;
				    border-bottom:1.5px;
				    margin-bottom: 0px;
				    margin-left:190px;
				    color: white;
				    border-style: solid;
				    width: 400px;
				    height:1.5px;
				    padding:0px;
				    position:absolute;
			    }
			    .divh3{
				    border: 0px;
				    border-bottom:1.5px;
				    margin-bottom: 0px;
				    margin-left:190px;
				    color: white;
				    border-style: solid;
				    width: 400px;
				    height:1.5px;
				    padding:0px;
				    position:absolute;
				    letter-spacing:0px;
			    }
			    .divran1{
				    font-family:微软雅黑;
				    font-size:30px;
				    color:white;
				    margin-bottom:24px;
			    }
            </style>
        </head>
        <body>

                <img class='maximg' src='[2]'>
			    <div class='divtext'>
				    <div style='width:1000px'>
					    <div class='divran1'>姓　　&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名&nbsp;<div class='divh1'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;dnas-1</div></div></div>
					    <div class='divran1'>样&nbsp;&nbsp;品&nbsp;&nbsp;编&nbsp;&nbsp;号&nbsp;<div class='divh2'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;dnas-2</div></div></div>
					    <div class='divran1'>DNA档&nbsp;案&nbsp;号&nbsp;<div class='divh3'>&nbsp;&nbsp;<div style='position:relative;bottom:75px;'>&nbsp;&nbsp;dnas-3</div></div></div>
				    </div>
			    </div>
        </body>
    </html>";

                #endregion

                var exePath = AppDomain.CurrentDomain.BaseDirectory;
                exePath = exePath.Replace("\\", "/");
                boyfanhtmltwo = boyfanhtmltwo.Replace("[1]", string.Format("{0}heng.png", exePath))
                    .Replace("[2]", string.Format("{0}boyfan.jpg", exePath));
                girlfanhtml1 = girlfanhtml1.Replace("[1]", string.Format("{0}heng.png", exePath))
                    .Replace("[2]", string.Format("{0}girlfan.jpg", exePath));
                zhengmianhtml = zhengmianhtml.Replace("[2]", string.Format("{0}zheng.jpg", exePath));

                foreach (var dnaDataEntity in dnaDatas)
                {
                    //生成该人的正面卡片
                    var pdfHtmlZheng = zhengmianhtml;
                    pdfHtmlZheng = Regex.Replace(pdfHtmlZheng, "dnas-1", dnaDataEntity.Name);
                    pdfHtmlZheng = Regex.Replace(pdfHtmlZheng, "dnas-2", dnaDataEntity.DataNum);
                    pdfHtmlZheng = Regex.Replace(pdfHtmlZheng, "dnas-3", dnaDataEntity.DnaNum);

                    //生成该人的反面卡片
                    var pdfHtmlFan = "";
                    if (dnaDataEntity.Sex == "女")
                    {
                        pdfHtmlFan = girlfanhtml1;
                    }
                    else
                    {
                        pdfHtmlFan = boyfanhtmltwo;
                    }
                    for (int i = 0; i < 23; i++)
                    {
                        var key = (i == 22) ? "Y" : (i + 1).ToString();
                        var ransetiThis = dnaDataEntity.DnaDataDetail.FirstOrDefault(x => x.Key == key);
                        for (int j = 1; j < 4; j++)
                        {
                            var bianhaodata = "";
                            if (ransetiThis.Value == null || ransetiThis.Value.Count < j ||
                                string.IsNullOrEmpty(ransetiThis.Value[j - 1]))
                            {
                                bianhaodata = "/";
                            }
                            else
                            {
                                bianhaodata = ransetiThis.Value[j - 1];
                            }
                            pdfHtmlFan = pdfHtmlFan.Replace(string.Format("({0}-{1})", key ?? "dd", j), bianhaodata);
                        }
                    }
                    var fpath = string.Format("{0}/{1}_{2}", txtDestinationFolder.Text, dnaDataEntity.Name,dnaDataEntity.DataNum);

                    var obj = new ObjectConfig().SetPrintBackground(true).SetAffectPageCounts(true);
                    SynchronizedPechkin sc =
                        new SynchronizedPechkin(new GlobalConfig().SetMargins(new Margins(0, 0, 0, 0))
                            .SetDocumentTitle("Olo").SetImageQuality(1000).SetCopyCount(1)
                            .SetLosslessCompression(true)
                            .SetMaxImageDpi(350)
                            .SetOutlineGeneration(true)
                            .SetOutputDpi(1200)
                            .SetPaperOrientation(true)
                            .SetPaperSize(new PaperSize("cus", int.Parse(txtkuan.Text), int.Parse(txtgao.Text))));

                    byte[] fan = sc.Convert(obj, pdfHtmlFan);
                    FileStream fs = new FileStream(fpath + "_反面.pdf", FileMode.Create);
                    fs.Write(fan, 0, fan.Length);
                    fs.Close();

                    byte[] zheng = sc.Convert(obj, pdfHtmlZheng);
                    fs = new FileStream(fpath + "_正面.pdf", FileMode.Create);
                    fs.Write(zheng, 0, zheng.Length);
                    fs.Close();

                    //Process myProcess = new Process();
                    //myProcess.StartInfo.FileName = fpath;
                    //myProcess.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"出错",MessageBoxButtons.OK);
            }
            btnCreateNew.Enabled = true;
            MessageBox.Show("生成成功！", "成功", MessageBoxButtons.OK);
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var result=FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFileSelect.Text = FileDialog.FileName;
            }
        }

        private void btnSelectFoler_Click(object sender, EventArgs e)
        {
            var result = FolderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestinationFolder.Text = FolderBrowser.SelectedPath;
                destPath = txtDestinationFolder.Text;
            }
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
