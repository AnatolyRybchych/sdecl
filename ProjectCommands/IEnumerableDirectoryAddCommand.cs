using sdecl.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class IEnumerableDirectoryAddCommand : CommandWithTypeOrDerivative<IEnumerable<ObservableDirectory>>
    {
        public PathCommandArgument PathArgument { get; private set; }
        public FlagArgument ReqursiveArgument { get; private set; }

        public IEnumerableDirectoryAddCommand(string commandName) : base(commandName)
        {
            PathArgument = new PathCommandArgument(true, "path");
            ReqursiveArgument = new FlagArgument("reqursive", "-r");
            Signeture.Args.Add(PathArgument);
            Signeture.Args.Add(ReqursiveArgument);
        }

        public override object ExecuteCommand(IEnumerable<ObservableDirectory> input, CommandManager mgr)
        {
            return input.Append(new ObservableDirectory(PathArgument.Value, ReqursiveArgument.Value));
        }
    }
}
