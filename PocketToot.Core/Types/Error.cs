using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Error
    {
        [JsonProperty("error")]
        public string Message { get; set; }
    }
}
