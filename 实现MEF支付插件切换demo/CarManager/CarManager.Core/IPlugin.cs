namespace CarManager.Core
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件描述
        /// </summary>
        PluginDescriptionAttribute PluginDescription { get; }

        /// <summary>
        /// 安装
        /// </summary>
        void Install();

        /// <summary>
        /// 卸载
        /// </summary>
        void UnInstall();


    }
}
