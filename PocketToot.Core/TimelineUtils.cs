using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot
{
    public static class TimelineUtils
    {
        public const string HOME_TIMELINE_ROUTE = "/api/v1/timelines/home";
        public const string PUBLIC_TIMELINE_ROUTE = "/api/v1/timelines/public";

        internal static Paginated<Types.Status> GetTimeline(ApiClient ac, string route)
        {
            var s = ac.Get(route);
            var sl = JsonUtility.MaybeDeserialize<List<Types.Status>>(s);
            return new Paginated<Types.Status>(sl);
        }

        public static Paginated<Types.Status> GetHomeTimeline(ApiClient ac,
            long? before,
            long? after)
        {
            var qs = new QueryString();
            if (before.HasValue)
                qs.Add("max_id", before.Value.ToString());
            if (after.HasValue)
                qs.Add("since_id", after.Value.ToString());

            var route = string.Format("{0}?{1}", HOME_TIMELINE_ROUTE, qs.ToQueryString());
            return GetTimeline(ac, route);
        }

        public static Paginated<Types.Status> GetPublicTimeline(ApiClient ac,
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

            var route = string.Format("{0}?{1}", PUBLIC_TIMELINE_ROUTE, qs.ToQueryString());
            return GetTimeline(ac, route);
        }
    }
}
