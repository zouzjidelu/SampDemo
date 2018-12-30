using Quartz;
using QuartzSampleMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace QuartzSampleMVC.Scheduler
{
    public class SampleJob2 : IJob
    {
        private readonly IDataService dataService;
        public SampleJob2(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            //这样写死了，不够灵活
            //dataService = new DataService();
            //DateTime time = dataService.GetNowDateTime();

            System.Diagnostics.Debug.WriteLine("Name=SampleJob2,Data={0},ThreadID={1}", this.dataService.GetNowDateTime(), Thread.CurrentThread.ManagedThreadId);
            return Task.FromResult(0);
        }
    }
}