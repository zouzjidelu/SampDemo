using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UserManager.Entitys.Mapping
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Role");
            this.Property(p=>p.Name).IsRequired().HasMaxLength(20);
            this.HasMany(p => p.Permissions).WithMany().Map(m => m.ToTable("RolePermissions").MapLeftKey("RoleID").MapRightKey("PermissionsID"));
        }
    }
}