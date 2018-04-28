using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot
{
    public static class NullableUtility
    {
        public static bool Coerce(this bool? nullable)
        {
            return nullable.HasValue ? nullable.Value : false;
        }
    }
}
