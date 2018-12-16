using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 认证提供者
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private UserManagerDbContext userDbContext = new UserManagerDbContext();

        /// <summary>
        /// 获得认证用户信息
        /// </summary>
        /// <returns></returns>
        public User GetAuthorizeUser()
        {
            //获得当前http请求
            HttpContext currentHttpContext = HttpContext.Current;
            //当前httpcontext不是空并且请求不是空，并且请求是认证过的。并且是Form认证种植的票据
            if (currentHttpContext != null && currentHttpContext.Request != null && currentHttpContext.Request.IsAuthenticated && (currentHttpContext.User.Identity is FormsIdentity))
            {
                //获得form认证种植的票据
                FormsIdentity formsIdentity = (FormsIdentity)currentHttpContext.User.Identity;
                string name = formsIdentity.Ticket.Name;
                //获得用户数据，当然这里的用户数据可以是一个用户对象，
                string userData = formsIdentity.Ticket.UserData;
                if (!string.IsNullOrEmpty(name))
                {
                    //可以将信息放入缓存，设置过期时间，不用每次，检测
                    return userDbContext.Users.FirstOrDefault(u => u.Name == name);
                }
            }
            return null;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rememberMe"></param>
        public void SignIn(User user, bool rememberMe)
        {
            string userData = Guid.NewGuid().ToString();
            //生成票据
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddDays(1), rememberMe, userData);

            //加密票据
            string encryptTicket = FormsAuthentication.Encrypt(ticket);
            //写入cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}