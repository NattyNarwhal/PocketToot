using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot
{
    public class ApiException : Exception
    {
        public ApiException(Types.Error error)
            : base(error.Message)
        {

        }
    }
}
