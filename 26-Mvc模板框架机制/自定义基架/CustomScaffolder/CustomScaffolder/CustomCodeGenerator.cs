using Microsoft.AspNet.Scaffolding;
using System;
namespace CustomScaffolder
{
    public class CustomCodeGenerator : CodeGenerator
    {
        public CustomCodeGenerator(CodeGenerationContext context, CodeGeneratorInformation information) : base(context, information)
        {

        }
        /// <summary>
        /// 自定义代码生成类
        /// </summary>
        public override void GenerateCode()
        {
        }

        /// <summary>
        /// 弹出自定义的对话框
        /// </summary>
        /// <returns></returns>
        public override bool ShowUIAndValidate()
        {
            throw new NotImplementedException();
        }
    }
}
