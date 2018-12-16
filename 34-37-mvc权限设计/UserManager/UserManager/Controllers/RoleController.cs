using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManager.Entitys;

namespace UserManager.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : Controller
    {
        private UserManagerDbContext dbContext = new UserManagerDbContext();
        // GET: Role
        public ActionResult Index()
        {
            List<Role> roles = dbContext.Roles.ToList();
            return View(roles);
        }


        public ActionResult Auth(int id)
        {
            //获得当前角色信息
            Role role = dbContext.Roles.FirstOrDefault(r => r.ID == id);
            //获取所有权限，并根据类型将权限分组
            var permissionGroup = dbContext.Permissions.GroupBy(p => p.Category).ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            //循环权限组
            foreach (var group in permissionGroup)
            {
                //将分组项添加到html select标签group下
                SelectListGroup selectListGroup = new SelectListGroup() { Name = group.Key };
                selectListItems.AddRange(group.Select(g => new SelectListItem()
                {
                    Selected = role.Permissions.Any(p => p.ID == g.ID),
                    Value = g.ID.ToString(),
                    Text = g.Description,
                    Group = selectListGroup,
                }));
            }

            return View(new SelectList(selectListItems));
        }


        [HttpPost]
        public ActionResult Auth(int id, IEnumerable<int> permissionIds)
        {
            permissionIds = permissionIds ?? Enumerable.Empty<int>();
            Role role = dbContext.Roles.First(r => r.ID == id);
            role.Permissions.ToList().ForEach(p => role.Permissions.Remove(p));
            permissionIds.ToList().ForEach(pid =>
           {
               if (!role.Permissions.Any(p => p.ID == pid))
               {
                   role.Permissions.Add(dbContext.Permissions.Find(pid));
               }
           });

            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}