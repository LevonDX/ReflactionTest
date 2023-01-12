using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflactionTest
{
    static class Extensions
    {
        public static MethodInfo GetMethodInfoByName(this IEnumerable<MethodInfo> infos, string name)
        {
            foreach (MethodInfo item in infos)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return item;
            }

            return null;
        }
    }
}