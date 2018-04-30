using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketToot.Types
{
    public class Account
    {
        const string ACCOUNT_ROUTE_TEMPLATE = "/api/v1/accounts/{0}";
        const string ACCOUNT_ROUTE_SUB_TEMPLATE = "/api/v1/accounts/{0}/{1}";
        const string ACCOUNT_RELATIONSHIPS_ROUTE_TEMPLATE = "/api/v1/accounts/relationships?id={0}";
        const string VERIFY_CREDENTIALS = "/api/v1/accounts/verify_credentials";

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

        [JsonProperty("header")]
        public string HeaderUrl { get; set; }
        [JsonProperty("header_static")]
        public string HeaderUrlStatic { get; set; }
        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }
        [JsonProperty("avatar_static")]
        public string AvatarUrlStatic { get; set; }

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

        [JsonProperty("moved")]
        public Account MovedTo { get; set; }

        public override string ToString()
        {
            var dispName = string.IsNullOrEmpty(DisplayName) ? UserName : DisplayName;
            return string.Format("{0} <@{1}>", dispName, AccountId);
        }

        // Notes on the following functions as this is first file with:
        //  * ApiClient is passed as deserialization wouldn't give us an
        //    oppurtunity to inject it.
        //  * These aren't getters because it could confuse deserialization and
        //    to me, properties imply something only a little heavier than
        //    using a field directly (like validation) - a network call is
        //    something too far.

        public Relationship GetRelationship(ApiClient ac)
        {
            var route = string.Format(ACCOUNT_RELATIONSHIPS_ROUTE_TEMPLATE, Id);
            var rJson = ac.Get(route);
            var rList = JsonUtility.MaybeDeserialize<List<Relationship>>(rJson);
            return rList.FirstOrDefault();
        }
        
        // TODO: various options for this
        public List<Status> GetStatuses(ApiClient ac)
        {
            var route = string.Format(ACCOUNT_ROUTE_SUB_TEMPLATE, Id, "statuses");
            var sJson = ac.Get(route);
            return JsonUtility.MaybeDeserialize<List<Status>>(sJson);
        }

        // TODO: Pagination for these two (it's passed through header)
        public List<Account> GetFollowers(ApiClient ac)
        {
            var route = string.Format(ACCOUNT_ROUTE_SUB_TEMPLATE, Id, "followers");
            var uJson = ac.Get(route);
            return JsonUtility.MaybeDeserialize<List<Account>>(uJson);
        }

        public List<Account> GetFollowing(ApiClient ac)
        {
            var route = string.Format(ACCOUNT_ROUTE_SUB_TEMPLATE, Id, "following");
            var uJson = ac.Get(route);
            return JsonUtility.MaybeDeserialize<List<Account>>(uJson);
        }

        public static Account GetById(ApiClient ac, long id)
        {
            var route = string.Format(ACCOUNT_ROUTE_TEMPLATE, id);
            var uJson = ac.Get(route);
            return JsonUtility.MaybeDeserialize<Account>(uJson);
        }

        public static Account GetSelf(ApiClient ac)
        {
            var uJson = ac.Get(VERIFY_CREDENTIALS);
            return JsonUtility.MaybeDeserialize<Account>(uJson);
        }
    }
}
