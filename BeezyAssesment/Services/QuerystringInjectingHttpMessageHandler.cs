using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BeezyAssesment.Services
{
    public class QuerystringInjectingHttpMessageHandler : DelegatingHandler
    {
        private readonly (string Key, string Value)[] injectedParameters;

        public QuerystringInjectingHttpMessageHandler(params (string key, string value)[] injectedParameters) : this()
        {
            this.injectedParameters = injectedParameters;
        }

        public QuerystringInjectingHttpMessageHandler() : base(new HttpClientHandler())
        {
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var finalUri = InjectIntoQuerystring(request.RequestUri, injectedParameters);

                request.RequestUri = finalUri;

                return base.SendAsync(request, cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        

        private static Uri InjectIntoQuerystring(Uri uri, IEnumerable<(string Key, string Value)> parameters)
        {
            var uriStr = uri.ToString();

            var queryString = new string(uriStr.SkipWhile(c => c != '?').ToArray());
            var baseUri = uriStr.Substring(0, uriStr.Length - queryString.Length);
            var currentParameters = HttpUtility.ParseQueryString(queryString);

            foreach (var (key, value) in parameters)
            {
                currentParameters[key] = value;
            }

            var tuples = currentParameters.ToTuples();

            var newUri =
                string.Join("&", tuples.Select(tuple =>
                {
                    if (tuple.name == null)
                    {
                        return tuple.value;
                    }

                    return tuple.name + "=" + tuple.value;
                }));

            var suffix = newUri == "" ? "" : "?" + newUri;
            var finalUri = new Uri(baseUri + suffix);
            return finalUri;
        }
    }
  
}
