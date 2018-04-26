using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
