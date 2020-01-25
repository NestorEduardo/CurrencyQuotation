using CurrencyQuotation.Services;
using CurrencyQuotation.Web.Utils;
using System;
using System.Threading;

namespace CurrencyQuotation.Web.Infrastructure
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);
        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
        }
        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
