using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PocketToot
{
#if DEBUG
    public class TrustAllCertificates : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }
    }
#endif
}
