using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Relationship
    {
        const string ACCOUNT_ROUTE_SUB_TEMPLATE = "/api/v1/accounts/{0}/{1}";

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

        // TODO: See if we can remove set above (& not confuse deserialization)
        // to avoid confusing consumer of object (i.e: you have to do this)
        // (We can't make it a setter due to our dependence on ApiClient, see
        // comment in Account)
        // TODO: also, maybe toggles?

        Relationship DoRelationshipChange(ApiClient ac, string verb)
        {
            return DoRelationshipChange(ac, verb, null);
        }

        Relationship DoRelationshipChange(ApiClient ac, string verb, QueryString qs)
        {
            var route = string.Format(ACCOUNT_ROUTE_SUB_TEMPLATE, Id, verb);
            var rJson = ac.Get(route);
            return JsonUtility.MaybeDeserialize<Relationship>(rJson);
        }

        public Relationship Follow(ApiClient ac)
        {
            return DoRelationshipChange(ac, "follow");
        }

        public Relationship Unfollow(ApiClient ac)
        {
            return DoRelationshipChange(ac, "unfollow");
        }

        public Relationship Block(ApiClient ac)
        {
            return DoRelationshipChange(ac, "block");
        }

        public Relationship Unblock(ApiClient ac)
        {
            return DoRelationshipChange(ac, "unblock");
        }

        public Relationship Mute(ApiClient ac, bool includingNotifications)
        {
            var qs = new QueryString();
            qs.Add("notifications", includingNotifications.ToString());
            return DoRelationshipChange(ac, "mute", qs);
        }

        public Relationship Unmute(ApiClient ac)
        {
            return DoRelationshipChange(ac, "unmute");
        }
    }
}
