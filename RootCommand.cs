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
        public override Command[] Commands => 
            new Command[]
            {

            };

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
    }
}
