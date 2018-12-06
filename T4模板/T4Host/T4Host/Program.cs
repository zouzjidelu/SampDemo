using Microsoft.VisualStudio.TextTemplating;
using System;
using System.IO;


namespace T4Host
{
    //1.ITextTemplatingSessionHost接口 由文本模板化主机实现，
    //  使调用方可获取表示当前会话的对象。 会话表示文本模板的执行序列。
    //  会话对象可用于将信息从主机传递到文本模板代码。
    //2.ITextTemplatingEngineHost 接口用于转换文本模板的主机接口。 
    //  这可用于指令处理器，也可以通过文本模板进行访问。
    class Program
    {
        static void Main(string[] args)
        {
            //string templeName = "TextTemplate1.tt";
            //var host = new CustomTextTemplatingEngineHost();
            //host.TemplateFileValue = templeName;
            //host.Session = new TextTemplatingSession();
            //host.Session.Add("people", new People() { Age = 18, Sex = "男", Name = "常帅" });

            //var input = File.ReadAllText(templeName);

            //Engine engine = new Engine();
            //string output = engine.ProcessTemplate(input, host);

            //System.Console.WriteLine(output);
            Console.ReadKey();

        }
    }
}
