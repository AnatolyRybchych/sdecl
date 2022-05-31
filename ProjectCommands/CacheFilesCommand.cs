using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class CacheFilesCommand : CommandWithType<Cache>
    {
        public CacheFilesCommand(string commandName) : base(commandName)
        {
        }

        public override object ExecuteCommand(Cache input, CommandManager mgr)
        {
            return input.HeaderFiles;
        }
    }
}
