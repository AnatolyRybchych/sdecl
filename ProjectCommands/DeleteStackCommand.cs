using CommandManager;
using sdecl.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class DeleteStackCommand : CommandWithTypeOrDerivative<Sdecl>
    {
        public StringCommandArgument StackName { get; private set; }

        public override string Help => "deletes stack by name";

        public DeleteStackCommand(string commandName) : base(commandName)
        {
            StackName = new StringCommandArgument(true, "stack name", @"[a-zA-Z0-9_]*");
        }

        public override object ExecuteCommand(Sdecl input, CommandManager.CommandManager mgr)
        {
            if (input.CurrStackName == StackName.Value)
                input.CurrStackName = null;
            if (File.Exists(Stack.GetPath(StackName.Value)))
                File.Delete(StackName.Value);
            else
                return new StackDeleteStatus(false, $"Stack named \"{StackName.Value}\" not found");
            return new StackDeleteStatus(true);
        }
    }
}
