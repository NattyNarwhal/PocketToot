using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return "#" + Name;
        }
    }
}
