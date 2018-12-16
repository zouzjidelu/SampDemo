using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UserManager.Security
{
    /// <summary>
    /// 授权特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ActionAuthorizeAttribute : AuthorizeAttribute
    {
        private IAuthorizationProvider authorizationProvider = new AuthorizationProvider();

        public string[] PermissionNames { get; private set; }

        public ActionAuthorizeAttribute(params string[] PermissionNames)
        {
            this.PermissionNames = PermissionNames ?? new string[0];
        }

        /// <summary>
        /// 在过程请求授权时调用。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }
            //如果控制器、action参数、特性上打的有允许访问的标签则跳出，不检测
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            //1.认证
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            //2.授权
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //认证完成，说明有权限访问此控制器，action，故，默认将此地址加入到权限集合中
            List<string> actionPermissionNames = PermissionNames.ToList();// new List<string>();
            actionPermissionNames.Add(controllerName + actionName);

            //如果有任何一个权限有，就通过 
            if (actionPermissionNames.Any(pName => authorizationProvider.Authorize(pName)))
            {
                return;
            }

            //认证通过，授权失败，继续走认证逻辑
            HandleUnauthorizedRequest(filterContext);
        }

        /// <summary>
        /// 没有认证的操作
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                //已经认证，没有权限、返回403
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);//返回403，没有权限
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }

    }
}