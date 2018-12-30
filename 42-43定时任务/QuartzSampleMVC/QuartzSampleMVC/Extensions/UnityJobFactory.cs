using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace QuartzSampleMVC.Extensions
{
    /// <summary>
    /// 任务工厂
    /// </summary>
    public class UnityJobFactory : SimpleJobFactory
    {
        private readonly IUnityContainer unityContainer;
        public UnityJobFactory(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobtype = jobDetail.JobType;

            try
            {
                //先从容器中拿，如果能转换成IJob就从容器拿，如果不能转换就调用父类的NewJob通过反射的方式获取
                return this.unityContainer.Resolve(jobtype) as IJob ?? base.NewJob(bundle, scheduler);
            }
            catch (Exception ex)
            {
                SchedulerException se = new SchedulerException("解析Job异常:" + jobDetail.JobType.FullName);
                throw ex;
            }


        }
    }
}