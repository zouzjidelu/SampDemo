using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManager.Entitys;
using UserManager.Security;

namespace UserManager.Controllers
{
    /// <summary>
    /// 导航控制器
    /// </summary>
    public class NavigateController : Controller
    {
        private UserManagerDbContext db = new UserManagerDbContext();
        private IEntityPermissionProvider entityPermissionProvider = new EntityPermissionProvider();

        public ActionResult List()
        {
            //获得当前用户的所有导航列表，条件：激活状态，并且在实体权限中存在
            var navigates = db.Navigates.Where(n => n.Active).ToList().Where(n => entityPermissionProvider.Authorize(n));
            //&& entityPermissionProvider.Authorize(n)
            return View(navigates);
        }

        public ActionResult Create()
        {
            this.ViewData["ParentID"] = new SelectList(new List<Navigate>() { new Navigate {
                Name="顶级菜单",
                Active=true,
            } }, "ParentID", "Name");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Navigate navigate)
        {
            db.Navigates.Add(navigate);
            db.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        /// <summary>
        /// 给当前导航实体授权给角色
        /// </summary>
        /// <param name="navId"></param>
        /// <returns></returns>
        public ActionResult Auth(int navId)
        {
            var entityPermissions = db.EntityPermissions.Where(n => n.EntityID == navId);

            List<Role> roles = db.Roles.Where(r => r.Active).ToList();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var role in roles)
            {
                foreach (var ep in entityPermissions)
                {
                    selectListItems.Add(new SelectListItem()
                    {
                        Text = role.Name,
                        Value = role.ID.ToString(),
                        Selected = role.ID == ep.RoleID,
                    });
                }
            }
            ViewBag.navId = navId;
            return View(new SelectList(selectListItems));
        }

        /// <summary>
        /// 给当前导航实体授权给角色
        /// </summary>
        /// <param name="navId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Auth(int navId, IEnumerable<int> roleIds)
        {
            using (db)
            {
                roleIds = roleIds ?? Enumerable.Empty<int>();
                Navigate navigate = db.Navigates.Where(n => n.ID == navId && n.Active).FirstOrDefault();
                var entityPermissions = db.EntityPermissions.Where(ep => ep.EntityID == navId);
                entityPermissions.ToList().Clear();
                List<EntityPermission> entityPermissionList = new List<EntityPermission>();
                roleIds.ToList().ForEach(r =>
                {
                    EntityPermission entity = new EntityPermission
                    {
                        EntityID = navId,
                        EntityName = nameof(Navigate),
                        RoleID = r
                    };
                    db.Entry<EntityPermission>(entity).State = System.Data.Entity.EntityState.Added;
                    entityPermissionList.Add(entity);
                });

                db.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }


    }
}