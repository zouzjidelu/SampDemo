using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 实体（数据）权限提供者（服务）接口
    /// </summary>
    public interface IEntityPermissionProvider
    {
        /// <summary>
        /// 当前实体是否有权限访问
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Authorize<T>(T entity) where T : BaseEntity;
    }
}
