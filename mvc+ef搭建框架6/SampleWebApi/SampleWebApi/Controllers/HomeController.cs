using SampleWebApi.Filters;
using System.Web.Mvc;

namespace SampleWebApi.Controllers
{
    
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
          
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
