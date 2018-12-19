using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionAndLogSapmle.Controllers
{
    public class HomeController : Controller
    {
        //[HandleErrorAttribute(ExceptionType = typeof(DivideByZeroException), Master = null, Order = 1, View = "Error2")]
        public ActionResult Index()
        {
            int a = 1;
            int b = 0;
            int c = a / b;
            
            return View();
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