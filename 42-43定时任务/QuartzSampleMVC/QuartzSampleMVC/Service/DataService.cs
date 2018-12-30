using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzSampleMVC.Service
{
    public class DataService : IDataService
    {
        public DateTime GetNowDateTime()
        {
            return DateTime.Now;
        }
    }
}