using CustomScaffolder.Properties;
using Microsoft.AspNet.Scaffolding;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace CustomScaffolder
{
    [Export(typeof(CodeGeneratorFactory))]
    public class CustomCodeGeneratorFactory : CodeGeneratorFactory
    {
        /// <summary>
        /// 关于代码生成信息显示
        /// 参数1[DisplayName]：代码显示名称
        /// 参数2[Description]：描述
        /// 参数3[author]：作者
        /// 参数4[version]：版本
        /// 参数5[id]，代码ID[这里写的是自定义代码类的名字]
        /// 参数6：[icon]:图标【这里图标在easyicon网站找的，然后放在资源中】
        /// 参数7：gestures:用于确定对UI中的某些操作的支持的匹配标准的字符串列表
        /// 参数8：categories：用于组织UI中的代码生成器的字符串列表。引用一些示例值的类别。
        /// </summary>
        private static CodeGeneratorInformation information = new CodeGeneratorInformation
     ("常帅分享控制器",
     "常帅自定义控制器",
     "常帅",
     new System.Version(1, 0, 0, 0),
     "CustomCodeGenerator",
     icon: ToImageSourceIcon(Resources.Controller),
     gestures: new string[] { "Controller", "View", "Area" },
     categories: new string[] { Categories.Common, Categories.MvcView, Categories.Other });

        public CustomCodeGeneratorFactory() : base(information)
        {

        }

        public override ICodeGenerator CreateInstance(CodeGenerationContext context)
        {
            return new CustomCodeGenerator(context, information);
        }

        private static ImageSource ToImageSourceIcon(Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
