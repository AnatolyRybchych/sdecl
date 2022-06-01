using CommandManager;
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

        public override string Help => "returns collection with new directory {path, -r(recursive, variadic)}";

        public IEnumerableDirectoryAddCommand(string commandName) : base(commandName)
        {
            PathArgument = new PathCommandArgument(true, "path");
            ReqursiveArgument = new FlagArgument("recursive", "-r");
            Signeture.Args.Add(PathArgument);
            Signeture.Args.Add(ReqursiveArgument);
        }

        public override object ExecuteCommand(IEnumerable<ObservableDirectory> input, CommandManager.CommandManager mgr)
        {
            string newPath = Path.GetFullPath(PathArgument.Value);
            var found = input.Select(dir => dir.Path);
            if (found.Contains(newPath))
            {
                return input.Select(dir => new ObservableDirectory(dir.Path, ReqursiveArgument.Value));
            }
            else
            {
                return input.Append(new ObservableDirectory(newPath, ReqursiveArgument.Value));
            }
        }
    }
}
