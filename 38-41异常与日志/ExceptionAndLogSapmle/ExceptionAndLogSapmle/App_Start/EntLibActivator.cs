using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(ExceptionAndLogSapmle.App_Start.EntLibActivator), "Start")]

namespace ExceptionAndLogSapmle.App_Start
{
    /// <summary>
    /// 企业类库激活器
    /// </summary>
    public static class EntLibActivator
    {
        public static void Start()
        {
            //获得配置信息
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config");
            //将配置信息加载到配置源中
            IConfigurationSource configSource = new FileConfigurationSource(configPath);

            // 将配置源放入异常策略工厂中。
            ExceptionPolicyFactory exceptionPolicyFactory = new ExceptionPolicyFactory(configSource);
            //策略工厂放入异常管理中，启动程序后执行异常处理激活器就会激活
            ExceptionPolicy.SetExceptionManager(exceptionPolicyFactory.CreateManager());

            //将日志加入到日志输出工厂中，
            LogWriterFactory logWriterFactory = new LogWriterFactory(configSource);
            Logger.SetLogWriter(logWriterFactory.Create());

        }
    }
}