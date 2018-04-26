using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Mention
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("acct")]
        public string AccountId { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return "@" + AccountId;
        }
    }
}
