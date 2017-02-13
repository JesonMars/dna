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

        public ActionResult Test()
        {
            SynchronizedPechkin sc = new SynchronizedPechkin(new GlobalConfig().SetMargins(new Margins(10, 10, 10, 10))
                .SetDocumentTitle("Ololo").SetCopyCount(1).SetImageQuality(1000)
                .SetLosslessCompression(true).SetMaxImageDpi(96).SetOutlineGeneration(true).SetOutputDpi(1200).SetPaperOrientation(true)
                .SetPaperSize(PaperKind.Letter).SetCopyCount(2));
            byte[] buf = sc.Convert(new ObjectConfig(), @"<html>
    <head>
        <title>Test HTML-PDF file</title>
        
        <style type='text/css'>
            
            p { text-indent: 3em; }
            .last-cell {
                text-align: center;
                font-style: italic;
            }
            code {
                color: #484848;
                border: 1px solid #dadada;
                background-color: rgb(250, 250, 250);
                padding: 5px;
                margin: 15px; display: block;
            }
        </style>
    </head>
    <body>
        <h1>Hello world!</h1>
        <p>
            
            <img width='270' height='129' src='d:/1.jpg'>
        </p>
        
        <table>
            <tr><th>Property</th><th>Value</th></tr>
            <tr><td>Text</td><td>Html to pdf test app</td></tr>
            <tr><td>Object type</td><td>Form</td></tr>
            <tr><td>Purpose</td><td><code>libraray test</code></td></tr>
        </table>
    </body>
</html>");
            try
            {
                string fn = Path.GetTempFileName()+".pdf";

                FileStream fs = new FileStream(fn, FileMode.Create);
                fs.Write(buf, 0, buf.Length);
                fs.Close();

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
