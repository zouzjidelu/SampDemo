using ExceptionAndLogSapmle.App_Start;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionAndLogSapmle.Controllers
{
    public class HomeController : Controller
    {
        //[CustomHandleError]
        public ActionResult Index()
        {
            //try
            //{
            //    int a = 1;
            //    int b = 0;
            //    int c = a / b;
            //}
            //catch (Exception ex)
            //{
            //    LogEntry logEntry = new LogEntry()
            //    {
            //        Severity = TraceEventType.Error,
            //        Message = ex.Message,
            //        Title = "计算异常",
            //        Categories = new string[] { "计算", "服务" },
            //        ExtendedProperties = new Dictionary<string, object>()
            //        {
            //            { "Controller",ControllerContext.RouteData.GetRequiredString("controller")},
            //            { "Action",ControllerContext.RouteData.GetRequiredString("action")},
            //            { "Exception",ex}
            //        }
            //    };

            //    Logger.Write(logEntry);
            //}

            return View();
        }

        public ActionResult Index1()
        {
            throw new DivideByZeroException();
            //return View();
        }
        public ActionResult OnIndex1Error()
        {
            return Json(new { ID = 1, user = "test" }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public ActionResult Index2()
        {
            throw new ArgumentException();
            //return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;
        //    filterContext.Result = RedirectToAction("Error","Error");

        //    base.OnException(filterContext);
        //}
    }
}