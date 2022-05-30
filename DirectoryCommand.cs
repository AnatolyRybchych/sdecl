using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class DirectoryCommand : Command
    {
        private ValueCommand<string> pathCommand;
        private ValueCommand<bool> reqursiveCommand;

        public override Command[] Commands { get; }

        public override string Type => "directory";

        public override string Help => "just directory, contains files and directories, has property \"reqursive\"";

        public override string StringRepresentation => Directory.IsValid ? $"path: \"{Directory.Path}\", reqursive: {Directory.Reqursive}" : "dir invalid";

        public override string CommandText => "dir";

        public ObservableDirectory Directory { get; private set; }

        public DirectoryCommand()
        {
            pathCommand = new ValueCommand<string>();
            reqursiveCommand = new ValueCommand<bool>();
            Commands = new Command[]
            {
                pathCommand,
                reqursiveCommand,
            };
            Directory = new ObservableDirectory();
        }

        public DirectoryCommand(ObservableDirectory directory):this()
        {
            Directory = directory;
        }

        public override void _Execute(ArgumentProvider args, ref object? context, Command previous)
        {
            if (context == null) throw new NullReferenceException("directory null");
            if (context is DirectoryCommand == false) throw new InvalidDataException("command context is not directory");
            pathCommand.Value = ((DirectoryCommand)context).Directory.Path;
            reqursiveCommand.Value = ((DirectoryCommand)context).Directory.Reqursive;
        }
    }
}
