using Microsoft.AspNet.SignalR.Client;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.建立hub连接，传入一个地址，也就是web启动的地址
            var hubConnection = new HubConnection("http://localhost:51163/");
            //2.创建hub代理，要指定创建的是哪个hub的代理，,这里是MessageHub(接收、转发中转站类)
            IHubProxy hubProxy = hubConnection.CreateHubProxy("MessageHub");
            //3.启动连接
            hubConnection.Start().Wait();//启动是异步的。需要等待连接启动完成
            //4.读取cpu信息
            PerformanceCounter performanceCounter = new PerformanceCounter();
            performanceCounter.CategoryName = "Processor";
            performanceCounter.CounterName = "% Processor Time";
            performanceCounter.InstanceName = "_Total";//InstanceName="qq.exe";//代表监控qq的exe 如果所有就是 "_Total";//固定写法

            while (true)
            {
                string cpuUsage = (performanceCounter.NextValue()).ToString();
                System.Console.WriteLine(cpuUsage);//打印使用率
                //查看连接状态。是否连接中
                if (hubConnection.State == ConnectionState.Connected)
                {
                    //推送cpu使用率给消息接收、转发中转站
                    hubProxy.Invoke("SendMessage", cpuUsage);//参数解读：推送给哪个方法，值
                }
                //每次收集完停止1s
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
        }
    }
}
