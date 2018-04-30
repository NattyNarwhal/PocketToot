using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot.Types
{
    public class Tag
    {
        const string TAG_TIMELINE_ROUTE_TEMPLATE = "/api/v1/timelines/tag/{0}?{1}";

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return "#" + Name;
        }

        public Paginated<Status> GetTimeline(ApiClient ac,
            bool onlyLocal,
            bool onlyMedia,
            long? before,
            long? after)
        {
            return GetTimeline(ac, Name, onlyLocal, onlyMedia, before, after);
        }

        public static Paginated<Status> GetTimeline(ApiClient ac,
            string tagName,
            bool onlyLocal,
            bool onlyMedia,
            long? before,
            long? after)
        {
            var qs = new QueryString();
            if (before.HasValue)
                qs.Add("max_id", before.Value.ToString());
            if (after.HasValue)
                qs.Add("since_id", after.Value.ToString());
            if (onlyLocal)
                qs.Add("local", "true");
            if (onlyMedia)
                qs.Add("media", "true");

            var route = string.Format(TAG_TIMELINE_ROUTE_TEMPLATE, tagName, qs.ToQueryString());
            return TimelineUtils.GetTimeline(ac, route);
        }
    }
}
