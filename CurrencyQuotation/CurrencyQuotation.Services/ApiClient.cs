using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CurrencyQuotation.Core.Models;
using System.Collections.Generic;
using System.Web;

namespace CurrencyQuotation.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }
        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }

            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }
        private async Task<T> GetAsync<T>(Uri requestUrl)
        {

            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {

            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }


        private async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {

            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T1>>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            //var uriBuilder = new UriBuilder(endpoint);
            //uriBuilder.Query = queryString;
            //return uriBuilder.Uri;


            var uriBuilder = new UriBuilder(endpoint);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["quantity"] = "1";
            query["key"] = "2903|FA*G~nMMRpf8LFPdU29W4j6aD~VV*Epu";

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
        public async Task<Quotation> GetQuote()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "https://api.cambio.today/v1/quotes/EUR/USD/json?quantity=1&key=2903|FA*G~nMMRpf8LFPdU29W4j6aD~VV*Epu"));
            return await GetAsync<Quotation>(requestUrl);
        }

    }
}



