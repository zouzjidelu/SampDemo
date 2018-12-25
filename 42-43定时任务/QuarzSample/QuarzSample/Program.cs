using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
namespace QuarzSample
{
    /// <summary>
    /// 学习资料：http://beckjin.com/2018/03/24/quartz-net-trigger/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(ThreadTest);
            //thread.Start();

            //ThreadPool.QueueUserWorkItem((object obj) => { ThreadPoolTest(obj); });
            //Timer timer = new Timer((object obj) =>  { ThreadPoolTest(obj); });
            //timer.Change(0, 3000);
            /*
            任务三要素：
            1.job【作业，任务】
            2.trigger【触发器】 具体什么时候干？
            3.Scheduler【调度器】,作业与触发器关联起来，进行监控
            */

            //1.创建作业
            IJobDetail jobDetail = JobBuilder.Create<MyJob>()
                .WithIdentity("myjob1", "mygroup1")//给当前作业【任务】创建一个标识，以及分组
                .Build();//生成job
            JobDataMap pairs = jobDetail.JobDataMap;
            pairs.Add("cs", "常帅");


            //2.创建触发器
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("mytrigger1", "mytriggergroup1")
                .StartNow()
                //.WithSimpleSchedule(t => t.WithIntervalInSeconds(5)//每5s执行一次
                //.WithRepeatCount(5))//总共执行5次

                //.WithCronSchedule("2,12,22,32,42,52 * * * * ? *")//表达式的方式执行任务 每分钟内的 2,12,22,32,42,52s 执行一次
                
                .Build();

            //3.调度器
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().Result;

            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();

            Console.ReadKey();
        }

        public static void ThreadTest()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        public static void ThreadPoolTest(object obj)
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

    }
}
