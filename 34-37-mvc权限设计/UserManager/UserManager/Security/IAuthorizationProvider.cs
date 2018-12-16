using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        bool Authorize(string permissionName, User user);

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <returns></returns>
        bool Authorize(string permissionName);

    }
}
