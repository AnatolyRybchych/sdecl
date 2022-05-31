using sdecl.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class IEnumerableAtCommand : CommandWithTypeOrDerivative<IEnumerable<object>>
    {
        private IntCommandArgument intArgument;
        public IEnumerableAtCommand() : base("at")
        {
            intArgument = new IntCommandArgument(true, "index", 0);
            Signeture.Args.Add(intArgument);
        }

        public override object ExecuteCommand(IEnumerable<object> input, CommandManager mgr)
        {
            return input.ElementAtOrDefault(intArgument.Value) ?? new CommandNullResponse();
        }
    }
}
