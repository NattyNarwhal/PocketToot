using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Context
    {
        [JsonProperty("ancestors")]
        public List<Status> Ancestors { get; set; }
        [JsonProperty("descendants")]
        public List<Status> Descendants { get; set; }
    }
}
