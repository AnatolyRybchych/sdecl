using CommandManager;
using sdecl.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class SelectStackCommand : CommandWithTypeOrDerivative<Sdecl>
    {
        public StringCommandArgument CurrentStackName { get; private set; }

        public override string Help => "selects stack using name";

        public SelectStackCommand(string commandName) : base(commandName)
        {
            CurrentStackName = new StringCommandArgument(true, "stack name", @"[a-zA-Z0-9_]+");
            Signeture.Args.Add(CurrentStackName);
        }

        public override object ExecuteCommand(Sdecl input, CommandManager.CommandManager mgr)
        {
            input.CurrStackName = CurrentStackName.Value;
            input.LoadCurrentStack();
            input.Save();
            return new SelectStackStatus(true);
        }
    }
}
