using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class NullCommand : Command
    {
        public override Command[] Commands => new Command[0];

        public override string Type => "null";

        public override string Help => "null";

        public override string StringRepresentation => "null";

        public override string CommandText => "null";
    }
}
