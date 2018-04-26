using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Application
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
