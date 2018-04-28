using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Emoji
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }
        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
