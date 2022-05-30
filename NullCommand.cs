using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class NullCommand : Command
    {
        protected override Command[] Commands => new Command[0];

        protected override string Type => "null";

        protected override string Help => "null, you should not see it";

        protected override string StringRepresentation => "null";

        protected override string CommandText => "null";
    }
}
