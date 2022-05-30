using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class RootCommand : Command
    {
        private ListCommand<DirectoryCommand> dirsCmd;
        private Command[] commands;
        public override Command[] Commands => commands;
        

        public override string Type => "sdecl";

        public override string Help =>
             "You must enter a command\n" +
            "    * commands are formed by one or more words separated by spaces\n" +
            "    * each team can return an object\n" +
            "    * each object follows 3 basic commands:\n" +
            "        - help // basic information about the object\n" +
            "        - commands // list of all commands\n" +
            "        - type // name of the object type";

        public override string StringRepresentation => $"it`s root object, you can see commads using \n\"{Type} {CommandsCommandText}\"";

        public override string CommandText => Type;

        public RootCommand()
        {
            dirsCmd = new ListCommand<DirectoryCommand>();
            commands = new Command[]
            {
                dirsCmd,
            };
        }

        public override void _Execute(ArgumentProvider args, Cache cache, Command previous)
        {
            dirsCmd.Elements = cache.Settings.ObservableDirectories.Select(dir=>new DirectoryCommand(dir)).ToList();
            base._Execute(args, cache, previous);
        }
    }
}
