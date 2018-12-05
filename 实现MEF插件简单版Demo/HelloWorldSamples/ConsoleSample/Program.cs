using Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Type> types = GetPluginTypes();
            foreach (var type in types)
            {
                IPlugin plugin = Activator.CreateInstance(type) as IPlugin;
                Console.WriteLine(plugin.HellWord());
            }

            Console.ReadKey();
        }

        public static IEnumerable<Type> GetPluginTypes()
        {
            string Dir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(Dir, "Plugins");
            //再文件夹中找到实现了IPlugin接口的dll,只在当前目录查找
            string[] dlls = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly);
            //循环dlls，查找已经实现了插件接口
            foreach (var item in dlls)
            {
                Assembly assembly = Assembly.LoadFile(item);
                //获取当前的加载的dll所有类型
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    //当前类型是一个类，并且当前的type类型的实例是否是指定类型的实例
                    if (type.IsClass && typeof(IPlugin).IsAssignableFrom(type))
                    {
                        yield return type;
                    }
                }

            }
        }
    }
}
