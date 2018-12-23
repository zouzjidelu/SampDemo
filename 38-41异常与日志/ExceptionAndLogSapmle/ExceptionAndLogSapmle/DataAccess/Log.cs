using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionAndLogSapmle.DataAccess
{
    public class Log
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 日志优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 错误级别 信息？启动？异常？
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// 附加标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  日志时间
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 机器名 [以后可以做分布式，定位哪个机器发生的错误，记录的日志]
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// 归档名称[盘古分词，抓取关键词]检索库，方便
        /// </summary>
        public string Categories { get; set; }

        /// <summary>
        /// 应用程序域
        /// </summary>
        public string AppDomainName { get; set; }

        /// <summary>
        /// 进程编号
        /// </summary>
        public string ProcessID { get; set; }

        /// <summary>
        /// 进程名称[qq||微信等等]
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 线程编号
        /// </summary>
        public string ThreadId { get; set; }

        /// <summary>
        /// 线程名称
        /// </summary>
        public string ThreadName { get; set; }


        /// <summary>
        /// 事件编号
        /// </summary>
        public int? EventID { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 日志详情
        /// </summary>
        public string FormattedMessage { get; set; }

    }
}