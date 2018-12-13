using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 权限提供者接口
    /// </summary>
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();
    }
}
