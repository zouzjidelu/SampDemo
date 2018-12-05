using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.China
{
    public class ChinaHelloWord : IPlugin
    {
        public string HellWord()
        {
            return "你好，HelloWord";
        }
    }
}
