using System.Data.Entity.ModelConfiguration;

namespace UserManager.Entitys.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(u => u.ID);
            this.Property(u => u.Name).HasMaxLength(20).IsRequired();
            this.Property(u => u.Password).HasMaxLength(128).IsRequired();
            this.HasMany(u => u.Roles).WithMany().Map(m => m.ToTable("UserRole").MapLeftKey("UserID").MapRightKey("RoleID"));
        }
    }
}