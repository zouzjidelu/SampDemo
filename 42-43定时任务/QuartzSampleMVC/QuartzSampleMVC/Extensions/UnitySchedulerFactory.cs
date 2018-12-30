using Quartz;
using Quartz.Core;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Unity;

namespace QuartzSampleMVC.Extensions
{
    /// <summary>
    /// 调度器工厂
    /// </summary>
    public class UnitySchedulerFactory : StdSchedulerFactory
    {
        private readonly UnityJobFactory unityJobFactory;
        public UnitySchedulerFactory(UnityJobFactory unityJobFactory, NameValueCollection props)
        {
            if (null != props)
            {
                base.Initialize(props);
            }
            this.unityJobFactory = unityJobFactory;
        }

        protected override IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler qs)
        {
            qs.JobFactory = this.unityJobFactory;

            return base.Instantiate(rsrcs, qs);
        }

    }
}