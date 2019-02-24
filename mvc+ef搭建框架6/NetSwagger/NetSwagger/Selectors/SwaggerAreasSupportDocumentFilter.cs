using Swashbuckle.Swagger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;

namespace NetSwagger.Selectors
{
    /// <summary>
    /// Swagger区域文档处理过滤器
    /// </summary>
    public class SwaggerAreasSupportDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 申请处理
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //创建线程安全的字典集合
            IDictionary<string, PathItem> replacePaths = new ConcurrentDictionary<string, PathItem>();

            foreach (var item in swaggerDoc.paths)
            {
                string key = item.Key;
                PathItem value = item.Value;
                string[] keys = key.Split('/');
                if (keys[3].IndexOf('.') != -1)
                {
                    //区域路径
                    string areaName = keys[2];
                    string namespaceFullName = keys[3];
                    string[] directoryNames = namespaceFullName.Split('.');
                    string namespaceName = directoryNames[2];
                    if (areaName.Equals(namespaceName, StringComparison.OrdinalIgnoreCase))
                    {
                        string controllerName = directoryNames[3];
                        replacePaths.Add(item.Key.Replace(namespaceFullName,
                            controllerName.Substring
                            (0, controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)),
                            value);
                    }
                }
                else if (keys[2].IndexOf(',') != -1)
                {
                    //基础路径
                    string namespaceFullName = keys[2];
                    string[] directoryNames = namespaceFullName.Split(',');
                    bool isControllers = directoryNames[2].Equals("Controllers", StringComparison.OrdinalIgnoreCase);
                    string controllerName = directoryNames[3];
                    if (isControllers)
                    {
                        replacePaths.Add(
                            item.Key.Replace(namespaceFullName,
                            controllerName.Substring(0
                            , controllerName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)), value);
                    }
                }
            }

            swaggerDoc.paths = replacePaths;
        }


    }
}