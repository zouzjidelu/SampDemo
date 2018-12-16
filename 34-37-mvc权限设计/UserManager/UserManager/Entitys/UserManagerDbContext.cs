using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace UserManager.Entitys
{
    public class UserManagerDbContext : DbContext
    {
        static UserManagerDbContext()
        {
            //数据库不存在。创建数据库
            Database.SetInitializer(new CreateDatabaseIfNotExists<UserManagerDbContext>());
        }
        public UserManagerDbContext() : base("UserManager") { }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Permission> Permissions { get; set; }
        public IDbSet<EntityPermission> EntityPermissions { get; set; }
        public IDbSet<Navigate> Navigates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //删除表名自带的复数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //加载继承了EntityTypeConfig的实体类
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}