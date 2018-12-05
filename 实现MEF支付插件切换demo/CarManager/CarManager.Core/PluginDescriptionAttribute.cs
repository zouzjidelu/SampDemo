using System;

namespace CarManager.Core
{
    /// <summary>
    /// 插件描述类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PluginDescriptionAttribute : Attribute
    {
        public PluginDescriptionAttribute(string pluginName, string pluginVersion, string pluginDescription, string pluginAuthor = "")
        {
            this.PluginName = pluginName;
            this.PluginAuthor = pluginAuthor;
            this.PluginVersion = pluginVersion;
            this.PluginDescription = pluginDescription;
        }

        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string PluginAuthor { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string PluginVersion { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string PluginDescription { get; set; }
    }
}
