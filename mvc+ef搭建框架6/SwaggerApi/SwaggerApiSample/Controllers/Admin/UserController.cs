using SwaggerApiSample.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace SwaggerApiSample.Controllers.Admin
{
    /// <summary>
    /// 用户控制器类
    /// </summary>
    public class UserController : ApiController
    {
        private readonly static List<User> users;
        static UserController()
        {
            users = new List<User>()
            {
                new User(){ ID=1,Name="常帅1",Email="550992499@qq.com1",Password="1234561"},
                new User(){ ID=2,Name="常帅2",Email="550992499@qq.com2",Password="1234562"},
                new User(){ ID=3,Name="常帅3",Email="550992499@qq.com3",Password="1234563"},
                new User(){ ID=4,Name="常帅4",Email="550992499@qq.com4",Password="1234564"},
                new User(){ ID=5,Name="常帅5",Email="550992499@qq.com5",Password="1234565"}
            };
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public List<User> GetList()
        {
            return users;
        }

        /// <summary>
        /// 根据用户id获取用户详细信息
        /// </summary>
        /// <param name="ID">标识ID</param>
        /// <returns></returns>

        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public User GetUserById(int ID)
        {
            return users.FirstOrDefault(u => u.ID == ID);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpPost]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool AddUser(User user)
        {
            users.Add(user);
            return true;
        }

        /// <summary>
        /// 根据用户id删除用户信息
        /// </summary>
        /// <param name="ID">标识id</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool Delete(int ID)
        {
            var user = users.FirstOrDefault(u => u.ID == ID);
            if (user == null)
            {
                return false;
            }
            return users.Remove(user);
        }
    }
}
