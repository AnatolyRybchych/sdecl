using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class StackDirsCommand : CommandWithType<Stack>
    {
        public StackDirsCommand(string commandName) : base(commandName)
        {

        }

        public override string Help => "returns collection of directories, of current stack";

        public override object ExecuteCommand(Stack input, CommandManager.CommandManager mgr)
        {
            return input.ObservableDirectories;
        }
    }
}
