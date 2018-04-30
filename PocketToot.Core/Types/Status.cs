using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;

namespace PocketToot.Types
{
    public class Status : IId
    {
        const string STATUS_ROUTE_TEMPLATE = "/api/v1/statuses/{0}/{1}";

        [JsonProperty("id")]
        public long Id { get; set; }

        // these are different, per docs:
        //   uri: A Fediverse-unique resource ID
        //   url: Normal link to status (even remote)
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("reblog")]
        public Status ContainedReblog { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("reblog_count")]
        public long ReblogCount { get; set; }
        [JsonProperty("favourite_count")]
        public long FavouriteCount { get; set; }
        [JsonProperty("reblogged")]
        public bool? HasReblogged { get; set; }
        [JsonProperty("favourited")]
        public bool? HasFavourited { get; set; }

        [JsonProperty("muted")]
        public bool? Muted { get; set; }

        // this is an enum (public, unlisted, private, direct)
        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("pinned")]
        public bool? Pinned { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }
        [JsonProperty("spoiler_text")]
        public string ContentWarning { get; set; }

        [JsonProperty("media_attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("emojis")]
        public List<Emoji> Emoji { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        public Status ReblogOrSelf()
        {
            return ContainedReblog ?? this;
        }

        // XXX: should we be using the reblogged status, or the status
        // containing the reblog?

        string FormatStatusRoute(string verb)
        {
            return FormatStatusRoute(verb, false);
        }

        string FormatStatusRoute(string verb, bool useReblogged)
        {
            var status = useReblogged ? ReblogOrSelf() : this;
            return string.Format(STATUS_ROUTE_TEMPLATE, status.Id, verb);
        }

        Status DoStatusChange(ApiClient ac, string verb)
        {
            var route = FormatStatusRoute(verb);
            var json = ac.SendUrlencoded(route, "POST", null);
            return JsonUtility.MaybeDeserialize<Status>(json);
        }

        public Context GetContext(ApiClient ac)
        {
            var contextJson = ac.Get(FormatStatusRoute("context"));
            return JsonUtility.MaybeDeserialize<Context>(contextJson);
        }

        public Status Reblog(ApiClient ac)
        {
            return DoStatusChange(ac, "reblog");
        }

        public Status Unreblog(ApiClient ac)
        {
            return DoStatusChange(ac, "unreblog");
        }

        public Status Favourite(ApiClient ac)
        {
            return DoStatusChange(ac, "favourite");
        }

        public Status Unfavourite(ApiClient ac)
        {
            return DoStatusChange(ac, "unfavourite");
        }

        public Status Pin(ApiClient ac)
        {
            return DoStatusChange(ac, "pin");
        }

        public Status Unpin(ApiClient ac)
        {
            return DoStatusChange(ac, "unpin");
        }

        public Status Mute(ApiClient ac)
        {
            return DoStatusChange(ac, "mute");
        }

        public Status Unmute(ApiClient ac)
        {
            return DoStatusChange(ac, "unmute");
        }

        public void Delete(ApiClient ac)
        {
            var route = string.Format("/api/v1/statuses/{0}", Id);
            var s = ac.SendUrlencoded(route, "DELETE", null);
        }

        public static Status GetById(ApiClient ac, long id)
        {
            var route = string.Format("/api/v1/statuses/{0}", id);
            var json = ac.Get(route);
            return JsonUtility.MaybeDeserialize<Status>(json);
        }

        // TODO: Idempotency-Key, attachments
        public static Status Post(ApiClient ac,
            string status,
            string spoilerText,
            bool sensitiveMedia,
            long? inReplyTo,
            string visibility)
        {
            var qs = new QueryString();
            qs.Add("status", status);
            if (inReplyTo != null)
                qs.Add("in_reply_to_id", inReplyTo.ToString());
            if (!string.IsNullOrEmpty(spoilerText))
                qs.Add("spoiler_text", spoilerText);
            if (sensitiveMedia)
                qs.Add("sensitive", "true");
            qs.Add("visibility", visibility);

            var res = ac.SendUrlencoded("/api/v1/statuses", "POST", qs);
            return JsonUtility.MaybeDeserialize<Types.Status>(res);
        }
    }
}
