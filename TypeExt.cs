using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal static class TypeExt
    {
        public static bool IsSameGenericAsIn(this Type t1, Type t2) => t1.GetGenericTypeDefinition() == t2.GetGenericTypeDefinition();

        public static bool IsGenericsArgsAreSubclassesOfArgsIn(this Type t1, Type t2)
        {
            return t1.IsSameGenericAsIn(t2) && t1.GenericTypeArguments.Length == t2.GenericTypeArguments.Length && t1.GenericTypeArguments.ContentEqualsAsIn(t2.GenericTypeArguments);
        }
    }
}
