using System;
using System.Linq;

namespace CarManager.Core
{
    /// <summary>
    /// 插件基类
    /// </summary>
    public class BasePlugin : IPlugin
    {
        public PluginDescriptionAttribute PluginDescription
            => this.GetType().GetCustomAttributes(true).
            OfType<PluginDescriptionAttribute>().FirstOrDefault();


        public virtual void Install()
        {
            Console.WriteLine("安装");
        }

        public virtual void UnInstall()
        {
            Console.WriteLine("卸载");
        }
    }
}
