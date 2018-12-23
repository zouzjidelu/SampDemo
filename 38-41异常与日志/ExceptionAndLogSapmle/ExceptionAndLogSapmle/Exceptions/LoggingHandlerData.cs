using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ExceptionAndLogSapmle.Exceptions
{
    /// <summary>
    /// 日志数据handle处理 自定义自己的日志处理节
    /// </summary>
    public class LoggingHandlerData : ExceptionHandlerData
    {
        private static readonly AssemblyQualifiedTypeNameConverter typeConvert = new AssemblyQualifiedTypeNameConverter();
        private const string title = "title";
        private const string formatterType = "formatterType";


        [ConfigurationProperty(title, IsRequired = false)]
        public string Title
        {
            get { return (string)this[title]; }
            set { this[title] = value; }
        }

        [ConfigurationProperty(formatterType, IsRequired = true)]
        public string FormatterTypeName
        {
            get { return (string)this[formatterType]; }
            set { this[formatterType] = value; }
        }

        public Type FormatterType
        {
            get { return (Type)typeConvert.ConvertFrom(FormatterTypeName); }
            set { this[FormatterTypeName] = typeConvert.ConvertToString(value); }
        }

        /// <summary>
        /// 构建此配置对象表示的异常处理程序。 
        /// </summary>
        /// <returns></returns>
        public override IExceptionHandler BuildExceptionHandler()
        {
            return new LoggingHandler(this.Title, this.FormatterType);
        }
    }
}