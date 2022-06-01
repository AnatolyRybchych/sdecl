using CommandManager;
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

        public override string Help => "returns collection with new File{path}";

        public IEnumerableFilesAddCommand(string commandName) : base(commandName)
        {
            Path = new PathCommandArgument(true, "path");
            Signeture.Args.Add(Path);
        }

        public override object ExecuteCommand(IEnumerable<ObservableFile> input, CommandManager.CommandManager mgr)
        {
            string newPath = System.IO.Path.GetFullPath(Path.Value);
            if (input.Select(i => i.Path).Contains(newPath)) return input;
            return input.Append(new ObservableFile(newPath));
        }
    }
}
