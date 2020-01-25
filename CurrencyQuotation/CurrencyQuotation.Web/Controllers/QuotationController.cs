using System.Threading.Tasks;
using CurrencyQuotation.Core.Models;
using CurrencyQuotation.Web.Infrastructure;
using CurrencyQuotation.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CurrencyQuotation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : ControllerBase
    {
        public IConfiguration configuration { get; }
        public QuotationController(IOptions<Config> appSettings, IConfiguration configuration)
        {
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            ApplicationSettings.WebApiToken = appSettings.Value.WebApiToken;
            this.configuration = configuration; 
        }

        [HttpGet("{target:regex(^[[a-zA-Z]])}")]
        public async Task<IActionResult> Get(string target)
        {
            var x = await ApiServiceFactory.Instance.GetQuote(target, 1, ApplicationSettings.WebApiToken);
            return Ok(Quotation.Map(x));
        }
    }
}

