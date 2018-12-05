using CarManager.Core;
using System.ComponentModel.Composition;

namespace CarManager.Plugin.WechatPay
{
    /// <summary>
    /// 微信支付插件
    /// </summary>
    [PluginDescription("微信", "2.2", "微信支付插件")]
    [Export(typeof(PaymentPlugin))]
    public class WechatPayPlugin : PaymentPlugin
    {
        public override bool Payment(double amount)
        {
            return false;
        }
    }
}
