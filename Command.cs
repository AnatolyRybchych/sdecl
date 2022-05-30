using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sdecl
{
    internal abstract class Command
    {
        public CommandSignature Signeture { get; private set; }
        public abstract Type InputType { get; }

        public abstract object Execute(object data, CommandManager mgr);

        public Command(string commandName)
        {
            Signeture = new CommandSignature(commandName);
        }
    }
}
