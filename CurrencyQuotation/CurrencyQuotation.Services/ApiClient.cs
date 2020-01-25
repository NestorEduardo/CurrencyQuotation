using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyQuotation.Core.Models;
using System.Web;
using System.Collections.Specialized;

namespace CurrencyQuotation.Services
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;
        private Uri BaseEndpoint { get; set; }
        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }

            BaseEndpoint = baseEndpoint;
            httpClient = new HttpClient();
        }
        private async Task<T> GetAsync<T>(Uri requestUrl)
        {

            var response = await httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private Uri CreateRequestUri(string relativePath, int quantity, string webApiToken)
        {
            Uri endpoint = new Uri(BaseEndpoint, relativePath);
            UriBuilder uriBuilder = new UriBuilder(endpoint);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["qty"] = quantity.ToString();
            query["key"] = webApiToken;
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }
        public async Task<QuotationRootObject> GetQuote(string target, int quantity, string webApiToken)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, $"{target}/json"), quantity, webApiToken);
            return await GetAsync<QuotationRootObject>(requestUrl);
        }
    }
}