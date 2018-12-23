using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace ExceptionAndLogSapmle.DataAccess
{
    public class ExceptionSampleContext : DbContext
    {
        static ExceptionSampleContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExceptionSampleContext>());
        }
        public ExceptionSampleContext() : base("ExceptionConnStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}