using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserManager.Entitys;
using UserManager.Models;
using UserManager.Security;

namespace UserManager.Controllers
{
    public class UserController : Controller
    {
        private UserManagerDbContext dbContext = new UserManagerDbContext();
        private IAuthenticationProvider authenticationProvider = new AuthenticationProvider();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "无效的用户名密码");
            }
            User user = dbContext.Users.FirstOrDefault(u => u.Name == loginModel.UserName && u.Password == loginModel.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "无效的用户名密码");
                return View(loginModel);
            }
            else
            {
                //认证登陆
                authenticationProvider.SignIn(user, loginModel.RememberMe);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        public ActionResult SignOut()
        {
            Action<int> act = new Action<int>((int a)=> { });
            IAsyncResult asyncResult= act.BeginInvoke(1, null, null);
            act.EndInvoke(asyncResult);
            //方式一
            authenticationProvider.SignOut();
            return RedirectToAction(nameof(Login));
            //方式二
            //throw new HttpException((int)HttpStatusCode.Unauthorized,"");
            //方式三
            //return new HttpStatusCodeResult(401);
        }

    }
}