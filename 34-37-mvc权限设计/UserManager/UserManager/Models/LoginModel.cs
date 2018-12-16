using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManager.Models
{
    /// <summary>
    /// 登陆实体类
    /// </summary>
    public class LoginModel
    {
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("记住我")]
        public bool RememberMe { get; set; }

    }
}