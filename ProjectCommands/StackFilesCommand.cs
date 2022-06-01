using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class StackFilesCommand : CommandWithType<Stack>
    {
        public StackFilesCommand(string commandName) : base(commandName)
        {
        }

        public override string Help => "returns collection of files in current stack";

        public override object ExecuteCommand(Stack input, CommandManager.CommandManager mgr)
        {
            return input.ObservableFiles;
        }
    }
}
