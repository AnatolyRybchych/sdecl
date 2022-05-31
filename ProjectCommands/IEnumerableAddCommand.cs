using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class IEnumerableAddCommand<T> : CommandWithTypeOrDerivative<IEnumerable<T>>
    {
        private TypedCommandArgument<T>[] arguments;
        public IEnumerableAddCommand(TypedCommandArgument<T>[] arguments, string commandName) : base(commandName)
        {
            this.arguments = arguments;

            foreach (var argument in arguments)
                if (argument.IsRequired == false) throw new ArgumentException("Argument should be required");
            
            Signeture.Args.AddRange(arguments);
        }

        public override object ExecuteCommand(IEnumerable<T> input, CommandManager mgr)
        {
            foreach (var arg in arguments)
                input.Append(arg.Value);

            return input;
        }
    }
}
