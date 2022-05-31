using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheCommand : CommandWithType<sdecl>
    {
        public CacheCommand(string commandName) : base(commandName)
        {

        }

        public override object ExecuteCommand(sdecl input, CommandManager mgr)
        {
            return input.Cache;
        }
    }
}
