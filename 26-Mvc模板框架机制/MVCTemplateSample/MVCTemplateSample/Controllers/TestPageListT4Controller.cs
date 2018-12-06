using MVCTemplateSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTemplateSample.Controllers
{
    public class TestPageListT4Controller : Controller
    {
        // GET: TestPageListT4
        public ActionResult Index()
        {
            List<UserModel> list = new List<UserModel>()
            {
                new UserModel(){ ID=1,UserName="a",PassWord="123",CreateTime=DateTime.Now},
                new UserModel(){ ID=2,UserName="b",PassWord="123",CreateTime=DateTime.Now},
                new UserModel(){ ID=3,UserName="c",PassWord="123",CreateTime=DateTime.Now}
            };
            return View(list);
        }
    }
}