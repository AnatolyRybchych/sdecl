using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl.ProjectCommands
{
    internal class IEnumerableSaveCommand<T> : CommandWithTypeOrDerivative<IEnumerable<T>>
    {
        public Action<IEnumerable<T>> SavingAction { get; private set; }

        public IEnumerableSaveCommand(string commandName, Action<IEnumerable<T>> savingAction) : base(commandName)
        {
            SavingAction = savingAction;
        }

        public override object ExecuteCommand(IEnumerable<T> input, CommandManager mgr)
        {
            SavingAction(input);
            return input;
        }
    }
}
