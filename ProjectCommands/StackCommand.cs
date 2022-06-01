using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class StackCommand : CommandWithType<Sdecl>
    {
        public StackCommand(string commandName) : base(commandName)
        {

        }

        public override string Help => "selects last selected stack";

        public override object ExecuteCommand(Sdecl input, CommandManager.CommandManager mgr)
        {
            input.LoadCurrentStack();
            return input.CurrStack;
        }
    }
}
