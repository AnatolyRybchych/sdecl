using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal static class Arr
    {

        public static T[] SubArray<T>(this T[] array, int index, int count = int.MaxValue)
        {
            if (index < 0) index = 0;
            if((long)index + (long)count > (long)array.Length) count = array.Length - index;

            T[] result = new T[count];
            for(int i = 0; i < count; i++)
                result[i] = array[i + index];
            return result;
        }
    }
}
