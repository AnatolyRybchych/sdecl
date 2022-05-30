using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace sdecl
{
    internal class sdecl
    {
        public Cache Cache { get; private set; }

        public sdecl()
        {
            Cache = new Cache();
        }

        public override string ToString()
        {
            return $"sdecl: [\n    cache\n]";
        }
    }
}
