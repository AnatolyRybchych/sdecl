using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheCommand : Command
    {
        private ListCommand<DirectoryCommand> dirsCmd;
        public override Command[] Commands { get; }

        public override string Type => "cache";

        public override string Help => "";

        public override string StringRepresentation => $"dirs:\n{dirsCmd}";

        public override string CommandText => "cache";

        public CacheCommand()
        {
            dirsCmd = new ListCommand<DirectoryCommand>("dirs", new List<DirectoryCommand>());
            Commands = new Command[]
            {
                dirsCmd,
            };
        }

        public override void _Execute(ArgumentProvider args, ref object? context, Command previous)
        {
            if (context is Cache == false) throw new ArgumentException("Cache command context is not Chache");

            dirsCmd.Elements = ((Cache)context).Settings.ObservableDirectories.Select(dir => new DirectoryCommand(dir)).ToList();
        }
    }
}
