using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheCommand : Command
    {
        public override Command[] Commands => new Command[]
        {

        };

        public override string Type => "cache";

        public override string Help => "";

        public override string StringRepresentation => throw new NotImplementedException();

        public override string CommandText => throw new NotImplementedException();
    }
}
