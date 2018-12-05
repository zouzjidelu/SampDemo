using System;

namespace TestT4Tempalte
{
    class Program
    {
        static void Main(string[] args)
        {
            RuntimeTextTemplate1 runtimeText = new RuntimeTextTemplate1();
            string str = runtimeText.TransformText();
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
