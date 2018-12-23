using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ExceptionAndLogSapmle.Exceptions
{
    /// <summary>
    /// 日志处理器
    /// </summary>
    [ConfigurationElementType(typeof(LoggingHandlerData))] // 自定义的日志handle数据 处理
    public class LoggingHandler : IExceptionHandler
    {
        private readonly string title;
        private readonly Type formatterType;
        public LoggingHandler(string title, Type formatterType)
        {
            this.title = title;
            this.formatterType = formatterType;
        }

        /// <summary>
        /// 当由类实现时，处理System.Exception。 自动处理异常
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="handlingInstanceId"></param>
        /// <returns></returns>
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            LogEntry logEntry = new LogEntry(exception.Message, "General", 0, 100, TraceEventType.Error, this.title, null);

            foreach (DictionaryEntry dataEntry in exception.Data)
            {
                if (dataEntry.Key is string)
                {
                    logEntry.ExtendedProperties.Add(dataEntry.Key as string, dataEntry.Value);
                }
            }

            //构造器拿到格式化器，，
            Type[] types = new Type[] { typeof(TextWriter), typeof(Exception), typeof(Guid) };
            ConstructorInfo constructorInfo = formatterType.GetConstructor(types);
            using (StringWriter writer = new StringWriter())
            {
                //获得格式化器字符串，
                var exceptionFormatter = (Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter)constructorInfo.Invoke(new object[] { writer, exception, handlingInstanceId });
                exceptionFormatter.Format();
                logEntry.ExtendedProperties.Add("Exception", writer.GetStringBuilder().ToString());
            }

            Logger.Write(logEntry);
            return exception;
        }
    }
}