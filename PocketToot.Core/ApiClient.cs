using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;

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

        // XXX: handtuned REST will likely get ugly, switch to last CF version of RestSharp instead?
        public string Get(string route)
        {
            var parsedRoute = MakeUri(route);
            var wr = WebRequest.Create(parsedRoute);

            wr.Method = "GET";
            wr.Headers.Add("Authorization",
                string.Format("Bearer {0}", Token));

            var r = wr.GetResponse();
            using (var rs = r.GetResponseStream())
            {
                using (var sr = new StreamReader(rs))
                {
                    var s = sr.ReadToEnd();
                    return s;
                }
            }
        }

        public string SendUrlencoded(string route, string method, QueryString data)
        {
            var parsedRoute = MakeUri(route);
            var wr = WebRequest.Create(parsedRoute);

            wr.Method = "POST";
            wr.Headers.Add("Authorization",
                string.Format("Bearer {0}", Token));

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

            var r = wr.GetResponse();
            using (var rs = r.GetResponseStream())
            {
                using (var sr = new StreamReader(rs))
                {
                    var s = sr.ReadToEnd();
                    return s;
                }
            }
        }

        string MakeUri(string route)
        {
            return string.Format("https://{0}/{1}", Hostname, route.TrimStart('/'));
        }
    }
}
