using Microsoft.Practices.Unity;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;


namespace QuartzSampleMVC.Extensions
{
    /// <summary>
    ///定是unity扩展
    /// </summary>
    public class QuartzUnityExtension : UnityContainerExtension
    {
        private readonly NameValueCollection quartzProps;
        public QuartzUnityExtension(NameValueCollection quartzProps)
        {
            this.quartzProps = quartzProps;
        }

        protected override void Initialize()
        {
            //构造函数注册
            var constructor = new InjectionConstructor(new UnityJobFactory(this.Container), new InjectionParameter<NameValueCollection>(quartzProps));
            //注册调度器工厂
            this.Container.RegisterType<ISchedulerFactory, UnitySchedulerFactory>(new ContainerControlledLifetimeManager(), constructor);
            //从工厂中拿到调度器结果
            this.Container.RegisterType<IScheduler>(new InjectionFactory(c => c.Resolve<ISchedulerFactory>().GetScheduler().Result));
        }
    }
}