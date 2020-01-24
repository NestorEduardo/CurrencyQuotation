using CurrencyQuotation.Core.Models;
using CurrencyQuotation.Web.Infrastructure;
using CurrencyQuotation.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CurrencyQuotation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IOptions<Settings> appSettings;
        public HomeController(IOptions<Settings> appSettings)
        {
            this.appSettings = appSettings;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }
        public async Task<IActionResult> Index()
        {
            var data = await ApiClientFactory.Instance.GetQuote();
            return null;
        }
    }
}