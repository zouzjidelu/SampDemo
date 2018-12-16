using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 当前工作者上下文
    /// </summary>
    public class WorkContext
    {
        /// <summary>
        /// 获得当前工作的用户信息
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                return new AuthenticationProvider().GetAuthorizeUser();
            }
        }
    }
}