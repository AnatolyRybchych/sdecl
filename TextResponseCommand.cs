using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class TextResponseCommand : Command
    {
        public override Command[] Commands => new Command[0];

        public override string Type => "text";

        public override string Help => "it`s just a text, probably you want to see it?";

        public override string StringRepresentation => text.ToString();

        public override string CommandText => command;

        protected StringBuilder text;
        protected string command;

        public TextResponseCommand(string command, StringBuilder text)
        {
            this.text = text;
            this.command = command;
        }
    }
}
