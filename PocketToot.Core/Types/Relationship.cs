using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Relationship
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("following")]
        public bool Following { get; set; }
        [JsonProperty("followed_by")]
        public bool FollowedBy { get; set; }
        [JsonProperty("blocking")]
        public bool Blocking { get; set; }
        [JsonProperty("muting")]
        public bool Muting { get; set; }
        [JsonProperty("muting_notifications")]
        public bool MutingNotifications { get; set; }
        [JsonProperty("requested")]
        public bool RequestedFollow { get; set; }
        [JsonProperty("domain_blocking")]
        public bool DomainBlocking { get; set; }
    }
}
