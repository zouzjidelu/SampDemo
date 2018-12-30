using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace QuartzSampleMVC.Scheduler
{
    public class SampleJob1 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("Name=SampleJob1,Data={0},ThreadID={1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            return Task.FromResult(0);
        }
    }
}