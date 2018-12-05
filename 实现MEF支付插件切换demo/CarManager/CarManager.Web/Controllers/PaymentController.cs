using CarManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Web.Controllers
{
    public class PaymentController : Controller
    {
        [ImportMany]
        public IEnumerable<PaymentPlugin> PaymentPlugin { get; set; }

        public PaymentController()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            //mef目录构建，将插件dll。传入
            DirectoryCatalog catalog = new DirectoryCatalog(dir);
            //目录构建完成、将目录插件导入到容器中
            CompositionContainer container = new CompositionContainer(catalog);
            //容器内自动匹配插件接口与对应的实例
            container.ComposeParts(this);
        }
        // GET: Payment
        public ActionResult Index()
        {
            return View(PaymentPlugin);
        }

        [HttpPost]
        public ActionResult Index(double amount, string PluginName)
        {
            var paymentPlugin = PaymentPlugin.Where(p => p.PluginDescription.PluginName == PluginName).FirstOrDefault();
            if (paymentPlugin.Payment(amount))
            {
                return Content("支付成功");
            }
            return Content("支付失败");
        }
    }
}