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
            if(obj.GetType().GetMethod("ToString", new Type[0])?.DeclaringType != typeof(object))
            {
                return obj.ToString() ?? "empty response";
            }
            else  
            {
                if((obj.GetType().IsAssignableTo(typeof(IEnumerable<object>))))
                    return "[\n    " + string.Join(",\n    ", ((IEnumerable<object>)obj).Select(o => Serialize(o))) + "\n]";
                else
                    return JsonSerializer.Serialize(obj).FormatJson();
            }
        }
    }
}
