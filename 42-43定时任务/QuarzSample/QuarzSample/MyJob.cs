using Quartz;
using System;
using System.Threading.Tasks;

namespace QuarzSample
{
    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var cs = context.JobDetail.JobDataMap["cs"].ToString();
            Console.WriteLine(cs+"---"+DateTime.Now);

            return Task.FromResult(0);

        }
    }
}
