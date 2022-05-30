using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheCommand : CommandWithType<sdecl>
    {
        public CacheCommand() : base("cache")
        {

        }

        public override object ExecuteCommand(sdecl input, CommandManager mgr)
        {
            return input.Cache;
        }
    }
}
