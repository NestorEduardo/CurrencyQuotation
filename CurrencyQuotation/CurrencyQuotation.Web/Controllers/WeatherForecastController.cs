using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyQuotation.Core.Models;
using CurrencyQuotation.Web.Infrastructure;
using CurrencyQuotation.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CurrencyQuotation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IOptions<Config> appSettings)
        {
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            ApplicationSettings.WebApiToken = appSettings.Value.WebApiToken;
        }

        [HttpGet]
        public async Task<QuotationRootObject> Get()
        {
            var x = await ApiClientFactory.Instance.GetQuote("USD", 1, ApplicationSettings.WebApiToken);
            return x;

        }
    }
}
