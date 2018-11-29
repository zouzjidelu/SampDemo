using Microsoft.AspNet.SignalR;

namespace WebSite.SignalR
{
    /// <summary>
    /// 消息转发、接收中转站
    /// </summary>
    public class MessageHub : Hub
    {
        public void SendMessage(string message)
        {
            //给所有用户发送--没有提示，是dynamic类型的
            //名字随意写，没有提示，主要在前端会找自定义的名字
            Clients.All.SendMessage(message);
            //给某个用户发送
            //Clients.User()
        }
    }
}