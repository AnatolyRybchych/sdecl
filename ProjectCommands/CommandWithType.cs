using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal abstract class CommandWithType<T> : Command
    {

        public override object Execute(object data, CommandManager mgr) => ExecuteCommand((T)data, mgr);

        public abstract object ExecuteCommand(T input, CommandManager mgr);

        public override bool IsTypeForInput(Type type) => type == typeof(T);

        public CommandWithType(string commandName):base(commandName) {}
    }
}
