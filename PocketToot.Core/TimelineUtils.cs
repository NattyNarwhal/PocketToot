using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PocketToot
{
    public static class TimelineUtils
    {
        const string HOME_TIMELINE_ROUTE = "/api/v1/timelines/home";
        const string PUBLIC_TIMELINE_ROUTE = "/api/v1/timelines/public";

        // <.*?(since_id|max_id)=(\d*)>; rel="(.*?)"
        const string LINK_HEADER_REGEX = "<.*?(?<param>since_id|max_id)=(?<number>\\d*)>; rel=\"(?<rel>.*?)\"";

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

        public static Paginated<Types.Status> GetFavourites(ApiClient ac,
            long? before,
            long? after)
        {
            var qs = new QueryString();
            if (before.HasValue)
                qs.Add("max_id", before.Value.ToString());
            if (after.HasValue)
                qs.Add("since_id", after.Value.ToString());

            var route = string.Format("/api/v1/favourites?{0}", qs.ToQueryString());
            var res = ac.GetResponse(route);
            var list = JsonUtility.MaybeDeserialize<List<Types.Status>>(res.Content);
            var linkHeader = res.Headers["Link"];

            long? newBefore = null;
            long? newAfter = null;
            if (linkHeader != null)
            {
                // Mastodon returns Link headers like:
                // <https://cronk.stenoweb.net/api/v1/timelines/public?max_id=99960437297163961>; rel="next",
                // <https://cronk.stenoweb.net/api/v1/timelines/public?since_id=99960515001287338>; rel="prev"
                var linkMatches = Regex.Matches(linkHeader, LINK_HEADER_REGEX);
                foreach (Match match in linkMatches)
                {
                    var rel = match.Groups["rel"];
                    if (rel.Value == "prev")
                    {
                        // prev/since_id/after
                        newAfter = long.Parse(match.Groups["number"].Value);
                    }
                    else if (rel.Value == "next")
                    {
                        // next/max_id/before
                        newBefore = long.Parse(match.Groups["number"].Value);
                    }
                }
            }

            return new Paginated<PocketToot.Types.Status>(list, newBefore, newAfter);
        }
    }
}
