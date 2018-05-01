using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PocketToot
{
    public class ApiException : Exception
    {
        public WebResponse Response { get; private set; }

        public Types.Error Error { get; private set; }

        public string ErrorJson { get; private set; }

        internal ApiException(Types.Error error, string errorJson, WebResponse wr)
            : base(error.Message ?? "No error message")
        {
            Response = wr;
            Error = error;
            ErrorJson = errorJson;
        }
    }
}
