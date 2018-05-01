using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace PocketToot
{
    // https://github.com/tootsuite/documentation/tree/master/Using-the-API
    public class ApiClient
    {
        public string Token { get; set; }
        public string Hostname { get; set; }

        public ApiClient(string hostname, string token)
        {
            Token = token;
            Hostname = hostname;
        }

        static ApiClient()
        {
#if DEBUG
            ServicePointManager.CertificatePolicy = new TrustAllCertificates();
#endif
        }

        static string ReadToEnd(Stream s)
        {
            using (var sr = new StreamReader(s))
            {
                var str = sr.ReadToEnd();
                return str;
            }
        }

        WebRequest CreateWebRequest(string rawRoute)
        {
            var parsedRoute = MakeUri(rawRoute);
            var wr = WebRequest.Create(parsedRoute);

            wr.Headers.Add("Authorization",
                string.Format("Bearer {0}", Token));

            return wr;
        }

        static void HandleWebException(WebException e1)
        {
            try
            {
                // try to extract an error object
                using (var rs = e1.Response.GetResponseStream())
                {
                    var json = ReadToEnd(rs);
                    var error = JsonConvert.DeserializeObject<Types.Error>(json);
                    throw new ApiException(error, json, e1.Response);
                }
            }
            catch (ApiException e2)
            {
                throw e2;
            }
            catch (Exception)
            {
                // fall back
                throw e1;
            }
        }

        static string ReadString(WebRequest wr)
        {
            try
            {

                var r = wr.GetResponse();
                using (var rs = r.GetResponseStream())
                {
                    return ReadToEnd(rs);
                }
            }
            catch (WebException e1)
            {
                HandleWebException(e1);
                return null;
            }
        }

        // XXX: handtuned REST will likely get ugly, switch to last CF version of RestSharp instead?
        // TODO: Let consumers access headers (likely a new overload)
        internal string Get(string route)
        {
            var wr = CreateWebRequest(route);
            wr.Method = "GET";
            return ReadString(wr);
        }

        internal string SendUrlencoded(string route, string method, QueryString data)
        {
            var wr = CreateWebRequest(route);
            wr.Method = method ?? "POST";

            if (data != null)
            {
                var formData = data.ToQueryString();
                var formDataBytes = Encoding.UTF8.GetBytes(formData);
                wr.ContentType = "application/x-www-form-urlencoded";
                wr.ContentLength = formDataBytes.Length;

                using (var rs = wr.GetRequestStream())
                {
                    rs.Write(formDataBytes, 0, formDataBytes.Length);
                    rs.Flush();
                }
            }

            return ReadString(wr);
        }

        string MakeUri(string route)
        {
            return string.Format("https://{0}/{1}", Hostname, route.TrimStart('/'));
        }
    }
}
