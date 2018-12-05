using CarManager.Core;
using System.ComponentModel.Composition;

namespace CarManager.Plugin.AliPay
{
    /// <summary>
    /// 支付宝支付插件
    /// </summary>
    [PluginDescriptionAttribute("支付宝", "1.0", "支付宝支付插件类", "常帅")]
    [Export(typeof(PaymentPlugin))]
    public class AliPayPlugin : PaymentPlugin
    {
        public override bool Payment(double amount)
        {
            return true;
        }
    }
}
