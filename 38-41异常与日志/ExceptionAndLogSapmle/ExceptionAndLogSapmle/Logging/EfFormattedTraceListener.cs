using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ExceptionAndLogSapmle.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
namespace ExceptionAndLogSapmle.Logging
{
    /// <summary>
    /// ef格式化监听器
    /// </summary>
    public class EfFormattedTraceListener : FormattedTraceListenerBase
    {
        /// <summary>
        /// 格式化器
        /// </summary>
        /// <param name="logFormatter"></param>
        public EfFormattedTraceListener(ILogFormatter logFormatter)
        {
            this.Formatter = logFormatter;
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        {
            SaveLogEntry(new LogEntry
            {
                EventId = 0,
                Priority = 5,
                Severity = TraceEventType.Information,
                TimeStamp = DateTime.Now,
                Message = message
            });

        }

        /// <summary>
        /// 输出行
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            //不支持的异常。
            //throw new NotSupportedException();
            //或者不实现的异常
            //或者调用上面的方法
            this.Write(message);
        }

        private void SaveLogEntry(LogEntry logEntry)
        {
            ExceptionSampleContext db = new ExceptionSampleContext();
            var log = db.Set<Log>();
            log.Add(new Log()
            {
                Priority = logEntry.Priority,
                AppDomainName = logEntry.AppDomainName,
                EventID = logEntry.EventId,
                MachineName = logEntry.MachineName,
                Message = logEntry.Message,
                ProcessID = logEntry.ProcessId,
                ProcessName = logEntry.ProcessName,
                Severity = logEntry.LoggedSeverity,
                ThreadId = logEntry.Win32ThreadId,
                ThreadName = logEntry.ManagedThreadName,
                Timestamp = logEntry.TimeStamp.ToLocalTime(),
                Categories = string.Join(",", logEntry.CategoriesStrings),
                Title = logEntry.Title,
                FormattedMessage = this.Formatter?.Format(logEntry)
            });
            db.SaveChanges();
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            //过滤器 == null，说明没有设置过滤器,或者写了，
            if (this.Filter == null || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (data is LogEntry)
                {
                    SaveLogEntry(data as LogEntry);
                }
                else if (data is string)
                {
                    Write(data as string);
                }
                else
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }
            }
        }
    }
}