using NetSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetSwagger.Controllers.Admin
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
                new User(){ID=1,Name="常帅1",CreateTime=DateTime.Now,Password="1234561"},
                new User(){ID=1,Name="常帅2",CreateTime=DateTime.Now,Password="1234562"},
                new User(){ID=1,Name="常帅3",CreateTime=DateTime.Now,Password="1234563"},
            };
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns>返回用户列表</returns>
        public List<User> GetUsers()
        {
            return users;
        }

        /// <summary>
        /// 根据用户id获取用户详细信息
        /// </summary>
        /// <param name="Id">用户id</param>
        /// <returns>用户详细信息</returns>
        public User GetById(int Id)
        {
            return users.FirstOrDefault(u => u.ID == Id);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>true：OK，false:error</returns>
        public bool Add(User user)
        {
            users.Add(user);
            return true;
        }

        /// <summary>
        /// 根据用户id删除用户信息
        /// </summary>
        /// <param name="Id">用户标识id</param>
        /// <returns>true：OK，false:error</returns>
        public bool Delete(int Id)
        {
            User user = users.FirstOrDefault(u => u.ID == Id);
            if (user == null)
            {
                return false;
            }

            return users.Remove(user);
        }
    }
}
