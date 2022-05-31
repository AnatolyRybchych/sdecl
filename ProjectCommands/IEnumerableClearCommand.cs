using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class IEnumerableClearCommand : CommandWithTypeOrDerivative<IEnumerable<object>>
    {
        public IEnumerableClearCommand(string commandName) : base(commandName)
        {
        }

        public override object ExecuteCommand(IEnumerable<object> input, CommandManager mgr)
        {
            return typeof(List<>).MakeGenericType(input.GetType().GetGenericArguments().First()).GetConstructor(new Type[0])?.Invoke(new object[0]) ?? new CommandNullResponse();
        }
    }
}
