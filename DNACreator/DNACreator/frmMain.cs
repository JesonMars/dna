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
            if (!File.Exists(txtFileSelect.Text))
            {
                MessageBox.Show("请选择dna数据集表", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var excelHelper = new ExcelHelper();
            var datas=excelHelper.GetDataBySheetName("Sheet1");
            var dnaDatas=new List<DNADataEntity>();
            datas.RemoveAt(0);
            datas.RemoveAt(datas.Count-1);

            foreach (var data in datas)
            {
                var dnaData=new DNADataEntity();
                dnaData.Name = data[0];
                dnaData.DataNum = data[1];
                dnaData.DnaNum = data[2];
                dnaData.DnaData = data[3];
                dnaData.DnaDataDetail=new Dictionary<int, List<string>>();
                foreach (var ranseti in dnaData.DnaData.Split(';'))
                {
                    var dnaShuju = ranseti.Split(':');
                    var dnaXuHao=dnaShuju[0];
                    switch (dnaXuHao.ToUpper())
                    {
                        case "TPOX":
                            dnaXuHao = "2";
                            break;
                        case "CSF1PO":
                            dnaXuHao = "5";
                            break;
                        case "PENTAD":
                            dnaXuHao = "21";
                            break;
                        case "VWA":
                            dnaXuHao = "12";
                            break;
                        case "TH01":
                            dnaXuHao = "11";
                            break;
                        case "FGA":
                            dnaXuHao = "4";
                            break;
                        case "PENTAE":
                            dnaXuHao = "15";
                            break;
                        case "AMEL":
                            break;
                    }
                    dnaXuHao = Regex.Match(dnaXuHao, "D[0-9]*S").Value;
                    dnaXuHao = Regex.Replace(dnaXuHao, "[a-z][A-Z]","");
                    var ransenticur=dnaData.DnaDataDetail.FirstOrDefault(x => x.Key == int.Parse(dnaXuHao));
                    
                    if (ransenticur.Value == null)
                    {
                        var dnaShujus = new List<string>();
                        dnaShujus.Add(dnaShuju[1]);
                        dnaData.DnaDataDetail.Add(int.Parse(dnaXuHao),dnaShujus);
                    }
                    else
                    {
                        ransenticur.Value.Add(dnaShuju[1]);
                    }
                }
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
                FileStream fs = File.Create("d:/12.pdf", buf.Length);
                fs.Write(buf, 0, buf.Length);
                fs.Close();

                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "d:/12.pdf";
                myProcess.Start();
            }
            catch { }
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
