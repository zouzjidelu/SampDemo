namespace CarManager.Core
{
    /// <summary>
    /// 支付插件
    /// </summary>
    public abstract class PaymentPlugin : BasePlugin
    {
        public abstract bool Payment(double amount);
    }
}
