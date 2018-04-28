using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;

namespace PocketToot.Types
{
    /*
    {
      "id": 356,
      "created_at": "2017-11-11T17:58:40.665Z",
      "in_reply_to_id": null,
      "in_reply_to_account_id": null,
      "sensitive": false,
      "spoiler_text": "",
      "visibility": "public",
      "language": null,
      "uri": "https://mastodon.social/users/bhtooefr/statuses/98987095854467393/activity",
      "content": "\\u003cp\\u003egoogle could help prevent a lot of android malware if they made internet access an app permission that requires user consent\\u003c/p\\u003e",
      "url": null,
      "reblogs_count": 0,
      "favourites_count": 0,
      "favourited": false,
      "reblogged": false,
      "muted": false,
      "reblog": {
        "id": 355,
        "created_at": "2017-11-11T17:58:46.000Z",
        "in_reply_to_id": null,
        "in_reply_to_account_id": null,
        "sensitive": false,
        "spoiler_text": "",
        "visibility": "public",
        "language": null,
        "uri": "https://cybre.space/users/sireebob/statuses/98987090011301463",
        "content": "\\u003cp\\u003egoogle could help prevent a lot of android malware if they made internet access an app permission that requires user consent\\u003c/p\\u003e",
        "url": "https://cybre.space/@sireebob/98987090011301463",
        "reblogs_count": 1,
        "favourites_count": 0,
        "favourited": false,
        "reblogged": false,
        "muted": false,
        "reblog": null,
        "application": null,
        "account": {
          "id": 120,
          "username": "sireebob",
          "acct": "sireebob@cybre.space",
          "display_name": "skibbity beep-bop zip ðŸŒ¹",
          "locked": false,
          "created_at": "2017-11-11T17:58:36.104Z",
          "note": "\\u003cp\\u003egay. broke. unwilling. 30ish ~volcel~ leftist dirtbag // he/him // no spoons for ableism // \\u003ca href=\"https://cybre.space/tags/healthjustice\" class=\"mention hashtag\" rel=\"nofollow noopener\" target=\"_blank\"\\u003e#\\u003cspan\\u003ehealthjustice\\u003c/span\\u003e\\u003c/a\\u003e \\u003ca href=\"https://cybre.space/tags/blacklivesmatter\" class=\"mention hashtag\" rel=\"nofollow noopener\" target=\"_blank\"\\u003e#\\u003cspan\\u003eblacklivesmatter\\u003c/span\\u003e\\u003c/a\\u003e \\u003ca href=\"https://cybre.space/tags/daeneryswouldhavewon\" class=\"mention hashtag\" rel=\"nofollow noopener\" target=\"_blank\"\\u003e#\\u003cspan\\u003edaeneryswouldhavewon\\u003c/span\\u003e\\u003c/a\\u003e \\u003ca href=\"https://cybre.space/tags/notaveteran\" class=\"mention hashtag\" rel=\"nofollow noopener\" target=\"_blank\"\\u003e#\\u003cspan\\u003enotaveteran\\u003c/span\\u003e\\u003c/a\\u003e\\u003c/p\\u003e",
          "url": "https://cybre.space/@sireebob",
          "avatar": "https://cronk.stenoweb.net/system/accounts/avatars/000/000/120/original/7b58e778c1a24437.png?1510423116",
          "avatar_static": "https://cronk.stenoweb.net/system/accounts/avatars/000/000/120/original/7b58e778c1a24437.png?1510423116",
          "header": "https://cronk.stenoweb.net/system/accounts/headers/000/000/120/original/dd506a0c357384dd.png?1510423117",
          "header_static": "https://cronk.stenoweb.net/system/accounts/headers/000/000/120/original/dd506a0c357384dd.png?1510423117",
          "followers_count": 55,
          "following_count": 183,
          "statuses_count": 1321
        },
        "media_attachments": [],
        "mentions": [],
        "tags": []
      },
      "application": null,
      "account": {
        "id": 3,
        "username": "bhtooefr",
        "acct": "bhtooefr@mastodon.social",
        "display_name": "",
        "locked": false,
        "created_at": "2017-11-11T02:02:06.407Z",
        "note": "\\u003cp\\u003eComputing, transportation, energy... really anything interesting.\\u003c/p\\u003e\\u003cp\\u003eWeb: \\u003ca href=\"http://bhtooefr.org/\" rel=\"nofollow noopener\" target=\"_blank\"\\u003e\\u003cspan class=\"invisible\"\\u003ehttp://\\u003c/span\\u003e\\u003cspan class=\"\"\\u003ebhtooefr.org/\\u003c/span\\u003e\\u003cspan class=\"invisible\"\\u003e\\u003c/span\\u003e\\u003c/a\\u003e\\u003c/p\\u003e",
        "url": "https://mastodon.social/@bhtooefr",
        "avatar": "https://cronk.stenoweb.net/system/accounts/avatars/000/000/003/original/82cf71992886b4fb.jpg?1510365727",
        "avatar_static": "https://cronk.stenoweb.net/system/accounts/avatars/000/000/003/original/82cf71992886b4fb.jpg?1510365727",
        "header": "https://cronk.stenoweb.net/headers/original/missing.png",
        "header_static": "https://cronk.stenoweb.net/headers/original/missing.png",
        "followers_count": 2,
        "following_count": 6,
        "statuses_count": 32
      },
      "media_attachments": [],
      "mentions": [],
      "tags": []
    },
    */
    public class Status
    {
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
        public Status Reblog { get; set; }

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
            return Reblog ?? this;
        }
    }
}
