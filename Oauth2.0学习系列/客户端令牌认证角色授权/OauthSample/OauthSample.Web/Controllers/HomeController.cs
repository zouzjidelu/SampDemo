using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Owin.Authorization.Mvc;

namespace OauthSample.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ResourceAuthorize("About", "HomeManager")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [ResourceAuthorize("Contact", "HomeManager")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetUserInfo()
        {
            return View((User as ClaimsPrincipal).Claims);
        }

        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}