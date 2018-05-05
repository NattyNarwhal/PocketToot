using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Notification : IId
    {
        public const string MENTION = "mention";
        public const string REBLOG = "reblog";
        public const string FAVOURITE = "favourite";
        public const string FOLLOW = "follow";

        [JsonProperty("id")]
        public long Id { get; set; }
        // another stringly enum; too bad Json.NET for CF didn't have better
        // string-enum facilitites to handle this
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("account")]
        public Account Account { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }

        public static Paginated<Notification> GetNotifications(ApiClient ac,
            long? before,
            long? after)
        {
            var qs = new QueryString();
            if (before.HasValue)
                qs.Add("max_id", before.Value.ToString());
            if (after.HasValue)
                qs.Add("since_id", after.Value.ToString());

            var route = string.Format("/api/v1/notifications?{0}", qs.ToQueryString());
            var json = ac.Get(route);
            var list = JsonUtility.MaybeDeserialize<List<Notification>>(json);
            // notifications can be flipped through via first/last
            return new Paginated<Notification>(list);
        }

        public static Notification GetById(ApiClient ac, long id)
        {
            var route = string.Format("/api/v1/notifications/{0}", id);
            var json = ac.Get(route);
            return JsonUtility.MaybeDeserialize<Notification>(json);
        }

        public static void DismissAll(ApiClient ac)
        {
            var route = "/api/v1/notifications/clear";
            var json = ac.SendUrlencoded(route, "POST", null);
        }

        public void Dismiss(ApiClient ac)
        {
            var qs = new QueryString();
            qs.Add("id", Id.ToString());
            var route = "/api/v1/notifications/dismiss";
            var json = ac.SendUrlencoded(route, "POST", qs);
        }
    }
}
