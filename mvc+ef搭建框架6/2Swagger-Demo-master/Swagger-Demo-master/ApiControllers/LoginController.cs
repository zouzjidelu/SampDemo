using Application;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;

namespace Swagger.Demo.Api.ApiControllers
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : ApiController
    {
        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto">登录信息</param>
        /// <remarks>
        /// 手持设备登录接口<br/>
        /// 必须要传参数MIME, AppId(后端约定),用户名，密码等<br/>
        /// 返回token、账号、用户姓名
        /// </remarks>
        [HttpPost]
        [AllowAnonymous]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Finish, Time = "2018-08-09")]
        public dynamic CheckLogin(LoginDto dto)
        {
            return dto;
        }
        #endregion
    }
}
