using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class TypeCommand : CommandWithTypeOrDerivative<object>
    {
        public TypeCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns type";

        public override object ExecuteCommand(object input, CommandManager.CommandManager mgr)
        {
            return input.GetType().Name;
        }
    }
}
