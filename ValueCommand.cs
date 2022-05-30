using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class ValueCommand<T> : Command
    {

        public override Command[] Commands => new Command[0];

        public override string Type => $"{typeof(T).Name} value";

        public override string Help => "string value, readonly string";

        public override string StringRepresentation => Value == null ? typeof(T).Name: $"{Value}";

        private string commandText;
        public override string CommandText => commandText;

        public T? Value { get; set; }

        public ValueCommand()
        {
            commandText = $"{typeof(T).Name} value";
            Value = default(T);
        }

        public ValueCommand(string commandText, T value)
        {
            this.commandText = commandText;
            Value = value;
        }
    }
}
