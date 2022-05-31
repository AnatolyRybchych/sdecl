using sdecl.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class IEnumerableFilesAddCommand : CommandWithTypeOrDerivative<IEnumerable<ObservableFile>>
    {
        public PathCommandArgument Path { get; private set; }

        public IEnumerableFilesAddCommand(string commandName) : base(commandName)
        {
            Path = new PathCommandArgument(true, "path");
            Signeture.Args.Add(Path);
        }

        public override object ExecuteCommand(IEnumerable<ObservableFile> input, CommandManager mgr)
        {
            return input.Append(new ObservableFile(Path.Value));
        }
    }
}
