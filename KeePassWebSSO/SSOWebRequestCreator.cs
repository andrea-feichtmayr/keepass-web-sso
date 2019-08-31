using System;
using System.Net;
using System.Text.RegularExpressions;


namespace KeePassWebSSO {
    class SSOWebRequestCreator : IWebRequestCreate {
        private static readonly string s_suffix = "+sso";
        private static readonly string[] s_schemes = new string[] { "http", "https" };

        public void Register() {
            foreach (string scheme in s_schemes) {
                WebRequest.RegisterPrefix($"{scheme}{s_suffix}:", this);
            }
        }

        public WebRequest Create(Uri uri) {
            UriBuilder builder = new UriBuilder(uri);
            builder.Scheme = Regex.Replace(builder.Scheme, Regex.Escape(s_suffix) + "$", "");

            WebRequest request = WebRequest.Create(builder.Uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            return request;
        }
    }
}
