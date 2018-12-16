using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManager.Security;

namespace UserManager.Controllers
{
    [ActionAuthorize]
    public class ManagerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [ActionAuthorize("ManagerIndex")]
        //[AllowAnonymous]
        public JsonResult GetJson()
        {
            return Json(new { id = 1, name = "code...." }, JsonRequestBehavior.AllowGet);
        }
    }
}