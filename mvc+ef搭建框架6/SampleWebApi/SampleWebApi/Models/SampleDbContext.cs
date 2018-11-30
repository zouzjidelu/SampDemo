using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext():base("SampleConnStr")
        {
            Database.SetInitializer<SampleDbContext>(null);
          
        }

        public  DbSet<Book> Books { get; set; }
    }
}