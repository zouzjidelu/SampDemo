using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ExceptionAndLogSapmle.Logging
{
    /// <summary>
    /// 创建ef数据格式化跟踪器
    /// </summary>
    public class EfFormattedTraceListenerData : TraceListenerData
    {
        private const string formatterNameProperty = "formatter";

        /// <summary>
        /// 配置属性，从配置文件读取 对应属性的数据，
        /// </summary>
        [ConfigurationProperty(formatterNameProperty, IsRequired = false)]
        public string Formatter
        {
            get { return (string)base[formatterNameProperty]; }
            set { base[formatterNameProperty] = value; }
        }

        protected override TraceListener CoreBuildTraceListener(LoggingSettings settings)
       {
            var formatter = this.BuildFormatterSafe(settings, this.Formatter);
            return new EfFormattedTraceListener(formatter);
        }
    }
}