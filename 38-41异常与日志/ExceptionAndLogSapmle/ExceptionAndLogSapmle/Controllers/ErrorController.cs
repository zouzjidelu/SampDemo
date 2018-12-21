using System;
using System.Web.Mvc;

namespace ExceptionAndLogSapmle.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult InternalServerError(Exception msg)
        {
            ViewBag.msg = msg;
            return View();
        }



        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult NotFound2()
        {
            return View();
        }
    }
}