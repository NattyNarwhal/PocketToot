using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Notification
    {
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

        public static List<Notification> GetNotifications(ApiClient ac)
        {
            var route = "/api/v1/notifications";
            var json = ac.Get(route);
            return JsonUtility.MaybeDeserialize<List<Notification>>(json);
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
