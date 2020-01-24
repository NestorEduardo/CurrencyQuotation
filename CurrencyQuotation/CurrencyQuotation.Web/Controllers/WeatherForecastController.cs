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
        private readonly IOptions<Settings> appSettings;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IOptions<Settings> appSettings)
        {
            this.appSettings = appSettings;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        [HttpGet]
        public async Task<Quotation> Get()
        {
            var x = await ApiClientFactory.Instance.GetQuote();
            return x;

        }
    }
}
