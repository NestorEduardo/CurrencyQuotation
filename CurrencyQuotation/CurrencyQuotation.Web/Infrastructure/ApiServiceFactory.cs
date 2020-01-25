using CurrencyQuotation.Services;
using CurrencyQuotation.Web.Utils;
using System;
using System.Threading;

namespace CurrencyQuotation.Web.Infrastructure
{
    internal static class ApiServiceFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiService> restClient = new Lazy<ApiService>(
          () => new ApiService(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);
        static ApiServiceFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
        }
        public static ApiService Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
