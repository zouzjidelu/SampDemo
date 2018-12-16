using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UserManager.Entitys.Mapping
{
    public class NavigateMap : EntityTypeConfiguration<Navigate>
    {
        public NavigateMap()
        {
            this.HasKey(n => n.ID);
            this.Property(n => n.Name).HasMaxLength(20).IsRequired();
            this.Property(n => n.IConClassCode).IsRequired().HasMaxLength(50);
            this.Property(n => n.ControllerName).HasMaxLength(50).IsOptional();
            this.Property(n => n.ActionName).HasMaxLength(50).IsOptional();
            //父级可以为空
            this.HasOptional(n => n.Parent);
        }
    }
}