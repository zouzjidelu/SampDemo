using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebActivatorEx;
using Microsoft.Web.Infrastructure;
using Quartz;
using Quartz.Impl;
using System.IO;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Specialized;
using QuartzSampleMVC.Extensions;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(QuartzSampleMVC.App_Start.QuartzActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(QuartzSampleMVC.App_Start.QuartzActivator), "Shutdown")]
namespace QuartzSampleMVC.App_Start
{
    /// <summary>
    /// 定时激活器
    /// </summary>
    public class QuartzActivator
    {
        //private static IScheduler scheduler;
        public static void Start()
        {
            //获得quartz配置文件路径
            string quartConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Quartz.config");
            //配置文件映射
            var configurationFileMap = new ExeConfigurationFileMap { ExeConfigFilename = quartConfigPath };
            //打开映射文件
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(configurationFileMap, ConfigurationUserLevel.None);
            //讲文件内容转换成xml格式
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            xmlDocument.Load(new StringReader(configuration.GetSection("quartz").SectionInformation.GetRawXml()));

            //微软自带的xml转换工具
            NameValueSectionHandler handler = new NameValueSectionHandler();
            //将xml转换成集合
            NameValueCollection props = handler.Create(null, null, xmlDocument.DocumentElement) as NameValueCollection;

            //在当前容器中添加一个扩展，针对unity的扩展 QuartzUnityExtension
            ServiceContainer.Current.AddExtension(new QuartzUnityExtension(props));

            ServiceContainer.Resolve<IScheduler>().Start();

            //将集合放入到调度器中执行
            //ISchedulerFactory schedulerFactory = new StdSchedulerFactory(props);

            //scheduler = schedulerFactory.GetScheduler().Result;

            ////工作
            //IJobDetail job = new JobDetailImpl("myjob", "myjobgroup", typeof(object));// JobBuilder.Create().WithIdentity("","").Build();

            ////触发器
            //ITrigger trigger = TriggerBuilder.Create().Build();

            ////调度器
            //scheduler.ScheduleJob(job, trigger);

            //由于以上三个要素经常变动，如果硬编码写死，不够灵活，可以通过配置文件的方式配置

            //启动
            //scheduler.Start();

        }

        public static void Shutdown()
        {
            ServiceContainer.Resolve<IScheduler>().Shutdown();
        }
    }
}