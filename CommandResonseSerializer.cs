using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CommandResonseSerializer
    {
        public CommandResonseSerializer()
        {

        }

        public string Serialize(object obj)
        {
            if(obj.GetType().GetMethod("ToString", new Type[0])?.DeclaringType == typeof(object))
            {
                return JsonSerializer.Serialize(obj);
            }
            else
            {
                return obj.ToString() ?? "empty response";
            }
        }
    }
}
