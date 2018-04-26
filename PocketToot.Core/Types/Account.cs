using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketToot.Types
{
    /*
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
    */
    public class Account
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("acct")]
        public string AccountId { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(DisplayName) ? UserName : DisplayName;
            }
        }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("followers_count")]
        public int Followers { get; set; }
        [JsonProperty("following_count")]
        public int Following { get; set; }
        [JsonProperty("statuses_count")]
        public int Statuses { get; set; }

        public override string ToString()
        {
            var dispName = string.IsNullOrEmpty(DisplayName) ? UserName : DisplayName;
            return string.Format("{0} <@{1}>", dispName, AccountId);
        }
    }
}
