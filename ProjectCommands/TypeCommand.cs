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

        public override object ExecuteCommand(object input, CommandManager mgr)
        {
            return input.GetType().Name;
        }
    }
}
