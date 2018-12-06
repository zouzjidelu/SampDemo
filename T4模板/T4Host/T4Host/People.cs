using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Host
{
    [Serializable]
    public class People
    {
        public string Name { set; get; }

        public uint Age { set; get; }

        public string Sex { set; get; }
    }
}
