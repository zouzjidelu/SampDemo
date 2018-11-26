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

        }

        public  DbSet<Book> Books { get; set; }
    }
}