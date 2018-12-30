using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzSampleMVC.Service
{
    public interface IDataService
    {
        DateTime GetNowDateTime();
    }
}