using System.Data.Entity.ModelConfiguration;

namespace UserManager.Entitys.Mapping
{
    public class EntityPermissionMap : EntityTypeConfiguration<EntityPermission>
    {
        public EntityPermissionMap()
        {
            //三个字段共同是一个主键，三个字段同时唯一，就是特殊权限
            this.HasKey(e => new { e.EntityID, e.RoleID, e.EntityName });
            this.Property(e=>e.EntityName).HasMaxLength(20);
            //级联删除  角色删除，对应的角色的外键也需要删除
            this.HasRequired(e=>e.Role).WithMany().HasForeignKey(t=>t.RoleID).WillCascadeOnDelete(true);
        }
    }
}