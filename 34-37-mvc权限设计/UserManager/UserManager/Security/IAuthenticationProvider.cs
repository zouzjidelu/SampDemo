using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 认证提供者接口
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="rememberMe">是否记住我</param>
        void SignIn(User user, bool rememberMe);

        /// <summary>
        /// 退出
        /// </summary>
        void SignOut();

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns></returns>
        User GetAuthorizeUser();
    }
}