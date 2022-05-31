using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sdecl
{
    internal abstract class TypedCommandArgument<T> : CommandArgument
    {
        public TypedCommandArgument(bool required, string name) : base(required, name)
        {
        }

        public override Type Type => typeof(T);

        public virtual T? Value => ObjValue == null ? default(T) : (T?)ObjValue;
    }
}
