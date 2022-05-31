using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class DirsCommand : CommandWithType<Cache>
    {
        public DirsCommand() : base("dirs")
        {

        }

        public override object ExecuteCommand(Cache input, CommandManager mgr)
        {
            return input.Settings.ObservableDirectories;
        }
    }
}
